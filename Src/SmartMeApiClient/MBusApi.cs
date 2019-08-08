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
    /// Class to access the MBus API
    /// </summary>
    public class MBusApi
    {
        /// <summary>
        /// M-BUS API: Adds data of a M-BUS Meter to the smart-me Cloud. 
        /// Just send us the M-BUS Telegram (RSP_UD) and we will do the Rest.
        /// </summary>
        /// <param name="usernamePassword">The Username and Password</param>
        /// <param name="mbusData">The M-BUS Telegram</param>
        /// <returns></returns>
        public static async Task<bool> SendTelegramAsync(UserPassword usernamePassword, MBusData mbusData)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.PostAsync<MBusData>("MBus", mbusData);
            }
        }
    }
}
