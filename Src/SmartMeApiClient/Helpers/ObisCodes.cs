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

namespace SmartMeApiClient.Helpers
{
    public static class ObisCodes
    {
        /// <summary>
        /// The smart-me specific Switch State (uint32) Bitmap
        /// 99-0:12.0.0*255
        /// </summary>
        public static byte[] SmartMeSpecificSwitchState => new byte[] { 99, 0, 12, 0, 0x00, 0xFF };

        /// <summary>
        /// A smart-me specific Phase Switch L1
        /// 99-0:12.0.1*255
        /// </summary>

        public static byte[] SmartMeSpecificPhaseSwitchL1 => new byte[] { 99, 0, 12, 0, 0x01, 0xFF };

        /// <summary>
        /// A smart-me specific Phase Switch L2
        /// 99-0:12.0.2*255
        /// </summary>

        public static byte[] SmartMeSpecificPhaseSwitchL2 => new byte[] { 99, 0, 12, 0, 0x02, 0xFF };

        /// <summary>
        /// A smart-me specific Phase Switch L3
        /// 99-0:12.0.3*255
        /// </summary>

        public static byte[] SmartMeSpecificPhaseSwitchL3 => new byte[] { 99, 0, 12, 0, 0x03, 0xFF };


        /// <summary>
        /// A smart-me specific Digital Output 1
        /// 99-0:12.1.1*255
        /// </summary>

        public static byte[] SmartMeSpecificDigitalOutput1 => new byte[] { 99, 0, 12, 1, 0x01, 0xFF };

        /// <summary>
        /// A smart-me specific Digital Output 2
        /// 99-0:12.1.2*255
        /// </summary>

        public static byte[] SmartMeSpecificDigitalOutput2 => new byte[] { 99, 0, 12, 1, 0x02, 0xFF };
    }
}
