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
    public partial class frmSignUp : Form
    {
        private frmAdminLoginForSignUp F1 { get; set; }

        public frmSignUp()
        {
            InitializeComponent();

            this.txtSetPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
        }

        public frmSignUp(frmAdminLoginForSignUp f1)
        {
            InitializeComponent();
            this.F1 = f1;

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
           

            try 
            {
                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtConfirmPassword.Text) || string.IsNullOrEmpty(txtFullName.Text) || string.IsNullOrEmpty(txtEmail.Text)
                    || string.IsNullOrEmpty(cbRole.Text) || string.IsNullOrEmpty(txtSetPassword.Text) || string.IsNullOrEmpty(txtConfirmPassword.Text)) 
                {
                    MessageBox.Show("Please fill in all required fields");
                }
                else
                {
                    DataAccess d = new DataAccess();

                    
                    string sqlSelect = "SELECT * FROM LoginInfo WHERE Username = '"+txtUsername.Text+"';";

                    d.ExecuteQueryTable(sqlSelect);


                    if (d.Ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Username already taken");
                    }

                    
                    else
                    {
                        if (txtSetPassword.Text == txtConfirmPassword.Text)
                        {

                            string sql = "INSERT INTO LoginInfo (Username, Password) VALUES ('" + txtUsername.Text + "', '" + txtConfirmPassword.Text + "');";
                            string sql2 = "INSERT INTO UserInfo (Username, FullName, DOB, Gender, Role, Email) VALUES ('" + txtUsername.Text + "', '" + txtFullName.Text + "', '" + dtpDOB.Value + "', '" + cbGender.Text + "', '" + cbRole.Text + "', '" + txtEmail.Text + "');";



                            int a = d.ExecuteDMLQuery(sql);
                            int b = d.ExecuteDMLQuery(sql2);



                            if (a > 0 && b > 0)
                            {
                                MessageBox.Show("User account created successfully");

                                frmLogin f = new frmLogin(this);
                                f.Visible = true;
                                this.Hide();

                            }
                            else
                            {
                                MessageBox.Show("Failed to create user account");
                            }
                        }

                        else if (txtSetPassword.Text != txtConfirmPassword.Text)
                        {
                            MessageBox.Show("Password not matched.");
                        }
                    }
                }

            }
            catch (Exception ex) 
            {
                MessageBox.Show("An error has occured: "+ex.Message);

            }



        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtFullName.Clear();
            this.txtConfirmPassword.Clear();
            this.txtEmail.Clear();
            this.txtSetPassword.Clear();
            this.txtUsername.Clear();
            this.cbGender.Text=null;
            this.cbRole.Text=null;
            this.dtpDOB.Value = DateTime.Now;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            F1.Visible = true;
            this.Hide();
        }

        private void cbShow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShow.Checked)
            {
                this.txtSetPassword.PasswordChar = '\0';
                this.txtConfirmPassword.PasswordChar = '\0';

            }
            else
            {
                this.txtSetPassword.PasswordChar = '●';
                this.txtConfirmPassword.PasswordChar = '●';

            }
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
