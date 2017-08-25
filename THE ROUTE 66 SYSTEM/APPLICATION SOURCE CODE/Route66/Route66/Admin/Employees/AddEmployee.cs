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

namespace Route66.Admin.Employees
{
    public partial class AddEmployee : UserControl
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Employee>();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;
            List<string> val1 = new List<string>();
            val1.Add("True");
            val1.Add("False");

            List<string> val2 = new List<string>();
            val2.Add("True");
            val2.Add("False");

            comboBoxAdmin.DataSource = val1;
            comboBoxActiv.DataSource = val2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Admin2>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label20.Visible = false;
            label12.Visible = false;
            label14.Visible = false;
            richTextBox1.Visible = false;
            IdentityNumber id = new IdentityNumber(txtID.Text);
            if(txtName.Text =="" || txtSur.Text == "" || txtID.Text == ""|| txtCell.Text =="" || txtEmail.Text =="" || comboBoxAdmin.SelectedItem == null || txtsalary.Text == "" || txtAddress.Text == "" || comboBoxActiv.SelectedItem == null || txtPassword.Text == "" || txtUsername.Text == "" || !id.IsValid )
            {
                label12.Visible = true;
                richTextBox1.Visible = true;
            }
            else
            {
                ///////////////////////CHECKS//////////////////
                bool isEmail = Regex.IsMatch(txtEmail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                bool isCell = Regex.IsMatch(txtCell.Text, @"^(?:\+?1[-. ]?)?\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");
                bool name = Regex.IsMatch(txtName.Text, @"^[a-zA-Z ]+$");
                bool sName = Regex.IsMatch(txtSur.Text, @"^[a-zA-Z ]+$");
                
                int exist;                
                
                exist = DAT.DataAccess.GetEmployee().Where(i => i.IDno == txtID.Text).ToList().Count;         
                
                //////////////////////CHECKS//////////////////
                if (!isEmail || !isCell || !name || !sName ||  exist != 0)
                {
                    if(exist != 0)
                    {
                        label20.Visible = true;
                    }
                    label12.Visible = true;
                    richTextBox1.Visible = true;

                }
                else
                {
                    if (DAT.DataAccess.GetEmployee().Where(i => i.Username == txtUsername.Text).ToList().Count > 0)
                    {
                        label14.Visible = true;
                    }
                    else
                    {
                        try
                        {

                            label14.Visible = false;
                            label12.Visible = false;
                            richTextBox1.Visible = false;
                            LTS.Employee emp = new LTS.Employee();
                            emp.Name = txtName.Text;
                            emp.Surname = txtSur.Text;
                            emp.IDno = txtID.Text;
                            emp.CellNo = txtCell.Text;
                            emp.Email = txtEmail.Text;
                            emp.EmpAddress = txtAddress.Text;
                            emp.Salary = Convert.ToDecimal(txtsalary.Text);
                            emp.Username = txtUsername.Text;
                            emp.Pass = txtPassword.Text;
                            emp.IsAdmin = Convert.ToBoolean(comboBoxAdmin.SelectedItem.ToString());
                            emp.Activated = Convert.ToBoolean(comboBoxActiv.SelectedItem.ToString());
                            int empID = DAT.DataAccess.AddEmployee(emp);
                            if (empID == -1)
                            {
                                if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the Employee Item was not Added!"))
                                {
                                    ((Form1)this.Parent.Parent).ChangeView<Employee>();
                                }

                            }
                            else
                            {
                                if (DialogResult.OK == MessageBox.Show("The Employee Item was added successfully!" + Environment.NewLine + "Employee ID:   " + empID.ToString()))
                                {
                                    ((Form1)this.Parent.Parent).ChangeView<Employee>();
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            label12.Visible = true;
                        }
                    }
                }
                    

            }
        }

        private void comboBoxAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
