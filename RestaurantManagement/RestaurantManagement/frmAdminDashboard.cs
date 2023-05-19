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
    
    public partial class frmAdminDashboard : Form
    {

       
        bool sidebarExpand;

        private frmLogin F1 { get; set; }
        public frmAdminDashboard()
        {
            InitializeComponent();

            //frmUcHomeAdmin f = new frmUcHomeAdmin();
            //addUserControl(f);
        }

        public frmAdminDashboard(frmLogin f1)
        {
            InitializeComponent();
            F1 = f1;
            


            //frmUcHomeAdmin f = new frmUcHomeAdmin();
            //addUserControl(f);


        }

      

        private void addUserControl(UserControl userControl) 
        { 
            userControl.Dock= DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
            
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmUcAdd f= new frmUcAdd();
            addUserControl(f);
            //this.panelContainer.Controls.Add(f);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmUcUpdate f = new frmUcUpdate();
            addUserControl(f);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            frmUcDelete f = new frmUcDelete();
            addUserControl(f);
        }


        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUpdateUserInfo_Click(object sender, EventArgs e)
        {
            frmUcUpdateUsers f = new frmUcUpdateUsers();
            addUserControl(f);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //frmUcHomeAdmin f = new frmUcHomeAdmin(Name);
            //addUserControl(f);

            frmUcHomeAdmin f1 = new frmUcHomeAdmin();
            addUserControl(f1);



        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            F1.Visible = true;
            this.Hide();
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    
}
