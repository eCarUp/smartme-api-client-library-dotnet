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

using SmartMeApiClient;
using SmartMeApiClient.Containers;
using SmartMeApiClient.Enumerations;
using SmartMeApiClient.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class FolderExamples
    {
        public static async Task FolderAsync(UserPassword credentials)
        {
            // Get Folder
            {
                Helpers.WriteConsoleTitle("Get Folder");

                var folder = await FolderApi.GetFolderAsync(credentials, new Guid("c04db633-3c35-4e88-b9ee-11ab04ee7331"));

                Console.WriteLine($"ElectricityCounterValue: {folder.ElectricityCounterValue}, ElectricityPower: {folder.ElectricityPower}");
            }

            // Get MeterFolderInformation
            {
                Helpers.WriteConsoleTitle("Get MeterFolderInformation");

                var info = await FolderApi.GetMeterFolderInformationAsync(credentials, new Guid("c04db633-3c35-4e88-b9ee-11ab04ee7331"));

                Console.WriteLine($"Name: {info.Name}, IsFolder: {info.IsFolder}");
            }

            // Set MeterFolderInformation
            {
                Helpers.WriteConsoleTitle("Set MeterFolderInformation");

                await FolderApi.SetMeterFolderInformationAsync(credentials, new MeterFolderInformationToSet
                {
                    Id = new Guid("c04db633-3c35-4e88-b9ee-11ab04ee7331"),
                    Name = "Test"
                });
            }
        }        
    }
}
