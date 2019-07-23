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
    public partial class ProductDetails : Form
    {
        public ProductDetails()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DELL-PC;Initial Catalog=abcphonecompany;Integrated Security=True");

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockController sct = new StockController();
            sct.Show();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT * FROM abc_item_detail";
            SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT * FROM abc_product_brand";
            SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "INSERT INTO [dbo].[abc_item_detail]([abc_item_id],[abc_item_name],[abc_item_model],[abc_item_desc],[abc_item_pur_price],[abc_item_sale_price],[abc_item_brand_ref]) VALUES('"+itemIdTxt.Text+"','" +itemNameTxt.Text+"' ,'"+itemModelTxt.Text+"','"+itemDesTxt.Text+"','"+priceTxt.Text+"','"+saleTxt.Text+"','"+ItemBrandIdTxt.Text+"');";

            if (itemIdTxt.Text != "" && itemNameTxt.Text != "" && itemModelTxt.Text != "" && itemDesTxt.Text != "" && priceTxt.Text != "" && saleTxt.Text != "" && ItemBrandIdTxt.Text != "")
            {
                SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
                SDA.SelectCommand.ExecuteNonQuery();
                conn.Close(); 
                MessageBox.Show("Inserted");            
            }
            else
            {
                MessageBox.Show("One more field is empty");
            }
           
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            itemIdTxt.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            itemNameTxt.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            itemModelTxt.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            itemDesTxt.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            priceTxt.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            saleTxt.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            ItemBrandIdTxt.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            
        }

        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            brandidTxt.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            brandNameTxt.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            brandDesTxt.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();           
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {

            DialogResult result1 = MessageBox.Show("Are you sure to Delete it?", "Conformation", MessageBoxButtons.YesNo);

            if (result1 == DialogResult.Yes)
            {
                conn.Open();
                string query = "DELETE FROM [dbo].[abc_item_detail] WHERE [abc_item_id]='" + itemIdTxt.Text + "'; ";
                SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
                SDA.SelectCommand.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Deleted");

                itemIdTxt.Text = "";
                itemNameTxt.Text = "";
                itemModelTxt.Text = "";
                itemDesTxt.Text = "";
                priceTxt.Text = "";
                saleTxt.Text = "";
                ItemBrandIdTxt.Text = "";
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "UPDATE [dbo].[abc_item_detail] SET  [abc_item_id]='" + itemIdTxt.Text + "',[abc_item_name]='" + itemNameTxt.Text + "',[abc_item_model]='" + itemModelTxt.Text + "',[abc_item_desc]='" + itemDesTxt.Text + "',[abc_item_pur_price]='" + priceTxt.Text + "',[abc_item_sale_price]='" + saleTxt.Text + "',[abc_item_brand_ref]='" + ItemBrandIdTxt.Text + "' WHERE [abc_item_id]='" + itemIdTxt.Text + "';";
            SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
            SDA.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Updated"); 
        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Are you sure to Clear?", "Conformation", MessageBoxButtons.YesNo);

            if (result1 == DialogResult.Yes)
            {
                itemIdTxt.Text = "";
                itemNameTxt.Text = "";
                itemModelTxt.Text = "";
                itemDesTxt.Text = "";
                priceTxt.Text = "";
                saleTxt.Text = "";
                ItemBrandIdTxt.Text = "";
            }
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "INSERT INTO [dbo].[abc_product_brand]([abc_brand_id],[abc_brand_name],[abc_brand_desc]) VALUES( '"+brandidTxt.Text+"', '"+brandNameTxt.Text+"', '"+brandDesTxt.Text+"');";
            SqlDataAdapter SDA = new SqlDataAdapter(query, conn);

            if (brandidTxt.Text != "" && brandNameTxt.Text != "")
            {
                SDA.SelectCommand.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Inserted");


                brandidTxt.Text = "";
                brandNameTxt.Text = "";
                brandDesTxt.Text = "";
            }
            else
            {
                MessageBox.Show("One more field is empty");            
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void comboBrandSearchTxt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            /*conn.Open();
            string query = "SELECT * from abc_product_brand where [abc_brand_name]='" + comboBrandSearchTxt.Text + "';";
            SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close(); */
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT * from abc_product_brand where [abc_brand_name]='" + comboBrandSearchTxt.Text + "';";
            SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close(); 
        }

        private void itemSearchTxt_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            /*conn.Open();
            string query = "SELECT * from abc_item_detail where CONCAT(abc_item_id,abc_item_name,abc_item_model) where like % ='"+itemSearchTxt+"';";
            SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close(); */
        } 
    }
}
