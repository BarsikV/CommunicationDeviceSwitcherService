using CommunicationDeviceSwitcherService.ApplicationServices;
using CommunicationDeviceSwitcherService.ApplicationServices.CoreAudioApi.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.ServiceProcess;

namespace CommunicationDeviceSwitcherService.Netframework
{
    public partial class CommunicationDeviceSwitcherService : ServiceBase
    {
        private LoggerFactory _loggerFactory;
        private ILogger<CommunicationDeviceSwitcherService> _logger;
        private IMMNotificationClient _notificationClient;

        public CommunicationDeviceSwitcherService()
        {
            _loggerFactory = new LoggerFactory();
            _logger = _loggerFactory.CreateLogger<CommunicationDeviceSwitcherService>();
            var logger = _loggerFactory.CreateLogger<DefaultCommunicateDeviceSwitchNotificationClient>();
            _notificationClient = new DefaultCommunicateDeviceSwitchNotificationClient(logger);
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionLog;
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
            _logger.LogInformation("Service has started");            
            RegisterNotificationClient();
        }

        private void OnProcessExit(object sender, EventArgs e)
        {
            _logger?.LogInformation("Communication Auto Switcher has exited");
        }

        private void UnhandledExceptionLog(object sender, UnhandledExceptionEventArgs e)
        {
            _logger?.LogError(e.ToString());
        }

        private void RegisterNotificationClient()
        {
            CoreAudioApplicationService.RegisterCallback(_notificationClient);
        }

        protected override void OnStop()
        {
        }
    }
}
