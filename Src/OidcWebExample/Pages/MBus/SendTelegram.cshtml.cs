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
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OidcWebExample.Helpers;
using SmartMeApiClient;
using SmartMeApiClient.Containers;

namespace OidcWebExample.Pages.MBus
{
    public class SendTelegramModel : PageModel
    {
        public SmartMeApiClient.Containers.User UserInfo { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }

            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var telegram = new byte[] { 0x68, 0x7A, 0x7A, 0x68, 0x08, 0x00, 0x72, 0x71, 0x76, 0x22, 0x15, 0xEE, 0x4D, 0x19, 0x04, 0x15, 0x00, 0x00, 0x00, 0x04, 0x06, 0x00, 0x00, 0x00, 0x00, 0x84, 0x0A, 0x06, 0x00, 0x00, 0x00, 0x00, 0x04, 0x14, 0x0B, 0x00, 0x00, 0x00, 0x84, 0x0A, 0x14, 0x00, 0x00, 0x00, 0x00, 0x0B, 0xFD, 0x0F, 0x00, 0x03, 0x01, 0x0A, 0xFD, 0x0D, 0x00, 0x11, 0x05, 0xFF, 0x01, 0xF2, 0x4E, 0x2E, 0x3C, 0x05, 0xFF, 0x02, 0x85, 0xDA, 0x50, 0x3F, 0x0C, 0x78, 0x71, 0x76, 0x22, 0x15, 0x04, 0x6D, 0x2F, 0x0B, 0xDB, 0x18, 0x82, 0x0A, 0x6C, 0xE1, 0xF1, 0x05, 0x5B, 0x00, 0x9A, 0xB8, 0x41, 0x05, 0x5F, 0x80, 0x00, 0xB2, 0x41, 0x05, 0x3E, 0x00, 0x00, 0x00, 0x00, 0x05, 0x2B, 0x00, 0x00, 0x00, 0x00, 0x01, 0xFF, 0x2B, 0x00, 0x03, 0x22, 0x29, 0x02, 0x00, 0x02, 0xFF, 0x2C, 0x00, 0x00, 0x1F, 0x59, 0x16 };

            return await MBusApi.SendTelegramAsync(
                accessToken, 
                new MBusData
                {
                    Date = DateTime.UtcNow,
                    Telegram = BitConverter.ToString(telegram).Replace("-", "")
                },
                new ResultHandler<MBusData>
                {
                    OnError = DefaultErrorHandler.Handle
                }
            );
        }
    }
}