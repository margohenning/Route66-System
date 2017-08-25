using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Route66.Admin.Employees
{
    public partial class RemoveEmployee : UserControl
    {
        public RemoveEmployee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Employee>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Admin2>();
        }

        private void RemoveStock1_Load(object sender, EventArgs e)
        {
            lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;
            List<LTS.Employee> emp = new List<LTS.Employee>();
            emp = DAT.DataAccess.GetEmployee().Where(i => i.Activated == true).ToList();
            for (int i = 0; i < emp.Count; i++)
            {
                dataGridView1.Rows.Add(emp[i].EmpID, emp[i].Name, emp[i].Surname, emp[i].IDno, emp[i].CellNo, emp[i].Email, emp[i].EmpAddress, emp[i].Salary, emp[i].IsAdmin);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows == null)
            {

            }
            else
            {
                if (MessageBox.Show("Are You sure you want to remove this employee Item?" , "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string empID;
                    using (DataGridViewRow item = this.dataGridView1.SelectedRows[0])
                    {
                        int i = item.Index;

                        
                        empID = dataGridView1.Rows[i].Cells[0].Value.ToString();

                        LTS.Employee employee = new LTS.Employee();
                        employee = DAT.DataAccess.GetEmployee().Where(it => it.EmpID == Convert.ToInt32(empID)).FirstOrDefault();
                        employee.Activated = false;
                        bool updated = DAT.DataAccess.UpdateEmployee(employee);

                        
                        if (updated)
                        {
                            if (DialogResult.OK == MessageBox.Show("Employee item removed successfully!"))
                            {
                                ((Form1)this.Parent.Parent).ChangeView<Employee>();
                            }
                        }
                        else
                        {
                            if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the employee item was not removed successfully!"))
                            {
                                ((Form1)this.Parent.Parent).ChangeView<Employee>();
                            }
                        }

                    }
                }
                else { }
            }
            
        }
    }
}
