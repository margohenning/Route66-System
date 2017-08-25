using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Route66.Admin.Customer
{
    public partial class RemoveAllCustomer1 : UserControl
    {
        public RemoveAllCustomer1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<AllCustomer1>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Admin2>();
        }

        private void RemoveAllCustomer1_Load(object sender, EventArgs e)
        {
            lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;
            List<LTS.Sale> c = DAT.DataAccess.GetSale().ToList();
            List<LTS.Customer> cust = DAT.DataAccess.GetCustomer().ToList();
            List<LTS.Customer> custToDel = new List<LTS.Customer>();
            for (int i = 0; i < cust.Count; i++)
            {
                int index = c.FindIndex(f => f.CustID == cust[i].CustID);
                if(index == -1 )
                {
                    custToDel.Add(cust[i]);
                }

            }
            
           
            for (int i = 0; i < custToDel.Count; i++)
            {
                dataGridView1.Rows.Add(cust[i].Name, cust[i].Surname, cust[i].IDno, cust[i].CellNo, cust[i].Email, cust[i].CustAddress);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows == null)
            {

            }
            else
            {
                if (MessageBox.Show("Are You sure you want to remove this Customer Item?" , "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string customerIDno;
                    using (DataGridViewRow item = this.dataGridView1.SelectedRows[0])
                    {
                        int i = item.Index;

                        
                        customerIDno = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        dataGridView1.Rows.RemoveAt(i);

                        bool removed =DAT.DataAccess.RemoveCustomer(DAT.DataAccess.GetCustomer().Where(o => o.IDno == customerIDno).FirstOrDefault().CustID);
                        if (removed)
                        {
                            if (DialogResult.OK == MessageBox.Show("Customer item removed successfully!"))
                            {
                                ((Form1)this.Parent.Parent).ChangeView<AllCustomer1>();
                            }
                        }
                        else
                        {
                            if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the customer item was not removed successfully!"))
                            {
                                ((Form1)this.Parent.Parent).ChangeView<AllCustomer1>();
                            }
                        }

                    }
                }
                else { }
            }
            
        }
    }
}
