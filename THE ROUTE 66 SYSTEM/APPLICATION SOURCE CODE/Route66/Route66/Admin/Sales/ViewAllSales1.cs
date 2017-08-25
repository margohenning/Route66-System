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

namespace Route66.Admin.Sales
{
    public partial class ViewAllSales1 : UserControl
    {
        string empSelect ="All";
        string vinSelect = "All";
        string cusSelect = "All";
        public ViewAllSales1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<AllSales1>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Admin2>();
        }

        private void ViewSales1_Load(object sender, EventArgs e)
        {
            lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;

            List<string> emp = new List<string>();
            emp.Add("All");
            List<string> cus = new List<string>();
            cus.Add("All");
            List<string> vin = new List<string>();
            vin.Add("All");

            List<LTS.Employee> em = DAT.DataAccess.GetEmployee().ToList();
            for(int x = 0; x < em.Count; x++)
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
            Paragraph writing = new iTextSharp.text.Paragraph("Route 66 Car Dealership " + Environment.NewLine + "Sales Information                " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine + "Employee: " + empSelect + Environment.NewLine + "Customer: " + cusSelect + Environment.NewLine  + "Vehicle ID Number: " + vinSelect + Environment.NewLine + Environment.NewLine);

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

        private void btnlogin_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<LTS.Sale> theList = new List<LTS.Sale>();
            string emp = comboBoxEMP.SelectedItem.ToString();
            string vin = comboBoxVIN.SelectedItem.ToString();
            string cus = comboBoxCUS.SelectedItem.ToString();
            empSelect = emp;
            vinSelect = vin;
            cusSelect =cus;

            if (emp != "All")
            {
                theList = DAT.DataAccess.GetSale().Where(i => i.EmpID == Convert.ToInt32(emp)).ToList();                
            }
            else
            {
                theList = DAT.DataAccess.GetSale().ToList();
            }

            if(vin != "All")
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
