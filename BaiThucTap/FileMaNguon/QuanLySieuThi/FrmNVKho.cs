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
    public partial class FrmNVKho : Form
    {
        public FrmNVKho()
        {
            InitializeComponent();
        }
        Conection cn = new Conection();
        public static string ngaynhaptest;
        private void FrmNVKho_Load(object sender, EventArgs e)
        {
            string sql3 = "select Fullname from TAIKHOAN where TenTK='" + FrmDangNhap.name + "'";
            FrmDangNhap.fname = cn.XemDL(sql3).Rows[0][0].ToString().Trim();
            label5.Text = "Xin chào " + FrmDangNhap.fname + "!!!";
            string sqldsncc = "select * from NCC";
            DataGridViewNCC.DataSource = cn.XemDL(sqldsncc);
            string sqldsnhap = "select * from NHAPSP";
            dataGridView1.DataSource = cn.XemDL(sqldsnhap);
            ngaynhaptest = ngaynhaptextBox4.Text;
            string sqltien = "select SUM(SoLuong*Gianhap) from NHAPSP where Ngaynhap='"+ngaynhaptest+"'";
            textBox16.Text = cn.XemDL(sqltien).Rows[0][0].ToString();
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            label8.Text = "Ngày " + day + " tháng " + month + " năm " + year;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            FrmCapNhatTK ud = new FrmCapNhatTK();
            ud.Show();
        }

        private void DataGridViewNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            manccTextBox1.Text = DataGridViewNCC.CurrentRow.Cells[0].Value.ToString().Trim();
            tennccTextBox3.Text = DataGridViewNCC.CurrentRow.Cells[1].Value.ToString().Trim();
            diachiTextBox1.Text = DataGridViewNCC.CurrentRow.Cells[2].Value.ToString().Trim();
            sdtTextBox.Text = DataGridViewNCC.CurrentRow.Cells[3].Value.ToString().Trim();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                DataGridViewNCC.DataSource = cn.XemDL("select * from NCC");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                try
                {
                    string sql = "select * from NCC where MaNCC like N'%" + textBox2.Text + "%' or TenNCC like N'%" + textBox2.Text + "%' or Diachi like N'%" + textBox2.Text + "%' or Sdt like N'%" + textBox2.Text + "%'";
                    DataGridViewNCC.DataSource = cn.XemDL(sql);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chưa tìm kiếm được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm kiếm!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Đăng Xuất!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                DataGridViewNCC.DataSource = cn.XemDL("select * from NHAPSP");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            {
                try
                {
                    string sql = "select * from NHAPSP where MaPhieu like N'%" + textBox8.Text + "%' or MaSP like N'%" + textBox8.Text + "%' or TenSP like N'%" + textBox8.Text + "%' or MaNCC like N'%" + textBox8.Text + "%'or Ngaynhap like N'%" + textBox8.Text + "%'or Soluong like N'%" + textBox8.Text + "%'or Gianhap like N'%" + textBox8.Text + "%'or Thanhtien like N'%" + textBox8.Text + "%'or Ghichu like N'%" + textBox8.Text + "%'";
                    dataGridView1.DataSource = cn.XemDL(sql);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chưa tìm kiếm được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm kiếm!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (maphieutextBox3.Text == "" | maspTextBox.Text == "" | tenspTextBox.Text == "" | manccTextBoxnhap.Text == "" | ngaynhaptextBox4.Text == "" | soluongTextBox.Text == "" | gianhaptextBox1.Text == "" | thanhtientextBox14.Text == "" | ghichutextBox15.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường thông tin!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sqlmancctest = "select * from NCC where MaNCC =N'" + manccTextBoxnhap.Text + "'";
                if (cn.XemDL(sqlmancctest).Rows.Count != 0)
                {
                    try
                    {
                        string sql = "insert into NHAPSP(MaPhieu,MaSP,TenSP,MaNCC,Ngaynhap,Soluong,Gianhap,Thanhtien,Ghichu) values('" + maphieutextBox3.Text + "',N'" + maspTextBox.Text + "',N'" + tenspTextBox.Text + "',N'" + manccTextBoxnhap.Text + "','" + ngaynhaptextBox4.Text + "',N'" + soluongTextBox.Text + "','" + gianhaptextBox1.Text + "','" + thanhtientextBox14.Text + "',N'" + ghichutextBox15.Text + "')";
                        cn.ThucThiDl(sql);
                        string sql2 = "insert into DULIEUNHAP(MaPhieu,MaSP,TenSP,MaNCC,Ngaynhap,Soluong,Gianhap,Thanhtien,Ghichu) values('" + maphieutextBox3.Text + "',N'" + maspTextBox.Text + "',N'" + tenspTextBox.Text + "',N'" + manccTextBoxnhap.Text + "','" + ngaynhaptextBox4.Text + "',N'" + soluongTextBox.Text + "','" + gianhaptextBox1.Text + "','" + thanhtientextBox14.Text + "',N'" + ghichutextBox15.Text + "')";
                        cn.ThucThiDl(sql2);
                        MessageBox.Show("Thêm thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = cn.XemDL("select * from NHAPSP");
                        ngaynhaptest = ngaynhaptextBox4.Text;
                        string sqltien = "select SUM(SoLuong*Gianhap) from NHAPSP where Ngaynhap='" + ngaynhaptest + "'";
                        textBox16.Text = cn.XemDL(sqltien).Rows[0][0].ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi! Chưa thêm được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Nhà cung cấp không tồn tại! Vui lòng thêm NCC mới!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FrmThemNCC ncc = new FrmThemNCC();
                    ncc.ShowDialog();
                }
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            string sqldsncc = "select * from NCC";
            DataGridViewNCC.DataSource = cn.XemDL(sqldsncc);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmPhieunhap phieu = new FrmPhieunhap();
            phieu.ShowDialog();
        }

        private void tenspTextBox_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (tenspTextBox.Text == "")
                this.errorProvider1.Clear();
            else
            {

                if (char.IsDigit(control.Text[control.Text.Length - 1]))
                    this.errorProvider1.SetError(control, "Tên SP không chứa giá trị số !");
                else
                    this.errorProvider1.Clear();
            }
        }

        private void soluongTextBox_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (soluongTextBox.Text == "")
                this.errorProvider1.Clear();
            else
            {

                if (char.IsDigit(control.Text[control.Text.Length - 1]))
                    this.errorProvider1.Clear();
                else
                    this.errorProvider1.SetError(control, "Vui lòng nhập giá trị số !");
            }
        }

        private void gianhaptextBox1_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (gianhaptextBox1.Text == "")
                this.errorProvider1.Clear();
            else
            {

                if (char.IsDigit(control.Text[control.Text.Length - 1]))
                    this.errorProvider1.Clear();
                else
                    this.errorProvider1.SetError(control, "Vui lòng nhập giá trị số !");
            }
        }

        private void thanhtientextBox14_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (thanhtientextBox14.Text == "")
                this.errorProvider1.Clear();
            else
            {

                if (char.IsDigit(control.Text[control.Text.Length - 1]))
                    this.errorProvider1.Clear();
                else
                    this.errorProvider1.SetError(control, "Vui lòng nhập giá trị số !");
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maphieutextBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            maspTextBox.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
            tenspTextBox.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
            manccTextBoxnhap.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim();
            ngaynhaptextBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString().Trim();
            soluongTextBox.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString().Trim();
            gianhaptextBox1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString().Trim();
            thanhtientextBox14.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString().Trim();
            ghichutextBox15.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString().Trim();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maphieutextBox3.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần cập nhật!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (maphieutextBox3.Text == "" | maspTextBox.Text == "" | tenspTextBox.Text == "" | manccTextBoxnhap.Text == "" | ngaynhaptextBox4.Text == "" | soluongTextBox.Text == "" | gianhaptextBox1.Text == "" | thanhtientextBox14.Text == "" | ghichutextBox15.Text == "")
            {
                MessageBox.Show("Các trường thông tin không được phép rỗng! Vui lòng nhập lại!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {
                    string sql = "update NHAPSP set MaSP=N'" + maspTextBox.Text + "', TenSP=N'" + tenspTextBox.Text + "',MaNCC=N'" + manccTextBoxnhap.Text + "',Ngaynhap='" + ngaynhaptextBox4.Text + "',Soluong=N'" + soluongTextBox.Text + "',Gianhap='" + gianhaptextBox1.Text + "',Thanhtien='" + thanhtientextBox14.Text + "',Ghichu=N'" + ghichutextBox15.Text + "' where MaPhieu='" + maphieutextBox3.Text + "'";
                    cn.ThucThiDl(sql);
                    MessageBox.Show("Cập nhật thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = cn.XemDL("select * from NHAPSP");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi! Chưa cập nhật được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
