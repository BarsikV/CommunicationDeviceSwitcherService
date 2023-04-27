using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CliWrap;

namespace CommunicationDeviceSwitcherService
{
    internal class InstallationManager
    {
        private const string ServiceName = "CommunicationDeviceSwitcherService";
        private const string ServiceName2 = "CommunicationAudioAutoSwitchService";
        private const string Install = "/Install";
        private const string Uninstall = "/Uninstall";

        public static async Task HandleInstallationHooks(string hookName)
        {
            var executablePath =
                Path.Combine(AppContext.BaseDirectory, $"{ServiceName}.exe");

            switch (hookName)
            {
                case Install:
                {
                    await DeleteAll();
                    await WindowsServiceCommands.Create(ServiceName, executablePath);
                    await WindowsServiceCommands.Start(ServiceName);
                    break;
                }
                case Uninstall:
                {
                    await DeleteAll();
                    break;
                }
            }
        }

        private static async Task DeleteAll()
        {
            await WindowsServiceCommands.Stop(ServiceName);
            await WindowsServiceCommands.Stop(ServiceName2);
            await WindowsServiceCommands.Delete(ServiceName);
            await WindowsServiceCommands.Delete(ServiceName2);
        }
    }
}
