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

namespace ABC_PhoneSystem
{
    public partial class Manage_Stock_Info : Form
    {
        public Manage_Stock_Info()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DELL-PC;Initial Catalog=abcphonecompany;Integrated Security=True");
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockController sc = new StockController();
            sc.Show();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT branch.branch_name,item.abc_item_name,item.abc_item_model,brand.abc_brand_name,item.abc_item_sale_price,stock.abc_stk_qty FROM abc_stock_detail stock inner join abc_item_detail item on stock.abc_stk_item_ref = item.abc_item_id  inner join abc_branch_detail branch on stock.abc_stk_branch_ref = branch.branch_id  inner join abc_product_brand brand on item.abc_item_brand_ref = brand.abc_brand_id ;";
            SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
