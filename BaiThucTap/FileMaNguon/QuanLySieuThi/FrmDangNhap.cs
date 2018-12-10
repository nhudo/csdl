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
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
           
        }
        
        public static string quyen, name, fname, passdoi;
        Conection cn = new Conection();
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn hủy không?", "Hủy!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Để được trợ giúp vui lòng liên hệ qua email: kunbi.081195@gmail.com hoặc sđt: 01298081195! Xin cảm ơn!", "Trợ giúp", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Red;
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            label3.ForeColor = Color.Blue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text.Trim();
            string pass = textBox2.Text.Trim();
            passdoi = pass;
            string sql = "select * from TAIKHOAN where TenTK='" + user + "'and MK='" + pass + "'";
            if (user != "" || pass != "")
            {
                if (cn.XemDL(sql).Rows.Count != 0)
                {
                    string sql2 = "select CV from TAIKHOAN where TenTK='" + user + "'and MK='" + pass + "'";
                    quyen = cn.XemDL(sql2).Rows[0][0].ToString().Trim();
                    this.Hide();
                    name = user;
                    if (quyen == "Admin")
                    {
                        FrmChaoMung cm = new FrmChaoMung();
                        FrmAdmin ad = new FrmAdmin();
                        Dem.sum = 1;
                        ad.Show();                    
                        this.Close();
                        
                       
                    }
                    else if (quyen == "Kho")
                    {
                        FrmNVKho kho = new FrmNVKho();
                        Dem.sum = 1;
                        kho.Show();                        
                        this.Close();                        
                    }
                    else
                    {
                        FrmNhanVien nv = new FrmNhanVien();
                        Dem.sum = 1;
                        nv.Show();                       
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu! Vui lòng thử lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
           
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
