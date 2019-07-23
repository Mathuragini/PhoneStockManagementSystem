using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_PhoneSystem
{
    public partial class Admin_Menu : Form
    {
        public Admin_Menu()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administrator ad = new Administrator();
            ad.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            BranchDetail bd = new BranchDetail();
            bd.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Help hp = new Help();
            hp.Show();
        }
    }
}
