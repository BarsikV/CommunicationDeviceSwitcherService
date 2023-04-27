using CommunicationDeviceSwitcherService.ApplicationServices;

namespace CommunicationDeviceSwitcherService.Netframework
{
    internal class SettingsProvider : ISettingsProvider
    {
        public bool IsSwitchInputDeviceEnabled()
        {
            return true;
        }

        public bool IsSwitchOutputDeviceEnabled()
        {
            return true;
        }
    }
}
