using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Utilities.SouthAfrica;

namespace Route66.Admin.Customer
{
    public partial class EditAllCustomer1 : UserControl
    {
        string oldcID = "";
        public EditAllCustomer1()
        {
            InitializeComponent();
        }

        private void EditCustomer1_Load(object sender, EventArgs e)
        {
            lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;

            List<LTS.Customer> cust = new List<LTS.Customer>();
            cust = DAT.DataAccess.GetCustomer().ToList();
            for (int i = 0; i < cust.Count; i++)
            {
                dataGridView1.Rows.Add(cust[i].Name, cust[i].Surname, cust[i].IDno, cust[i].CellNo, cust[i].Email, cust[i].CustAddress);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<AllCustomer1>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Admin2>();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 1)
            {
                using (DataGridViewRow item = this.dataGridView1.SelectedRows[0])
                {
                    int i = item.Index;

                    cName.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    cSurname.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    cID.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    oldcID = cID.Text;
                    cCell.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    cEmail.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    cAddress.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();

                }
            }
            else
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label22.Visible = false;
            richTextBox1.Visible = false;
            if (cEmail.Text == "" || cAddress.Text == "" || cCell.Text == "" || cName.Text == "" || cSurname.Text == ""|| cID.Text=="")
            {
                label22.Visible = true;
                richTextBox1.Visible = true;
            }
            else
            {
                ///////////////////////CHECKS//////////////////
                bool isEmail = Regex.IsMatch(cEmail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                bool isCell = Regex.IsMatch(cCell.Text, @"^(?:\+?1[-. ]?)?\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");
                bool name = Regex.IsMatch(cName.Text, @"^[a-zA-Z ]+$");
                bool sName = Regex.IsMatch(cSurname.Text, @"^[a-zA-Z ]+$");
                IdentityNumber id = new IdentityNumber(cID.Text);
                bool IDVALID = id.IsValid;
                int exist;
                if (oldcID == cID.Text)
                {
                    exist = 0;
                }
                else
                { 
                    exist = DAT.DataAccess.GetCustomer().Where(i => i.IDno == cID.Text).ToList().Count;
                }
                





                //////////////////////CHECKS//////////////////
                if (!isEmail || !isCell || !name || !sName || !IDVALID || exist != 0)
                {
                    label22.Visible = true;
                    richTextBox1.Visible = true;
                }
                else
                {
                    int custID;

                    using (DataGridViewRow item = this.dataGridView1.SelectedRows[0])
                    {
                        int i = item.Index;

                        string ID = dataGridView1.Rows[i].Cells[2].Value.ToString();


                        custID = DAT.DataAccess.GetCustomer().Where(o => o.IDno == ID).FirstOrDefault().CustID;


                    }
                    try
                    {
                        LTS.Customer newCust = new LTS.Customer();
                        newCust.CustID = custID;
                        newCust.Name = cName.Text;
                        newCust.Surname = cSurname.Text;
                        newCust.IDno = cID.Text;
                        newCust.CustAddress = cAddress.Text;
                        newCust.CellNo = cCell.Text;
                        newCust.Email = cEmail.Text;
                        bool updated = DAT.DataAccess.UpdateCustomer(newCust);
                        if (updated)
                        {

                            if (DialogResult.OK == MessageBox.Show("Customer information edited successfully!"))
                            {
                                ((Form1)this.Parent.Parent).ChangeView<AllCustomer1>();
                            }
                        }
                        else
                        {
                            if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the customer information was not edited successfully!"))
                            {
                                ((Form1)this.Parent.Parent).ChangeView<AllCustomer1>();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        label22.Visible = true;
                        richTextBox1.Visible = true;
                    }
                }
                

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
