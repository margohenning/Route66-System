using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Route66.Admin.Sales
{
    public partial class RemoveAllSales1 : UserControl
    {
        public RemoveAllSales1()
        {
            InitializeComponent();
        }

        private void RemoveSale1_Load(object sender, EventArgs e)
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
            }

            List<LTS.Customer> cu = DAT.DataAccess.GetCustomer().ToList();
            for (int x = 0; x < cu.Count; x++)
            {
                cus.Add(cu[x].IDno.ToString());
            }

            List<LTS.Stock> st = DAT.DataAccess.GetStock().ToList();
            for (int x = 0; x < st.Count; x++)
            {
                vin.Add(st[x].VIN.ToString());

            }

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
                int empID = sale[i].EmpID;
                string eName = DAT.DataAccess.GetEmployee().Where(o => o.EmpID == empID).FirstOrDefault().Name;
                string eSName = DAT.DataAccess.GetEmployee().Where(o => o.EmpID == empID).FirstOrDefault().Surname;
                string paid = sale[i].Paid.ToString();
                dataGridView1.Rows.Add(VIN, cName, cSName, empID, eName, eSName, sale[i].SaleDate.ToString(),paid);
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows == null)
            {

            }
            else
            {
                if (MessageBox.Show("Are You sure you want to remove this sale Item?" , "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string VIN;
                    using (DataGridViewRow item = this.dataGridView1.SelectedRows[0])
                    {
                        int i = item.Index;
                        VIN = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        int StockID = DAT.DataAccess.GetStock().Where(o => o.VIN == VIN).FirstOrDefault().StockID;
                        int saleID = DAT.DataAccess.GetSale().Where(o => o.StockID == StockID).FirstOrDefault().SaleID;
                        bool removed = DAT.DataAccess.RemoveSale(saleID);

                        LTS.Stock s = DAT.DataAccess.GetStock().Where(u => u.VIN == VIN).FirstOrDefault();
                        s.VehicleStatus = "Available";
                        bool updated = DAT.DataAccess.UpdateStock(s);

                        
                        if (removed && updated)
                        {
                            if (DialogResult.OK == MessageBox.Show("Sale item removed successfully!"))
                            {
                                ((Form1)this.Parent.Parent).ChangeView<AllSales1>();
                            }
                        }
                        else
                        {
                            if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the sale item was not removed successfully!"))
                            {
                                ((Form1)this.Parent.Parent).ChangeView<AllSales1>();
                            }
                        }

                    }
                }
                else { }
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
                int empID = theList[i].EmpID;
                string eName = DAT.DataAccess.GetEmployee().Where(o => o.EmpID == empID).FirstOrDefault().Name;
                string eSName = DAT.DataAccess.GetEmployee().Where(o => o.EmpID == empID).FirstOrDefault().Surname;

                dataGridView1.Rows.Add(VIN, cName, cSName, empID, eName, eSName, theList[i].SaleDate.ToString(), theList[i].Paid);
            }
        }
    }

}

