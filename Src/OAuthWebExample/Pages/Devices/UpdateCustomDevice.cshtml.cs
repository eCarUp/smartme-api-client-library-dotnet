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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OAuthWebExample.Helpers;
using OAuthWebExample.OAuth2;
using SmartMeApiClient;
using SmartMeApiClient.Containers;
using SmartMeApiClient.Enumerations;

namespace OAuthWebExample.Pages.Devices
{
    public class UpdateCustomDeviceModel : PageModel
    {
        public Guid Id { get; set; }

        public CustomDevice CustomDevice { get; set; }

        public UpdateCustomDeviceModel()
        {
            Id = new Guid("0eed34eb-aa5e-417a-ab01-6221c1ea23d3");
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }

            var tokenData = await SmartMeOAuthConfiguration.GetAccessToken(HttpContext);

            return await DevicesApi.GetCustomDeviceAsync(tokenData.AccessToken, Id, new ResultHandler<CustomDevice>
            {
                OnSuccess = (customDevice) =>
                {
                    CustomDevice = customDevice;
                    return Page();
                },

                OnError = DefaultErrorHandler.Handle
            });
        }

        public async Task<IActionResult> OnPostAsync(CustomDevice customDevice)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }

            var tokenData = await SmartMeOAuthConfiguration.GetAccessToken(HttpContext);

            return await DevicesApi.UpdateCustomDeviceAsync(tokenData.AccessToken, customDevice, new ResultHandler<CustomDevice>
            {
                OnSuccess = (empty) =>
                {
                    // Trigger another GET to show the updated custom device
                    return Redirect("/Devices/UpdateCustomDevice");
                },

                OnError = DefaultErrorHandler.Handle
            });
        }
    }
}