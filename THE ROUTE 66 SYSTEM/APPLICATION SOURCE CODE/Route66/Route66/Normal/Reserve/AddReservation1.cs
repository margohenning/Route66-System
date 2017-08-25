using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Utilities.SouthAfrica;

namespace Route66.Normal.Reserve
{
    public partial class AddReservation1 : UserControl
    {
        public AddReservation1()
        {
            InitializeComponent();
        }

        private void AddReservation1_Load(object sender, EventArgs e)
        {
            lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;
            List<LTS.Stock> VIN = new List<LTS.Stock>();
            VIN = DAT.DataAccess.GetStock().Where(i => i.VehicleStatus == "Available").ToList();
            List<string> V = new List<string>();

            for (int x = 0; x < VIN.Count; x++)
            {
                V.Add(VIN[x].VIN);
            }
            VID.DataSource = V;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Normal2>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Reserve1>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label17.Visible = false;
            richTextBox1.Visible = false;
            if (VID.SelectedItem == null || email.Text == "" || cell.Text == "" || PID.Text == "" || Surname.Text == "" || Pname.Text == "")
            {
                label17.Visible = true;
                richTextBox1.Visible = true;
            }
            else
            {
                ///////////////////////CHECKS//////////////////
                bool isEmail = Regex.IsMatch(email.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                bool isCell = Regex.IsMatch(cell.Text, @"^(?:\+?1[-. ]?)?\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");
                bool name = Regex.IsMatch(Pname.Text, @"^[a-zA-Z ]+$");
                bool sName = Regex.IsMatch(Surname.Text, @"^[a-zA-Z ]+$");
                IdentityNumber id = new IdentityNumber(PID.Text);
                bool IDVALID = id.IsValid;

                //////////////////////CHECKS//////////////////
                if (!isEmail || !isCell || !name || !sName || !IDVALID)
                {
                    label17.Visible = true;
                    richTextBox1.Visible = true;
                }
                else
                {

                    LTS.Reserve r = new LTS.Reserve();
                    r.StockID = DAT.DataAccess.GetStock().Where(i => i.VIN == VID.SelectedItem.ToString()).FirstOrDefault().StockID;
                    r.Name = Pname.Text;
                    r.Surname = Surname.Text;
                    r.IDno = PID.Text;
                    r.CellNo = cell.Text;
                    r.Email = email.Text;
                    r.ResDate = DateTime.Now;

                    int RID = DAT.DataAccess.AddReserve(r);

                    int stockID;
                    string status;

                    string oldVIN = VID.SelectedItem.ToString();


                    stockID = DAT.DataAccess.GetStock().Where(i => i.VIN == VID.SelectedItem.ToString()).FirstOrDefault().StockID;


                    try
                    {
                        LTS.Stock newStock = new LTS.Stock();
                        newStock.StockID = stockID;
                        newStock.Make = DAT.DataAccess.GetStock().Where(i => i.StockID == stockID).FirstOrDefault().Make;
                        newStock.Model = DAT.DataAccess.GetStock().Where(i => i.StockID == stockID).FirstOrDefault().Model;
                        newStock.Price = DAT.DataAccess.GetStock().Where(i => i.StockID == stockID).FirstOrDefault().Price;
                        newStock.VehicleStatus = "Reserved";
                        newStock.VehicleYear = DAT.DataAccess.GetStock().Where(i => i.StockID == stockID).FirstOrDefault().VehicleYear;
                        newStock.VIN = DAT.DataAccess.GetStock().Where(i => i.StockID == stockID).FirstOrDefault().VIN;
                        bool updated = DAT.DataAccess.UpdateStock(newStock);
                        if (RID > 0 && updated == true)
                        {

                            if (DialogResult.OK == MessageBox.Show("The Reservation was made successfully!"))
                            {
                                ((Form1)this.Parent.Parent).ChangeView<Reserve1>();
                            }
                            else
                            {
                                if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the Reservation was not made!"))
                                {
                                    ((Form1)this.Parent.Parent).ChangeView<Reserve1>();
                                }

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        label17.Visible = true;
                        richTextBox1.Visible = true;
                    }
                }
            }
        }
    }
}
