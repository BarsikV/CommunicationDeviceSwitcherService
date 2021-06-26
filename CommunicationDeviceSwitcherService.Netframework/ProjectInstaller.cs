using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Windows.Forms;

namespace CommunicationDeviceSwitcherService.Netframework
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        const string ServiceName = "CommunicationDeviceSwitcherService";
        const string ServiceName2 = "CommunicationAudioAutoSwitchService";

        public ProjectInstaller()
        {
            InitializeComponent();
        }

        protected override void OnAfterInstall(IDictionary savedState)
        {
            try
            {
                using (var service = GetService(ServiceName))
                {
                    if (service != null)
                    {
                        service.Start();
                    }
                }
            }
            catch { }
        }

        protected override void OnBeforeInstall(IDictionary savedState)
        {            
            UninstallService(ServiceName);
            UninstallService(ServiceName2);
        }

        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            try
            {
                using (var service = GetService(ServiceName))
                {
                    if (service != null && service.Status == ServiceControllerStatus.Running)
                    {
                        service.Stop();
                    }
                }
            }
            catch { }            
        }

        private void UninstallService(string serviceName)
        {
            try
            {
                var company = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCompanyAttribute), false)).Company;
                var applicationFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), company, Assembly.GetExecutingAssembly().GetName().Name);

                var serviceInstaller = new ServiceInstaller();
                var service = GetService(serviceName);

                if (service != null)
                {
                    try
                    {
                        service.Stop();
                    }
                    catch
                    {

                    }

                    serviceInstaller.Context = new InstallContext(applicationFolder, null);
                    serviceInstaller.ServiceName = serviceName;
                    serviceInstaller.Uninstall(null);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private ServiceController GetService(string name)
        {
            return ServiceController.GetServices().FirstOrDefault(s => s.ServiceName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
