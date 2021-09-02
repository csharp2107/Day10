using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServicesListApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GetAllServices()
        {
            lbServices.Items.Clear();
            foreach(var service in ServiceController.GetServices(".")) // . means Local machine
            {
                string serviceName = service.ServiceName;
                string serviceDisplayName = service.DisplayName;
                string serviceType = service.ServiceType.ToString();
                string status = service.Status.ToString();

                lbServices.Items.Add($"{serviceName} | {serviceDisplayName} | {serviceType} | {status}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAllServices();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageService(1);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageService(0);
        }

        private void ManageService(int operation)
        {
            String serviceName = lbServices.SelectedItem.ToString().Split('|')[0].Trim();
            ServiceController service = new ServiceController(serviceName);
            if (operation == 1)
            {
                service.Start();
                //service.WaitForStatus(ServiceControllerStatus.Running);

                try
                {
                    service.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 10));
                    MessageBox.Show("Running");
                } catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            else if (operation == 0)
            {
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped);
                MessageBox.Show("Stopped");
            }
            else
            {
                MessageBox.Show("Incorrect operation");
            }

            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAllServices();
        }
    }
}
