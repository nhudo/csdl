namespace QuanLySieuThi
{
    partial class FrmPhieunhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPhieunhap));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QLsieuthiDataSet3 = new QuanLySieuThi.QLsieuthiDataSet3();
            this.NHAPSPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NHAPSPTableAdapter = new QuanLySieuThi.QLsieuthiDataSet3TableAdapters.NHAPSPTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QLsieuthiDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NHAPSPBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.NHAPSPBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLySieuThi.ReportPhieunhap.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(684, 417);
            this.reportViewer1.TabIndex = 0;
            // 
            // QLsieuthiDataSet3
            // 
            this.QLsieuthiDataSet3.DataSetName = "QLsieuthiDataSet3";
            this.QLsieuthiDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // NHAPSPBindingSource
            // 
            this.NHAPSPBindingSource.DataMember = "NHAPSP";
            this.NHAPSPBindingSource.DataSource = this.QLsieuthiDataSet3;
            // 
            // NHAPSPTableAdapter
            // 
            this.NHAPSPTableAdapter.ClearBeforeFill = true;
            // 
            // FrmPhieunhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 417);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPhieunhap";
            this.Text = "Phiếu Nhập Hàng";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPhieunhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QLsieuthiDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NHAPSPBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource NHAPSPBindingSource;
        private QLsieuthiDataSet3 QLsieuthiDataSet3;
        private QLsieuthiDataSet3TableAdapters.NHAPSPTableAdapter NHAPSPTableAdapter;
    }
}