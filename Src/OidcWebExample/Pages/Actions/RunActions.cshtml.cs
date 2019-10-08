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

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OidcWebExample.Helpers;
using SmartMeApiClient;
using SmartMeApiClient.Containers;
using SmartMeApiClient.Helpers;

namespace OidcWebExample.Pages.Actions
{
    public class RunActionsModel : PageModel
    {
        public Guid Id { get; set; }

        public int Action { get; set; }

        public RunActionsModel()
        {
            Id = new Guid("00315ffa-a6b6-4538-84f5-b50b685b0e83");
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostSwitchOnAsync(int action)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }

            var accessToken = await HttpContext.GetTokenAsync("access_token");

            return await ActionsApi.RunActionsAsync(
                accessToken,
                new ActionToRun
                {
                    DeviceID = Id,
                    Actions = new List<ActionToRunItem>
                    {
                        new ActionToRunItem(HexStringHelper.ByteArrayToString(ObisCodes.SmartMeSpecificPhaseSwitchL1), 1.0)
                    }
                }, 
                new ResultHandler<ActionToRun>
                {
                    OnError = DefaultErrorHandler.Handle
                }
            );
        }

        public async Task<IActionResult> OnPostSwitchOffAsync(int action)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }

            var accessToken = await HttpContext.GetTokenAsync("access_token");

            return await ActionsApi.RunActionsAsync(
                accessToken,
                new ActionToRun
                {
                    DeviceID = Id,
                    Actions = new List<ActionToRunItem>
                    {
                        new ActionToRunItem(HexStringHelper.ByteArrayToString(ObisCodes.SmartMeSpecificPhaseSwitchL1), 0.0)
                    }
                },
                new ResultHandler<ActionToRun>
                {
                    OnError = DefaultErrorHandler.Handle
                }
            );
        }
    }
}
