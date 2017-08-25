using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Route66.Admin.Customer;
using Route66.Admin.Sales;
using Route66.Admin.Salaries;
using Route66.Admin.Stock;
using Route66.Admin.Reserve;

namespace Route66.Admin
{
    public partial class Admin2 : UserControl
    {
        public Admin2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Employee>();
        }

        private void Admin2_Load(object sender, EventArgs e)
        {
            lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want to Log Out?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ((Form1)this.Parent.Parent).ChangeView<Welcome>();
            }
            else
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<StockA>();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<ReserveA>();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<AllCustomer1>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<AllSales1>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Salaries1>();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<AllCustomer1>();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<SystemReport>();
        }
    }
}
