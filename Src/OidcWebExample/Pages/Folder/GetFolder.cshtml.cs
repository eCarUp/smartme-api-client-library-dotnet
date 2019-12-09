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
using SmartMeApiClient;

namespace OidcWebExample.Pages.Folder
{
    public class GetFolderModel : PageModel
    {
        public Guid Id { get; set; }

        public SmartMeApiClient.Containers.Folder Folder { get; set; }

        public GetFolderModel()
        {
            Id = new Guid("686e51c1-2df8-4596-88aa-113f9022474a");
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }

            var accessToken = await HttpContext.GetTokenAsync("access_token");

            return await FolderApi.GetFolderAsync(accessToken, Id, new ResultHandler<SmartMeApiClient.Containers.Folder>
            {
                OnSuccess = (folder) =>
                {
                    Folder = folder;
                    return Page();
                },

                OnError = (errorType, errorMessage) =>
                {
                    if (errorType == ErrorType.Unauthorized)
                    {
                        errorMessage = $"Folder with Id '{Id}' does not exist";
                    }

                    return new RedirectResult("/Error?message=" + errorMessage);
                }
            });
        }
    }
}