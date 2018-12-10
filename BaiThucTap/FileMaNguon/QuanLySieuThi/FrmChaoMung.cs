using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class FrmChaoMung : Form
    {
        
        public FrmChaoMung()
        {
            InitializeComponent();
            
        }
        public static int trangthai;
        
        private void label7_Click(object sender, EventArgs e)
        {
            FrmDangNhap dn = new FrmDangNhap();
            dn.ShowDialog();
            trangthai = 1;
        }
        void show()
        {
             if(Dem.sum==1)
            {
                báoCáoBánHàngToolStripMenuItem.Enabled = true;
                inBảngLươngToolStripMenuItem.Enabled = true;
                toolStripMenuItem1.Enabled = true;
                hóaĐơnToolStripMenuItem.Enabled = true;
                đăngNhậpToolStripMenuItem.Enabled = false;
            }
            else if(Dem.sum==0)
            {
                báoCáoBánHàngToolStripMenuItem.Enabled = false;
                inBảngLươngToolStripMenuItem.Enabled = false;
                toolStripMenuItem1.Enabled = false;
                hóaĐơnToolStripMenuItem.Enabled = false;
                đăngNhậpToolStripMenuItem.Enabled = true;
            }
            
        }

        private void label7_CursorChanged(object sender, EventArgs e)
        { 
        }

        private void label7_MouseMove(object sender, MouseEventArgs e)
        {
            if (label7.Cursor == Cursors.Hand) { label7.ForeColor = Color.Blue; };
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            if (label7.Cursor == Cursors.Hand) { label7.ForeColor = Color.Brown; };
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.ForeColor = Color.Blue;
        }
        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Red;
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            label2.ForeColor = Color.Blue;
        }
        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Red;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
        }
        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            label3.ForeColor = Color.Blue;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label9.Text = "MSV: 13103100453";
            label10.Text = "Ngày Sinh: 08/11/1995";
            label11.Text = "Sđt: 01298081195";
            label12.Text = "Nhóm trưởng";
        }
        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Red;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            label4.ForeColor = Color.Blue;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label9.Text = "MSV: 13103100474";
            label10.Text = "Ngày Sinh: 16/04/1997";
            label11.Text = "Sđt: 0971651512";
            label12.Text = "Thành Viên";
        }
        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Red;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            label5.ForeColor = Color.Blue;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label9.Text = "MSV: 13103100472";
            label10.Text = "Ngày Sinh: 26/05/1995";
            label11.Text = "Sđt: 01673629688";
            label12.Text = "Thành Viên";
        }

        private void FrmChaoMung_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (trangthai == 1)
            {
                đăngNhậpToolStripMenuItem.Enabled = false;
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDangNhap dn = new FrmDangNhap();
            dn.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }
        
        private void FrmChaoMung_Load(object sender, EventArgs e)
        {
        }

        private void liênHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://facebook.com/kunbi.081195");
        }

        private void thôngTinPhầnMềmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void FrmChaoMung_FormClosed(object sender, FormClosedEventArgs e)
        {
                Application.Exit();
        }

        private void máyTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmPhieunhap ph = new FrmPhieunhap();
            ph.Show();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.Show();
        }

        private void inBảngLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inluong luong = new Inluong();
            luong.Show();
        }

        private void báoCáoBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTonkho ton = new FrmTonkho();
            ton.Show();
        }

        private void hướngDẫnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("Tro Giup.chm");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
