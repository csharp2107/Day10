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
            foreach(var service in ServiceController.GetServices())
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
    }
}
