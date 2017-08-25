using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Route66.Admin.Salaries
{
    public partial class Salaries1 : UserControl
    {
        public Salaries1()
        {
            InitializeComponent();
        }

        private void Salaries1_Load(object sender, EventArgs e)
        {
            lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Admin2>();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Calculate>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Report>();
        }
    }
}
