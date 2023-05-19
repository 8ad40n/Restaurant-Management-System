using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagement
{
    public partial class frmForgotPasswordSetPassword : Form
    {
        private string email;

        private frmForgotPasswordVarify F1 { get; set; }
        public frmForgotPasswordSetPassword()
        {
            InitializeComponent();
            this.txtNewPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
        }
        public frmForgotPasswordSetPassword(string email, frmForgotPasswordVarify f1)
        {
            InitializeComponent();

            this.email = email;
            this.F1 = f1;
            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text == txtConfirmPassword.Text)
            { 

                string sql = "UPDATE LoginInfo SET LoginInfo.Password ='"+this.txtConfirmPassword.Text+"' FROM LoginInfo INNER JOIN UserInfo ON LoginInfo.Username = UserInfo.Username WHERE UserInfo.Email = '"+ email +"';";


                DataAccess d = new DataAccess();

                d.ExecuteDMLQuery(sql);

                MessageBox.Show("Password updated successfully.");


                frmLogin f = new frmLogin(this);
                f.Visible= true;
                this.Hide();


            }
            else if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password Not Matched.");
            }

            


        }

        private void frmForgotPasswordSetPassword_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            F1.Visible= true;
            this.Hide();
        }

        private void cbShow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShow.Checked)
            {
                this.txtNewPassword.PasswordChar = '\0';
                this.txtConfirmPassword.PasswordChar = '\0';

            }
            else
            {
                this.txtNewPassword.PasswordChar = '●';
                this.txtConfirmPassword.PasswordChar = '●';

            }
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
