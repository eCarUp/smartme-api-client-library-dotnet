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
    /// Class to access the Folder API
    /// </summary>
    public class FolderApi
    {
        /// <summary>
        /// Gets the available Folders or Meters
        /// </summary>
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
        /// <param name="id">The ID of the Folder or Meter</param>
        /// <returns></returns>
        public static async Task<Folder> GetFolderAsync(UserPassword usernamePassword, Guid id)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.GetAsync<Folder>("Folder/" + id);
            }
        }

        /// <summary>
        /// Gets the available Folders or Meters
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="id">The ID of the Folder or Meter</param>
        /// <returns></returns>
        public static async Task<Folder> GetFolderAsync(string accessToken, Guid id)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<Folder>("Folder/" + id);
            }
        }

        /// <summary>
        /// Gets the available Folders or Meters
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="id">The ID of the Folder or Meter</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns></returns>
        public static async Task<IActionResult> GetFolderAsync(
            string accessToken, 
            Guid id, 
            ResultHandler<Folder> resultHandler)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<Folder>("Folder/" + id, resultHandler);
            }
        }

        /// <summary>
        /// Gets the Information of a Folder or a Meter
        /// </summary>
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
        /// <param name="id">The ID of the Folder or Meter</param>
        /// <returns></returns>
        public static async Task<MeterFolderInformation> GetMeterFolderInformationAsync(UserPassword usernamePassword, Guid id)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.GetAsync<MeterFolderInformation>("MeterFolderInformation/" + id);
            }
        }

        /// <summary>
        /// Gets the Information of a Folder or a Meter
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="id">The ID of the Folder or Meter</param>
        /// <returns></returns>
        public static async Task<MeterFolderInformation> GetMeterFolderInformationAsync(string accessToken, Guid id)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<MeterFolderInformation>("MeterFolderInformation/" + id);
            }
        }

        /// <summary>
        /// Gets the Information of a Folder or a Meter
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="id">The ID of the Folder or Meter</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns></returns>
        public static async Task<IActionResult> GetMeterFolderInformationAsync(
            string accessToken, 
            Guid id, 
            ResultHandler<MeterFolderInformation> resultHandler)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<MeterFolderInformation>("MeterFolderInformation/" + id, resultHandler);
            }
        }

        /// <summary>
        /// Sets the Name of a Meter or a Folder
        /// </summary>
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
        /// <param name="meterFolderInformation">The Id of the meter or folder and the Name to be set</param>
        /// <returns></returns>
        public static async Task<bool> SetMeterFolderInformationAsync(UserPassword usernamePassword, MeterFolderInformationToSet meterFolderInformation)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.PostAsync<MeterFolderInformationToSet>("MeterFolderInformation", meterFolderInformation);
            }
        }

        /// <summary>
        /// Sets the Name of a Meter or a Folder
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="meterFolderInformation">The Id of the meter or folder and the Name to be set</param>
        /// <returns></returns>
        public static async Task<bool> SetMeterFolderInformationAsync(string accessToken, MeterFolderInformationToSet meterFolderInformation)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.PostAsync<MeterFolderInformationToSet>("MeterFolderInformation", meterFolderInformation);
            }
        }

        /// <summary>
        /// Sets the Name of a Meter or a Folder
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="meterFolderInformation">The Id of the meter or folder and the Name to be set</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns></returns>
        public static async Task<IActionResult> SetMeterFolderInformationAsync(
            string accessToken, 
            MeterFolderInformationToSet meterFolderInformation, 
            ResultHandler<MeterFolderInformationToSet> resultHandler)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.PostAsync<MeterFolderInformationToSet>("MeterFolderInformation", meterFolderInformation, resultHandler);
            }
        }
    }
}
