using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationDeviceSwitcherService.Netframework
{
    public partial class CommunicationDeviceSwitcherService : ServiceBase
    {
        public CommunicationDeviceSwitcherService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
