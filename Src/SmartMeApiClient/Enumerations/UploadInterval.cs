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

namespace SmartMeApiClient.Enumerations
{
    /// <summary>
    /// Enumeration for the Upload Interval
    /// </summary>
    public enum UploadInterval
    {
        // 1s
        UploadInterval_1s = 1,

        // 5s
        UploadInterval_5s = 2,

        // 10s
        UploadInterval_10s = 3,

        // 30s
        UploadInterval_30s = 4,

        // 60s
        UploadInterval_60s = 5,

        // 5 min
        UploadInterval_5min = 6,

        // 15 min
        UploadInterval_15min = 7,

        // 30 min
        UploadInterval_30min = 8,

        // 60 min
        UploadInterval_60min = 9,

        // 6h
        UploadInterval_6h = 10,

        // 12h
        UploadInterval_12h = 11,

        // 24h
        UploadInterval_24h = 12,
    }
}
