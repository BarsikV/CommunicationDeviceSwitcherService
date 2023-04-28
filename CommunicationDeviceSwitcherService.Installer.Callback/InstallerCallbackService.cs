namespace CommunicationDeviceSwitcherService.Installer.Callback
{
    internal class InstallerCallbackService
    {
        private const string ServiceName = "CommunicationDeviceSwitcherService";
        private const string ServiceName2 = "CommunicationAudioAutoSwitchService";
        private const string Install = "/Install";
        private const string Uninstall = "/Uninstall";

        public static bool IsInstallerCallback(string[] args)
        {
            return args is { Length: > 0 } &&
                (args[0] == Install ||
                 args[0] == Uninstall);
        }

        public static async Task HandleInstallerCallback(string[] args)
        {
            var setupCommand = CallbackParametersReader.GetCallbackCommand(args);
            var setupParameters = CallbackParametersReader.GetCallbackParameters(args);

            switch (setupCommand)
            {
                case Install:
                {
                    await UninstallService();
                    await InstallService(setupParameters);
                    break;
                }
                case Uninstall:
                {
                    await UninstallService();
                    break;
                }
            }
        }

        private static async Task InstallService(Dictionary<string, string?> setupParameters)
        {
            var executablePath = Path.Combine(AppContext.BaseDirectory, $"{ServiceName}.exe");

            await WindowsServiceCommands.Create(ServiceName, executablePath);

            await AppSettingsReadWriteService.UpdateAppsettingsJson(setupParameters);

            await WindowsServiceCommands.Start(ServiceName);
        }

        private static async Task UninstallService()
        {
            await WindowsServiceCommands.Stop(ServiceName);
            await WindowsServiceCommands.Stop(ServiceName2);
            await WindowsServiceCommands.Delete(ServiceName);
            await WindowsServiceCommands.Delete(ServiceName2);
        }
    }
}
