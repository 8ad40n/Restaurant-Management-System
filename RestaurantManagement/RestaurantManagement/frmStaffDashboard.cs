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
    public partial class frmStaffDashboard : Form
    {
        private frmLogin F1 { get; set; }
        public frmStaffDashboard()
        {
            InitializeComponent();
        }

        public frmStaffDashboard(frmLogin f1)
        {
            InitializeComponent();
            this.F1 = f1;
            //this.Name = Name;


        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();

        }

        private void frmEmployeeDashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            frmUcPlaceOrder f = new frmUcPlaceOrder();
            addUserControl(f);

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //frmUcStaffHome f = new frmUcStaffHome(Name);
            //addUserControl(f);

            frmUcStaffHome f1 = new frmUcStaffHome();
            addUserControl(f1);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click_1(object sender, EventArgs e)
        {
            F1.Visible= true;
            this.Hide();
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
