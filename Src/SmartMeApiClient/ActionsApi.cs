#region License
// Copyright (c) 2019 smart-me AG https://web.smart-me.com/
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace SmartMeApiClient
{
    /// <summary>
    /// Class to access the Actions API
    /// </summary>
    public class ActionsApi
    {
        /// <summary>
        /// Gets all available Actions for a Device
        /// </summary>
        /// <param name="usernamePassword">The Username and Password</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns></returns>
        public static async Task<List<Containers.Action>> GetActionsAsync(UserPassword usernamePassword, Guid deviceId)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.GetAsync<List<Containers.Action>>("Actions/" + deviceId);
            }
        }

        /// <summary>
        /// Runs an action for the specified device
        /// </summary>
        /// <param name="usernamePassword">The Username and Password</param>
        /// <param name="actionToRun">The Action Data</param>
        /// <returns></returns>
        public static async Task<bool> RunActionsAsync(UserPassword usernamePassword, Containers.ActionToRun actionToRun)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.PostAsync<Containers.ActionToRun>("Actions", actionToRun);
            }
        }
    }
}
