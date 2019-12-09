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
using System;

namespace SmartMeApiClient.Containers
{
    /// <summary>
    /// Container Class for the smart-me MeterValue
    /// </summary>
    public class MeterValues
    {
        /// <summary>
        /// The ID of the device
        /// </summary>
        /// <remarks>The ID of the device</remarks>
        public Guid Id { get; set; }

        /// <summary>
        /// The Serial number
        /// </summary>
        public Int64 Serial { get; set; }

        /// <summary>
        /// The Date of the Values
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The Meter Counter Reading (Total Energy used)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CounterReading { get; set; }

        /// <summary>
        /// The Unit of the Counter Reading
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CounterReadingUnit { get; set; }

        /// <summary>
        /// The Meter Counter Reading Tariff 1
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CounterReadingT1 { get; set; }

        /// <summary>
        /// The Meter Counter Reading Tariff 2
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CounterReadingT2 { get; set; }

        /// <summary>
        /// The Meter Counter Reading Tariff 3
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CounterReadingT3 { get; set; }

        /// <summary>
        /// The Meter Counter Reading Tariff 4
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CounterReadingT4 { get; set; }

        /// <summary>
        /// The Meter Counter Reading Import
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CounterReadingImport { get; set; }

        /// <summary>
        /// The Meter Counter Reading Import Tariff 1
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CounterReadingImportT1 { get; set; }

        /// <summary>
        /// The Meter Counter Reading Import Tariff 2
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CounterReadingImportT2 { get; set; }

        /// <summary>
        /// The Meter Counter Reading Import Tariff 3
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CounterReadingImportT3 { get; set; }

        /// <summary>
        /// The Meter Counter Reading Import Tariff 4
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CounterReadingImportT4 { get; set; }

        /// <summary>
        /// The Meter Counter Reading Export
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CounterReadingExport { get; set; }

        /// <summary>
        /// The Meter Counter Reading Export Tariff 1
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CounterReadingExportT1 { get; set; }

        /// <summary>
        /// The Meter Counter Reading Export Tariff 2
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CounterReadingExportT2 { get; set; }

        /// <summary>
        /// The Meter Counter Reading Export Tariff 3
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CounterReadingExportT3 { get; set; }

        /// <summary>
        /// The Meter Counter Reading Export Tariff 4
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CounterReadingExportT4 { get; set; }

    }
}
