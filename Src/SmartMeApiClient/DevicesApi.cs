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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using SmartMeApiClient.Enumerations;

namespace SmartMeApiClient
{
    /// <summary>
    /// Class to access the Devices API
    /// </summary>
    public class DevicesApi
    {
        /// <summary>
        /// Gets all Devices
        /// </summary>
        /// <param name="usernamePassword">The Username and Password</param>
        /// <returns></returns>
        public static async Task<List<Device>> GetDevicesAsync(UserPassword usernamePassword)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.GetAsync<List<Device>>("Devices");
            }
        }

        /// <summary>
        /// Adds a new Device
        /// </summary>
        /// <param name="usernamePassword">The Username and Password</param>
        /// <param name="device">The device</param>
        /// <returns>The added Device</returns>
        public static async Task<Device> AddDeviceAsync(UserPassword usernamePassword, Device device)
        {
            if (device.Id != null && device.Id.CompareTo(new Guid()) != 0)
            {
                throw new ArgumentException("The Id must be empty to create a new Device");
            }

            if (device.DeviceEnergyType == MeterEnergyType.MeterTypeUnknown)
            {
                throw new ArgumentException("The MeterEnergyType cannot be unknown to create a new Device");
            }

            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.PostAddAsync<Device>("Devices", device);
            }
        }

        /// <summary>
        /// Updates a Device
        /// </summary>
        /// <param name="usernamePassword">The Username and Password</param>
        /// <param name="device">The device</param>
        /// <returns></returns>
        public static async Task<bool> UpdateDeviceAsync(UserPassword usernamePassword, Device device)
        {
            if (device.Id == null && device.Id.CompareTo(new Guid()) == 0)
            {
                throw new ArgumentException("The Id cannot be empty to update an existing Device");
            }

            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.PostAsync<Device>("Devices", device);
            }
        }

        /// <summary>
        /// Gets a Device by it's ID
        /// </summary>
        /// <param name="usernamePassword">The Username and Password</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns></returns>
        public static async Task<Device> GetDeviceAsync(UserPassword usernamePassword, Guid deviceId)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.GetAsync<Device>("Devices/" + deviceId);
            }
        }

        /// <summary>
        /// Gets a Device by it's Serial Number. The Serial is the part before the "-".
        /// </summary>
        /// <param name="usernamePassword">The Username and Password</param>
        /// <param name="serial">The Serial Number of the device</param>
        /// <returns></returns>
        public static async Task<Device> GetDeviceAsync(UserPassword usernamePassword, Int64 serial)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.GetAsync<Device>("DeviceBySerial", new Dictionary<string, object> {
                    { "serial", serial }
                });
            }
        }

        /// <summary>
        /// Gets all Devices for an Energy Type
        /// </summary>
        /// <param name="usernamePassword">The Username and Password</param>
        /// <param name="meterEnergyType">The MeterEnergyType by which to filter</param>
        /// <returns></returns>
        public static async Task<List<Device>> GetDevicesAsync(UserPassword usernamePassword, MeterEnergyType meterEnergyType)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.GetAsync<List<Device>>("DevicesByEnergy", new Dictionary<string, object> {
                    { "meterEnergyType", Enum.GetName(typeof(MeterEnergyType), meterEnergyType) }
                });
            }
        }

        /// <summary>
        /// Gets all Devices by it's Sub Type (e.g. E-Charging Station)
        /// </summary>
        /// <param name="usernamePassword">The Username and Password</param>
        /// <param name="meterSubType">The MeterSubType by which to filter</param>
        /// <returns></returns>
        public static async Task<List<Device>> GetDevicesAsync(UserPassword usernamePassword, MeterSubType meterSubType)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.GetAsync<List<Device>>("DevicesBySubType", new Dictionary<string, object> {
                    { "meterSubType", Enum.GetName(typeof(MeterSubType), meterSubType) }
                });
            }
        }

        /// <summary>
        /// Gets the additional information (e.g. Firmware Version) about a device.
        /// </summary>
        /// <param name="usernamePassword">The Username and Password</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns></returns>
        public static async Task<AdditionalDeviceInformation> GetAdditionalDeviceInformationAsync(UserPassword usernamePassword, Guid deviceId)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.GetAsync<AdditionalDeviceInformation>("AdditionalDeviceInformation/" + deviceId);
            }
        }

        /// <summary>
        /// Gets the configuration of a smart-me device.
        /// </summary>
        /// <param name="usernamePassword">The Username and Password</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns></returns>
        public static async Task<SmartMeDeviceConfiguration> GetSmartMeDeviceConfigurationAsync(UserPassword usernamePassword, Guid deviceId)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.GetAsync<SmartMeDeviceConfiguration>("SmartMeDeviceConfiguration/" + deviceId);
            }
        }

        /// <summary>
        /// Sets the configuration of a smart-me device. The device needs to be online.
        /// </summary>
        /// <param name="usernamePassword">The Username and Password</param>
        /// <param name="configuration">The smart-me device configuration</param>
        /// <returns></returns>
        public static async Task<bool> SetSmartMeDeviceConfigurationAsync(UserPassword usernamePassword, SmartMeDeviceConfiguration configuration)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.PostAsync<SmartMeDeviceConfiguration>("SmartMeDeviceConfiguration", configuration);
            }
        }

        /// <summary>
        /// Gets all Custom Devices
        /// </summary>
        /// <param name="usernamePassword">The Username and Password</param>
        /// <returns></returns>
        public static async Task<List<CustomDevice>> GetCustomDevicesAsync(UserPassword usernamePassword)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.GetAsync<List<CustomDevice>>("CustomDevice");
            }
        }

        /// <summary>
        /// Creates a new Custom Device.
        /// A Custom Device can be any device that like to add some measurement values to the smart-me Cloud. 
        /// Only use a custom device for all non meters. 
        /// </summary>
        /// <param name="usernamePassword">The Username and Password</param>
        /// <param name="customDevice">Custom Device object with all the data</param>
        /// <returns>The added CustomDevice</returns>
        public static async Task<CustomDevice> AddCustomDeviceAsync(UserPassword usernamePassword, CustomDevice customDevice)
        {            
            if(customDevice.Id != null && customDevice.Id.CompareTo(new Guid()) != 0)
            {
                throw new ArgumentException("The Id must be empty to create a new Custom Device");
            }

            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.PostAddAsync<CustomDevice>("CustomDevice", customDevice);
            }
        }

        /// <summary>
        /// Update an existing Custom Device.
        /// </summary>
        /// <param name="usernamePassword">The Username and Password</param>
        /// <param name="customDevice">Custom Device object with all the data</param>
        /// <returns></returns>
        public static async Task<bool> UpdateCustomDeviceAsync(UserPassword usernamePassword, CustomDevice customDevice)
        {
            if (customDevice.Id == null && customDevice.Id.CompareTo(new Guid()) == 0)
            {
                throw new ArgumentException("The Id cannot be empty to update an existing Custom Device");
            }

            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.PostAsync<CustomDevice>("CustomDevice", customDevice);
            }
        }

        /// <summary>
        /// Gets a Custom Device by it's ID
        /// </summary>
        /// <param name="usernamePassword">The Username and Password</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns></returns>
        public static async Task<CustomDevice> GetCustomDeviceAsync(UserPassword usernamePassword, Guid deviceId)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.GetAsync<CustomDevice>("CustomDevice/" + deviceId);
            }
        }
    }
}
