using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagement
{
    public partial class frmUcSalesReport : UserControl
    {

        private DataAccess Da { get; set; }
        public frmUcSalesReport()
        {
            InitializeComponent();

            this.Da = new DataAccess();

            this.PopulateGridView();

            this.dtpStartDate.Value= DateTime.Now;
            this.dtpEndDate.Value= DateTime.Now;
        }

        private void PopulateGridView(string sql = "select OrdersInfo.OrderID,OrdersInfo.CustomerName,OrdersInfo.OrderDate,OrdersInfo.Total,OrdersItems.Item,OrdersItems.Quantity from OrdersInfo,OrdersItems where OrdersInfo.OrderID=OrdersItems.OrderID;\r\n")
        {
            this.Da.ExecuteQueryTable(sql);

            //this.dgvAdd.AutoGenerateColumns = false;
            this.dgvSales.DataSource = Da.Ds.Tables[0];
        }


        private void btnGenerate_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Generating the sales report from "+dtpStartDate.Value+" to "+dtpEndDate.Value +" !");
            decimal totalSale = 0; // Initialize totalSale variable here

            string query = "SELECT * FROM OrdersInfo WHERE OrderDate >= '" + dtpStartDate.Value + "' AND OrderDate <= '" + dtpEndDate.Value + "';";

            PopulateGridView(query);

            foreach (DataGridViewRow row in dgvSales.Rows)
            {
                //if (!row.IsNewRow)
                //{
                    decimal sale = Convert.ToDecimal(row.Cells["Total"].Value);
                    totalSale += sale;
               // }
            }

            // Display the total sale in a label
            lblTK.Text = totalSale.ToString();



        }

        private void ClearContent()
        {
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now;
            lblTK.Text = "0.0";

            this.dgvSales.ClearSelection();
            PopulateGridView();
            //this.AutoIdGenerate();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearContent();
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
