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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmartMeApiClient.Enumerations;

namespace SmartMeApiClient.Containers
{
    /// <summary>
    /// Container Class for the smart-me latest Device Values
    /// </summary>
    public class DeviceValues
    {
        public DeviceValues()
        {
            Values = new List<DeviceValue>();
        }

        /// <summary>
        /// The ID of the device
        /// </summary>
        /// <remarks>The ID of the device</remarks>
        public Guid DeviceId { get; set; }

        /// <summary>
        /// The Date of the Value
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// All values
        /// </summary>
        public List<DeviceValue> Values { get; set; }
    }

    /// <summary>
    /// Container Class for a (Device) Value
    /// </summary>
    public class DeviceValue
    {
        /// <summary>
        /// The Obis code of this value. 
        /// A description you can find here:
        /// http://wiki.smart-me.com/index.php/Obis_codes
        /// </summary>
        public string Obis { get; set; }

        /// <summary>
        /// The Value
        /// </summary>
        public double Value { get; set; }
    }
}
