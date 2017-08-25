using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Route66.Admin.Reserve
{
    public partial class ReserveA : UserControl
    {
        public ReserveA()
        {
            InitializeComponent();
        }

        private void Reserve1_Load(object sender, EventArgs e)
        {
            lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Admin2>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<ViewReservationA>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<AddReservationA>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<RemoveReservationA>();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<EditReservationA>();
        }
    }
}
