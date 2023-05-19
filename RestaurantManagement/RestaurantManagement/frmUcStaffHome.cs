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
    public partial class frmUcStaffHome : UserControl
    {

        private DataAccess Da { get; set; }
        public frmUcStaffHome()
        {
            InitializeComponent();

            this.Da = new DataAccess();

            PopulateGridView();
        }
        //public frmUcStaffHome(string Name)
        //{
        //    InitializeComponent();

        //    this.Name = Name;
        //    lblInfo.Text = Name;    
        //}


        private void PopulateGridView(string sql = "select FoodDetails.FoodId,FoodDetails.FoodName,FoodPrices.Category,FoodPrices.Price from FoodDetails,FoodPrices where FoodDetails.FoodId = FoodPrices.FoodId;")
        {
            this.Da.ExecuteQueryTable(sql);

            //this.dgvAdd.AutoGenerateColumns = false;
            this.dgvMenu.DataSource = Da.Ds.Tables[0];
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = "select FoodDetails.FoodId,FoodDetails.FoodName,FoodPrices.Category,FoodPrices.Price from FoodDetails,FoodPrices where FoodDetails.FoodId=FoodPrices.FoodId and FoodDetails.FoodName like '" + this.txtSearch.Text + "%';";
            this.PopulateGridView(sql);
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
