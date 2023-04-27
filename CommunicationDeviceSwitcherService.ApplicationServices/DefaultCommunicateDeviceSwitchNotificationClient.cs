using CommunicationDeviceSwitcherService.ApplicationServices.CoreAudioApi;
using CommunicationDeviceSwitcherService.ApplicationServices.CoreAudioApi.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Options;

namespace CommunicationDeviceSwitcherService.ApplicationServices
{
    public class DefaultCommunicateDeviceSwitchNotificationClient : IMMNotificationClient
    {
        public DefaultCommunicateDeviceSwitchNotificationClient(ILogger<DefaultCommunicateDeviceSwitchNotificationClient> logger, ISettingsProvider settingsProvider)
        {
            _logger = logger;
            _settingsProvider = settingsProvider;
        }

        private static readonly PolicyConfigClient _policyConfig = new PolicyConfigClient();
        private readonly ILogger<DefaultCommunicateDeviceSwitchNotificationClient> _logger;
        private readonly ISettingsProvider _settingsProvider;

        public void OnDefaultDeviceChanged([MarshalAs(UnmanagedType.I4)] DataFlow dataFlow, [MarshalAs(UnmanagedType.I4)] Role deviceRole, [MarshalAs(UnmanagedType.LPWStr)] string defaultDeviceId)
        {
            try
            {
                var switchInputEnabled = _settingsProvider.IsSwitchInputDeviceEnabled();
                var switchOutputEnabled = _settingsProvider.IsSwitchOutputDeviceEnabled();

                if (switchOutputEnabled && dataFlow == DataFlow.Render && deviceRole == Role.Multimedia)
                {
                    _policyConfig.SetDefaultEndpoint(defaultDeviceId, Role.Communications);
                }
                else if (switchInputEnabled && dataFlow == DataFlow.Capture && deviceRole == Role.Multimedia)
                {
                    _policyConfig.SetDefaultEndpoint(defaultDeviceId, Role.Communications);
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
