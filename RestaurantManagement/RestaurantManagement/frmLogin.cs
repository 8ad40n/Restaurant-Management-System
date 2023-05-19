using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Web.Security;

namespace RestaurantManagement
{
    public partial class frmLogin : Form
    {

        private frmSignUp F3 { get; set; }
        private frmSplashScreen F1 { get; set; }
        private frmForgotPasswordSetPassword F2 { get; set; }
        
        public frmLogin()
        {
            InitializeComponent();
            //this.txtPassword.UseSystemPasswordChar = true;
        }

        public frmLogin(frmSplashScreen f1)
        {
            InitializeComponent();
            this.F1 = f1;
        }

        public frmLogin(frmForgotPasswordSetPassword f2)
        {
            InitializeComponent();
            this.F2 = f2;
        }

        public frmLogin(frmSignUp f3)
        {
            InitializeComponent();
            this.F3 = f3;
        }



        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtUsername.Clear();
            this.txtPassword.Clear();
        }

        private void cbShow_CheckedChanged(object sender, EventArgs e)
        {
            if(cbShow.Checked)
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
            try
            {
                string sql = "SELECT * FROM LoginInfo WHERE Username='" + this.txtUsername.Text + "' and Password='" + this.txtPassword.Text + "';";



                DataAccess d = new DataAccess();
                d.ExecuteQueryTable(sql);


                if (d.Ds.Tables[0].Rows.Count == 1)
                {
                    MessageBox.Show("Successful Login.\nWelcome, " + txtUsername.Text);

                    string sqlDashboard = "select * from UserInfo where Role ='Admin' and Username='" + txtUsername.Text + "';";
                    d.ExecuteQueryTable(sqlDashboard);



                    if (d.Ds.Tables[0].Rows.Count == 1)
                    {
                        frmAdminDashboard admin = new frmAdminDashboard(this);
                        admin.Show();
                        this.Hide();
                    }

                    string sqlDashboard2 = "select * from UserInfo where Role ='Staff' and Username='" + txtUsername.Text + "';";
                    d.ExecuteQueryTable(sqlDashboard2);



                    if (d.Ds.Tables[0].Rows.Count == 1)
                    {
                        frmStaffDashboard emp = new frmStaffDashboard(this);
                        emp.Show();
                        this.Hide();
                    }

                    string sqlDashboard3 = "select * from UserInfo where Role ='Manager' and Username='" + txtUsername.Text + "';";
                    d.ExecuteQueryTable(sqlDashboard3);

                    if (d.Ds.Tables[0].Rows.Count == 1)
                    {
                        frmManagerDashboard man = new frmManagerDashboard(this);
                        man.Show();
                        this.Hide();
                    }
                    this.txtUsername.Clear();
                    this.txtPassword.Clear();
                }
                else
                {
                    MessageBox.Show("Invalid Login.\nPlease Try Again");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            

        }

        private void lblDonotHaveAccount_Click(object sender, EventArgs e)
        {

        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            frmForgotPasswordVarify f = new frmForgotPasswordVarify(this);
            f.Show();
            this.Hide();

        }

        private void lblSignUpNow_Click(object sender, EventArgs e)
        {
            frmAdminLoginForSignUp f = new frmAdminLoginForSignUp(this);
            f.Show();
            this.Hide();
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
