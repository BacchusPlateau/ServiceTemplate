using BusinessLogicCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTemplateDotNet
{
    public partial class Service1 : ServiceBase
    {
        private StartMeUp _startMeUp;
        public Service1()
        {
            InitializeComponent();
            ServiceName = "Amazing Service";
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            LoadConfigValues();
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            EventLog.WriteEntry("Unhandled Exception: " + ((Exception)e.ExceptionObject).ToString());
        }

        protected override void OnStart(string[] args)
        {
            _startMeUp = new StartMeUp();
            ExitCode = _startMeUp.Start();

            if (ExitCode != 0)
            {
                EventLog.WriteEntry("OnStart not completed.", EventLogEntryType.Warning);
                Stop();
                return;
            }

            EventLog.WriteEntry("OnStart completed.", EventLogEntryType.Information);
        }

        protected override void OnStop()
        {
            _startMeUp.Stop();

            EventLog.WriteEntry("OnStop completed.", EventLogEntryType.Information);
        }


        private void LoadConfigValues()
        {
            try
            {
                ConfigurationValues config = new ConfigurationValues();

                config.SomeConfigItem = 0;

                ApplicationConfiguration.Config = config;
            }
            catch (Exception ex)
            {
                this.EventLog.WriteEntry("LoadConfigValues - Exception: " + ex.ToString(), EventLogEntryType.Error);
            }
        }
    }
}
