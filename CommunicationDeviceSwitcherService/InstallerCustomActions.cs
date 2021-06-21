using System;
using System.Collections.Specialized;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;

namespace CommunicationDeviceSwitcherService
{
    public partial class InstallerCustomActions
    {
        const string ServiceName = "CommunicationDeviceSwitcherService";
        const string ServiceName2 = "CommunicationAudioAutoSwitchService";
        public void Install()
        {
            UninstallService(ServiceName);
            UninstallService(ServiceName2);
            InstallService(ServiceName);
            using (var sc = new ServiceController(nameof(CommunicationDeviceSwitcherService)))
            {
                sc.Start();
            }
        }

        private void InstallService(string serviceName)
        {
            try
            {
                var company = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCompanyAttribute), false)).Company;
                var applicationFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), company, Assembly.GetExecutingAssembly().GetName().Name);

                var serviceInstaller = new ServiceInstaller();                

                serviceInstaller.Context = new InstallContext(applicationFolder, null);
                serviceInstaller.ServiceName = serviceName;
                serviceInstaller.StartType = ServiceStartMode.Automatic;
                var state = new ListDictionary();
                serviceInstaller.Install(state);
            }
            catch (Exception ex)
            {
                File.AppendAllText("C:\\Users\\Barsik\\Desktop\\logs.txt", ex.ToString() + "\n\r");

            }
        }

        public void OnBeforeInstall()
        {
            UninstallService(ServiceName);
        }

        public void OnBeforeUninstall()
        {
            using (var sc = new ServiceController(nameof(CommunicationDeviceSwitcherService)))
            {
                sc.Stop();
            }
            UninstallService(ServiceName);
        }

        private void UninstallService(string serviceName)
        {
            try
            {
                var company = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCompanyAttribute), false)).Company;
                var applicationFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), company, Assembly.GetExecutingAssembly().GetName().Name);

                var serviceInstaller = new ServiceInstaller();
                var service = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName.Equals(serviceName, StringComparison.OrdinalIgnoreCase));

                if (service != null)
                {
                    service.Stop();
                }

                serviceInstaller.Context = new InstallContext(applicationFolder, null);
                serviceInstaller.ServiceName = serviceName;
                serviceInstaller.Uninstall(null);
            }
            catch (Exception ex)
            {
                File.AppendAllText("C:\\Users\\Barsik\\Desktop\\logs.txt", ex.ToString() + "\n\r");
                
            }
        }
    }
}
