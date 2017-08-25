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
    public partial class EditReservation : UserControl
    {
        public EditReservation()
        {
            InitializeComponent();
        }

        private void EditReservation_Load(object sender, EventArgs e)
        {
            lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;
            

            List<LTS.Reserve> reserve = new List<LTS.Reserve>();
            reserve = DAT.DataAccess.GetReserve().ToList();
            for (int i = 0; i < reserve.Count; i++)
            {
                dataGridView1.Rows.Add(DAT.DataAccess.GetStock().Where(o => o.StockID == reserve[i].StockID).FirstOrDefault().VIN, reserve[i].Name, reserve[i].Surname, reserve[i].IDno, reserve[i].CellNo, reserve[i].Email, reserve[i].ResDate);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Reserve1>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Normal2>();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                using (DataGridViewRow item = this.dataGridView1.SelectedRows[0])
                {
                    int i = item.Index;

                    VINText.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    Namep.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    surnameP.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    PID.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    cell.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    mail.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();

                    

                   


                }
            }
            else
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label18.Visible = false;
            richTextBox1.Visible = false;
            if (Namep.Text == "" || surnameP.Text == "" || PID.Text == "" || cell.Text == ""|| mail.Text =="" )
            {
                label18.Visible = true;
                richTextBox1.Visible = true;
            }
            else
            {
                ///////////////////////CHECKS//////////////////
                bool isEmail = Regex.IsMatch(mail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                bool isCell = Regex.IsMatch(cell.Text, @"^(?:\+?1[-. ]?)?\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");
                bool name = Regex.IsMatch(Namep.Text, @"^[a-zA-Z ]+$");
                bool sName = Regex.IsMatch(surnameP.Text, @"^[a-zA-Z ]+$");
                IdentityNumber id = new IdentityNumber(PID.Text);
                bool IDVALID = id.IsValid;

                //////////////////////CHECKS//////////////////
                if (!isEmail || !isCell || !name || !sName || !IDVALID)
                {
                    label18.Visible = true;
                    richTextBox1.Visible = true;
                }
                else
                {
                    int stockID;
                    using (DataGridViewRow item = this.dataGridView1.SelectedRows[0])
                    {
                        int i = item.Index;
                        string oldVIN = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        stockID = DAT.DataAccess.GetStock().Where(o => o.VIN == oldVIN).FirstOrDefault().StockID;

                    }
                    try
                    {
                        LTS.Reserve res = new LTS.Reserve();
                        res.ResID = DAT.DataAccess.GetReserve().Where(o => o.StockID == stockID).FirstOrDefault().ResID;
                        res.StockID = stockID;
                        res.Name = Namep.Text;
                        res.Surname = surnameP.Text;
                        res.IDno = PID.Text;
                        res.CellNo = cell.Text;
                        res.Email = mail.Text;
                        res.ResDate = DAT.DataAccess.GetReserve().Where(o => o.StockID == stockID).FirstOrDefault().ResDate;
                        bool updated = DAT.DataAccess.UpdateReserve(res);
                        if (updated)
                        {

                            if (DialogResult.OK == MessageBox.Show("Reservation edited successfully!"))
                            {
                                ((Form1)this.Parent.Parent).ChangeView<Reserve1>();
                            }
                        }
                        else
                        {
                            if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the Reservation was not edited successfully!"))
                            {
                                ((Form1)this.Parent.Parent).ChangeView<Reserve1>();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        label18.Visible = true;
                        richTextBox1.Visible = true;
                    }
                }

            }

        
    }
    }
    }

