using CommunicationDeviceSwitcherService.ApplicationServices;
using CommunicationDeviceSwitcherService.ApplicationServices.CoreAudioApi.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CommunicationDeviceSwitcherService
{
    public class Worker : BackgroundService
    {
        private ILogger<Worker> _logger;
        private readonly IMMNotificationClient _notificationClient;

        public Worker(ILogger<Worker> logger, IMMNotificationClient notificationClient)
        {
            _logger = logger;
            _notificationClient = notificationClient;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            RegisterNotificationClient();
            return Task.FromResult(true);
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionLog;
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
            _logger.LogInformation("Service has started");
            return base.StartAsync(cancellationToken);
        }

        private void OnProcessExit(object sender, EventArgs e)
        {
            _logger?.LogInformation("Communication Auto Switcher has exited");            
        }

        private void UnhandledExceptionLog(object sender, UnhandledExceptionEventArgs e)
        {
            _logger?.LogError(e.ToString());
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Service has stopped");
            return base.StopAsync(cancellationToken);
        }

        private void RegisterNotificationClient()
        {
            CoreAudioApplicationService.RegisterCallback(_notificationClient);
        }
    }
}
