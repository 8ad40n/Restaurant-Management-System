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
    public partial class frmUsersInfoManager : UserControl
    {
        private DataAccess Da { get; set; }
        public frmUsersInfoManager()
        {

            InitializeComponent();

            this.Da = new DataAccess();

            this.PopulateGridView();
        }
        private void PopulateGridView(string sql = "select * from UserInfo;")
        {
            this.Da.ExecuteQueryTable(sql);

            //this.dgvAdd.AutoGenerateColumns = false;
            this.dgvUpdate.DataSource = Da.Ds.Tables[0];
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from UserInfo where FullName like '%" + this.txtSearch.Text + "%';";
            this.PopulateGridView(sql);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
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
