using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Route66.Normal.Stock;

namespace Route66
{
    public partial class Stock1 : UserControl
    {
        public Stock1()
        {
            InitializeComponent();
        }

        private void Stock1_Load(object sender, EventArgs e)
        {
             lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Normal2>();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void lblloggedInAs_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<ViewStock1>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<AddStock1>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<RemoveStock1>();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<EditStock1>();
        }
    }
}
