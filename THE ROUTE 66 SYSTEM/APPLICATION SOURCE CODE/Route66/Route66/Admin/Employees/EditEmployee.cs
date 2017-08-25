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
    public partial class EditEmployee : UserControl
    {
        string oldeID;
        //can not edit the stock status here, use app functionality to do that,(make sale) (reserve)
        public EditEmployee()
        {
            InitializeComponent();
            List<string> val1 = new List<string>();
            val1.Add("True");
            val1.Add("False");

            List<string> val2 = new List<string>();
            val2.Add("True");
            val2.Add("False");
            comboBoxActiv.DataSource = val1;
            comboBoxAdmin.DataSource = val2; 
        }
        
        private void EditStock1_Load(object sender, EventArgs e)
        {
            lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Employee>();
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
                    string emp = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    em.Text = emp;
                    txtName.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    txtSur.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    txtID.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    oldeID = txtID.Text;
                    txtCell.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    txtAddress.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    txtEmail.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    txtsalary.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
                    if(dataGridView1.Rows[i].Cells[8].Value.ToString() == "True")
                    {
                        comboBoxAdmin.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBoxAdmin.SelectedIndex = 1;
                    }
                    if (dataGridView1.Rows[i].Cells[9].Value.ToString() == "True")
                    {
                        comboBoxActiv.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBoxActiv.SelectedIndex = 1;
                    }

                    txtUsername.Text = DAT.DataAccess.GetEmployee().Where(o => o.EmpID == Convert.ToInt32(emp)).FirstOrDefault().Username;
                    txtPassword.Text = DAT.DataAccess.GetEmployee().Where(o => o.EmpID == Convert.ToInt32(emp)).FirstOrDefault().Pass;

                }
            }
            else
            {

            }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            error.Visible = false;
            richTextBox1.Visible = false;
            label22.Visible = false;
            IdentityNumber id = new IdentityNumber(txtID.Text);
            
            if (txtName.Text == "" || txtSur.Text == "" || txtID.Text == "" || txtCell.Text == "" || txtEmail.Text == "" || txtAddress.Text == "" ||txtsalary.Text == "" || txtUsername.Text == "" || txtPassword.Text =="" || comboBoxActiv.SelectedItem.ToString()=="" || comboBoxAdmin.SelectedItem.ToString()=="" || !id.IsValid) 
            {
                error.Visible = true;
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
                if (oldeID == txtID.Text)
                {
                    exist = 0;
                }
                else
                {
                    exist = DAT.DataAccess.GetEmployee().Where(i => i.IDno == txtID.Text).ToList().Count;
                }
                

                //////////////////////CHECKS//////////////////
                if (!isEmail || !isCell || !name || !sName || exist != 0)
                {
                    if (exist != 0)
                    {
                        label22.Visible = true;
                    }
                    error.Visible = true;
                    richTextBox1.Visible = true;

                }
                else
                {

                    try
                    {
                        LTS.Employee newEmp = new LTS.Employee();
                        newEmp.EmpID = Convert.ToInt32(em.Text);
                        newEmp.Name = txtName.Text;
                        newEmp.Surname = txtSur.Text;
                        newEmp.IDno = txtID.Text;
                        newEmp.CellNo = txtCell.Text;
                        newEmp.Email = txtEmail.Text;
                        newEmp.EmpAddress = txtAddress.Text;
                        newEmp.Salary = Convert.ToDecimal(txtsalary.Text);
                        newEmp.IsAdmin = Convert.ToBoolean(comboBoxAdmin.SelectedItem);
                        newEmp.Username = txtUsername.Text;
                        newEmp.Pass = txtPassword.Text;
                        newEmp.Activated = Convert.ToBoolean(comboBoxActiv.SelectedItem);
                        bool updated = DAT.DataAccess.UpdateEmployee(newEmp);
                        if (updated)
                        {

                            if (DialogResult.OK == MessageBox.Show("Employee item edited successfully!"))
                            {
                                ((Form1)this.Parent.Parent).ChangeView<Employee>();
                            }
                        }
                        else
                        {
                            if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the Employee item was not edited successfully!"))
                            {
                                ((Form1)this.Parent.Parent).ChangeView<Employee>();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        error.Visible = true;
                        richTextBox1.Visible = true;
                    }
                }


            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (radioButton1.Checked == true)
            {
                
                List<LTS.Employee> emp = new List<LTS.Employee>();
                emp = DAT.DataAccess.GetEmployee().Where(i => i.Activated == true).ToList();
                for (int i = 0; i < emp.Count; i++)
                {
                    dataGridView1.Rows.Add(emp[i].EmpID, emp[i].Name, emp[i].Surname, emp[i].IDno, emp[i].CellNo, emp[i].Email, emp[i].EmpAddress, emp[i].Salary, emp[i].IsAdmin, emp[i].Activated);
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (radioButton2.Checked == true)
            {
                
                List<LTS.Employee> emp = new List<LTS.Employee>();
                emp = DAT.DataAccess.GetEmployee().Where(i => i.Activated == false).ToList();
                for (int i = 0; i < emp.Count; i++)
                {
                    dataGridView1.Rows.Add(emp[i].EmpID, emp[i].Name, emp[i].Surname, emp[i].IDno, emp[i].CellNo, emp[i].Email, emp[i].EmpAddress, emp[i].Salary, emp[i].IsAdmin, emp[i].Activated);
                }
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (radioButton3.Checked == true)
            {
                //whatChecked = "All";
                List<LTS.Employee> emp = new List<LTS.Employee>();
                emp = DAT.DataAccess.GetEmployee().ToList();
                for (int i = 0; i < emp.Count; i++)
                {
                    dataGridView1.Rows.Add(emp[i].EmpID, emp[i].Name, emp[i].Surname, emp[i].IDno, emp[i].CellNo, emp[i].Email, emp[i].EmpAddress, emp[i].Salary, emp[i].IsAdmin, emp[i].Activated);
                }
            }
        }
    }
    }

