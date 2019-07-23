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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userTxt_Enter(object sender, EventArgs e)
        {
            if (userTxt.Text == "USERNAME")
            {
                userTxt.Text = "";
            }
        }

        private void userTxt_Leave(object sender, EventArgs e)
        {
            if (userTxt.Text == "")
            {
                userTxt.Text = "USERNAME";
            }

        }

        private void pwdTxt_Enter(object sender, EventArgs e)
        {
            if (pwdTxt.Text == "PASSWORD")
            {
                pwdTxt.Text = "";
            }

        }

        private void pwdTxt_Leave(object sender, EventArgs e)
        {
            if (pwdTxt.Text == "")
            {
                pwdTxt.Text = "PASSWORD";
            }


        }

        private void comboType_Enter(object sender, EventArgs e)
        {
            if (comboTypeLogin.Text == "USER_TYPE")
            {
                comboTypeLogin.Text = "";
            }
        }

        private void comboType_Leave(object sender, EventArgs e)
        {
            if (comboTypeLogin.Text == "")
            {
                comboTypeLogin.Text = "USER_TYPE";
            }

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection cnn;
            connectionString =@"Data Source=DELL-PC;Initial Catalog=abcphonecompany;Integrated Security=True";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql = "";

            sql = "select * from abc_user_detail where user_username='" + userTxt.Text + "' and user_password='" + pwdTxt.Text + "'and  user_type='" + comboTypeLogin.Text + "' ;";

            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {

                //MessageBox.Show("connected");
                if ((comboTypeLogin.Text == "Admin"))
                {
                    this.Hide();
                    Admin_Menu am = new Admin_Menu();
                    am.Show();
                }
                else
                {
                    this.Hide();
                    StockController sc = new StockController();
                    sc.Show();

                }
            }


            else
            {
                MessageBox.Show("Notconnected");
            }
            dataReader.Close();
            command.Dispose();
            cnn.Close();


        }
    }
}
