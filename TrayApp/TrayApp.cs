using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrayApp
{
    public partial class TrayApp : Form
    {
        public TrayApp()
        {
            InitializeComponent();
        }
        List<int> prolist = new List<int>();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            searchProcess();
        }

        private void searchProcess()
        {
            prolist = new List<int>();
            processlist.Items.Clear();
            Process[] p = Process.GetProcesses();
            foreach (Process item in p)
            {
                processlist.Items.Add("Name: " + item.ProcessName + "   ID: " + item.Id);
                prolist.Add(item.Id);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            searchProcess();
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            if (processlist.SelectedIndices.Count > 0)
            {
                int id = prolist[processlist.SelectedIndex];
                Process.GetProcessById(id).Kill();
                searchProcess();
            }
        }
    }
}
