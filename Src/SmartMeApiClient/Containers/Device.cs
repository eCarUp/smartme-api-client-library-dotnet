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
    /// An empty Guid must be serialized to an empty string for the smart-me API.
    /// This is achieved with this JsonConverter.
    /// </summary>
    public class GuidConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Guid);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new Guid(reader.Value.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Guid guid = (Guid)value;

            // Serialize empty Guid as ""
            if (guid.CompareTo(new Guid()) == 0)
            {
                writer.WriteValue("");
            }
            else
            {
                writer.WriteValue(guid.ToString());
            }
        }
    }

    /// <summary>
    /// Container Class for the smart-me Device
    /// </summary>
    public class Device
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
        /// The Energy Type of this device
        /// </summary>
        public MeterEnergyType DeviceEnergyType { get; set; }

        /// <summary>
        /// The Sub Type of this Meter. 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public MeterSubType? MeterSubType { get; set; }

        /// <summary>
        /// The Active Power or current flow rate. In kW or m3/h
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? ActivePower { get; set; }

        /// <summary>
        /// The Meter Counter Reading (Total Energy used) in kWh or m3.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CounterReading { get; set; }

        /// <summary>
        /// The Meter Counter Reading Tariff 1 in kWh or m3.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CounterReadingT1 { get; set; }

        /// <summary>
        /// The Meter Counter Reading Tariff 2 in kWh or m3.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CounterReadingT2 { get; set; }

        /// <summary>
        /// The Meter Counter Reading only export
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CounterReadingExport { get; set; }

        /// <summary>
        /// The Meter Counter Reading only export (Tariff 1)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CounterReadingExportT1 { get; set; }

        /// <summary>
        /// The Meter Counter Reading only export (Tariff 2)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CounterReadingExportT2 { get; set; }

        /// <summary>
        /// The Temperature (in degree celsius)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? Temperature { get; set; }

        /// <summary>
        /// The Date of the Value (in UTC). If this is null the Server Time is used.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ValueDate { get; set; }

        /// <summary>
        /// The Voltage (in V)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? Voltage { get; set; }

        /// <summary>
        /// The Voltage Phase L1 (in V)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? VoltageL1 { get; set; }

        /// <summary>
        /// The Voltage Phase L2 (in V)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? VoltageL2 { get; set; }

        /// <summary>
        /// The Voltage Phase L3 (in V)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? VoltageL3 { get; set; }

        /// <summary>
        /// The Current (in A)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? Current { get; set; }

        /// <summary>
        /// The Current Phase L1 (in A)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CurrentL1 { get; set; }

        /// <summary>
        /// The Current Phase L2 (in A)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CurrentL2 { get; set; }

        /// <summary>
        /// The Current Phase L3 (in A)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? CurrentL3 { get; set; }

        /// <summary>
        /// The Power Factor (cos phi). Range: 0 - 1
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? PowerFactor { get; set; }

        /// <summary>
        /// The Power Factor (cos phi) Phase L1. Range: 0 - 1 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? PowerFactorL1 { get; set; }

        /// <summary>
        /// The Power Factor (cos phi) Phase L2. Range: 0 - 1 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? PowerFactorL2 { get; set; }

        /// <summary>
        /// The Power Factor (cos phi) Phase L3. Range: 0 - 1 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? PowerFactorL3 { get; set; }

        /// <summary>
        /// The digital input number 1
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? DigitalInput1 { get; set; }
    }
}
