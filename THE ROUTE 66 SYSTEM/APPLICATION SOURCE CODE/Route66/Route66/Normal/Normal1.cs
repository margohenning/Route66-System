using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Route66
{
    public partial class Normal1 : UserControl
    {
        public Normal1()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Welcome>();
        }

        private void btnlogin_Click_1(object sender, EventArgs e)
        {   //check log in from db

            if (textBox1.Text =="" || textBox2.Text =="")
            {
                label4.Visible = true;
            }
            else
            {
                label4.Visible = false;
                string username = textBox1.Text;
                string pass = textBox2.Text;

                int exist = DAT.DataAccess.GetEmployee().Where(i => i.Username == username).ToList().Count;
                if(exist == 0)
                {
                    label4.Visible = true;
                }
                else
                {
                    bool active = DAT.DataAccess.GetEmployee().Where(i => i.Username == username).FirstOrDefault().Activated.Value;
                    if (active)
                    {
                        int correct = DAT.DataAccess.GetEmployee().Where(i => i.Username == username && i.Pass == pass).ToList().Count;
                        if (correct == 0)
                        {
                            label4.Visible = true;
                        }
                        else
                        {
                            ((Form1)this.Parent.Parent).loggedIn = username;
                            ((Form1)this.Parent.Parent).ChangeView<Normal2>();
                        }
                    }
                    else
                    {
                        label4.Visible = true;
                    }
                    
                    
                }




            }
            //set logged in as name after logging in succesfully
           
            
            
        }

        

        private void Normal1_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
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
