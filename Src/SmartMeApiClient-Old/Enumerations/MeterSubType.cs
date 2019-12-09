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

namespace SmartMeApiClient.Enumerations
{
    public enum MeterSubType
    {
        /// <summary>
        /// Unknown meter sub type
        /// </summary>
        MeterSubTypeUnknown = 0,

        /// <summary>
        /// A Cold / Cold Water Meter
        /// </summary>
        MeterSubTypeCold = 1,

        /// <summary>
        /// A Heat / Hot Water Meter
        /// </summary>
        MeterSubTypeHeat = 2,

        /// <summary>
        /// A E-Charging Station
        /// </summary>
        MeterSubTypeChargingStation = 3,

        /// <summary>
        /// A Electricity meter
        /// </summary>
        MeterSubTypeElectricity = 4,

        /// <summary>
        /// A Water meter
        /// </summary>
        MeterSubTypeWater = 5,

        /// <summary>
        /// A Gas meter
        /// </summary>
        MeterSubTypeGas = 6,

        /// <summary>
        /// A Electricity / Heat meter
        /// </summary>
        MeterSubTypeElectricityHeat = 7,

        /// <summary>
        /// A Temperature meter
        /// </summary>
        MeterSubTypeTemperature = 8,

        /// <summary>
        /// A Virtual battery
        /// </summary>
        MeterSubTypeVirtualBattery = 9,
    }
}
