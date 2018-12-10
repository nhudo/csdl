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
    public partial class FrmLayThongTinKH : Form
    {
        public static int giamgia;
        public FrmLayThongTinKH()
        {
            InitializeComponent();
        }
        Conection cn = new Conection();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void tenkhTextBox_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (tenkhTextBox.Text == "")
                this.errorProvider1.Clear();
            else
            {

                if (char.IsDigit(control.Text[control.Text.Length - 1]))
                    this.errorProvider1.SetError(control, "Họ tên không chứa giá trị số !");
                else
                    this.errorProvider1.Clear();
            }
        }

        private void sdttextBox2_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (sdttextBox2.Text == "")
                this.errorProvider1.Clear();
            else
            {

                if (char.IsDigit(control.Text[control.Text.Length - 1]))
                    this.errorProvider1.Clear();
                else
                    this.errorProvider1.SetError(control, "Vui lòng nhập giá trị số !");

            }
        }
        Random Random = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            if (makhTextBox2.Text == "" | tenkhTextBox.Text == "" | diachitextBox4.Text == "" | sdttextBox2.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường thông tin!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                string sqltentest = "select * from KHACHHANG where TenKH=N'" + tenkhTextBox.Text + "'";
                if (cn.XemDL(sqltentest).Rows.Count != 0)
                {
                    int mahd = Random.Next(1000, 100000);
                    MessageBox.Show("Thông tin khách hàng đã tồn tại! Hệ thống sẽ tự truy xuất thông tin khách hàng!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    giamgia = 1;
                    string sqllaymakh = "select MaKH from KHACHHANG where TenKH=N'" + tenkhTextBox.Text + "'";
                    string makhdaco = cn.XemDL(sqllaymakh).Rows[0][0].ToString();
                    string sqlthemhd = "update BANHANG set MaKH='" + makhdaco + "', MaHD='" + mahd.ToString() + "'";
                    cn.ThucThiDl(sqlthemhd);
                    string sqlluuthemhd = "update DULIEUBAN set MaKH='" + makhdaco + "', MaHD='" + mahd.ToString() + "'";
                    cn.ThucThiDl(sqlluuthemhd);
                    HoaDon hd = new HoaDon();
                    hd.ShowDialog();
                    this.Close();
                }
                else
                {
                    try
                    {
                        int mahd = Random.Next(1000, 100000);
                        string sqlthemkh = "insert into KHACHHANG values('" + makhTextBox2.Text + "',N'" + tenkhTextBox.Text + "',N'" + diachitextBox4.Text + "','" + sdttextBox2.Text + "')";
                        cn.ThucThiDl(sqlthemkh);
                        string sqlthemhd = "update BANHANG set MaKH='" + makhTextBox2.Text + "', MaHD='" + mahd.ToString() + "'";
                        cn.ThucThiDl(sqlthemhd);
                        string sqlluuthemhd = "update DULIEUBAN set MaKH='" + makhTextBox2.Text + "', MaHD='" + mahd.ToString() + "'";
                        cn.ThucThiDl(sqlluuthemhd);
                        MessageBox.Show("Thêm thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        giamgia = 0;
                        HoaDon hd = new HoaDon();
                        hd.ShowDialog();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi! Chưa thêm được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                }
            }
        }
    }
}
