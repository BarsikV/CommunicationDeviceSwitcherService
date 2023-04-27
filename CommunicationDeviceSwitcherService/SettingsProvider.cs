using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunicationDeviceSwitcherService.ApplicationServices;
using Microsoft.Extensions.Options;

namespace CommunicationDeviceSwitcherService
{
    public class SettingsProvider : ISettingsProvider
    {
        private readonly IOptionsMonitor<AppSettings> _appSettingsMonitor;

        public SettingsProvider(IOptionsMonitor<AppSettings> appSettingsMonitor)
        {
            _appSettingsMonitor = appSettingsMonitor;
        }

        public bool IsSwitchInputDeviceEnabled()
        {
            return _appSettingsMonitor.CurrentValue.SwitchInputDevice ?? true;
        }

        public bool IsSwitchOutputDeviceEnabled()
        {
            return _appSettingsMonitor.CurrentValue.SwitchOutputDevice ?? true;
        }
    }
}
