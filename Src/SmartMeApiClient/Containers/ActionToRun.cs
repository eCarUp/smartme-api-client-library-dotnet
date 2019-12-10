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

namespace SmartMeApiClient.Containers
{
    /// <summary>
    /// Container Class for an action to be run
    /// </summary>
    public class ActionToRun
    {
        public ActionToRun()
        {
            this.Actions = new List<ActionToRunItem>();
        }

        /// <summary>
        /// The ID of the Device
        /// </summary>
        public Guid DeviceID { get; set; }

        /// <summary>
        /// List with all Actions for this device
        /// </summary>
        public List<ActionToRunItem> Actions { get; set; }
    }

    /// <summary>
    /// Container class for an action item
    /// </summary>
    public class ActionToRunItem
    {
        public ActionToRunItem(string obisCode, double value)
        {
            this.ObisCode = obisCode;
            this.Value = value;
        }

        /// <summary>
        /// The ObisCode (ID) of the Action
        /// </summary>
        public string ObisCode { get; set; }

        /// <summary>
        /// The Value to set
        /// </summary>
        public double Value { get; set; }
    }
}
