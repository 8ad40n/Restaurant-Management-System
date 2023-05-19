using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagement
{
    public partial class frmManagerDashboard : Form
    {

        private frmLogin F1 { get; set; }
        public frmManagerDashboard()
        {
            InitializeComponent();
        }

        public frmManagerDashboard(frmLogin f1)
        {
            InitializeComponent();
            F1 = f1;
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();

        }
        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            frmUcSalesReport f = new frmUcSalesReport();
            addUserControl(f);

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            frmUcManagerHomecs f = new frmUcManagerHomecs();
            addUserControl(f);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            F1.Visible = true;
            this.Hide();

        }

        private void btnUpdateUserInfo_Click(object sender, EventArgs e)
        {
            frmUsersInfoManager f = new frmUsersInfoManager();
            addUserControl(f);
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
