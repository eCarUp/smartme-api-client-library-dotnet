﻿#region License
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

using SmartMeApiClient;
using SmartMeApiClient.Containers;
using SmartMeApiClient.Helpers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Example
{
    public class ActionsExamples
    {
        public static async Task ActionsAsync(UserPassword credentials)
        {
            // Get Actions
            {
                Helpers.WriteConsoleTitle("Get Actions");

                List<SmartMeApiClient.Containers.Action> actions = await ActionsApi.GetActionsAsync(credentials, new Guid("00315ffa-a6b6-4538-84f5-b50b685b0e83"));

                foreach (var action in actions)
                {
                    Console.WriteLine($"Name: {action.Name}, ObisCode: {action.ObisCode}");
                }
            }

            // Run Actions
            {
                Helpers.WriteConsoleTitle("Run Actions");

                await ActionsApi.RunActionsAsync(credentials, new SmartMeApiClient.Containers.ActionToRun
                {
                    DeviceID = new Guid("00315ffa-a6b6-4538-84f5-b50b685b0e83"),
                    Actions = new List<SmartMeApiClient.Containers.ActionToRunItem>
                    {
                        new SmartMeApiClient.Containers.ActionToRunItem(HexStringHelper.ByteArrayToString(ObisCodes.SmartMeSpecificPhaseSwitchL1), 1.0)
                    }
                });

                Console.WriteLine("Switch on");

                Thread.Sleep(5000);

                await ActionsApi.RunActionsAsync(credentials, new SmartMeApiClient.Containers.ActionToRun
                {
                    DeviceID = new Guid("00315ffa-a6b6-4538-84f5-b50b685b0e83"),
                    Actions = new List<SmartMeApiClient.Containers.ActionToRunItem>
                    {
                        new SmartMeApiClient.Containers.ActionToRunItem(HexStringHelper.ByteArrayToString(ObisCodes.SmartMeSpecificPhaseSwitchL1), 0.0)
                    }
                });

                Console.WriteLine("Switch off");
            }
        }        
    }
}