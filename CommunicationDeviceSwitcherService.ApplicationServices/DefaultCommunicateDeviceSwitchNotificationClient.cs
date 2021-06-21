using CommunicationDeviceSwitcherService.ApplicationServices.CoreAudioApi;
using CommunicationDeviceSwitcherService.ApplicationServices.CoreAudioApi.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.InteropServices;

namespace CommunicationDeviceSwitcherService.ApplicationServices
{
    public class DefaultCommunicateDeviceSwitchNotificationClient : IMMNotificationClient
    {
        public DefaultCommunicateDeviceSwitchNotificationClient(ILogger<DefaultCommunicateDeviceSwitchNotificationClient> logger)
        {
            _logger = logger;
        }

        private static readonly PolicyConfigClient _policyConfig = new PolicyConfigClient();
        private readonly ILogger<DefaultCommunicateDeviceSwitchNotificationClient> _logger;

        public void OnDefaultDeviceChanged([MarshalAs(UnmanagedType.I4)] DataFlow dataFlow, [MarshalAs(UnmanagedType.I4)] Role deviceRole, [MarshalAs(UnmanagedType.LPWStr)] string defaultDeviceId)
        {
            try
            {
                if (dataFlow == DataFlow.Render && deviceRole == Role.Multimedia)
                {
                    var deviceId = defaultDeviceId;
                    _policyConfig.SetDefaultEndpoint(deviceId, Role.Communications);
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }
        }

        public void OnDeviceAdded([MarshalAs(UnmanagedType.LPWStr)] string deviceId)
        {
            return;
        }

        public void OnDeviceRemoved([MarshalAs(UnmanagedType.LPWStr)] string deviceId)
        {
            return;
        }

        public void OnDeviceStateChanged([MarshalAs(UnmanagedType.LPWStr)] string deviceId, [MarshalAs(UnmanagedType.U4)] DeviceState newState)
        {
            return;
        }

        public void OnPropertyValueChanged([MarshalAs(UnmanagedType.LPWStr)] string deviceId, PROPERTYKEY propertyKey)
        {
            return;
        }
    }
}
