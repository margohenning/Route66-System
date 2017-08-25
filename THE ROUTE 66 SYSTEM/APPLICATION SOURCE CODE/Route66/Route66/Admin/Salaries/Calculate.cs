using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;
using System.Text.RegularExpressions;

namespace Route66.Admin.Salaries
{
    public partial class Calculate : UserControl
    {
        double comPercentage;
        double totalCommission;
        int year;
        int month;
        DateTime MonthYear;
        int EMPID;
        string saleCount;
        int path =1;
        List<string> empl = new List<string>();
        public Calculate()
        {
            InitializeComponent();
        }
        
        private void Calculate_Load(object sender, EventArgs e)
        {
            lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/yyyy";
            List<LTS.Employee> emp = DAT.DataAccess.GetEmployee().ToList();
            
            for (int x = 0; x < emp.Count; x++)
            {
                empl.Add(emp[x].EmpID.ToString());
            }
            

            comboBox1.DataSource = empl;


        }

        private void button5_Click(object sender, EventArgs e)
        {
             ((Form1)this.Parent.Parent).ChangeView<Admin2>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Salaries1>();
        }

        

        



private void button2_Click(object sender, EventArgs e)
        {
            reportViewer1.Visible = true;
            
            if (comboBox1.SelectedItem == null || dateTimePicker1.Value == null)
            {

            }
            else
            {
                
                    comPercentage = 5;
                    totalCommission = 0;
                    year = dateTimePicker1.Value.Year;
                    month = dateTimePicker1.Value.Month;
                    MonthYear = new DateTime(year, month, 1).Date;
                    string dateS = MonthYear.ToString("MM/yyyy");
                    // MonthYear = Convert.ToDateTime(MonthYear.ToShortDateString());
                    EMPID = Convert.ToInt32(comboBox1.SelectedItem.ToString());

                        List<LTS.Sale> t = DAT.DataAccess.GetSale().Where(i => i.Paid == true && i.EmpID == EMPID && i.SaleDate.Month == MonthYear.Month && i.SaleDate.Year == MonthYear.Year).ToList();
                        saleCount = t.Count.ToString();
                        for (int x = 0; x < t.Count; x++)
                        {
                            totalCommission += Convert.ToDouble(DAT.DataAccess.GetStock().Where(j => j.StockID == t[x].StockID).FirstOrDefault().Price) * (comPercentage / 100);
                        }

                        ReportParameter empID = new ReportParameter("EmpID", EMPID.ToString());
                        reportViewer1.LocalReport.SetParameters(empID);

                        ReportParameter MY = new ReportParameter("MonthYear", MonthYear.ToString());
                        reportViewer1.LocalReport.SetParameters(MY);

                        ReportParameter date = new ReportParameter("DateString", dateS.ToString());
                        reportViewer1.LocalReport.SetParameters(date);

                        ReportParameter tc = new ReportParameter("TotalCommision", totalCommission.ToString());
                        reportViewer1.LocalReport.SetParameters(tc);

                        ReportParameter comP = new ReportParameter("PercentageCom", comPercentage.ToString());
                        reportViewer1.LocalReport.SetParameters(comP);

                        ReportParameter s = new ReportParameter("SaleCount", saleCount);
                        reportViewer1.LocalReport.SetParameters(s);

                        this.employeeTableAdapter.Fill(itspRouteDataSetFinal1.Employee, EMPID);
                        this.salesTableAdapter.Fill(itspRouteDataSetFinal1.Sales, EMPID, MonthYear);
                        this.salesTableAdapter.Fill(itspRouteDataSetFinal1.Sales, EMPID, MonthYear);

                        this.reportViewer1.RefreshReport();

                        

                       

                    
                   
                   
                    




                }
                
            }
            }

}
