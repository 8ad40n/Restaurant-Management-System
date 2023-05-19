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
    public partial class frmSplashScreen : Form
    {
        public frmSplashScreen()
        {
            InitializeComponent();
        }

        private void lblSpashScreen_Click(object sender, EventArgs e)
        {
            
        }

        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
            lblSpashScreen.Parent = pbSplashScreen;
            lblSpashScreen.BackColor = Color.Transparent;

            lblLoading.Parent = pbSplashScreen;
            lblLoading.BackColor = Color.Transparent;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;
            if(panel2.Width >= 632)
            {
                timer1.Stop();

                frmLogin f= new frmLogin(this);

                f.Visible= true;
                this.Hide();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
