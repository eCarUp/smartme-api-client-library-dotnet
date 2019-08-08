﻿#region License
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

using Newtonsoft.Json;
using SmartMeApiClient.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SmartMeApiClient
{
    /// <summary>
    /// Class that acts a client to the smart-me API
    /// </summary>
    class SmartMeApiClient : IDisposable
    {
        private HttpClient client;
        private string baseUrl = "https://smart-me.com:443/api/";

        /// <summary>
        /// Smart-me API Call without Authentication
        /// </summary>
        public SmartMeApiClient()
        {
            this.CreateClient();
        }

        /// <summary>
        /// Smart-me API Calls with Basic Authentication
        /// </summary>
        /// <param name="usernamePassword"></param>
        public SmartMeApiClient(UserPassword usernamePassword)
        {
            this.CreateClient();
            var byteArray = Encoding.ASCII.GetBytes(usernamePassword.Username + ":" + usernamePassword.Password);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }

        private void CreateClient()
        {
            this.client = new HttpClient();            
            this.client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void Dispose()
        {
            this.client.Dispose();
        }

        /// <summary>
        /// Sends a GET request to the specified relative url
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="relativeUrl"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string relativeUrl)
        {
            var response = await client.GetAsync(relativeUrl);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(content);
                return result;
            }

            return default(T);
        }

        /// <summary>
        /// Sends a GET request to the specified relative url with the provided parameters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="relativeUrl"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string relativeUrl, Dictionary<string, object> parameters)
        {
            // Build full url including query parameters
            var query = HttpUtility.ParseQueryString(string.Empty);

            foreach(var parameter in parameters.Keys)
            {
                query[parameter] = parameters[parameter].ToString();
            }

            var builder = new UriBuilder(baseUrl + relativeUrl);
            builder.Query = query.ToString();

            var response = await client.GetAsync(builder.ToString());
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(content);
                return result;
            }

            return default(T);
        }

        /// <summary>
        /// Sends a POST request to the specified relative url with the provided content
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="relativeUrl"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task<bool> PostAsync<T>(string relativeUrl, T content)
        {
            string jsonContent = JsonConvert.SerializeObject(content);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(relativeUrl, httpContent);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Sends a POST request to the specified relative url with the provided content
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="relativeUrl"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task<T> PostAddAsync<T>(string relativeUrl, T content)
        {
            string jsonContent = JsonConvert.SerializeObject(content);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(relativeUrl, httpContent);

            if(response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(responseContent);
                return result;
            }

            return default(T);
        }
    }
}
