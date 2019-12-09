﻿#region License
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

using SmartMeApiClient.Containers;
using System.Threading.Tasks;

namespace SmartMeApiClient
{
    /// <summary>
    /// Class to access the User API
    /// </summary>
    public class UserApi
    {
        /// <summary>
        /// Gets the informations of the user
        /// </summary>
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
        /// <returns></returns>
        public static async Task<User> GetUserAsync(UserPassword usernamePassword)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.GetAsync<User>("User");
            }
        }

        /// <summary>
        /// Gets the informations of the user
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <returns></returns>
        public static async Task<User> GetUserAsync(string accessToken)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<User>("User");
            }
        }

        /// <summary>
        /// Gets the informations of the user
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns></returns>
        public static async Task<IActionResult> GetUserAsync(
            string accessToken, 
            ResultHandler<User> resultHandler)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<User>("User", resultHandler);
            }
        }
    }
}
