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

using SmartMeApiClient.Containers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
        /// <returns></returns>
        public static async Task<List<Device>> GetDevicesAsync(UserPassword usernamePassword)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.GetAsync<List<Device>>("Devices");
            }
        }

        /// <summary>
        /// Gets all Devices
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <returns></returns>
        public static async Task<List<Device>> GetDevicesAsync(string accessToken)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<List<Device>>("Devices");
            }
        }

        /// <summary>
        /// Gets all Devices
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns></returns>
        public static async Task<IActionResult> GetDevicesAsync(string accessToken, ResultHandler<List<Device>> resultHandler)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<List<Device>>("Devices", resultHandler);
            }
        }

        /// <summary>
        /// Adds a new Device
        /// </summary>
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
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
        /// Adds a new Device
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="device">The device</param>
        /// <returns>The added Device</returns>
        public static async Task<Device> AddDeviceAsync(string accessToken, Device device)
        {
            if (device.Id != null && device.Id.CompareTo(new Guid()) != 0)
            {
                throw new ArgumentException("The Id must be empty to create a new Device");
            }

            if (device.DeviceEnergyType == MeterEnergyType.MeterTypeUnknown)
            {
                throw new ArgumentException("The MeterEnergyType cannot be unknown to create a new Device");
            }

            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.PostAddAsync<Device>("Devices", device);
            }
        }

        /// <summary>
        /// Adds a new Device
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="device">The device</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns></returns>
        public static async Task<IActionResult> AddDeviceAsync(
            string accessToken, 
            Device device, 
            ResultHandler<Device> resultHandler)
        {
            if (device.Id != null && device.Id.CompareTo(new Guid()) != 0)
            {
                resultHandler.OnError?.Invoke(ErrorType.InvalidArgument, "The Id must be empty to create a new Device");                
            }

            if (device.DeviceEnergyType == MeterEnergyType.MeterTypeUnknown)
            {
                resultHandler.OnError?.Invoke(ErrorType.InvalidArgument, "The MeterEnergyType cannot be unknown to create a new Device");
            }

            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.PostAddAsync<Device>("Devices", device, resultHandler);
            }
        }

        /// <summary>
        /// Updates a Device
        /// </summary>
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
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
        /// Updates a Device
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="device">The device</param>
        /// <returns></returns>
        public static async Task<bool> UpdateDeviceAsync(string accessToken, Device device)
        {
            if (device.Id == null && device.Id.CompareTo(new Guid()) == 0)
            {
                throw new ArgumentException("The Id cannot be empty to update an existing Device");
            }

            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.PostAsync<Device>("Devices", device);
            }
        }

        /// <summary>
        /// Updates a Device
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="device">The device</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns></returns>
        public static async Task<IActionResult> UpdateDeviceAsync(
            string accessToken, 
            Device device, 
            ResultHandler<Device> resultHandler)
        {
            if (device.Id == null && device.Id.CompareTo(new Guid()) == 0)
            {
                throw new ArgumentException("The Id cannot be empty to update an existing Device");
            }

            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.PostAsync<Device>("Devices", device, resultHandler);
            }
        }

        /// <summary>
        /// Gets a Device by it's ID
        /// </summary>
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
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
        /// Gets a Device by it's ID
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns></returns>
        public static async Task<Device> GetDeviceAsync(string accessToken, Guid deviceId)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<Device>("Devices/" + deviceId);
            }
        }

        /// <summary>
        /// Gets a Device by it's ID
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns></returns>
        public static async Task<IActionResult> GetDeviceAsync(
            string accessToken, 
            Guid deviceId, 
            ResultHandler<Device> resultHandler)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<Device>("Devices/" + deviceId, resultHandler);
            }
        }

        /// <summary>
        /// Gets a Device by it's Serial Number. The Serial is the part before the "-".
        /// </summary>
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
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
        /// Gets a Device by it's Serial Number. The Serial is the part before the "-".
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="serial">The Serial Number of the device</param>
        /// <returns></returns>
        public static async Task<Device> GetDeviceAsync(string accessToken, Int64 serial)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<Device>("DeviceBySerial", new Dictionary<string, object> {
                    { "serial", serial }
                });
            }
        }

        /// <summary>
        /// Gets a Device by it's Serial Number. The Serial is the part before the "-".
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="serial">The Serial Number of the device</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns></returns>
        public static async Task<IActionResult> GetDeviceAsync(
            string accessToken, 
            Int64 serial, 
            ResultHandler<Device> resultHandler)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<Device>(
                    "DeviceBySerial", 
                    new Dictionary<string, object> { { "serial", serial } },
                    resultHandler
                );
            }
        }

        /// <summary>
        /// Gets all Devices for an Energy Type
        /// </summary>
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
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
        /// Gets all Devices for an Energy Type
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="meterEnergyType">The MeterEnergyType by which to filter</param>
        /// <returns></returns>
        public static async Task<List<Device>> GetDevicesAsync(string accessToken, MeterEnergyType meterEnergyType)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<List<Device>>("DevicesByEnergy", new Dictionary<string, object> {
                    { "meterEnergyType", Enum.GetName(typeof(MeterEnergyType), meterEnergyType) }
                });
            }
        }

        /// <summary>
        /// Gets all Devices for an Energy Type
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="meterEnergyType">The MeterEnergyType by which to filter</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns></returns>
        public static async Task<IActionResult> GetDevicesAsync(
            string accessToken, 
            MeterEnergyType meterEnergyType, 
            ResultHandler<List<Device>> resultHandler)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<List<Device>>(
                    "DevicesByEnergy", 
                    new Dictionary<string, object> {
                        { "meterEnergyType", Enum.GetName(typeof(MeterEnergyType), meterEnergyType) }
                    },
                    resultHandler
                );
            }
        }

        /// <summary>
        /// Gets all Devices by it's Sub Type (e.g. E-Charging Station)
        /// </summary>
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
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
        /// Gets all Devices by it's Sub Type (e.g. E-Charging Station)
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="meterSubType">The MeterSubType by which to filter</param>
        /// <returns></returns>
        public static async Task<List<Device>> GetDevicesAsync(string accessToken, MeterSubType meterSubType)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<List<Device>>("DevicesBySubType", new Dictionary<string, object> {
                    { "meterSubType", Enum.GetName(typeof(MeterSubType), meterSubType) }
                });
            }
        }

        /// <summary>
        /// Gets all Devices by it's Sub Type (e.g. E-Charging Station)
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="meterSubType">The MeterSubType by which to filter</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns></returns>
        public static async Task<IActionResult> GetDevicesAsync(
            string accessToken, 
            MeterSubType meterSubType, 
            ResultHandler<List<Device>> resultHandler)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<List<Device>>(
                    "DevicesBySubType", 
                    new Dictionary<string, object> {
                        { "meterSubType", Enum.GetName(typeof(MeterSubType), meterSubType) }
                    },
                    resultHandler
                );
            }
        }

        /// <summary>
        /// Gets the additional information (e.g. Firmware Version) about a device.
        /// </summary>
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
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
        /// Gets the additional information (e.g. Firmware Version) about a device.
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns></returns>
        public static async Task<AdditionalDeviceInformation> GetAdditionalDeviceInformationAsync(string accessToken, Guid deviceId)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<AdditionalDeviceInformation>("AdditionalDeviceInformation/" + deviceId);
            }
        }

        /// <summary>
        /// Gets the additional information (e.g. Firmware Version) about a device.
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns></returns>
        public static async Task<IActionResult> GetAdditionalDeviceInformationAsync(
            string accessToken, 
            Guid deviceId, 
            ResultHandler<AdditionalDeviceInformation> resultHandler)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<AdditionalDeviceInformation>("AdditionalDeviceInformation/" + deviceId, resultHandler);
            }
        }

        /// <summary>
        /// Gets the configuration of a smart-me device.
        /// </summary>
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
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
        /// Gets the configuration of a smart-me device.
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns></returns>
        public static async Task<SmartMeDeviceConfiguration> GetSmartMeDeviceConfigurationAsync(string accessToken, Guid deviceId)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<SmartMeDeviceConfiguration>("SmartMeDeviceConfiguration/" + deviceId);
            }
        }

        /// <summary>
        /// Gets the configuration of a smart-me device.
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns></returns>
        public static async Task<IActionResult> GetSmartMeDeviceConfigurationAsync(
            string accessToken, 
            Guid deviceId, 
            ResultHandler<SmartMeDeviceConfiguration> resultHandler)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<SmartMeDeviceConfiguration>("SmartMeDeviceConfiguration/" + deviceId, resultHandler);
            }
        }

        /// <summary>
        /// Sets the configuration of a smart-me device. The device needs to be online.
        /// </summary>
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
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
        /// Sets the configuration of a smart-me device. The device needs to be online.
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="configuration">The smart-me device configuration</param>
        /// <returns></returns>
        public static async Task<bool> SetSmartMeDeviceConfigurationAsync(string accessToken, SmartMeDeviceConfiguration configuration)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.PostAsync<SmartMeDeviceConfiguration>("SmartMeDeviceConfiguration", configuration);
            }
        }

        /// <summary>
        /// Sets the configuration of a smart-me device. The device needs to be online.
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="configuration">The smart-me device configuration</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns></returns>
        public static async Task<IActionResult> SetSmartMeDeviceConfigurationAsync(
            string accessToken, 
            SmartMeDeviceConfiguration configuration, 
            ResultHandler<SmartMeDeviceConfiguration> resultHandler)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.PostAsync<SmartMeDeviceConfiguration>("SmartMeDeviceConfiguration", configuration, resultHandler);
            }
        }

        /// <summary>
        /// Gets all Custom Devices
        /// </summary>
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
        /// <returns></returns>
        public static async Task<List<CustomDevice>> GetCustomDevicesAsync(UserPassword usernamePassword)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.GetAsync<List<CustomDevice>>("CustomDevice");
            }
        }

        /// <summary>
        /// Gets all Custom Devices
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <returns></returns>
        public static async Task<List<CustomDevice>> GetCustomDevicesAsync(string accessToken)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<List<CustomDevice>>("CustomDevice");
            }
        }

        /// <summary>
        /// Gets all Custom Devices
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns></returns>
        public static async Task<IActionResult> GetCustomDevicesAsync(string accessToken, ResultHandler<List<CustomDevice>> resultHandler)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<List<CustomDevice>>("CustomDevice", resultHandler);
            }
        }

        /// <summary>
        /// Creates a new Custom Device.
        /// A Custom Device can be any device that like to add some measurement values to the smart-me Cloud. 
        /// Only use a custom device for all non meters. 
        /// </summary>
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
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
        /// Creates a new Custom Device.
        /// A Custom Device can be any device that like to add some measurement values to the smart-me Cloud. 
        /// Only use a custom device for all non meters. 
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="customDevice">Custom Device object with all the data</param>
        /// <returns>The added CustomDevice</returns>
        public static async Task<CustomDevice> AddCustomDeviceAsync(string accessToken, CustomDevice customDevice)
        {
            if (customDevice.Id != null && customDevice.Id.CompareTo(new Guid()) != 0)
            {
                throw new ArgumentException("The Id must be empty to create a new Custom Device");
            }

            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.PostAddAsync<CustomDevice>("CustomDevice", customDevice);
            }
        }

        /// <summary>
        /// Creates a new Custom Device.
        /// A Custom Device can be any device that like to add some measurement values to the smart-me Cloud. 
        /// Only use a custom device for all non meters. 
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="customDevice">Custom Device object with all the data</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns>The added CustomDevice</returns>
        public static async Task<IActionResult> AddCustomDeviceAsync(
            string accessToken, 
            CustomDevice customDevice, 
            ResultHandler<CustomDevice> resultHandler)
        {
            if (customDevice.Id != null && customDevice.Id.CompareTo(new Guid()) != 0)
            {
                throw new ArgumentException("The Id must be empty to create a new Custom Device");
            }

            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.PostAddAsync<CustomDevice>("CustomDevice", customDevice, resultHandler);
            }
        }

        /// <summary>
        /// Update an existing Custom Device.
        /// </summary>
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
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
        /// Update an existing Custom Device.
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="customDevice">Custom Device object with all the data</param>
        /// <returns></returns>
        public static async Task<bool> UpdateCustomDeviceAsync(string accessToken, CustomDevice customDevice)
        {
            if (customDevice.Id == null && customDevice.Id.CompareTo(new Guid()) == 0)
            {
                throw new ArgumentException("The Id cannot be empty to update an existing Custom Device");
            }

            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.PostAsync<CustomDevice>("CustomDevice", customDevice);
            }
        }

        /// <summary>
        /// Update an existing Custom Device.
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="customDevice">Custom Device object with all the data</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns></returns>
        public static async Task<IActionResult> UpdateCustomDeviceAsync(
            string accessToken, 
            CustomDevice customDevice, 
            ResultHandler<CustomDevice> resultHandler)
        {
            if (customDevice.Id == null && customDevice.Id.CompareTo(new Guid()) == 0)
            {
                throw new ArgumentException("The Id cannot be empty to update an existing Custom Device");
            }

            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.PostAsync<CustomDevice>("CustomDevice", customDevice, resultHandler);
            }
        }

        /// <summary>
        /// Gets a Custom Device by it's ID
        /// </summary>
        /// <param name="usernamePassword">The Username and Password for Basic Authentication</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns></returns>
        public static async Task<CustomDevice> GetCustomDeviceAsync(UserPassword usernamePassword, Guid deviceId)
        {
            using (var restApi = new SmartMeApiClient(usernamePassword))
            {
                return await restApi.GetAsync<CustomDevice>("CustomDevice/" + deviceId);
            }
        }

        /// <summary>
        /// Gets a Custom Device by it's ID
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns></returns>
        public static async Task<CustomDevice> GetCustomDeviceAsync(string accessToken, Guid deviceId)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<CustomDevice>("CustomDevice/" + deviceId);
            }
        }

        /// <summary>
        /// Gets a Custom Device by it's ID
        /// </summary>
        /// <param name="accessToken">The OAuth2 access token</param>
        /// <param name="deviceId">The ID of the device</param>
        /// <param name="resultHandler">The result handler</param>
        /// <returns></returns>
        public static async Task<IActionResult> GetCustomDeviceAsync(
            string accessToken, 
            Guid deviceId, 
            ResultHandler<CustomDevice> resultHandler)
        {
            using (var restApi = new SmartMeApiClient(accessToken))
            {
                return await restApi.GetAsync<CustomDevice>("CustomDevice/" + deviceId, resultHandler);
            }
        }
    }
}
