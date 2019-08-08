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

using SmartMeApiClient.Containers;
using Newtonsoft.Json;
using System.IO;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            UserPassword credentials = JsonConvert.DeserializeObject<UserPassword>(File.ReadAllText("Credentials.json"));

            DevicesExamples.DevicesAsync(credentials).Wait();
            DevicesExamples.DeviceConfigurationAsync(credentials).Wait();
            DevicesExamples.CustomDevicesAsync(credentials).Wait();

            ActionsExamples.ActionsAsync(credentials).Wait();

            ValuesExamples.ValuesAsync(credentials).Wait();

            UserExamples.UserAsync(credentials).Wait();

            FolderExamples.FolderAsync(credentials).Wait();

            MBusExamples.SendMBusDataAsync(credentials).Wait();
        }
    }
}
