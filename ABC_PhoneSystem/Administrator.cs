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
    public partial class Administrator : Form
    {
        public Administrator()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DELL-PC;Initial Catalog=abcphonecompany;Integrated Security=True");

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Administrator_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'abcphonecompanyDataSet.abc_user_detail' table. You can move, or remove it, as needed.
            this.abc_user_detailTableAdapter.Fill(this.abcphonecompanyDataSet.abc_user_detail);

        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuRefreshBtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT * FROM abc_user_detail";
            SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource=dt;
            conn.Close();
        }

        private void bunifuInsertBtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "INSERT INTO [dbo].[abc_user_detail]([user_id],[user_firstname],[user_lastname],[user_email],[user_type],[user_username],[user_password],[user_active_status] ,[user_branch_ref])VALUES('" + userIdTxt.Text + "','" + fnameTxt.Text + "','" + lnameTxt.Text + "','" + mailTxt.Text + "','" + comboType.Text + "','" + unameTxt.Text + "','" + pwdTxt.Text + "','" + comboStatus.Text + "','" +branchIdTxt.Text + "');";

            if (userIdTxt.Text != "" && fnameTxt.Text != "" && lnameTxt.Text != "" && mailTxt.Text != "" && comboType.Text != "" && unameTxt.Text != "" && pwdTxt.Text != "" && comboStatus.Text != "" && branchIdTxt.Text != "")
            {
                SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
                SDA.SelectCommand.ExecuteNonQuery();               
                MessageBox.Show("Inserted");

                userIdTxt.Text = "";
                fnameTxt.Text = "";
                lnameTxt.Text = "";
                mailTxt.Text = "";
                comboType.Text = "";
                unameTxt.Text = "";
                pwdTxt.Text = "";
                comboStatus.Text = "";
                branchIdTxt.Text = ""; 
            }
            else
            {
                MessageBox.Show("One more field is empty");                          
            }
            conn.Close();  

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Menu am = new Admin_Menu();
            am.Show();
        }

        private void bunifuDeleteBtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "DELETE FROM [dbo].[abc_user_detail] WHERE [user_id]='" + userIdTxt.Text + "'; ";
            


            DialogResult result1 = MessageBox.Show("Are you sure to Delete it?", "Conformation", MessageBoxButtons.YesNo);

            if (result1 == DialogResult.Yes)
            {
                SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
                SDA.SelectCommand.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Deleted");

                userIdTxt.Text = "";
                fnameTxt.Text = "";
                lnameTxt.Text = "";
                mailTxt.Text = "";
                comboType.Text = "";
                unameTxt.Text = "";
                pwdTxt.Text = "";
                comboStatus.Text = "";
                branchIdTxt.Text = "";
            }
            


        }

        private void bunifuUpdateBtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            
            string query = "UPDATE [dbo].[abc_user_detail] SET [user_id]='" + userIdTxt.Text + "',[user_firstname]='" + fnameTxt.Text + "',[user_lastname]='" + lnameTxt.Text + "',[user_email]='" + mailTxt.Text + "',[user_type]='" + comboType.Text + "',[user_username]='" + unameTxt.Text + "',[user_password]='" + pwdTxt.Text + "',[user_active_status]='" + comboStatus.Text + "',[user_branch_ref]='" + branchIdTxt.Text + "' WHERE [user_id]='" + userIdTxt.Text + "';";
            if (userIdTxt.Text != "" && fnameTxt.Text != "" && lnameTxt.Text != "" && mailTxt.Text != "" && comboType.Text != "" && unameTxt.Text != "" && pwdTxt.Text != "" && comboStatus.Text != "" && branchIdTxt.Text != "")
            {
                SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
                SDA.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Updated");

                userIdTxt.Text = "";
                fnameTxt.Text = "";
                lnameTxt.Text = "";
                mailTxt.Text = "";
                comboType.Text = "";
                unameTxt.Text = "";
                pwdTxt.Text = "";
                comboStatus.Text = "";
                branchIdTxt.Text = "";
            }
            else
            {
                MessageBox.Show("One more field is empty");
            }
            conn.Close();  
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            userIdTxt.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            fnameTxt.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            lnameTxt.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            mailTxt.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboType.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            unameTxt.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            pwdTxt.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            comboStatus.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            branchIdTxt.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void bunifuClearBtn_Click(object sender, EventArgs e)
        {

            DialogResult result1 = MessageBox.Show("Are you sure clear detail?", "Conformation", MessageBoxButtons.YesNo);

            if (result1 == DialogResult.Yes)
            {
                userIdTxt.Text = "";
                fnameTxt.Text = "";
                lnameTxt.Text = "";
                mailTxt.Text = "";
                comboType.Text = "";
                unameTxt.Text = "";
                pwdTxt.Text = "";
                comboStatus.Text = "";
                branchIdTxt.Text = "";
            }
        }

        private void bunifuSearchBtn_Click(object sender, EventArgs e)
        {
            /*conn.Open();
            string query = "SELECT * from abc_user_detail where [user_id]='" + userSearchTxt.Text + "';";
            SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close(); */
        }

        private void userSearchTxt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            conn.Open();
            string query = "SELECT * from abc_user_detail where [user_id]='" + userSearchTxt.Text + "';";
            SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close(); 

        }

        private void userSearchTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
