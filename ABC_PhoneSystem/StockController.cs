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
    public partial class StockController : Form
    {
        public StockController()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            TransferStock ts = new TransferStock();
            ts.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductDetails pde = new ProductDetails();
            pde.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Stock_Info msi = new Manage_Stock_Info();
            msi.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Help hp = new Help();
            hp.Show();
        }
    }
}
