using System.Text.Json.Nodes;

namespace CommunicationDeviceSwitcherService.Installer.Callback
{
    internal class AppSettingsReadWriteService
    {
        private const string AppsettingsJson = "appsettings.json";
        private const string PropertyName = "AppSettings";
        private const string SwitchInputDevice = "SwitchInputDevice";
        private const string SwitchOutputDevice = "SwitchOutputDevice";

        public static async Task UpdateAppsettingsJson(Dictionary<string, string?> setupParameters)
        {
            var appsettingsFilePath = GetAppsettingsFilePath();
            var appSettingsFileRootNode = await GetAppsettingsFileRootNode(appsettingsFilePath);

            var settingsNode = appSettingsFileRootNode?[PropertyName];

            if (appSettingsFileRootNode == null || settingsNode == null)
            {
                return;
            }

            settingsNode[SwitchInputDevice] = CallbackParametersReader.GetBool(setupParameters[SwitchInputDevice]);
            settingsNode[SwitchOutputDevice] = CallbackParametersReader.GetBool(setupParameters[SwitchOutputDevice]);

            await SaveAppSettingsToFile(appsettingsFilePath, appSettingsFileRootNode);
        }

        private static async Task<JsonNode?> GetAppsettingsFileRootNode(string appsettingsFilePath)
        {
            var json = await File.ReadAllTextAsync(appsettingsFilePath);
            var jsonNode = JsonNode.Parse(json);
            return jsonNode;
        }

        private static async Task SaveAppSettingsToFile(string appsettingsFilePath, JsonNode appSettingsFileRootNode)
        {
            var json = appSettingsFileRootNode.ToString();
            await File.WriteAllTextAsync(appsettingsFilePath, json);
        }

        private static string GetAppsettingsFilePath()
        {
            return Path.Combine(AppContext.BaseDirectory, AppsettingsJson);
        }
    }
}
