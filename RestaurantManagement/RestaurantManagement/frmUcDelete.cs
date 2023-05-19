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
    public partial class frmUcDelete : UserControl
    {
        private DataAccess Da { get; set; }
        public frmUcDelete()
        {
            InitializeComponent();

            this.Da = new DataAccess();

            this.PopulateGridView();
        }

        private void PopulateGridView(string sql = "select FoodDetails.FoodId,FoodDetails.FoodName,FoodPrices.Category,FoodPrices.Price from FoodDetails,FoodPrices where FoodDetails.FoodId = FoodPrices.FoodId;")
        {
            this.Da.ExecuteQueryTable(sql);

            //this.dgvAdd.AutoGenerateColumns = false;
            this.dgvDelete.DataSource = Da.Ds.Tables[0];
        }


        private void ClearContent()
        {
            this.txtFoodId.Clear();
            this.txtFoodName.Clear();
            this.txtPrice.Clear();
            this.txtCategory.Text = null;


            this.txtSearch.Clear();


            this.dgvDelete.ClearSelection();
            //this.AutoIdGenerate();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearContent();
        }

        

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = "select FoodDetails.FoodId,FoodDetails.FoodName,FoodPrices.Category,FoodPrices.Price from FoodDetails,FoodPrices where FoodDetails.FoodId=FoodPrices.FoodId and FoodDetails.FoodName like '" + this.txtSearch.Text + "%';";
            this.PopulateGridView(sql);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvDelete.SelectedRows.Count < 1)
            {
                MessageBox.Show("Plaese select a Row first to Delete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var FoodId = this.dgvDelete.CurrentRow.Cells[0].Value.ToString();
                var FoodName = this.dgvDelete.CurrentRow.Cells[1].Value.ToString();

                DialogResult dr = MessageBox.Show("Are you sure you want to delete", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                {
                    //MessageBox.Show("No delete");
                    return;
                }

                var query = "delete from FoodDetails where FoodId = '" + FoodId + "';";
                var query2 = "delete from FoodPrices where FoodId = '" + FoodId + "';";
                var count = this.Da.ExecuteDMLQuery(query);
                var count2 = this.Da.ExecuteDMLQuery(query2);

                if (count == 1 && count2 ==1)
                    MessageBox.Show(FoodName + " has been removed from the list.");
                else
                    MessageBox.Show("Data remove failed");

                this.PopulateGridView();
                this.ClearContent();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
        }

        private void dgvDelete_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDelete.SelectedRows != null && dgvDelete.SelectedRows.Count > 0)
            {
                string FoodId = dgvDelete.CurrentRow.Cells[0].Value.ToString();
                string FoodName = dgvDelete.CurrentRow.Cells[1].Value.ToString();
                string Category = dgvDelete.CurrentRow.Cells[2].Value.ToString();
                string Price = dgvDelete.CurrentRow.Cells[3].Value.ToString();

                txtFoodId.Text = FoodId;
                txtFoodName.Text = FoodName;
                txtCategory.Text = Category;
                txtPrice.Text = Price;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            dgvDelete.ClearSelection();
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
    }
}
