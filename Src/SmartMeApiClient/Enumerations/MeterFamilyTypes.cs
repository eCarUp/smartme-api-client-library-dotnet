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

namespace SmartMeApiClient.Enumerations
{
    /// <summary>
    /// The Family Type of the meter (e.g. Smart-me connect meter)
    /// </summary>
    public enum MeterFamilyType
    {
        /// <summary>
        /// The Family Type is unknown, (all M-BUS Meters, S0 meters, ...)
        /// </summary>
        MeterFamilyTypeUnknown = 0,

        /// <summary>
        /// It's a smart-me connect Meter (Plugin Power Meter)
        /// </summary>
        MeterFamilyTypeSmartMeConnectV1 = 1,

        /// <summary>
        /// smart-me Meter (1-Phase DIN Rail Meter) without switch
        /// </summary>
        MeterFamiliyTypeSmartMeMeter = 2,

        /// <summary>
        /// smart-me Meter (1-Phase DIN Rail Meter) with a Switch
        /// </summary>
        MeterFamiliyTypeSmartMeMeterWithSwitch = 3,

        /// <summary>
        /// It's a smart-me M-BUS Gateway V1
        /// </summary>
        MeterFamilyTypeMBusGatewayV1 = 4,

        /// <summary>
        /// It's a smart-me RS-485 Gateway V1
        /// </summary>
        MeterFamilyTypeRS485GatewayV1 = 5,

        /// <summary>
        /// It's a smart-me RS-485 Gateway V1
        /// </summary>
        MeterFamilyTypeKamstrupModule = 6,

        /// <summary>
        /// It's a smart-me 3-Phase Meter 80A
        /// </summary>
        MeterFamilyTypeSmartMe3PhaseMeter80A = 7,

        /// <summary>
        /// It's a smart-me 3-Phase Meter 32A (with Switch)
        /// </summary>
        MeterFamilyTypeSmartMe3PhaseMeter32A = 8,

        /// <summary>
        /// It's a smart-me 3-Phase Meter Transformer Edition
        /// </summary>
        MeterFamilyTypeSmartMe3PhaseMeterTransformer = 9,

        /// <summary>
        /// It's a rest API Meter
        /// </summary>
        MeterFamilyTypeRestApiMeter = 1001,

        /// <summary>
        /// It's a virtual Meter
        /// </summary>
        MeterFamilyTypeVirtualMeter = 1002,
    }
}
