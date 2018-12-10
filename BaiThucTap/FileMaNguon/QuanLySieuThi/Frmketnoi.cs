using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class Frmketnoi : Form
    {
        public Frmketnoi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng điền tên Server để thực hiện kết nối!");
            }
            else
            {
                String ketnoi = @"Data Source=" + textBox1.Text + ";Initial Catalog=QLsieuthi;Integrated Security=True";
                SqlConnection con = new SqlConnection(ketnoi);
                try
                {
                    con.Open();
                    con.Close();
                    MessageBox.Show("Kết nối thành công!");
                    ketnoi = QuanLySieuThi.Properties.Settings.Default.ConnectionString;
                    QuanLySieuThi.Properties.Settings.Default.Conn = ketnoi;
                    QuanLySieuThi.Properties.Settings.Default.Save();
                    FrmChaoMung cm = new FrmChaoMung();
                    cm.Show();
                    Hide();
                }
                catch (Exception)
                {
                    MessageBox.Show("Kết nối thất bại!");
                }
            }
        }
    }
}
