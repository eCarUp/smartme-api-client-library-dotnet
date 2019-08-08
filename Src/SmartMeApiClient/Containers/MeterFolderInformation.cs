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
    /// Container Class for the MeterFolderInformation
    /// </summary>
    public class MeterFolderInformation
    {
        public MeterFolderInformation()
        {
            OutputInformations = new List<OutputInformation>();
            InputInformations = new List<InputInformation>();
        }

        /// <summary>
        /// Name of the Meter or Folder
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Flag if it's a Folder or a Meter
        /// </summary>
        public bool IsFolder { get; set; }

        /// <summary>
        /// Informations about the available Outputs
        /// </summary>
        public List<OutputInformation> OutputInformations { get; set; }

        /// <summary>
        /// Informations about the available Inputs
        /// </summary>
        public List<InputInformation> InputInformations { get; set; }

        /// <summary>
        /// The Hardware Version of a Meter. 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? HardwareVersion { get; set; }

        /// <summary>
        /// The Firmware Version of a Meter
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? FirmwareVersion { get; set; }
    }

    /// <summary>
    /// Informations about the Outputs of a Meter or Folder
    /// </summary>
    public class OutputInformation
    {
        /// <summary>
        /// The Number of this Output. Use this as ID to switch it on or off. 
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// The Name of the Output
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Obis Code for this Output
        /// </summary>
        public string ObisCode { get; set; }

        /// <summary>
        /// The type of the Output
        /// </summary>
        public ActionType ActionType { get; set; }
    }

    /// <summary>
    /// Informations about the Inputs of a Meter or Folder
    /// </summary>
    public class InputInformation
    {
        /// <summary>
        /// The Number of this Input. Use this as ID to switch it on or off. 
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// The Name of the Input
        /// </summary>
        public string Name { get; set; }
    }
}
