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
using Newtonsoft.Json;
using SmartMeApiClient.Converters;

namespace SmartMeApiClient.Containers
{
    /// <summary>
    /// Container Class for a Custom Device
    /// </summary>
    public class CustomDevice
    {
        /// <summary>
        /// The ID of the device
        /// </summary>
        /// <remarks>The ID of the device</remarks>
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }

        /// <summary>
        /// The Name of the Device
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Serial number
        /// </summary>
        public Int64 Serial { get; set; }

        /// <summary>
        /// The Values of the custom Device
        /// </summary>
        public List<CustomDeviceValue> Values { get; set; }

        /// <summary>
        /// The Date of the Value (in UTC). If this is null the Server Time is used.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ValueDate { get; set; }
    }

    /// <summary>
    /// Container Class for a Custom Device Value
    /// </summary>
    public class CustomDeviceValue
    {
        /// <summary>
        /// The Name of the Value. 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Value
        /// </summary>
        public double Value { get; set; }
    }
}
