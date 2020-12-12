using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InPatientManagement
{
    public partial class frmScreen : Form
    {
        public frmScreen()
        {
            InitializeComponent();
        }

        private void btnDOCTOR_Click(object sender, EventArgs e)
        {
            global.category = "DOCTOR";
            HomeScreen hs = new HomeScreen();
            hs.ShowDialog();
        }

        private void btnNURSE_Click(object sender, EventArgs e)
        {
            global.category = "NURSE";
            HomeScreen hs = new HomeScreen();
            hs.ShowDialog();
        }
    }
}
