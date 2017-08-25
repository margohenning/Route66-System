namespace Route66.Admin.Salaries
{
    partial class Calculate
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.CustomerBindingSourceC = new System.Windows.Forms.BindingSource(this.components);
            this.itspRouteDataSetFinal1 = new Route66.itspRouteDataSetFinal();
            this.EmployeeBindingSourceC = new System.Windows.Forms.BindingSource(this.components);
            this.StockBindingSourceC = new System.Windows.Forms.BindingSource(this.components);
            this.ReserveBindingSourceC = new System.Windows.Forms.BindingSource(this.components);
            this.SaleBindingSourceC = new System.Windows.Forms.BindingSource(this.components);
            this.SalesBindingSourceC = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblloggedInAs = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.employeeTableAdapter = new Route66.itspRouteDataSetFinalTableAdapters.EmployeeTableAdapter();
            this.customerTableAdapter = new Route66.itspRouteDataSetFinalTableAdapters.CustomerTableAdapter();
            this.salesTableAdapter = new Route66.itspRouteDataSetFinalTableAdapters.SalesTableAdapter();
            this.saleTableAdapter = new Route66.itspRouteDataSetFinalTableAdapters.SaleTableAdapter();
            this.stockTableAdapter = new Route66.itspRouteDataSetFinalTableAdapters.StockTableAdapter();
            this.reserveTableAdapter = new Route66.itspRouteDataSetFinalTableAdapters.ReserveTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBindingSourceC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itspRouteDataSetFinal1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeBindingSourceC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockBindingSourceC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReserveBindingSourceC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleBindingSourceC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesBindingSourceC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomerBindingSourceC
            // 
            this.CustomerBindingSourceC.DataMember = "Customer";
            this.CustomerBindingSourceC.DataSource = this.itspRouteDataSetFinal1;
            // 
            // itspRouteDataSetFinal1
            // 
            this.itspRouteDataSetFinal1.DataSetName = "itspRouteDataSetFinal";
            this.itspRouteDataSetFinal1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // EmployeeBindingSourceC
            // 
            this.EmployeeBindingSourceC.DataMember = "Employee";
            this.EmployeeBindingSourceC.DataSource = this.itspRouteDataSetFinal1;
            // 
            // StockBindingSourceC
            // 
            this.StockBindingSourceC.DataMember = "Stock";
            this.StockBindingSourceC.DataSource = this.itspRouteDataSetFinal1;
            // 
            // ReserveBindingSourceC
            // 
            this.ReserveBindingSourceC.DataMember = "Reserve";
            this.ReserveBindingSourceC.DataSource = this.itspRouteDataSetFinal1;
            // 
            // SaleBindingSourceC
            // 
            this.SaleBindingSourceC.DataMember = "Sale";
            this.SaleBindingSourceC.DataSource = this.itspRouteDataSetFinal1;
            // 
            // SalesBindingSourceC
            // 
            this.SalesBindingSourceC.DataMember = "Sales";
            this.SalesBindingSourceC.DataSource = this.itspRouteDataSetFinal1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(770, 586);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 25);
            this.label3.TabIndex = 47;
            this.label3.Text = "Back";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(846, 586);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 25);
            this.label2.TabIndex = 45;
            this.label2.Text = "Admin Home";
            // 
            // lblloggedInAs
            // 
            this.lblloggedInAs.AutoSize = true;
            this.lblloggedInAs.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblloggedInAs.Location = new System.Drawing.Point(223, 588);
            this.lblloggedInAs.Name = "lblloggedInAs";
            this.lblloggedInAs.Size = new System.Drawing.Size(31, 15);
            this.lblloggedInAs.TabIndex = 65;
            this.lblloggedInAs.Text = "who";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(118, 588);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 64;
            this.label1.Text = "Logged In as:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(47, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(368, 18);
            this.label5.TabIndex = 67;
            this.label5.Text = "Please fill in the following details and click Calculate.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(45, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(376, 25);
            this.label4.TabIndex = 66;
            this.label4.Text = "Calculate Commision for an Employee";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(49, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(250, 16);
            this.label6.TabIndex = 68;
            this.label6.Text = "Month and Year to calculate Commission:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(305, 83);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(233, 20);
            this.dateTimePicker1.TabIndex = 76;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(305, 109);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(233, 21);
            this.comboBox1.TabIndex = 77;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(47, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 16);
            this.label9.TabIndex = 71;
            this.label9.Text = "Select Employee ID:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(544, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 25);
            this.label11.TabIndex = 79;
            this.label11.Text = "Calculate";
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Route66.Properties.Resources.calculator;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(544, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 61);
            this.button2.TabIndex = 78;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::Route66.Properties.Resources.route66;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox5.Location = new System.Drawing.Point(16, 527);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(83, 76);
            this.pictureBox5.TabIndex = 63;
            this.pictureBox5.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Route66.Properties.Resources.back_arrow;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(748, 522);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 61);
            this.button1.TabIndex = 46;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::Route66.Properties.Resources.icon;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(856, 522);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(102, 61);
            this.button5.TabIndex = 44;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "Customer";
            reportDataSource1.Value = this.CustomerBindingSourceC;
            reportDataSource2.Name = "Employee";
            reportDataSource2.Value = this.EmployeeBindingSourceC;
            reportDataSource3.Name = "Stock";
            reportDataSource3.Value = this.StockBindingSourceC;
            reportDataSource4.Name = "Reserve";
            reportDataSource4.Value = this.ReserveBindingSourceC;
            reportDataSource5.Name = "Sale";
            reportDataSource5.Value = this.SaleBindingSourceC;
            reportDataSource6.Name = "Sales";
            reportDataSource6.Value = this.SalesBindingSourceC;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Route66.Admin.Salaries.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(52, 157);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(879, 352);
            this.reportViewer1.TabIndex = 98;
            // 
            // employeeTableAdapter
            // 
            this.employeeTableAdapter.ClearBeforeFill = true;
            // 
            // customerTableAdapter
            // 
            this.customerTableAdapter.ClearBeforeFill = true;
            // 
            // salesTableAdapter
            // 
            this.salesTableAdapter.ClearBeforeFill = true;
            // 
            // saleTableAdapter
            // 
            this.saleTableAdapter.ClearBeforeFill = true;
            // 
            // stockTableAdapter
            // 
            this.stockTableAdapter.ClearBeforeFill = true;
            // 
            // reserveTableAdapter
            // 
            this.reserveTableAdapter.ClearBeforeFill = true;
            // 
            // Calculate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblloggedInAs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button5);
            this.Name = "Calculate";
            this.Size = new System.Drawing.Size(983, 627);
            this.Load += new System.EventHandler(this.Calculate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBindingSourceC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itspRouteDataSetFinal1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeBindingSourceC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockBindingSourceC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReserveBindingSourceC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleBindingSourceC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesBindingSourceC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label lblloggedInAs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private itspRouteDataSetFinal itspRouteDataSetFinal1;
        private System.Windows.Forms.BindingSource EmployeeBindingSourceC;
        private itspRouteDataSetFinalTableAdapters.EmployeeTableAdapter employeeTableAdapter;
        private System.Windows.Forms.BindingSource CustomerBindingSourceC;
        private itspRouteDataSetFinalTableAdapters.CustomerTableAdapter customerTableAdapter;
        private System.Windows.Forms.BindingSource SalesBindingSourceC;
        private itspRouteDataSetFinalTableAdapters.SalesTableAdapter salesTableAdapter;
        private System.Windows.Forms.BindingSource SaleBindingSourceC;
        private itspRouteDataSetFinalTableAdapters.SaleTableAdapter saleTableAdapter;
        private System.Windows.Forms.BindingSource StockBindingSourceC;
        private itspRouteDataSetFinalTableAdapters.StockTableAdapter stockTableAdapter;
        private System.Windows.Forms.BindingSource ReserveBindingSourceC;
        private itspRouteDataSetFinalTableAdapters.ReserveTableAdapter reserveTableAdapter;
    }
}
