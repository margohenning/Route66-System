using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Route66.Admin.Stock
{
    public partial class RemoveStockA : UserControl
    {
        public RemoveStockA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<StockA>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Admin2>();
        }

        private void RemoveStock1_Load(object sender, EventArgs e)
        {
            lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;
            List<LTS.Stock> stock = new List<LTS.Stock>();
            stock = DAT.DataAccess.GetStock().Where(i=>i.VehicleStatus == "Available").ToList();
            for (int i = 0; i < stock.Count; i++)
            {
                dataGridView1.Rows.Add(stock[i].VIN, stock[i].Make, stock[i].Model, stock[i].VehicleYear, stock[i].Price, stock[i].VehicleStatus);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows == null)
            {

            }
            else
            {
                if (MessageBox.Show("Are You sure you want to remove this stock Item?" + Environment.NewLine + "The system records which user removes stock.", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string VIN;
                    using (DataGridViewRow item = this.dataGridView1.SelectedRows[0])
                    {
                        int i = item.Index;

                        LTS.StockRemoved removing = new LTS.StockRemoved();
                        removing.VIN = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        VIN = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        removing.EmpId = DAT.DataAccess.GetEmployee().Where(o => o.Username == lblloggedInAs.Text).FirstOrDefault().EmpID;
                        removing.DateRemoved = DateTime.Now;
                        DAT.DataAccess.AddStockRemoved(removing);
                        dataGridView1.Rows.RemoveAt(i);

                        bool removed =DAT.DataAccess.RemoveStock(DAT.DataAccess.GetStock().Where(o => o.VIN == VIN).FirstOrDefault().StockID);
                        if (removed)
                        {
                            if (DialogResult.OK == MessageBox.Show("Stock item removed successfully!"))
                            {
                                ((Form1)this.Parent.Parent).ChangeView<StockA>();
                            }
                        }
                        else
                        {
                            if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the stock item was not removed successfully!"))
                            {
                                ((Form1)this.Parent.Parent).ChangeView<StockA>();
                            }
                        }

                    }
                }
                else { }
            }
            
        }
    }
}
