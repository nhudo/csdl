﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class FrmTonkho : Form
    {
        public FrmTonkho()
        {
            InitializeComponent();
        }

        private void FrmTonkho_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLsieuthiDataSet3.NHAPSP' table. You can move, or remove it, as needed.
            this.NHAPSPTableAdapter.Fill(this.QLsieuthiDataSet3.NHAPSP);

            this.reportViewer1.RefreshReport();
        }
    }
}
