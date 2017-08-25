using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Route66.Normal.Sale;

namespace Route66
{
    public partial class Sale1 : UserControl
    {
        public Sale1()
        {
            InitializeComponent();
        }

        private void Sale1_Load(object sender, EventArgs e)
        {
            lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Normal2>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<ViewSales1>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<MakeSale1>();
        }
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<ViewSales1>();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<MakeSale1>();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<EditSale1>();
        }
    }
}
