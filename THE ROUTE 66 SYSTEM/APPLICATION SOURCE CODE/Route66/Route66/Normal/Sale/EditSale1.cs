using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Route66.Normal.Sale
{
    public partial class EditSale1 : UserControl
    {
        List<string> empIDs = new List<string>();
        List<string> cusID = new List<string>();
        List<string> vinID = new List<string>();
        int StockCount;
        
        public EditSale1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Sale1>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Normal2>();
        }

        private void EditSale1_Load(object sender, EventArgs e)
        {
            
            lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;
           
            
            List<string> emp = new List<string>();
            emp.Add("All");
            List<string> cus = new List<string>();
            cus.Add("All");
            List<string> vin = new List<string>();
            vin.Add("All");

            
            

            List<LTS.Employee> em = DAT.DataAccess.GetEmployee().ToList();
            for (int x = 0; x < em.Count; x++)
            {
                emp.Add(em[x].EmpID.ToString());
                empIDs.Add(em[x].EmpID.ToString()); ;
            }

            List<LTS.Customer> cu = DAT.DataAccess.GetCustomer().ToList();
            for (int x = 0; x < cu.Count; x++)
            {
                cus.Add(cu[x].IDno.ToString());
                cusID.Add(cu[x].IDno.ToString());
            }

            List<LTS.Stock> st = DAT.DataAccess.GetStock().ToList();
            for (int x = 0; x < st.Count; x++)
            {
                vin.Add(st[x].VIN.ToString());
                if(st[x].VehicleStatus == "Available")
                {
                    vinID.Add(st[x].VIN.ToString());
                }
                

            }

            List<string> pay = new List<string>();
            pay.Add("True");
            pay.Add("False");
            comboBoxp.DataSource = pay;
            comboBoxCUS.DataSource = cus;
            comboBoxEMP.DataSource = emp;
            comboBoxVIN.DataSource = vin;

            




            List<LTS.Sale> sale = new List<LTS.Sale>();
            sale = DAT.DataAccess.GetSale().ToList();
            for (int i = 0; i < sale.Count; i++)
            {
                string VIN = DAT.DataAccess.GetStock().Where(o => o.StockID == sale[i].StockID).FirstOrDefault().VIN;
                string cName = DAT.DataAccess.GetCustomer().Where(o => o.CustID == sale[i].CustID).FirstOrDefault().Name;
                string cSName = DAT.DataAccess.GetCustomer().Where(o => o.CustID == sale[i].CustID).FirstOrDefault().Surname;
                string cIDno = DAT.DataAccess.GetCustomer().Where(o => o.CustID == sale[i].CustID).FirstOrDefault().IDno;
                int empID = sale[i].EmpID;
                string eName = DAT.DataAccess.GetEmployee().Where(o => o.EmpID == empID).FirstOrDefault().Name;
                string eSName = DAT.DataAccess.GetEmployee().Where(o => o.EmpID == empID).FirstOrDefault().Surname;

                dataGridView1.Rows.Add(VIN,cIDno, cName, cSName, empID, eName, eSName, sale[i].SaleDate.ToString(), sale[i].Paid.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool edit;


            if (dataGridView1.SelectedRows == null)
            {
                label15.Visible = true;
            }
            else
            {
                if (comboBoxp.SelectedItem == null)
                {
                    label15.Visible = true;
                }
                else
                {
                    int sID = DAT.DataAccess.GetStock().Where(i => i.VIN == dataGridView1.SelectedRows[0].Cells[0].Value.ToString()).FirstOrDefault().StockID;
                    LTS.Sale s = new LTS.Sale();
                    s = DAT.DataAccess.GetSale().Where(i => i.StockID == sID).FirstOrDefault();
                    s.Paid = Convert.ToBoolean(comboBoxp.SelectedItem.ToString());
                    edit = DAT.DataAccess.UpdateSale(s);
                    if (edit)
                    {

                        if (DialogResult.OK == MessageBox.Show("Sale item edited successfully!"))
                        {
                            ((Form1)this.Parent.Parent).ChangeView<Sale1>();
                        }
                    }
                    else
                    {
                        if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the Sale item was not edited successfully!"))
                        {
                            ((Form1)this.Parent.Parent).ChangeView<Sale1>();
                        }
                    }
                }
            }


               


                
            




        }
               
        

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
         {
            if (dataGridView1.SelectedRows.Count >= 1)
            {
                using (DataGridViewRow item = this.dataGridView1.SelectedRows[0])
                {
                    int i = item.Index;
                    string VIN = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string custIDno = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string cName = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string cSur = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    string empID = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    string empName = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    string empSur = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    string saleDate = dataGridView1.Rows[i].Cells[7].Value.ToString();
                    string paid = dataGridView1.Rows[i].Cells[8].Value.ToString();

                    vin.Text = VIN;
                    sDate.Text = saleDate;
                    comboBoxp.SelectedIndex = comboBoxp.FindStringExact(paid);
                    cID.Text = custIDno;
                    cusName.Text = cName;
                    cusSur.Text = cSur;
                    eID.Text = empID;
                    eNa.Text = empName;
                    eSur.Text = empSur;






                }
            }
            else
            {

            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<LTS.Sale> theList = new List<LTS.Sale>();
            string emp = comboBoxEMP.SelectedItem.ToString();
            string vin = comboBoxVIN.SelectedItem.ToString();
            string cus = comboBoxCUS.SelectedItem.ToString();

            if (emp != "All")
            {
                theList = DAT.DataAccess.GetSale().Where(i => i.EmpID == Convert.ToInt32(emp)).ToList();
            }
            else
            {
                theList = DAT.DataAccess.GetSale().ToList();
            }

            if (vin != "All")
            {
                int stockID = DAT.DataAccess.GetStock().Where(o => o.VIN == vin).FirstOrDefault().StockID;
                theList = theList.Where(i => i.StockID == stockID).ToList();
            }
            else
            {

            }

            if (cus != "All")
            {
                int cusID = DAT.DataAccess.GetCustomer().Where(o => o.IDno == cus).FirstOrDefault().CustID;
                theList = theList.Where(i => i.CustID == cusID).ToList();
            }
            else
            {

            }


            for (int i = 0; i < theList.Count; i++)
            {
                string VIN = DAT.DataAccess.GetStock().Where(o => o.StockID == theList[i].StockID).FirstOrDefault().VIN;
                string cName = DAT.DataAccess.GetCustomer().Where(o => o.CustID == theList[i].CustID).FirstOrDefault().Name;
                string cSName = DAT.DataAccess.GetCustomer().Where(o => o.CustID == theList[i].CustID).FirstOrDefault().Surname;
                string cIDno = DAT.DataAccess.GetCustomer().Where(o => o.CustID == theList[i].CustID).FirstOrDefault().IDno;
                int empID = theList[i].EmpID;
                string eName = DAT.DataAccess.GetEmployee().Where(o => o.EmpID == empID).FirstOrDefault().Name;
                string eSName = DAT.DataAccess.GetEmployee().Where(o => o.EmpID == empID).FirstOrDefault().Surname;

                dataGridView1.Rows.Add(VIN,cIDno, cName, cSName, empID, eName, eSName, theList[i].SaleDate.ToString(), theList[i].Paid.ToString());
            }
        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 1)
            {
                using (DataGridViewRow item = this.dataGridView1.SelectedRows[0])
                {
                    int i = item.Index;
                    string VIN = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string custIDno = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string cName = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string cSur = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    string empID = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    string empName = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    string empSur = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    string saleDate = dataGridView1.Rows[i].Cells[7].Value.ToString();
                    string paid = dataGridView1.Rows[i].Cells[8].Value.ToString();

                    vin.Text = VIN;
                    sDate.Text = saleDate;
                    comboBoxp.SelectedIndex = comboBoxp.FindStringExact(paid);
                    cID.Text = custIDno;
                    cusName.Text = cName;
                    cusSur.Text = cSur;
                    eID.Text = empID;
                    eNa.Text = empName;
                    eSur.Text = empSur;






                }
            }
            else
            {

            }
        }
    }
}
