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
    public partial class frmUcAdd : UserControl
    {

        private DataAccess Da { get; set; }
        public frmUcAdd()
        {
            InitializeComponent();

            this.Da = new DataAccess();



            this.PopulateGridView();
            this.AutoIdGenerate();

            
        }


        private void PopulateGridView(string sql = "select FoodDetails.FoodId,FoodDetails.FoodName,FoodPrices.Category,FoodPrices.Price from FoodDetails,FoodPrices where FoodDetails.FoodId = FoodPrices.FoodId;")
        {
            this.Da.ExecuteQueryTable(sql);

            //this.dgvAdd.AutoGenerateColumns = false;
            this.dgvAdd.DataSource = Da.Ds.Tables[0];
        }
        

        private void ClearContent()
        {
            this.txtFoodId.Clear();
            this.txtFoodName.Clear();
            this.txtPrice.Clear();
            this.cmbCategory.Text= null;
            

            this.txtSearch.Clear();
            

            this.dgvAdd.ClearSelection();
            this.AutoIdGenerate();
        }


        private void AutoIdGenerate()
        {
            var q = "select FoodId from FoodDetails order by FoodId desc;";
            var dt = this.Da.ExecuteQueryTable(q);
            var lastId = dt.Rows[0][0].ToString();
            string[] s = lastId.Split('-');
            int temp = Convert.ToInt32(s[1]);
            string newId = "f-" + (++temp).ToString("d2");
            //string newId = (++temp).ToString("d2");
            this.txtFoodId.Text = newId;
            //MessageBox.Show(newId);
        }



        private void btnShow_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();

        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtFoodId.Text) || String.IsNullOrEmpty(this.txtFoodName.Text) ||
                String.IsNullOrEmpty(this.txtPrice.Text) || String.IsNullOrEmpty(this.cmbCategory.Text))
            {
                MessageBox.Show("Fields are blank!");
            }

            else
            {
                try
                {

                    

                    string sqlSelect = "SELECT * FROM FoodDetails WHERE FoodId = '" + txtFoodId.Text + "'or FoodName='"+txtFoodName.Text+"';";

                Da.ExecuteQueryTable(sqlSelect);


                    if (Da.Ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Item already exists");
                    }


                    else
                    {

                        

                        string sql1 = "INSERT INTO FoodDetails (FoodId, FoodName) VALUES ('" + txtFoodId.Text + "', '" + txtFoodName.Text + "');";
                        string sql2 = "INSERT INTO FoodPrices (FoodId, Category, Price) VALUES ('" + txtFoodId.Text + "', '" + cmbCategory.Text + "', '" + txtPrice.Text + "');";

                        DialogResult d = MessageBox.Show("Are you sure want to add food?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (d == DialogResult.No)
                            return;


                        int a = Da.ExecuteDMLQuery(sql1);
                        int b = Da.ExecuteDMLQuery(sql2);



                        if (a > 0 && b > 0)
                        {
                            MessageBox.Show(txtFoodName.Text+" has been added successfully!");
                            this.PopulateGridView();
                            this.ClearContent();

                        }
                        else
                        {
                            MessageBox.Show("Failed to add");
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has occured!",ex.Message);
                }
            }

        }
            
    


        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearContent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = "select FoodDetails.FoodId,FoodDetails.FoodName,FoodPrices.Category,FoodPrices.Price from FoodDetails,FoodPrices where FoodDetails.FoodId=FoodPrices.FoodId and FoodDetails.FoodName like '"+ this.txtSearch.Text +"%';";
            this.PopulateGridView(sql);
        }

        private void dgvAdd_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmUcAdd_Load(object sender, EventArgs e)
        {
            dgvAdd.ClearSelection();

        }
    }
}
