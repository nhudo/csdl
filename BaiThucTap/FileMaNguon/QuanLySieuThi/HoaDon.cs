using System;
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
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLsieuthiDataSet1.BANHANG' table. You can move, or remove it, as needed.
            this.BANHANGTableAdapter.Fill(this.QLsieuthiDataSet1.BANHANG);

            this.reportViewer1.RefreshReport();
        }
        Conection cn = new Conection();
        private void HoaDon_FormClosed(object sender, FormClosedEventArgs e)
        {
            string xoabangban = "delete BANHANG";
            cn.ThucThiDl(xoabangban);
            FrmNhanVien nv = new FrmNhanVien();
            nv.Refresh();
        }
    }
}
