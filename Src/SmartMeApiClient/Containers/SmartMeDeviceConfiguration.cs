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

using Newtonsoft.Json;
using SmartMeApiClient.Enumerations;
using System;
using System.Collections.Generic;

namespace SmartMeApiClient.Containers
{
    /// <summary>
    /// API Container class for the meter configuration
    /// </summary>
    public class SmartMeDeviceConfiguration
    {
        /// <summary>
        /// The ID of the device
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Number of seconds the device will upload the data. For smaller values maybe a professional license is needed. 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public UploadInterval? UploadInterval { get; set; }

        /// <summary>
        /// The configuration for the phase switches
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<SwitchConfiguration> SwitchConfiguration { get; set; }

        /// <summary>
        /// The configuration for the external outputs
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<OutputConfiguration> OutputConfiguration { get; set; }

        /// <summary>
        /// The configuration for the intput outputs
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<InputConfiguration> InputConfiguration { get; set; }

        /// <summary>
        /// Shows the reactive energy values (if the meter supports it).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowReactiveEnergy { get; set; }

        /// <summary>
        /// Enables or disables Modbus TCP (if the meter supports it).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnableModbusTcp { get; set; }

        /// <summary>
        /// Configuration of the dynamic DNS service. More information: http://wiki.smart-me.com/index.php/Dynamisches_DNS
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public MeterDnsUpdateMode? DnsUpdateState { get; set; }

        /// <summary>
        /// PIN code to enter on a external meter (e.g. for the FNN meters)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DevicePinCode { get; set; }

        /// <summary>
        /// The encryption key used to decrypt messages received from an external meter (used only for the smart-me modules)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceEncryptionKey { get; set; }
    }
}
