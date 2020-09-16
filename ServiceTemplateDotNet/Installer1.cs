using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace ServiceTemplateDotNet
{
    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        private ServiceInstaller serviceInstaller;
        private ServiceProcessInstaller serviceProcessInstaller;

        public Installer1()
        {
            InitializeComponent();

            serviceInstaller = new ServiceInstaller();
            serviceInstaller.Description = "Does amazing things!";
            serviceInstaller.DisplayName = "New Service Display Name";
            serviceInstaller.ServiceName = "New Service Service Name";
            serviceInstaller.StartType = ServiceStartMode.Manual;

            serviceProcessInstaller = new ServiceProcessInstaller();
            serviceProcessInstaller.Password = null;
            serviceProcessInstaller.Username = null;

            Installers.AddRange(new Installer[]
            {
                serviceProcessInstaller,
                serviceInstaller
            });

        }
    }
}
