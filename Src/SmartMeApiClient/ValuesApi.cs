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

using SmartMeApiClient.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace SmartMeApiClient
{
    /// <summary>
    /// Class to access the Values API
    /// </summary>
    public class ValuesApi
    {
        /// <summary>
        /// Gets all (last) values of a device
        /// </summary>
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns></returns>
        public static async Task<DeviceValues> GetDeviceValuesAsync(UserPassword usernamePassword, Guid deviceId)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.GetAsync<DeviceValues>("Values/" + deviceId);
            }
        }

        /// <summary>
        /// Gets all (last) values of a device
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns></returns>
        public static async Task<DeviceValues> GetDeviceValuesAsync(string accessToken, Guid deviceId)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<DeviceValues>("Values/" + deviceId);
            }
        }

        /// <summary>
        /// Gets all (last) values of a device
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns></returns>
        public static async Task<IActionResult> GetDeviceValuesAsync(
            string accessToken, 
            Guid deviceId, 
            ResultHandler<DeviceValues> resultHandler)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<DeviceValues>("Values/" + deviceId, resultHandler);
            }
        }

        /// <summary>
        /// Gets the Values for a device at a given Date. The first Value found before the given Date is returned.
        /// </summary>
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <param name="date">The date of the value</param>
        /// <returns></returns>
        public static async Task<DeviceValues> GetDeviceValuesInPastAsync(UserPassword usernamePassword, Guid deviceId, DateTime date)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.GetAsync<DeviceValues>("ValuesInPast/" + deviceId, new Dictionary<string, object> {
                    { "date", date.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") }
                });
            }
        }

        /// <summary>
        /// Gets the Values for a device at a given Date. The first Value found before the given Date is returned.
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <param name="date">The date of the value</param>
        /// <returns></returns>
        public static async Task<DeviceValues> GetDeviceValuesInPastAsync(string accessToken, Guid deviceId, DateTime date)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<DeviceValues>("ValuesInPast/" + deviceId, new Dictionary<string, object> {
                    { "date", date.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") }
                });
            }
        }

        /// <summary>
        /// Gets the Values for a device at a given Date. The first Value found before the given Date is returned.
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <param name="date">The date of the value</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns></returns>
        public static async Task<IActionResult> GetDeviceValuesInPastAsync(
            string accessToken, 
            Guid deviceId, 
            DateTime date, 
            ResultHandler<DeviceValues> resultHandler)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<DeviceValues>(
                    "ValuesInPast/" + deviceId, 
                    new Dictionary<string, object> {
                        { "date", date.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") }
                    },
                    resultHandler
                );
            }
        }

        /// <summary>
        /// Gets multiple values of a device. This call needs a smart-me professional licence.
        /// </summary>
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <param name="startDate">The date when the first value should start</param>
        /// <param name="endDate">The date when the last value should start</param>
        /// <param name="intervalInMinutes">The interval in minutes betwenn the values. 0 means as fast as possible. Only 1000 values can be get in one call.</param>
        /// <returns></returns>
        public static async Task<List<DeviceValues>> GetDeviceValuesInPastMultipleAsync(
            UserPassword usernamePassword, 
            Guid deviceId, 
            DateTime startDate, 
            DateTime endDate, 
            int intervalInMinutes)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.GetAsync<List<DeviceValues>>("ValuesInPastMultiple/" + deviceId, new Dictionary<string, object> {
                    { "startDate", startDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") },
                    { "endDate", endDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") },
                    { "interval", intervalInMinutes }
                });
            }
        }

        /// <summary>
        /// Gets multiple values of a device. This call needs a smart-me professional licence.
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <param name="startDate">The date when the first value should start</param>
        /// <param name="endDate">The date when the last value should start</param>
        /// <param name="intervalInMinutes">The interval in minutes betwenn the values. 0 means as fast as possible. Only 1000 values can be get in one call.</param>
        /// <returns></returns>
        public static async Task<List<DeviceValues>> GetDeviceValuesInPastMultipleAsync(
            string accessToken, 
            Guid deviceId, 
            DateTime startDate, 
            DateTime endDate, 
            int intervalInMinutes)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<List<DeviceValues>>("ValuesInPastMultiple/" + deviceId, new Dictionary<string, object> {
                    { "startDate", startDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") },
                    { "endDate", endDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") },
                    { "interval", intervalInMinutes }
                });
            }
        }

        /// <summary>
        /// Gets multiple values of a device. This call needs a smart-me professional licence.
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <param name="startDate">The date when the first value should start</param>
        /// <param name="endDate">The date when the last value should start</param>
        /// <param name="intervalInMinutes">The interval in minutes betwenn the values. 0 means as fast as possible. Only 1000 values can be get in one call.</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns></returns>
        public static async Task<IActionResult> GetDeviceValuesInPastMultipleAsync(
            string accessToken, 
            Guid deviceId, 
            DateTime startDate, 
            DateTime endDate, 
            int intervalInMinutes,
            ResultHandler<List<DeviceValues>> resultHandler)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<List<DeviceValues>>(
                    "ValuesInPastMultiple/" + deviceId, 
                    new Dictionary<string, object> {
                        { "startDate", startDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") },
                        { "endDate", endDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") },
                        { "interval", intervalInMinutes }
                    },
                    resultHandler
                );
            }
        }

        /// <summary>
        /// Gets the Values for a Meter at a given Date. The first Value found before the given Date is returned.
        /// </summary>
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
        /// <param name="meterId">The ID of the meter</param>
        /// <param name="date">The date of the value</param>
        /// <returns></returns>
        public static async Task<MeterValues> GetMeterValuesAsync(UserPassword usernamePassword, Guid meterId, DateTime date)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.GetAsync<MeterValues>("MeterValues/" + meterId, new Dictionary<string, object> {
                    { "date", date.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") }
                });
            }
        }

        /// <summary>
        /// Gets the Values for a Meter at a given Date. The first Value found before the given Date is returned.
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="meterId">The ID of the meter</param>
        /// <param name="date">The date of the value</param>
        /// <returns></returns>
        public static async Task<MeterValues> GetMeterValuesAsync(string accessToken, Guid meterId, DateTime date)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<MeterValues>("MeterValues/" + meterId, new Dictionary<string, object> {
                    { "date", date.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") }
                });
            }
        }

        /// <summary>
        /// Gets the Values for a Meter at a given Date. The first Value found before the given Date is returned.
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="meterId">The ID of the meter</param>
        /// <param name="date">The date of the value</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns></returns>
        public static async Task<IActionResult> GetMeterValuesAsync(
            string accessToken, 
            Guid meterId, 
            DateTime date,
            ResultHandler<MeterValues> resultHandler)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<MeterValues>(
                    "MeterValues/" + meterId, 
                    new Dictionary<string, object> {
                        { "date", date.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") }
                    },
                    resultHandler
                );
            }
        }
    }
}
