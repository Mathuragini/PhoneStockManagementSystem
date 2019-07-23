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
    public partial class TransferStock : Form
    {
        public TransferStock()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DELL-PC;Initial Catalog=abcphonecompany;Integrated Security=True");

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockController sct = new StockController();
            sct.Show();
        }

        private void bunifuUpdateBtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT * FROM abc_item_detail";
            SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT * FROM abc_branch_detail";
            SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void bunifuTransferBtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "UPDATE [dbo].[abc_item_detail] SET [abc_item_id]='" + transItemidTxt.Text + "',[user_firstname]='" + fnameTxt.Text + "'WHERE [user_id]='" + transItemidTxt.Text + "';";          
            SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
            SDA.SelectCommand.ExecuteNonQuery();
            MessageBox.Show("Updated");
            conn.Close();  
        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT abc_item_id,abc_item_name,abc_item_brand_ref,abc_item_sale_price FROM abc_item_detail where abc_item_brand_ref=1; ";
            string query1 = "SELECT abc_item_id,abc_item_name,abc_item_brand_ref,abc_item_sale_price FROM abc_item_detail where abc_item_brand_ref=2; ";
            SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
            SqlDataAdapter SDA1 = new SqlDataAdapter(query1, conn);
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            SDA.Fill(dt);
            SDA1.Fill(dt1);
            dataGridView3.DataSource = dt;
            dataGridView2.DataSource = dt1;
            conn.Close();
        }
    }
}
