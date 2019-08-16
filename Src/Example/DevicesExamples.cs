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

using SmartMeApiClient;
using SmartMeApiClient.Containers;
using SmartMeApiClient.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example
{
    public class DevicesExamples
    {
        public static async Task DevicesAsync(UserPassword credentials)
        {
            // Get all devices
            {
                Helpers.WriteConsoleTitle("Get all devices");

                List<Device> devices = await DevicesApi.GetDevicesAsync(credentials);

                foreach (var device in devices)
                {
                    Console.WriteLine($"Id: {device.Id}, Name: {device.Name}");
                }
            }

            // Get all devices with a certain energy type 
            {
                Helpers.WriteConsoleTitle("Get all devices with energy type 'MeterTypeElectricity'");

                List<Device> devices = await DevicesApi.GetDevicesAsync(credentials, MeterEnergyType.MeterTypeElectricity);

                foreach (var device in devices)
                {
                    Console.WriteLine($"Id: {device.Id}, Name: {device.Name}, EnergyType: {Enum.GetName(typeof(MeterEnergyType), device.DeviceEnergyType)}");
                }
            }

            // Get all devices with a certain meter sub type
            {
                Helpers.WriteConsoleTitle("Get all devices with meter sub type 'MeterSubTypeHeat'");

                List<Device> devices = await DevicesApi.GetDevicesAsync(credentials, MeterSubType.MeterSubTypeHeat);

                foreach (var device in devices)
                {
                    Console.Write($"Id: {device.Id} Name: {device.Name} ");

                    if (device.MeterSubType != null)
                    {
                        Console.Write($"SubType: {Enum.GetName(typeof(MeterSubType), device.MeterSubType)}");
                    }

                    Console.WriteLine();
                }
            }

            // Get device by Id
            {
                Helpers.WriteConsoleTitle("Get device by Id");

                Device device = await DevicesApi.GetDeviceAsync(credentials, new Guid("00315ffa-a6b6-4538-84f5-b50b685b0e83"));
                Console.WriteLine($"Name: {device.Name}, Id: {device.Id}");
            }

            // Get device by Serial
            {
                Helpers.WriteConsoleTitle("Get device by serial number");

                Device device = await DevicesApi.GetDeviceAsync(credentials, 200354);
                Console.WriteLine($"Name: {device.Name}, Serial: {device.Serial}");
            }

            // Get additional device information
            {
                Helpers.WriteConsoleTitle("Get additional device information");

                var info = await DevicesApi.GetAdditionalDeviceInformationAsync(credentials, new Guid("00315ffa-a6b6-4538-84f5-b50b685b0e83"));
                Console.WriteLine($"ID: {info.ID}, HardwareVersion: {info.HardwareVersion}, FirmwareVersion: {info.FirmwareVersion}, AdditionalMeterSerialNumber: {info.AdditionalMeterSerialNumber}");
            }

            // Add and update device
            {
                Helpers.WriteConsoleTitle("Add a new device");

                Device newDevice = await DevicesApi.AddDeviceAsync(credentials, new Device
                {
                    Name = "NewDevice",
                    DeviceEnergyType = MeterEnergyType.MeterTypeElectricity,
                    ActivePower = 0,
                    CounterReading = 0,
                    Voltage = 230,
                    VoltageL1 = 230,
                    Current = 1.0,
                    PowerFactor = 0,
                    PowerFactorL1 = 0,
                    Temperature = 26
                });

                Helpers.WriteConsoleTitle("Update the name of a device");

                newDevice.Name = "UpdatedDevice";

                await DevicesApi.UpdateDeviceAsync(credentials, newDevice);

                Helpers.WriteConsoleTitle("Update CounterReadingImport and ActivePower of a device");

                for (int i = 0; i < 10; i++)
                {
                    newDevice.CounterReading = i + 1;
                    newDevice.ActivePower = i * 1.1;

                    await DevicesApi.UpdateDeviceAsync(credentials, newDevice);

                    Thread.Sleep(1000);
                }
            }
        }

        public static async Task DeviceConfigurationAsync(UserPassword credentials)
        {
            // Get smart-me Device Configuration
            {
                Helpers.WriteConsoleTitle("Get smart-me device configuration");

                var configuration = await DevicesApi.GetSmartMeDeviceConfigurationAsync(credentials, new Guid("00315ffa-a6b6-4538-84f5-b50b685b0e83"));
                Console.WriteLine($"Id: {configuration.Id}, UploadInterval: {configuration.UploadInterval}");
            }

            // Set smart-me Device Configuration
            {
                Helpers.WriteConsoleTitle("Set smart-me device configuration");

                var configuration = await DevicesApi.GetSmartMeDeviceConfigurationAsync(credentials, new Guid("00315ffa-a6b6-4538-84f5-b50b685b0e83"));

                configuration.SwitchConfiguration[0].CanSwitchOff = false;

                try
                {
                    await DevicesApi.SetSmartMeDeviceConfigurationAsync(credentials, configuration);
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }

                Console.WriteLine("Device is not allowed to switch off");

                Thread.Sleep(5000);

                configuration = await DevicesApi.GetSmartMeDeviceConfigurationAsync(credentials, new Guid("00315ffa-a6b6-4538-84f5-b50b685b0e83"));

                configuration.SwitchConfiguration[0].CanSwitchOff = true;

                try
                {
                    await DevicesApi.SetSmartMeDeviceConfigurationAsync(credentials, configuration);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }

                Console.WriteLine("Device is allowed to switch off");

                Thread.Sleep(5000);
            }
        }

        public static async Task CustomDevicesAsync(UserPassword credentials)
        {
            // Add Custom Device
            {
                Helpers.WriteConsoleTitle("Add a custom device");

                await DevicesApi.AddCustomDeviceAsync(credentials, new CustomDevice
                {
                    Id = new Guid(),
                    Name = "CustomDeviceTest",
                    Serial = 0,
                    ValueDate = DateTime.UtcNow,
                    Values = new List<CustomDeviceValue>
                    {
                        new CustomDeviceValue { Name = "SomeVoltageValue", Value = 5.6 },
                        new CustomDeviceValue { Name = "SomeTemperatureValue", Value = 12.1 }
                    }
                });
            }

            // Get Custom Devices
            {
                Helpers.WriteConsoleTitle("Get custom devices");

                List<CustomDevice> customDevices = await DevicesApi.GetCustomDevicesAsync(credentials);

                foreach (CustomDevice customDevice in customDevices)
                {
                    if (customDevice != null)
                    {
                        Console.WriteLine($"Id: {customDevice.Id}, Name: {customDevice.Name}");
                    }
                }
            }

            // Update Custom Device
            {
                Helpers.WriteConsoleTitle("Update a custom device");

                List<CustomDevice> customDevices = await DevicesApi.GetCustomDevicesAsync(credentials);

                foreach (CustomDevice customDevice in customDevices)
                {
                    if (customDevice != null)
                    {
                        customDevice.Name = "UpdatedCustomDeviceTest";
                        await DevicesApi.UpdateCustomDeviceAsync(credentials, customDevice);
                        break;
                    }
                }
            }

            // Get Custom Device by Id
            {
                Helpers.WriteConsoleTitle("Get custom device by id");

                CustomDevice customDevice = await DevicesApi.GetCustomDeviceAsync(credentials, new Guid("{b41338ba-b2bf-4717-bacb-10a9fa278e59}"));
                Console.WriteLine($"Id: {customDevice.Id}, Name: {customDevice.Name}");
            }
        }
    }
}
