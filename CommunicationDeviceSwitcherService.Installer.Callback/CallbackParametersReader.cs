namespace CommunicationDeviceSwitcherService.Installer.Callback
{
    internal class CallbackParametersReader
    {
        public static string? GetCallbackCommand(string[] args)
        {
            return args.ElementAtOrDefault(0);
        }

        public static Dictionary<string, string?> GetCallbackParameters(string[] args)
        {
            var setupParameters = args
                .Skip(1)
                .Select(a => a.Split('='))
                .ToDictionary(a => a[0], a => a.ElementAtOrDefault(1));
            return setupParameters;
        }


        public static bool GetBool(string? installArg)
        {
            return installArg is null or "1";
        }
    }
}
