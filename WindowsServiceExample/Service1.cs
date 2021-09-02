using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsServiceExample
{
    public partial class ServiceTestName : ServiceBase
    {

        MyTimer myTimer = new MyTimer();
        public ServiceTestName()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            myTimer.Start();
        } 

        protected override void OnStop()
        {
            myTimer.Stop();
        }

        
    }
}
