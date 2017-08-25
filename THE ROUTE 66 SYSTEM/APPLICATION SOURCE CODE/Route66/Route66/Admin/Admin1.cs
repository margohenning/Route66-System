using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Route66.Admin;

namespace Route66
{
    public partial class Admin1 : UserControl
    {
        public Admin1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Welcome>();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                label4.Visible = true;
            }
            else
            {
                label4.Visible = false;
                string username = textBox1.Text;
                string pass = textBox2.Text;

                int exist = DAT.DataAccess.GetEmployee().Where(i => i.Username == username).ToList().Count;
                if (exist == 0)
                {
                    label4.Visible = true;
                }
                else
                {
                    int correct = DAT.DataAccess.GetEmployee().Where(i => i.Username == username && i.Pass == pass && i.IsAdmin == true && i.Activated ==true).ToList().Count;
                    if (correct == 0)
                    {
                        label4.Visible = true;
                    }
                    else
                    {
                        ((Form1)this.Parent.Parent).loggedIn = username;
                        ((Form1)this.Parent.Parent).ChangeView<Admin2>();
                    }

                }

            }
        }

        private void Admin1_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked ==true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
