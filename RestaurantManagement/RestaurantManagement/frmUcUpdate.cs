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
    public partial class frmUcUpdate : UserControl
    {
        private DataAccess Da { get; set; }
        public frmUcUpdate()
        {
            InitializeComponent();

            this.Da = new DataAccess();

            this.PopulateGridView();
        }

        private void PopulateGridView(string sql = "select FoodDetails.FoodId,FoodDetails.FoodName,FoodPrices.Category,FoodPrices.Price from FoodDetails,FoodPrices where FoodDetails.FoodId = FoodPrices.FoodId;")
        {
            this.Da.ExecuteQueryTable(sql);

            //this.dgvAdd.AutoGenerateColumns = false;
            this.dgvUpdate.DataSource = Da.Ds.Tables[0];
        }


        private void ClearContent()
        {
            this.txtFoodId.Clear();
            this.txtFoodName.Clear();
            this.txtPrice.Clear();
            this.cmbCategory.Text = null;


            this.txtSearch.Clear();


            this.dgvUpdate.ClearSelection();
            //this.AutoIdGenerate();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearContent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = "select FoodDetails.FoodId,FoodDetails.FoodName,FoodPrices.Category,FoodPrices.Price from FoodDetails,FoodPrices where FoodDetails.FoodId=FoodPrices.FoodId and FoodDetails.FoodName like '" + this.txtSearch.Text + "%';";
            this.PopulateGridView(sql);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtFoodId.Text) || String.IsNullOrEmpty(this.txtFoodName.Text) ||
                String.IsNullOrEmpty(this.txtPrice.Text) || String.IsNullOrEmpty(this.cmbCategory.Text))
            {
                MessageBox.Show("Fields are blank!  Plaese select a Row first to Update");
            }

            else
            {
                if (this.dgvUpdate.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Plaese select a Row first to Update", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    var FoodId = this.dgvUpdate.CurrentRow.Cells[0].Value.ToString();
                    var FoodName = this.dgvUpdate.CurrentRow.Cells[1].Value.ToString();

                    DialogResult dr = MessageBox.Show("Are you sure you want to change?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.No)
                    {
                        //MessageBox.Show("No delete");
                        return;
                    }

                    var query = "BEGIN TRANSACTION; UPDATE FoodDetails SET FoodName = '"+txtFoodName.Text+"'WHERE FoodId='"+txtFoodId.Text+"';UPDATE FoodPrices SET Category = '"+cmbCategory.Text+"',Price = '"+txtPrice.Text+"'WHERE FoodId='"+txtFoodId.Text+"';COMMIT;";
                    var count = this.Da.ExecuteDMLQuery(query);

                   // if (count == 1)
                        MessageBox.Show(txtFoodName.Text+" has been updated!");
                   // else
                   //     MessageBox.Show("Data upgradation failed");

                    this.PopulateGridView();
                    this.ClearContent();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("An error has occured: " + exc.Message);
                }
            }
        }

        private void dgvUpdate_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUpdate.SelectedRows != null && dgvUpdate.SelectedRows.Count > 0)
            {
                string FoodId = dgvUpdate.CurrentRow.Cells[0].Value.ToString();
                string FoodName = dgvUpdate.CurrentRow.Cells[1].Value.ToString();
                string Category = dgvUpdate.CurrentRow.Cells[2].Value.ToString();
                string Price = dgvUpdate.CurrentRow.Cells[3].Value.ToString();

                txtFoodId.Text = FoodId;
                txtFoodName.Text = FoodName;
                cmbCategory.Text = Category;
                txtPrice.Text = Price;
            }
        }

        private void lblFoodId_Click(object sender, EventArgs e)
        {

        }

        private void lblFoodName_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            dgvUpdate.ClearSelection();
        }
    }
}
