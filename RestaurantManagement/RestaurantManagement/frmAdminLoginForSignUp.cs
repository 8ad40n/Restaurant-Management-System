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
    public partial class frmAdminLoginForSignUp : Form
    {

        private frmLogin F1 { get; set; }
        public frmAdminLoginForSignUp()
        {
            InitializeComponent();
            this.txtPassword.UseSystemPasswordChar = true;


        }

        public frmAdminLoginForSignUp(frmLogin f1)
        {
            InitializeComponent();

            F1= f1;

           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtUsername.Clear();
            this.txtPassword.Clear();
        }

        private void cbShow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShow.Checked)
            {
                this.txtPassword.PasswordChar = '\0';
            }
            else
            {
                this.txtPassword.PasswordChar = '●';
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM LoginInfo WHERE Username='" + this.txtUsername.Text + "' and Password='" + this.txtPassword.Text + "';";



            DataAccess d = new DataAccess();
            d.ExecuteQueryTable(sql);


            if (d.Ds.Tables[0].Rows.Count == 1)
            {
                MessageBox.Show("Valid Login");

                string sqlDashboard = "select * from UserInfo where Role ='Admin' and Username='" + txtUsername.Text + "';";
                d.ExecuteQueryTable(sqlDashboard);



                if (d.Ds.Tables[0].Rows.Count == 1)
                {
                    frmSignUp admin = new frmSignUp(this);
                    admin.Show();
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("Invalid Login.\nPlease Try Again");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
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
