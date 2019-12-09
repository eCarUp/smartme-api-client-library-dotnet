#region License
// Copyright (c) 2019 smart-me AG https://www.smart-me.com/
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OAuthWebExample.OAuth2.Containers;
using SmartMeApiClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OAuthWebExample.OAuth2
{
    public class SmartMeOAuthConfiguration
    {
        private const string serverAddress = "https://www.smart-me.com";

        private static string clientId;
        private static string clientSecret;

        public static void ConfigureOAuthClientServices(IServiceCollection services, IConfiguration configuration)
        {
            clientId = configuration.GetSection("OAuth2")["ClientId"];
            clientSecret = configuration.GetSection("OAuth2")["ClientSecret"];

            services.AddMvc();

            _ = services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "SmartMeOAuth2";
            })
            .AddCookie()
            .AddOAuth("SmartMeOAuth2", options =>
            {
                options.ClientId = clientId;
                options.ClientSecret = clientSecret;
                options.CallbackPath = new PathString("/signin-smartme");

                options.AuthorizationEndpoint = serverAddress + "/api/oauth/authorize";
                options.TokenEndpoint = serverAddress + "/api/oauth/token";
                options.UserInformationEndpoint = serverAddress + "/api/user";

                // Add scope to read the devices
                options.Scope.Add("user.read");
                options.Scope.Add("device.read");
                options.Scope.Add("device.readwrite");
                options.Scope.Add("device.readswitch");

                options.SaveTokens = true;

                options.Events = new OAuthEvents
                {
                    OnCreatingTicket = async context =>
                    {
                        var user = await UserApi.GetUserAsync(context.AccessToken);

                        if (user == null)
                        {
                            return;
                        }

                        // Our respone should contain the claims we're interested in.
                        context.Identity.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username));
                    }
                };
            });
        }

        public static async Task<TokenData> GetAccessToken(TokenData tokenData, HttpContext context, bool updateTokenInSession = true)
        {
            var expires = DateTime.Parse(tokenData.ExpireAt, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);

            if (expires.ToUniversalTime().Ticks < DateTime.UtcNow.Ticks)
            {
                var client = new HttpClient();

                var response = await client.RequestRefreshTokenAsync(new RefreshTokenRequest
                {
                    Address = serverAddress + "/api/oauth/token",
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    GrantType = "refresh_token",
                    RefreshToken = tokenData.RefreshToken
                });

                if (response.IsError)
                {
                    return tokenData;
                }

                var newAccessToken = response.AccessToken;
                var newRefreshToken = response.RefreshToken;
                var newExpiresAt = DateTime.UtcNow.AddSeconds(response.ExpiresIn).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");

                if (updateTokenInSession)
                {
                    var auth = await context.AuthenticateAsync("Cookies");
                    auth.Properties.StoreTokens(new List<AuthenticationToken>()
                    {
                        new AuthenticationToken()
                        {
                            Name = "access_token",
                            Value = newAccessToken
                        },
                        new AuthenticationToken()
                        {
                            Name = "refresh_token",
                            Value = newRefreshToken
                        },
                        new AuthenticationToken()
                        {
                            Name = "expires_at",
                            Value = newExpiresAt
                        }
                    });

                    await context.SignInAsync(auth.Principal, auth.Properties);
                }

                tokenData.AccessToken = newAccessToken;
                tokenData.RefreshToken = newRefreshToken;
                tokenData.ExpireAt = newExpiresAt;

                return tokenData;
            }

            return tokenData;
        }

        public static async Task<TokenData> GetAccessToken(HttpContext context)
        {
            var accessToken = await context.GetTokenAsync("access_token");
            var refreshToken = await context.GetTokenAsync("refresh_token");
            var expiresText = await context.GetTokenAsync("expires_at");

            var tokenData = new TokenData();
            tokenData.AccessToken = accessToken;
            tokenData.RefreshToken = refreshToken;
            tokenData.ExpireAt = expiresText;

            var token = await GetAccessToken(tokenData, context);

            return token;
        }
    }
}
