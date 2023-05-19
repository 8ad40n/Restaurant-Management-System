using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RestaurantManagement
{
    public partial class frmForgotPasswordVarify : Form
    {
        private frmLogin F1 { set; get; }
        
        int randomCode;
        public static string to;


        public string TxtEmail
        {
            get; set;
        }

        public frmForgotPasswordVarify()
        {
            InitializeComponent();
        }
        public frmForgotPasswordVarify(frmLogin f1)
        {
            InitializeComponent();

            this.F1 = f1;
        }


        private void btnSendCode_Click(object sender, EventArgs e)
        {

            string sql = "SELECT * FROM USERINFO WHERE Email='" + this.txtEmail.Text  + "';";

            DataAccess d = new DataAccess();

            d.ExecuteQueryTable(sql);


            if (d.Ds.Tables[0].Rows.Count == 1)
            {
                string to, from, pass;

                Random x = new Random();
                randomCode = x.Next(100000, 999999);


                MailMessage message = new MailMessage();

                to = txtEmail.Text;
                from = "restaurentmanagement@gmail.com";
                pass = "gqebtkdusbtscblo";

                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = "\nYour reset code is : " + randomCode.ToString() + ".";
                message.Subject = "Password Reseting Code.";
                message.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);

                try
                {
                    smtp.Send(message);
                    MessageBox.Show("        Code send successfully.\n        Please check your mail!         ");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has occured: " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Email not found");
            }
            

           
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (randomCode.ToString() == txtCode.Text.ToString())
            {
                string email = txtEmail.Text;

                frmForgotPasswordSetPassword obj = new frmForgotPasswordSetPassword(email,this);
                obj.Visible= true;
                this.Hide();
            }
            else
            {
                MessageBox.Show("       Wrong Code.                  ");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.F1.Visible= true;
            this.Hide();
        }

        private void frmForgotPasswordVarify_Load(object sender, EventArgs e)
        {

        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
