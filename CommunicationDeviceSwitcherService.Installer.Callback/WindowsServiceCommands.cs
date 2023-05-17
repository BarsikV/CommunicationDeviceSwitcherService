using CliWrap;

namespace CommunicationDeviceSwitcherService.Installer.Callback
{
    internal class WindowsServiceCommands
    {
        private const string ServiceControlCommand = "sc";
        private const string CreateCommand = "create";
        private const string StopCommand = "stop";
        private const string StartCommand = "start";
        private const string DeleteCommand = "delete";


        public static async Task Create(string serviceName, string executablePath)
        {
            var res = await Cli.Wrap(ServiceControlCommand)
                .WithArguments(new[] { CreateCommand, serviceName, $"binPath={executablePath}", "start=auto" })
                .ExecuteAsync();
        }
        
        public static async Task Start(string serviceName)
        {
            var res = await Cli.Wrap(ServiceControlCommand)
                .WithArguments(new[] { StartCommand, serviceName })
                .WithValidation(CommandResultValidation.None)
                .ExecuteAsync();
        }

        public static async Task Stop(string serviceName)
        {
            var res = await Cli.Wrap(ServiceControlCommand)
                .WithArguments(new[] { StopCommand, serviceName })
                .WithValidation(CommandResultValidation.None)
                .ExecuteAsync();
        }

        public static async Task Delete(string serviceName)
        {
            var res = await Cli.Wrap(ServiceControlCommand)
                .WithArguments(new[] { DeleteCommand, serviceName })
                .WithValidation(CommandResultValidation.None)
                .ExecuteAsync();
        }
    }
}
