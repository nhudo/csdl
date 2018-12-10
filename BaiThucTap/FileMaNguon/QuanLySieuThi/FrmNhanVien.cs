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
    public partial class FrmNhanVien : Form
    {
        public string masp, tensp, mancc, tenncc, soluong, gia, ghichu;
        public string masp1, tensp1, mancc1, tenncc1, soluong1, gia1, ghichu1;
        public FrmNhanVien()
        {
            InitializeComponent();
        }
        Conection cn = new Conection();
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLsieuthiDataSet.SP' table. You can move, or remove it, as needed.
            this.sPTableAdapter.Fill(this.qLsieuthiDataSet.SP);
            string sql3 = "select Fullname from TAIKHOAN where TenTK='" + FrmDangNhap.name + "'";
            FrmDangNhap.fname = cn.XemDL(sql3).Rows[0][0].ToString().Trim();
            label11.Text = "Xin chào " + FrmDangNhap.fname + "!!!";
            string xoabangban = "delete BANHANG";
            cn.ThucThiDl(xoabangban);
            string sqlhang = "select MaSP,TenSP,SP.MaNCC,TenNCC,Soluong,Gia,Ghichu from SP,NCC where SP.MaNCC=NCC.MaNCC";
            dataGridView1.DataSource = cn.XemDL(sqlhang);
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            string ngaythang = day.ToString() + "/" + month.ToString() + "/" + year.ToString();
            string sqlban = "select MaSP,TenSP,NCC.MaNCC,TenNCC,Soluong,Gia,Ghichu from BANHANG,NCC where BANHANG.MaNCC=NCC.MaNCC";
            dataGridView2.DataSource = cn.XemDL(sqlban);
            string sqltien = "select SUM(SoLuong*Gia) from BANHANG";
            textBox1.Text = cn.XemDL(sqltien).Rows[0][0].ToString();
            string sqldskh = "select * from KHACHHANG";
            DataGridView3.DataSource = cn.XemDL(sqldskh);
            label8.Text = "Ngày " + day + " tháng " + month + " năm " + year;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            FrmCapNhatTK ud = new FrmCapNhatTK();
            ud.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txtmh.Text != "")
            {
                if (txtSluong.Text != "")
                {
                    int sluong = int.Parse(txtSluong.Text);
                    int a = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim());
                    int soluongkhohang = a - sluong;
                    if (sluong > (a) || sluong < 0)
                    {
                        MessageBox.Show("Số lượng lớn hơn số lượng ban đầu", "Thông báo");
                    }
                    else
                    {
                        if (dataGridView2.CurrentCell == null)
                        {
                            try
                            {
                                string sqltrusl = "update SP set Soluong='" + soluongkhohang.ToString() + "' where TenSP=N'"+txtmh.Text+"'";
                                cn.ThucThiDl(sqltrusl);
                                string sqlhang = "select MaSP,TenSP,SP.MaNCC,TenNCC,Soluong,Gia,Ghichu from SP,NCC where SP.MaNCC=NCC.MaNCC";
                                dataGridView1.DataSource = cn.XemDL(sqlhang);
                                int day = DateTime.Now.Day;
                                int month = DateTime.Now.Month;
                                int year = DateTime.Now.Year;
                                string ngaythang = day.ToString() + "/" + month.ToString() + "/" + year.ToString();
                                string sqlthem = "insert into BANHANG (MaSP,TenSP,SP.MaNCC,Ngayban,Soluong,Gia,Ghichu) values('" + masp + "',N'" + tensp + "','" + mancc + "','" + ngaythang + "','" + sluong + "','" + gia + "',N'" + ghichu + "')";
                                cn.ThucThiDl(sqlthem);
                                string sqlluu = "insert into DULIEUBAN (MaSP,TenSP,SP.MaNCC,Ngayban,Soluong,Gia,Ghichu) values('" + masp + "',N'" + tensp + "','" + mancc + "','" + ngaythang + "','" + sluong + "','" + gia + "',N'" + ghichu + "')";
                                cn.ThucThiDl(sqlluu);
                                string sqlban = "select MaSP,TenSP,NCC.MaNCC,TenNCC,Soluong,Gia,Ghichu from BANHANG,NCC where BANHANG.MaNCC=NCC.MaNCC and Ngayban='" + ngaythang + "'";
                                dataGridView2.DataSource = cn.XemDL(sqlban);
                                int soluong1sp = sluong;
                                int gia1sp = int.Parse(gia);
                                int thanhtien = gia1sp * soluong1sp;
                                string sqlgia1sp = "update BANHANG set Thanhtien='" + thanhtien.ToString() + "' where TenSP=N'" + txtmh.Text + "' ";
                                cn.ThucThiDl(sqlgia1sp);
                                string sqlluugia = "update DULIEUBAN set Thanhtien='" + thanhtien.ToString() + "' where TenSP=N'" + txtmh.Text + "' ";
                                cn.ThucThiDl(sqlluugia);
                                MessageBox.Show("Thêm thành công!", "Thông báo");
                                string sqltien = "select SUM(SoLuong*Gia) from BANHANG";
                                textBox1.Text = cn.XemDL(sqltien).Rows[0][0].ToString();          
                                txtmh.Clear();
                                txtSluong.Clear();
                                
                            }
                            catch
                            {
                                MessageBox.Show("Lỗi! Chưa thêm được! Vui lòng kiểm tra lại!", "Thông báo");
                            }
                        }
                        else
                        {
                            if (txtmh.Text == dataGridView2.CurrentRow.Cells[1].Value.ToString().Trim())
                            {
                                int sldaco = Convert.ToInt32(dataGridView2.CurrentRow.Cells[4].Value.ToString().Trim());
                                int slthem = Convert.ToInt32(txtSluong.Text);
                                int tongthem = sldaco + slthem;
                                try
                                {
                                    int day = DateTime.Now.Day;
                                    int month = DateTime.Now.Month;
                                    int year = DateTime.Now.Year;
                                    string ngaythang = day.ToString() + "/" + month.ToString() + "/" + year.ToString();
                                    string sqltrusl = "update SP set Soluong='" + soluongkhohang.ToString() + "' where TenSP=N'" + txtmh.Text + "'";
                                    cn.ThucThiDl(sqltrusl);
                                    string sqlhang = "select MaSP,TenSP,SP.MaNCC,TenNCC,Soluong,Gia,Ghichu from SP,NCC where SP.MaNCC=NCC.MaNCC";
                                    dataGridView1.DataSource = cn.XemDL(sqlhang);
                                    string sqlthem = "update BANHANG set Soluong='" + tongthem.ToString() + "' where TenSP=N'" + txtmh.Text + "'";
                                    cn.ThucThiDl(sqlthem);
                                    string sqlluuthem = "update DULIEUBAN set Soluong='" + tongthem.ToString() + "' where TenSP=N'" + txtmh.Text + "'";
                                    cn.ThucThiDl(sqlluuthem);
                                    string sqlban = "select MaSP,TenSP,NCC.MaNCC,TenNCC,Soluong,Gia,Ghichu from BANHANG,NCC where BANHANG.MaNCC=NCC.MaNCC and Ngayban='" + ngaythang + "'";
                                    dataGridView2.DataSource = cn.XemDL(sqlban);
                                    int soluong1sp = tongthem;
                                    int gia1sp = int.Parse(gia);
                                    int thanhtien = gia1sp * soluong1sp;
                                    string sqlgia1sp = "update BANHANG set Thanhtien='" + thanhtien.ToString() + "' where TenSP=N'" + txtmh.Text + "' ";
                                    cn.ThucThiDl(sqlgia1sp);
                                    string sqlluugia = "update DULIEUBAN set Thanhtien='" + thanhtien.ToString() + "' where TenSP=N'" + txtmh.Text + "' ";
                                    cn.ThucThiDl(sqlluugia);
                                    MessageBox.Show("Thêm thành công!", "Thông báo");
                                    string sqltien = "select SUM(SoLuong*Gia) from BANHANG";
                                    textBox1.Text = cn.XemDL(sqltien).Rows[0][0].ToString();
                                    txtmh.Clear();
                                    txtSluong.Clear();

                                }
                                catch
                                {
                                    MessageBox.Show("Lỗi! Chưa thêm được! Vui lòng kiểm tra lại!", "Thông báo");
                                }
                            }
                            else
                            {
                                try
                                {
                                    string sqltrusl = "update SP set Soluong='" + soluongkhohang.ToString() + "' where TenSP=N'" + txtmh.Text + "'";
                                    cn.ThucThiDl(sqltrusl);
                                    string sqlhang = "select MaSP,TenSP,SP.MaNCC,TenNCC,Soluong,Gia,Ghichu from SP,NCC where SP.MaNCC=NCC.MaNCC";
                                    dataGridView1.DataSource = cn.XemDL(sqlhang);
                                    int day = DateTime.Now.Day;
                                    int month = DateTime.Now.Month;
                                    int year = DateTime.Now.Year;
                                    string ngaythang = day.ToString() + "/" + month.ToString() + "/" + year.ToString();
                                    string sqlthem = "insert into BANHANG (MaSP,TenSP,SP.MaNCC,Ngayban,Soluong,Gia,Ghichu) values('" + masp + "',N'" + tensp + "','" + mancc + "','" + ngaythang + "','" + sluong + "','" + gia + "',N'" + ghichu + "')";
                                    cn.ThucThiDl(sqlthem);
                                    string sqlluu = "insert into DULIEUBAN (MaSP,TenSP,SP.MaNCC,Ngayban,Soluong,Gia,Ghichu) values('" + masp + "',N'" + tensp + "','" + mancc + "','" + ngaythang + "','" + sluong + "','" + gia + "',N'" + ghichu + "')";
                                    cn.ThucThiDl(sqlluu);
                                    string sqlban = "select MaSP,TenSP,NCC.MaNCC,TenNCC,Soluong,Gia,Ghichu from BANHANG,NCC where BANHANG.MaNCC=NCC.MaNCC and Ngayban='"+ngaythang+"'";
                                    dataGridView2.DataSource = cn.XemDL(sqlban);
                                    int soluong1sp = sluong;
                                    int gia1sp = int.Parse(gia);
                                    int thanhtien = gia1sp * soluong1sp;
                                    string sqlgia1sp = "update BANHANG set Thanhtien='" + thanhtien.ToString() + "' where TenSP=N'"+txtmh.Text+"' ";
                                    cn.ThucThiDl(sqlgia1sp);
                                    string sqlluugia = "update DULIEUBAN set Thanhtien='" + thanhtien.ToString() + "' where TenSP=N'" + txtmh.Text + "' ";
                                    cn.ThucThiDl(sqlluugia);
                                    MessageBox.Show("Thêm thành công!", "Thông báo");
                                    string sqltien = "select SUM(SoLuong*Gia) from BANHANG";
                                    textBox1.Text = cn.XemDL(sqltien).Rows[0][0].ToString();
                                    txtmh.Clear();
                                    txtSluong.Clear();

                                }
                                catch
                                {
                                    MessageBox.Show("Lỗi! Chưa thêm được! Vui lòng kiểm tra lại!", "Thông báo");
                                }
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Vui lòng nhập số lượng cần mua!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Bạn chưa chọn mặt hàng!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmh.Text = tensp = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            masp = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
            mancc = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
            tenncc = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
            soluong = dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim();
            gia = dataGridView1.CurrentRow.Cells[5].Value.ToString().Trim();
            ghichu = dataGridView1.CurrentRow.Cells[6].Value.ToString().Trim();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentCell == null)
            {              
                    MessageBox.Show("Chưa có mặt hàng nào trong danh sách!", "Thông báo");
            }
            else
            {
                if (txtmh.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn một mặt hàng để hủy!", "Thông báo");
                }
                else
                {
                    
                    if (MessageBox.Show("Bạn có chắc chắn muốn hủy mặt hàng này không?", "Hủy!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int slban = Convert.ToInt32(dataGridView2.CurrentRow.Cells[4].Value.ToString().Trim());
                        string sqlslkho = "select Soluong from SP where TenSP=N'" + txtmh.Text + "'";
                        int slkho = Convert.ToInt32(cn.XemDL(sqlslkho).Rows[0][0].ToString());
                        int tongtra = slkho + slban;
                        try
                        {
                            string sqltrusl = "update SP set Soluong='" + tongtra.ToString() + "' where TenSP=N'" + txtmh.Text + "'";
                            cn.ThucThiDl(sqltrusl);
                            string sqlhang = "select MaSP,TenSP,SP.MaNCC,TenNCC,Soluong,Gia,Ghichu from SP,NCC where SP.MaNCC=NCC.MaNCC";
                            dataGridView1.DataSource = cn.XemDL(sqlhang);
                            string sqlthem = "delete BANHANG where TenSP=N'" + txtmh.Text + "'";
                            cn.ThucThiDl(sqlthem);
                            string sqlban = "select MaSP,TenSP,NCC.MaNCC,TenNCC,Soluong,Gia,Ghichu from BANHANG,NCC where BANHANG.MaNCC=NCC.MaNCC";
                            dataGridView2.DataSource = cn.XemDL(sqlban);
                            MessageBox.Show("Đã hủy mặt hàng thành công!", "Thông báo");
                            string sqltien = "select SUM(SoLuong*Gia) from BANHANG";
                            textBox1.Text = cn.XemDL(sqltien).Rows[0][0].ToString();
                            txtmh.Clear();
                            txtSluong.Clear();

                        }
                        catch
                        {
                            MessageBox.Show("Lỗi! Chưa hủy được! Vui lòng kiểm tra lại!", "Thông báo");
                        }
                    }
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmh.Text = tensp1 = dataGridView2.CurrentRow.Cells[1].Value.ToString().Trim();
            masp = dataGridView2.CurrentRow.Cells[0].Value.ToString().Trim();
            mancc = dataGridView2.CurrentRow.Cells[2].Value.ToString().Trim();
            tenncc = dataGridView2.CurrentRow.Cells[3].Value.ToString().Trim();
            soluong = dataGridView2.CurrentRow.Cells[4].Value.ToString().Trim();
            gia = dataGridView2.CurrentRow.Cells[5].Value.ToString().Trim();
            ghichu = dataGridView2.CurrentRow.Cells[6].Value.ToString().Trim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTimkiem.Text != "")
            {
                try
                {
                    string sql = "select MaSP,TenSP,SP.MaNCC,TenNCC,Soluong,Gia,Ghichu from SP,NCC where (SP.MaNCC=NCC.MaNCC) and (MaSP like N'%" + txtTimkiem.Text + "%' or TenSP like N'%" + txtTimkiem.Text + "%' or SP.MaNCC like N'%" + txtTimkiem.Text + "%' or TenNCC like N'%" + txtTimkiem.Text + "%' or Soluong like N'%" + txtTimkiem.Text + "%' or Gia like N'%" + txtTimkiem.Text + "%'or Ghichu like N'%" + txtTimkiem.Text + "%')";
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

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
             if (txtTimkiem.Text == "")
            {
                dataGridView1.DataSource = cn.XemDL("select MaSP,TenSP,SP.MaNCC,TenNCC,Soluong,Gia,Ghichu from SP,NCC where SP.MaNCC=NCC.MaNCC");
            }
        }

        private void DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            makhTextBox2.Text = DataGridView3.CurrentRow.Cells[0].Value.ToString().Trim();
            tenkhTextBox.Text = DataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
            diachitextBox4.Text = DataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
            sdttextBox2.Text = DataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                try
                {
                    string sql = "select * from KHACHHANG where MaKH like N'%" + textBox3.Text + "%' or TenKH like N'%" + textBox3.Text + "%' or Diachi like N'%" + textBox3.Text + "%' or Sdt like N'%" + textBox3.Text + "%'";
                    DataGridView3.DataSource = cn.XemDL(sql);
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
               DataGridView3.DataSource = cn.XemDL("select * from KHACHHANG");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentCell == null)
            {
                MessageBox.Show("Chưa có mặt hàng nào để thanh toán!", "Thông báo");
            }
            else
            {
                FrmLayThongTinKH ttkh = new FrmLayThongTinKH();
                ttkh.ShowDialog();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Đăng Xuất!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            string sqldskh = "select * from KHACHHANG";
            DataGridView3.DataSource = cn.XemDL(sqldskh);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            string sqlhang = "select MaSP,TenSP,SP.MaNCC,TenNCC,Soluong,Gia,Ghichu from SP,NCC where SP.MaNCC=NCC.MaNCC";
            dataGridView1.DataSource = cn.XemDL(sqlhang);
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            string ngaythang = day.ToString() + "/" + month.ToString() + "/" + year.ToString();
            string sqlban = "select MaSP,TenSP,NCC.MaNCC,TenNCC,Soluong,Gia,Ghichu from BANHANG,NCC where BANHANG.MaNCC=NCC.MaNCC";
            dataGridView2.DataSource = cn.XemDL(sqlban);
            string sqltien = "select SUM(SoLuong*Gia) from BANHANG";
            textBox1.Text = cn.XemDL(sqltien).Rows[0][0].ToString();
            string sqldskh = "select * from KHACHHANG";
            DataGridView3.DataSource = cn.XemDL(sqldskh);
        }
    }
}
