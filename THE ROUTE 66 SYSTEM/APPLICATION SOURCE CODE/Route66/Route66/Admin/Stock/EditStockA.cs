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
    public partial class EditStockA : UserControl
    {
        //can not edit the stock status here, use app functionality to do that,(make sale) (reserve)
        public EditStockA()
        {
            InitializeComponent();
        }

        private void EditStock1_Load(object sender, EventArgs e)
        {
            lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;
            List<LTS.Stock> stock = new List<LTS.Stock>();
            stock = DAT.DataAccess.GetStock().ToList();
            for (int i = 0; i < stock.Count; i++)
            {
                dataGridView1.Rows.Add(stock[i].VIN, stock[i].Make, stock[i].Model, stock[i].VehicleYear, stock[i].Price, stock[i].VehicleStatus);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<StockA>();
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

                    VINtext.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    MakeText.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    ModelText.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    YearText.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    PriceText.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();

                }
            }
            else
            {

            }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            label16.Visible = false;
            richTextBox1.Visible = false;
            if (VINtext.Text ==""|| ModelText.Text =="" || MakeText.Text =="" || PriceText.Text =="" || YearText.Text =="" )
            {
                label16.Visible = true;
                richTextBox1.Visible = true;
            }
            else {
                int stockID;
                string status;
                using (DataGridViewRow item = this.dataGridView1.SelectedRows[0])
                {
                    int i = item.Index;

                    string oldVIN = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    status = dataGridView1.Rows[i].Cells[5].Value.ToString();

                    stockID = DAT.DataAccess.GetStock().Where(o => o.VIN == oldVIN).FirstOrDefault().StockID;
                    //MakeText.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    //ModelText.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    //YearText.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    //PriceText.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();

                }
                try {
                    LTS.Stock newStock = new LTS.Stock();
                    newStock.StockID = stockID;
                    newStock.Make = MakeText.Text;
                    newStock.Model = ModelText.Text;
                    newStock.Price = Decimal.Parse(PriceText.Text);
                    newStock.VehicleStatus = status;
                    newStock.VehicleYear = YearText.Text;
                    newStock.VIN = VINtext.Text;
                   bool updated =  DAT.DataAccess.UpdateStock(newStock);
                    if (updated)
                    {

                        if (DialogResult.OK == MessageBox.Show("Stock item edited successfully!"))
                        {
                            ((Form1)this.Parent.Parent).ChangeView<StockA>();
                        }
                    }
                    else
                    {
                        if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the stock item was not edited successfully!"))
                        {
                            ((Form1)this.Parent.Parent).ChangeView<StockA>();
                        }
                    }
                }
                catch (Exception ex)
                {
                    label16.Visible = true;
                    richTextBox1.Visible = true;
                }

            }
            
        }
    }
    }

