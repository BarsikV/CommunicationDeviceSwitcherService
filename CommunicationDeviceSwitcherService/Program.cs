using CommunicationDeviceSwitcherService.ApplicationServices;
using CommunicationDeviceSwitcherService.ApplicationServices.CoreAudioApi.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace CommunicationDeviceSwitcherService
{
    public class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length == 1)
            {
                var customActions = new InstallerCustomActions();
                switch (args[0])
                {
                    case "/Install":
                    {

                        try
                        {
                            customActions.Install();
                        }
                        catch (System.Exception ex)
                        {
                            File.AppendAllText($"C:\\Users\\Barsik\\Desktop\\logs.txt", ex.ToString() + "\n\r");
                            throw;
                        }
                        
                        return 0;
                    }                                        
                    case "/Uninstall":
                    {
                        customActions.OnBeforeUninstall();
                        return 0;
                    }
                    default:
                    {                        
                        return 1;
                    }
                        
                }
            }

            CreateHostBuilder(args).Build().Run();

            return 0;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddSingleton<IMMNotificationClient, DefaultCommunicateDeviceSwitchNotificationClient>();
                });
    }
}
