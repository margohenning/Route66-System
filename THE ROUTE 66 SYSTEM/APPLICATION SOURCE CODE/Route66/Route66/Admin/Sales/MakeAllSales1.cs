using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.SouthAfrica;
using System.Text.RegularExpressions;

namespace Route66.Admin.Sales
{
    public partial class MakeAllSales1 : UserControl
    {
        List<string> ids = new List<string>();
        public MakeAllSales1()
        {
            InitializeComponent();
            for(int y=0;y< DAT.DataAccess.GetCustomer().ToList().Count;y++)
            {
                ids.Add(DAT.DataAccess.GetCustomer().ToList()[y].IDno);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<AllSales1>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Admin2>();
        }

        private void MakeSale1_Load(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            panel2.Enabled = false;
            lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;
            List<string> VIN = new List<string>();
            List<LTS.Stock> s = new List<LTS.Stock>();
            s = DAT.DataAccess.GetStock().Where(o =>  o.VehicleStatus == "Available").ToList();
            for (int i = 0; i < s.Count; i++)
            {
                VIN.Add(s[i].VIN);
            }
            comboBox1.DataSource = VIN;
            List<string> pay = new List<string>();
            pay.Add("Yes");
            pay.Add("No");
            comboBoxp.DataSource = pay;

            List<string> EMPID = new List<string>();
            List<LTS.Employee> emp = new List<LTS.Employee>();
            emp = DAT.DataAccess.GetEmployee().ToList();
            for (int i = 0; i < emp.Count; i++)
            {
                EMPID.Add(emp[i].EmpID.ToString() + " - " + emp[i].Name + " "+ emp[i].Surname);
            }
            comboBox2.DataSource = EMPID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label22.Visible = false;
            richTextBox1.Visible = false;
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || (radioButton1.Checked == false && radioButton2.Checked == false))
            {
                label22.Visible = true;
                richTextBox1.Visible = true;
            }
            else
            {
                if (radioButton1.Checked && NewNameC.Text != "" && NewSurnameC.Text != "" && newIDC.Text != "" && newCellC.Text != "" && newEmailC.Text != "" && newAddressC.Text != "")
                {
                    ///////////////////////CHECKS//////////////////
                    bool isEmail = Regex.IsMatch(newEmailC.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                    bool isCell = Regex.IsMatch(newCellC.Text, @"^(?:\+?1[-. ]?)?\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");
                    bool name = Regex.IsMatch(NewNameC.Text, @"^[a-zA-Z ]+$");
                    bool sName = Regex.IsMatch(NewSurnameC.Text, @"^[a-zA-Z ]+$");
                    IdentityNumber id = new IdentityNumber(newIDC.Text);
                    bool IDVALID = id.IsValid;
                    int exist;                    
                    exist = DAT.DataAccess.GetCustomer().Where(i => i.IDno == newIDC.Text).ToList().Count;
                    
                    //////////////////////CHECKS//////////////////
                    if (!isEmail || !isCell || !name || !sName || !IDVALID || exist != 0)
                    {
                        label22.Visible = true;
                        richTextBox1.Visible = true;
                    }
                    else
                    {
                        
                    
                       
                        LTS.Customer c = new LTS.Customer();
                        c.Name = NewNameC.Text;
                        c.Surname = NewSurnameC.Text;
                        c.IDno = newIDC.Text;
                        c.Email = newEmailC.Text;
                        c.CellNo = newCellC.Text;
                        c.CustAddress = newAddressC.Text;

                        int custID = DAT.DataAccess.AddCustomer(c);

                        if (custID != -1)
                        {
                            LTS.Sale s = new LTS.Sale();
                            s.EmpID = DAT.DataAccess.GetEmployee().ToList()[comboBox2.SelectedIndex].EmpID;
                            s.SaleDate = DateTime.Now.Date;
                            s.CustID = custID;

                            if (comboBoxp.SelectedItem.ToString() == "Yes")
                            {
                                s.Paid = true;
                            }
                            else
                            {
                                s.Paid = false;
                            }
                            s.StockID = DAT.DataAccess.GetStock().Where(i => i.VIN == comboBox1.SelectedItem.ToString()).FirstOrDefault().StockID;
                            int stockID = DAT.DataAccess.GetStock().Where(i => i.VIN == comboBox1.SelectedItem.ToString()).FirstOrDefault().StockID;
                            int saleID = DAT.DataAccess.AddSale(s);

                            if (saleID == -1)
                            {
                                if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the Sale Item was not Added!"))
                                {
                                    ((Form1)this.Parent.Parent).ChangeView<AllSales1>();
                                }

                            }
                            else
                            {
                                LTS.Stock res = new LTS.Stock();

                                res = DAT.DataAccess.GetStock().Where(i => i.StockID == stockID).FirstOrDefault();
                                res.VehicleStatus = "Sold";
                                bool updated = DAT.DataAccess.UpdateStock(res);
                                if (updated)
                                {
                                    if (DialogResult.OK == MessageBox.Show("The Sale Item was added successfully!"))
                                    {
                                        ((Form1)this.Parent.Parent).ChangeView<AllSales1>();
                                    }
                                }
                                else
                                {
                                    if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the Sale Item was not Added!"))
                                    {
                                        ((Form1)this.Parent.Parent).ChangeView<AllSales1>();
                                    }
                                }

                            }
                        }
                    }
                    

                }else if (radioButton2.Checked && oldNameC.Text != "" && oldSurnameC.Text != "" && comboBoxOldNameC.SelectedItem != null && oldCellC.Text != "" && oldEmailC.Text != "" && oldAddressC.Text != "")
                {
                    ///////////////////////CHECKS//////////////////
                    bool isEmail = Regex.IsMatch(oldEmailC.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                    bool isCell = Regex.IsMatch(oldCellC.Text, @"^(?:\+?1[-. ]?)?\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");
                    bool name = Regex.IsMatch(oldNameC.Text, @"^[a-zA-Z ]+$");
                    bool sName = Regex.IsMatch(oldSurnameC.Text, @"^[a-zA-Z ]+$");
                    

                    //////////////////////CHECKS//////////////////
                    if (!isEmail || !isCell || !name || !sName )
                    {
                        label22.Visible = true;
                        richTextBox1.Visible = true;
                    }
                    else
                    {
                        richTextBox1.Visible = false;
                        label22.Visible = false;
                        LTS.Customer c = DAT.DataAccess.GetCustomer().Where(p => p.IDno == comboBoxOldNameC.SelectedItem.ToString()).FirstOrDefault();
                        c.Name = oldNameC.Text;
                        c.Surname = oldSurnameC.Text;
                        c.Email = oldEmailC.Text;
                        c.CellNo = oldCellC.Text;
                        c.CustAddress = oldAddressC.Text;

                        bool custID = DAT.DataAccess.UpdateCustomer(c);

                        if (custID)
                        {
                            LTS.Sale s = new LTS.Sale();
                            s.EmpID = DAT.DataAccess.GetEmployee().ToList()[comboBox2.SelectedIndex].EmpID;
                            s.SaleDate = DateTime.Now.Date;
                            s.CustID = c.CustID;

                            if (comboBoxp.SelectedItem.ToString() == "Yes")
                            {
                                s.Paid = true;
                            }
                            else
                            {
                                s.Paid = false;
                            }
                            s.StockID = DAT.DataAccess.GetStock().Where(i => i.VIN == comboBox1.SelectedItem.ToString()).FirstOrDefault().StockID;
                            int stockID = DAT.DataAccess.GetStock().Where(i => i.VIN == comboBox1.SelectedItem.ToString()).FirstOrDefault().StockID;
                            int saleID = DAT.DataAccess.AddSale(s);

                            if (saleID == -1)
                            {
                                if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the Sale Item was not Added!"))
                                {
                                    ((Form1)this.Parent.Parent).ChangeView<AllSales1>();
                                }

                            }
                            else
                            {
                                LTS.Stock res = new LTS.Stock();

                                res = DAT.DataAccess.GetStock().Where(i => i.StockID == stockID).FirstOrDefault();
                                res.VehicleStatus = "Sold";
                                bool updated = DAT.DataAccess.UpdateStock(res);
                                if (updated)
                                {
                                    if (DialogResult.OK == MessageBox.Show("The Sale Item was added successfully!"))
                                    {
                                        ((Form1)this.Parent.Parent).ChangeView<AllSales1>();
                                    }
                                }
                                else
                                {
                                    if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the Sale Item was not Added!"))
                                    {
                                        ((Form1)this.Parent.Parent).ChangeView<AllSales1>();
                                    }
                                }

                            }
                        }
                    }

                        

                }

                else

                {
                label22.Visible = true;
                    richTextBox1.Visible = true;

                }
        }
                






        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                panel1.Enabled = true;
            }
            else
            {
                panel1.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                panel2.Enabled = true;
                comboBoxOldNameC.DataSource = ids;
            }
            else
            {
                panel2.Enabled = false;
                comboBoxOldNameC.DataSource = null;
            }
        }

        private void comboBoxOldNameC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxOldNameC.SelectedItem != null)
            {
                string id = comboBoxOldNameC.SelectedItem.ToString();
                LTS.Customer c = DAT.DataAccess.GetCustomer().Where(u => u.IDno == id).FirstOrDefault();
                oldNameC.Text = c.Name;
                oldSurnameC.Text = c.Surname;
                oldCellC.Text = c.CellNo;
                oldEmailC.Text = c.Email;
                oldAddressC.Text = c.CustAddress;
            }
            else
            {

            }
           
        }
    }
    }

