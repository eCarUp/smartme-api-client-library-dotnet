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

using SmartMeApiClient.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMeApiClient.Containers
{
    /// <summary>
    /// Configuration for the outputs of a meter (analog/digital outputs)
    /// </summary>
    public class OutputConfiguration
    {
        /// <summary>
        /// The number of the Output. (1 for Output 1, 2 for Output 2)
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// The Name of the Output
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Type of the output
        /// </summary>
        public DigitalOutputType? Type { get; set; }

        /// <summary>
        /// The Action when the device has lost the connection
        /// </summary>
        public DigitalOutputNoConnectionAction? DigitalOutputNoConnectionAction { get; set; }

        /// <summary>
        /// The S0 Pulse Value
        /// </summary>
        public S0PulseValueType? S0PulseValue { get; set; }

    }
}
