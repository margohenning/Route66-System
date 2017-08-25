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
using System.Globalization;

namespace Route66.Admin
{
    public partial class SystemReport : UserControl
    {
        public SystemReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Admin2>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent.Parent).ChangeView<Admin2>();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            lblloggedInAs.Text = ((Form1)this.Parent.Parent).loggedIn;
            this.employeeAllTableAdapter1.Fill(itspRouteDataSetFinal1.EmployeeAll);
            this.stockTableAdapter1.Fill(itspRouteDataSetFinal1.Stock);
            this.saleAllTableAdapter1.Fill(itspRouteDataSetFinal1.SaleAll);
            this.inActiveEmpTableAdapter1.Fill(itspRouteDataSetFinal1.InActiveEmp);
            this.activeEmpTableAdapter1.Fill(itspRouteDataSetFinal1.ActiveEmp);
            this.salesAllTableAdapter1.Fill(itspRouteDataSetFinal1.SalesAll);
            this.customerTableAdapter1.Fill(itspRouteDataSetFinal1.Customer);
            this.reserveTableAdapter1.Fill(itspRouteDataSetFinal1.Reserve);
            this.stockRemovedTableAdapter1.Fill(itspRouteDataSetFinal1.StockRemoved);
            this.reportViewer1.RefreshReport();



        }

        private void button2_Click(object sender, EventArgs e)
        {
           

                

               

               

                

               
            
                




            }

        }

       
    
}
