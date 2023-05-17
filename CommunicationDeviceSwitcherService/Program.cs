using System;
using System.IO;
using CommunicationDeviceSwitcherService.ApplicationServices;
using CommunicationDeviceSwitcherService.ApplicationServices.CoreAudioApi.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CommunicationDeviceSwitcherService
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                await CreateHostBuilder(args).Build().RunAsync();
            }
            catch (Exception e)
            {
                await File.WriteAllTextAsync(Path.Combine(AppContext.BaseDirectory, "startup_error.txt"), e.ToString());
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddJsonFile("appsettings,json", true, true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    var config = hostContext.Configuration;
                    services.Configure<AppSettings>(config.GetSection("AppSettings"));
                    services.AddHostedService<Worker>();
                    services.AddSingleton<IMMNotificationClient, DefaultCommunicateDeviceSwitchNotificationClient>();
                    services.AddSingleton<ISettingsProvider, SettingsProvider>();
                });
    }
}
