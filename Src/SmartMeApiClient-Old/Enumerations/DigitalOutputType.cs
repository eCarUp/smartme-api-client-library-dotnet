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
    /// <summary>
    /// Enumeration for the Type of a Digital output
    /// </summary>
    public enum DigitalOutputType
    {
        /// <summary>
        /// It's a normal Impulse Output (Active Energy Import and Export)
        /// </summary>
        ImpulseOutputActiveEnergy = 0,

        /// <summary>
        /// It's a Impuls output for the Active Energy Import
        /// </summary>
        ImpulseOutputActiveEnergyImport = 1,

        /// <summary>
        /// It's a Impuls output for the Active Energy Export
        /// </summary>
        ImpulseOutputActiveEnergyExport = 2,

        /// <summary>
        /// It's a Impulse output for the Reactive Energy
        /// </summary>
        ImpulseOutputReactiveEnergy = 10,

        /// <summary>
        /// It's a Digital output
        /// </summary>
        DigitalOutput = 50,

        /// <summary>
        /// It's a analog PWM signal output
        /// </summary>
        AnalogPwmSignalOutput = 51,
    }
}
