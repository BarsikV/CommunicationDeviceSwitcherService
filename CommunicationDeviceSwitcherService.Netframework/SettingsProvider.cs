using CommunicationDeviceSwitcherService.ApplicationServices;

namespace CommunicationDeviceSwitcherService.Netframework
{
    internal class SettingsProvider : ISettingsProvider
    {
        public bool SwitchInputDevice()
        {
            return true;
        }

        public bool SwitchOutputDevice()
        {
            return true;
        }
    }
}
