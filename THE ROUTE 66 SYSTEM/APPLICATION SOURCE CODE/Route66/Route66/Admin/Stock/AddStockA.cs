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
    public partial class AddStockA : UserControl
    {
        public AddStockA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<StockA>();
        }

        private void AddStock1_Load(object sender, EventArgs e)
        {
            lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;
            List<string> status = new List<string>();
            status.Add("Reserved");
            status.Add("Available");
            status.Add("Sold");
            comboBox1.DataSource = status;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Admin2>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(VIN.Text =="" || Make.Text == "" || Model.Text == ""|| Year.Text =="" || Price.Text =="" || comboBox1.SelectedItem == null)
            {
                label12.Visible = true;
                richTextBox1.Visible = true;
            }
            else
            {
                if (DAT.DataAccess.GetStock().Where(i => i.VIN == VIN.Text).ToList().Count > 0)
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
                        LTS.Stock stock = new LTS.Stock();
                        stock.VIN = VIN.Text.ToUpper();
                        stock.VehicleYear = Year.Text;
                        stock.Model = Model.Text;
                        stock.Make = Make.Text;
                        stock.VehicleStatus = comboBox1.SelectedItem.ToString();
                        stock.Price = Decimal.Parse(Price.Text);
                        int stockID = DAT.DataAccess.AddStock(stock);
                        if (stockID == -1)
                        {
                            if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the Stock Item was not Added!"))
                            {
                                ((Form1)this.Parent.Parent).ChangeView<StockA>();
                            }

                        }
                        else
                        {
                            if (DialogResult.OK == MessageBox.Show("The Stock Item was added successfully!"))
                            {
                                ((Form1)this.Parent.Parent).ChangeView<StockA>();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        label12.Visible = true;
                        richTextBox1.Visible = true;
                    }
                }

            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
