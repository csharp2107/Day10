using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsServiceExample
{
    class MyTimer
    {
        Timer timer = new Timer();

        public void Start()
        {
            WriteLog("Starting service...." + DateTime.Now);
            timer.Interval = 5000;
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            WriteLog("Service alive..." + DateTime.Now);
        }

        private void WriteLog(string s)
        {
            File.AppendAllText("c:/tmp/service_log.txt", s + "\r\n");
        }

        public void Stop()
        {
            WriteLog("Stopping service..." + DateTime.Now);
        }
    }
}
