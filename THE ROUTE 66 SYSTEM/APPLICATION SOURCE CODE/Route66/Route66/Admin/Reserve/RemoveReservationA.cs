using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Route66.Admin.Reserve
{
    public partial class RemoveReservationA : UserControl
    {
        public RemoveReservationA()
        {
            InitializeComponent();
        }

        private void RemoveReservation_Load(object sender, EventArgs e)
        {
            lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;
            List<LTS.Reserve> reserve = new List<LTS.Reserve>();
            reserve = DAT.DataAccess.GetReserve().ToList();
            for (int i = 0; i < reserve.Count; i++)
            {
                dataGridView1.Rows.Add(DAT.DataAccess.GetStock().Where(o => o.StockID == reserve[i].StockID).FirstOrDefault().VIN, reserve[i].Name, reserve[i].Surname, reserve[i].IDno, reserve[i].CellNo, reserve[i].Email, reserve[i].ResDate);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Admin2>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<ReserveA>();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows == null)
            {

            }
            else
            {
                if (MessageBox.Show("Are You sure you want to remove this reservation?" , "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string VIN;
                    using (DataGridViewRow item = this.dataGridView1.SelectedRows[0])
                    {
                        int i = item.Index;
                        VIN = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        int stockID = DAT.DataAccess.GetStock().Where(o => o.VIN == VIN).FirstOrDefault().StockID;

                        int ID = DAT.DataAccess.GetReserve().Where(o => o.StockID == stockID).FirstOrDefault().ResID;
                        dataGridView1.Rows.RemoveAt(i);
                        bool removed =DAT.DataAccess.RemoveReserve(ID);
                        try
                        {
                            LTS.Stock newStock = new LTS.Stock();
                            newStock.StockID = stockID;
                            newStock.Make = DAT.DataAccess.GetStock().Where(o => o.StockID == stockID).FirstOrDefault().Make;
                            newStock.Model = DAT.DataAccess.GetStock().Where(o => o.StockID == stockID).FirstOrDefault().Model;
                            newStock.Price = DAT.DataAccess.GetStock().Where(o => o.StockID == stockID).FirstOrDefault().Price;
                            newStock.VehicleStatus = "Available";
                            newStock.VehicleYear = DAT.DataAccess.GetStock().Where(o => o.StockID == stockID).FirstOrDefault().VehicleYear;
                            newStock.VIN = DAT.DataAccess.GetStock().Where(o => o.StockID == stockID).FirstOrDefault().VIN;
                            bool updated = DAT.DataAccess.UpdateStock(newStock);

                            if (removed && updated)
                            {
                                if (DialogResult.OK == MessageBox.Show("Reservation removed successfully!"))
                                {
                                    ((Form1)this.Parent.Parent).ChangeView<ReserveA>();
                                }
                            }
                            else
                            {
                                if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the Reservation was not removed successfully!"))
                                {
                                    ((Form1)this.Parent.Parent).ChangeView<ReserveA>();
                                }
                            }

                        }
                        catch(Exception ex)
                        {

                        }
                            

                    }
                }
                else { }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
