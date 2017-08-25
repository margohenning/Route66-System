using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Route66.Normal.Stock
{
    public partial class ViewStock1 : UserControl
    {
        string whatChecked = "";
        public ViewStock1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Stock1>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Normal2>();
        }

        private void ViewStock1_Load(object sender, EventArgs e)
        {
            lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;

            

            radioButton1.Checked = true;


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                whatChecked = "All";
                List<LTS.Stock> stock = new List<LTS.Stock>();
                stock = DAT.DataAccess.GetStock().ToList();
                for (int i = 0; i < stock.Count; i++)
                {
                    dataGridView1.Rows.Add(stock[i].VIN, stock[i].Make, stock[i].Model, stock[i].VehicleYear, stock[i].Price, stock[i].VehicleStatus);
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                whatChecked = "Available";
                List<LTS.Stock> stock = new List<LTS.Stock>();
                stock = DAT.DataAccess.GetStock().Where(i => i.VehicleStatus == "Available").ToList();
                for (int i = 0; i < stock.Count; i++)
                {
                    dataGridView1.Rows.Add(stock[i].VIN, stock[i].Make, stock[i].Model, stock[i].VehicleYear, stock[i].Price, stock[i].VehicleStatus);
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                whatChecked = "Reserved";
                List<LTS.Stock> stock = new List<LTS.Stock>();
                stock = DAT.DataAccess.GetStock().Where(i => i.VehicleStatus == "Reserved").ToList();
                for (int i = 0; i < stock.Count; i++)
                {
                    dataGridView1.Rows.Add(stock[i].VIN, stock[i].Make, stock[i].Model, stock[i].VehicleYear, stock[i].Price, stock[i].VehicleStatus);
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                whatChecked = "Sold";
                List<LTS.Stock> stock = new List<LTS.Stock>();
                stock = DAT.DataAccess.GetStock().Where(i => i.VehicleStatus == "Sold").ToList();
                for (int i = 0; i < stock.Count; i++)
                {
                    dataGridView1.Rows.Add(stock[i].VIN, stock[i].Make, stock[i].Model, stock[i].VehicleYear, stock[i].Price, stock[i].VehicleStatus);
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8);
            string folderPath = saveFileDialog1.FileName + ".pdf";


            //Creating iTextSharp Table from the DataTable data
            Document pdfDoc = new Document(PageSize.A4);

            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
            pdfTable.DefaultCell.Padding = dataGridView1.DefaultCellStyle.Padding.All;

            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 0;



            //Adding Header row
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // pdfTable.AddCell(cell.Value.ToString());
                    PdfPCell cellRows = new PdfPCell(new Phrase(cell.Value.ToString(), font));
                    int R = cell.Style.BackColor.R;
                    int G = cell.Style.BackColor.G;
                    int B = cell.Style.BackColor.B;
                    if (R == 0 && G == 0 && B == 0)
                    {
                        R = 255;
                        G = 255;
                        B = 255;
                    }
                    cellRows.BackgroundColor = new iTextSharp.text.BaseColor(R, G, B);
                    cellRows.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(cellRows);

                }
            }
            Paragraph writing = new iTextSharp.text.Paragraph("Route 66 Car Dealership " + Environment.NewLine + "Stock Information: " + whatChecked + "                " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine);

            using (FileStream stream = new FileStream(folderPath, FileMode.Create))
            {

                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(writing);
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
        }
    }
}
