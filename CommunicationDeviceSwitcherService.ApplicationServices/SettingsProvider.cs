using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationDeviceSwitcherService.ApplicationServices
{
    public interface ISettingsProvider
    {
        bool SwitchInputDevice();
        bool SwitchOutputDevice();
    }
}
