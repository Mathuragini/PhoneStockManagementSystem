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
    public partial class BranchDetail : Form
    {
        public BranchDetail()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DELL-PC;Initial Catalog=abcphonecompany;Integrated Security=True");

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Menu am = new Admin_Menu();
            am.Show();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT * FROM abc_branch_detail";
            SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "INSERT INTO [dbo].[abc_branch_detail]([branch_id],[branch_name],[branch_location],[branch_desc])VALUES('" + branchIDTxt.Text + "','" + nameTxt.Text + "','" + locationTxt.Text + "','" + descTxt.Text + "');";
            if (branchIDTxt.Text != "" && nameTxt.Text != "" && locationTxt.Text != "" && descTxt.Text != "")
            {
                SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
                SDA.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Inserted");

                branchIDTxt.Text = "";
                nameTxt.Text = "";
                locationTxt.Text = "";
                descTxt.Text = "";
                
            }
            else
            {
                MessageBox.Show("One more field is empty");
            }
            conn.Close();  

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            branchIDTxt.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            nameTxt.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            locationTxt.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            descTxt.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
           
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "UPDATE [dbo].[abc_branch_detail] SET [branch_id]='" + branchIDTxt.Text + "',[branch_name]='" + nameTxt.Text + "',[branch_location]='" + locationTxt.Text + "',[branch_desc]='" + descTxt.Text + "' WHERE [branch_id]='" + branchIDTxt.Text + "';";
            SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
            SDA.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Updated");
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "DELETE FROM [dbo].[abc_branch_detail] WHERE [branch_id]='" + branchIDTxt.Text + "'; ";
            
            DialogResult result1 = MessageBox.Show("Are you sure to Delete it?", "Conformation", MessageBoxButtons.YesNo);

            if (result1 == DialogResult.Yes)
            {
                SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
                SDA.SelectCommand.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Deleted");
            }
            
            
        }

        private void bunifuThinButton25_Click_1(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Are you sure to clear?", "Conformation", MessageBoxButtons.YesNo);

            if (result1 == DialogResult.Yes)
            {
                branchIDTxt.Text = "";
                nameTxt.Text = "";
                locationTxt.Text = "";
                descTxt.Text = "";
            }
        }

        private void searchTxt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            conn.Open();
            string query = "SELECT * from abc_branch_detail where [branch_id]='" + searchTxt.Text + "';";
            SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close(); 
        }
    }
}
