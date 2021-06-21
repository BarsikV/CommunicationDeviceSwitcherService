using CommunicationDeviceSwitcherService.ApplicationServices.CoreAudioApi;
using CommunicationDeviceSwitcherService.ApplicationServices.CoreAudioApi.Interfaces;

namespace CommunicationDeviceSwitcherService.ApplicationServices
{
    public class CoreAudioApplicationService
    {
        public static void RegisterCallback(IMMNotificationClient notificationClient)
        {
            var devEnm = new MMDeviceEnumerator();
            devEnm.RegisterEndpointNotificationCallback(notificationClient);
        }
    }
}
