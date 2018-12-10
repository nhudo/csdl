namespace QuanLySieuThi
{
    partial class HoaDon
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HoaDon));
            this.BANHANGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QLsieuthiDataSet1 = new QuanLySieuThi.QLsieuthiDataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BANHANGTableAdapter = new QuanLySieuThi.QLsieuthiDataSet1TableAdapters.BANHANGTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.BANHANGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLsieuthiDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // BANHANGBindingSource
            // 
            this.BANHANGBindingSource.DataMember = "BANHANG";
            this.BANHANGBindingSource.DataSource = this.QLsieuthiDataSet1;
            // 
            // QLsieuthiDataSet1
            // 
            this.QLsieuthiDataSet1.DataSetName = "QLsieuthiDataSet1";
            this.QLsieuthiDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.BANHANGBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLySieuThi.ReportHoaDon.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(419, 457);
            this.reportViewer1.TabIndex = 0;
            // 
            // BANHANGTableAdapter
            // 
            this.BANHANGTableAdapter.ClearBeforeFill = true;
            // 
            // HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 457);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HoaDon";
            this.Text = "Hóa Đơn Bán Hàng";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HoaDon_FormClosed);
            this.Load += new System.EventHandler(this.HoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BANHANGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLsieuthiDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BANHANGBindingSource;
        private QLsieuthiDataSet1 QLsieuthiDataSet1;
        private QLsieuthiDataSet1TableAdapters.BANHANGTableAdapter BANHANGTableAdapter;
    }
}