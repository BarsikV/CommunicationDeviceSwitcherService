using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;

namespace CommunicationDeviceSwitcherService
{
    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        const string ServiceName = nameof(CommunicationDeviceSwitcherService);
        public Installer()
        {
            InitializeComponent();
        }

        protected override void OnAfterInstall(IDictionary savedState)
        {
            using (var sc = new ServiceController(nameof(CommunicationDeviceSwitcherService)))
            {
                sc.Start();
            }
        }

        protected override void OnBeforeInstall(IDictionary savedState)
        {
            UninstallService();
        }

        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            using (var sc = new ServiceController(nameof(CommunicationDeviceSwitcherService)))
            {
                sc.Stop();
            }
            //UninstallService();
        }

        private void UninstallService()
        {
            var company = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCompanyAttribute), false)).Company;
            var applicationFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), company, Assembly.GetExecutingAssembly().GetName().Name);

            var serviceInstaller = new ServiceInstaller();
            var service = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName.Equals(ServiceName, StringComparison.OrdinalIgnoreCase));

            if (service != null)
            {
                service.Stop();
            }

            serviceInstaller.Context = new InstallContext(applicationFolder, null);
            serviceInstaller.ServiceName = ServiceName;
            serviceInstaller.Uninstall(null);
        }
    }
}
