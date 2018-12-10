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
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }
        Conection cn = new Conection();
        private void ngaysinhLabel_Click(object sender, EventArgs e)
        {

        }

        private void tenkhoaTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLsieuthiDataSet.TAIKHOAN' table. You can move, or remove it, as needed.
            this.tAIKHOANTableAdapter.Fill(this.qLsieuthiDataSet.TAIKHOAN);
            // TODO: This line of code loads data into the 'qLsieuthiDataSet.NCC' table. You can move, or remove it, as needed.
            this.nCCTableAdapter.Fill(this.qLsieuthiDataSet.NCC);
            // TODO: This line of code loads data into the 'qLsieuthiDataSet.KHACHHANG' table. You can move, or remove it, as needed.
            this.kHACHHANGTableAdapter.Fill(this.qLsieuthiDataSet.KHACHHANG);
            // TODO: This line of code loads data into the 'qLsieuthiDataSet.SP' table. You can move, or remove it, as needed.
            this.sPTableAdapter.Fill(this.qLsieuthiDataSet.SP);
            // TODO: This line of code loads data into the 'qLsieuthiDataSet.NHANVIEN' table. You can move, or remove it, as needed.
            this.nHANVIENTableAdapter.Fill(this.qLsieuthiDataSet.NHANVIEN);
            // TODO: This line of code loads data into the 'qLsieuthiDataSet.NHANVIEN' table. You can move, or remove it, as needed.
            this.nHANVIENTableAdapter.Fill(this.qLsieuthiDataSet.NHANVIEN);
            // TODO: This line of code loads data into the 'qLsieuthiDataSet.NHANVIEN' table. You can move, or remove it, as needed.
            this.nHANVIENTableAdapter.Fill(this.qLsieuthiDataSet.NHANVIEN);
            string sql3 = "select Fullname from TAIKHOAN where TenTK='"+FrmDangNhap.name+"'";
            FrmDangNhap.fname = cn.XemDL(sql3).Rows[0][0].ToString().Trim();
            label9.Text = "Xin chào " + FrmDangNhap.fname + "!!!";
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

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Đăng Xuất!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FrmDangNhap dn = new FrmDangNhap();
                this.Hide();
                dn.Show();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (maNVTextBox.Text == "" | hotenTextBox.Text == "" | ngaysinhTextBox.Text == "" | diachiTextBox.Text == "" | sdtTextBox.Text == "" | chucvuTextBox.Text == "" | luongcbTextBox.Text == "" | thuongTextBox.Text == "" | phucapTextBox.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường thông tin!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string sql = "insert into NHANVIEN values('" + maNVTextBox.Text + "',N'" + hotenTextBox.Text + "','" + ngaysinhTextBox.Text + "',N'" + diachiTextBox.Text + "','" + sdtTextBox.Text + "',N'" + chucvuTextBox.Text + "','" + luongcbTextBox.Text + "','" + phucapTextBox.Text + "','" + thuongTextBox.Text + "','0')";
                    cn.ThucThiDl(sql);
                    MessageBox.Show("Thêm thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.nHANVIENTableAdapter.Fill(this.qLsieuthiDataSet.NHANVIEN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi! Chưa thêm được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maNVTextBox.Text != "")
            {
                try
                {
                    string sql = "delete NHANVIEN where Manv = '" + maNVTextBox.Text + "'";
                    cn.ThucThiDl(sql);
                    MessageBox.Show("Xóa thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nHANVIENDataGridView.DataSource = cn.XemDL("select * from NHANVIEN");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi! Chưa xóa được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (maNVTextBox.Text == "" )
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần cập nhật!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);         
            }
            else if (hotenTextBox.Text == "" | ngaysinhTextBox.Text == "" | diachiTextBox.Text == "" | sdtTextBox.Text == "" | chucvuTextBox.Text == "" | luongcbTextBox.Text == "" | thuongTextBox.Text == "" | phucapTextBox.Text == "")
            {
                MessageBox.Show("Các trường thông tin không được phép rỗng! Vui lòng nhập lại!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            else
            {
                try
                {
                    string sql = "update NHANVIEN set Hoten=N'" + hotenTextBox.Text + "', Ngaysinh='" + ngaysinhTextBox.Text + "',Diachi=N'" + diachiTextBox.Text + "',Sdt='" + sdtTextBox.Text + "',Chucvu=N'" + chucvuTextBox.Text + "',Luongcb='" + luongcbTextBox.Text + "',Phucap='" + phucapTextBox.Text + "',thuong='" + thuongTextBox.Text + "',Luong='" + luongTextBox.Text + "' where Manv='" + maNVTextBox.Text + "'";
                    cn.ThucThiDl(sql);
                    MessageBox.Show("Cập nhật thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.nHANVIENTableAdapter.Fill(this.qLsieuthiDataSet.NHANVIEN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi! Chưa cập nhật được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timkiemTextbox.Text != "")
            {
                try
                {
                    string sql = "select * from NHANVIEN where Hoten like N'%" + timkiemTextbox.Text + "%' or Diachi like N'%" + timkiemTextbox.Text + "%' or Manv like N'%" + timkiemTextbox.Text + "%' or Ngaysinh like N'%" + timkiemTextbox.Text + "%' or Chucvu like N'%" + timkiemTextbox.Text + "%' or Sdt like N'%" + timkiemTextbox.Text + "%'or Luongcb like N'%" + timkiemTextbox.Text + "%'or Phucap like N'%" + timkiemTextbox.Text + "%'or thuong like N'%" + timkiemTextbox.Text + "%'or Luong like N'%" + timkiemTextbox.Text + "%'";
                    nHANVIENDataGridView.DataSource = cn.XemDL(sql);
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

        private void timkiemTextbox_TextChanged(object sender, EventArgs e)
        {
            if (timkiemTextbox.Text == "")
            {
                nHANVIENDataGridView.DataSource = cn.XemDL("select * from NHANVIEN");
            }
        }

        private void nHANVIENDataGridView_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void nHANVIENDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnTinhluong_Click(object sender, EventArgs e)
        {
            int luongcb, phucap, thuong, luong;
            luongcb = Convert.ToInt32(luongcbTextBox.Text);
            phucap = Convert.ToInt32(phucapTextBox.Text);
            thuong = Convert.ToInt32(thuongTextBox.Text);
            luong = luongcb + phucap + thuong;
            luongTextBox.Text = luong.ToString();
            MessageBox.Show("Tính lương thành công! Vui lòng bấm nút 'Cập Nhật' để lưu vào hệ thống!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void hotenTextBox_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (hotenTextBox.Text != "")
                 if (char.IsDigit(control.Text[control.Text.Length - 1]))
                    this.errorProvider1.SetError(control, "Họ tên không chứa giá trị số !");
                else
                    this.errorProvider1.Clear();
                
            else
            {
                this.errorProvider1.Clear();
            }
        }

        private void luongcbTextBox_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (luongcbTextBox.Text == "")
            {
                this.errorProvider1.Clear();
                phucapTextBox.Enabled = false;
            }
            else
            {

                if (char.IsDigit(control.Text[control.Text.Length - 1]))
                    this.errorProvider1.Clear();
                else
                    this.errorProvider1.SetError(control, "Vui lòng nhập giá trị số !");
                phucapTextBox.Enabled = true;
            }
        }

        private void phucapTextBox_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (phucapTextBox.Text == "")
            {
                this.errorProvider1.Clear();
                thuongTextBox.Enabled = false;
            }
            else
            {

                if (char.IsDigit(control.Text[control.Text.Length - 1]))
                    this.errorProvider1.Clear();
                else
                    this.errorProvider1.SetError(control, "Vui lòng nhập giá trị số !");
                thuongTextBox.Enabled = true;
            }
        }

        private void thuongTextBox_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (thuongTextBox.Text == "")
                this.errorProvider1.Clear();
            else
            {

                if (char.IsDigit(control.Text[control.Text.Length - 1]))
                    this.errorProvider1.Clear();
                else
                    this.errorProvider1.SetError(control, "Vui lòng nhập giá trị số !");

            }
        }

        private void chucvuTextBox_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (chucvuTextBox.Text == "")
                this.errorProvider1.Clear();
            else
            {

                if (char.IsDigit(control.Text[control.Text.Length - 1]))
                    this.errorProvider1.SetError(control, "Chức vụ không chứa giá trị số !");
                else
                    this.errorProvider1.Clear();
            }
        }

        private void maSPLabel_Click(object sender, EventArgs e)
        {

        }

        private void mKTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void sdtTextBox_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (sdtTextBox.Text == "")
                this.errorProvider1.Clear();
            else
            {

                if (char.IsDigit(control.Text[control.Text.Length - 1]))
                    this.errorProvider1.Clear();
                else
                    this.errorProvider1.SetError(control, "Vui lòng nhập giá trị số !");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                try
                {
                    string sql = "select * from SP where MaSP like N'%" + textBox2.Text + "%' or TenSP like N'%" + textBox2.Text + "%' or MaNCC like N'%" + textBox2.Text + "%' or Soluong like N'%" + textBox2.Text + "%' or Gia like N'%" + textBox2.Text + "%' or Ghichu like N'%" + textBox2.Text + "%'";
                    sPDataGridView.DataSource = cn.XemDL(sql);
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (timkiemTextbox.Text == "")
            {
                sPDataGridView.DataSource = cn.XemDL("select * from SP");
            }
        }

        private void sPDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (maSPTextBox.Text == "" | tenSPTextBox.Text == "" | maNCCTextBox.Text == "" | soluongTextBox.Text == "" | giaTextBox.Text == "" | ghichuTextBox.Text == "" )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường thông tin!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string sql = "insert into SP values('" + maSPTextBox.Text + "',N'" + tenSPTextBox.Text + "','" + maNCCTextBox.Text + "','" + soluongTextBox.Text + "','" + giaTextBox.Text + "',N'" + ghichuTextBox.Text + "')";
                    cn.ThucThiDl(sql);
                    MessageBox.Show("Thêm thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.sPTableAdapter.Fill(this.qLsieuthiDataSet.SP);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi! Chưa thêm được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (maSPTextBox.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần cập nhật!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (tenSPTextBox.Text == "" | maNCCTextBox.Text == "" | soluongTextBox.Text == "" | giaTextBox.Text == "" | ghichuTextBox.Text == "")
            {
                MessageBox.Show("Các trường thông tin không được phép rỗng! Vui lòng nhập lại!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {
                    string sql = "update SP set TenSP=N'" + tenSPTextBox.Text + "',MaNCC=N'" + maNCCTextBox.Text + "',soluong='" + soluongTextBox.Text + "',gia=N'" + giaTextBox.Text + "',Ghichu=N'"+ghichuTextBox.Text +  "' where MaSP='" + maSPTextBox.Text + "'";
                    cn.ThucThiDl(sql);
                    MessageBox.Show("Cập nhật thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.sPTableAdapter.Fill(this.qLsieuthiDataSet.SP);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi! Chưa cập nhật được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (maSPTextBox.Text != "")
            {
                try
                {
                    string sql = "delete SP where MaSP = '" + maSPTextBox.Text + "'";
                    cn.ThucThiDl(sql);
                    MessageBox.Show("Xóa thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sPDataGridView.DataSource = cn.XemDL("select * from SP");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi! Chưa xóa được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (maKHTextBox.Text != "")
            {
                try
                {
                    string sql = "delete KHACHHANG where MaKH = '" + maKHTextBox.Text + "'";
                    cn.ThucThiDl(sql);
                    MessageBox.Show("Xóa thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   kHACHHANGDataGridView.DataSource = cn.XemDL("select * from KHACHHANG");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi! Chưa xóa được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (maKHTextBox.Text == "")
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần cập nhật!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (maKHTextBox.Text == "" | tenKHTextBox.Text == "" | diachiTextBox1.Text == "" | sdtTextBox1.Text == "" )
            {
                MessageBox.Show("Các trường thông tin không được phép rỗng! Vui lòng nhập lại!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {
                    string sql = "update KHACHHANG set TenKH=N'" + tenKHTextBox.Text + "',Diachi=N'" + diachiTextBox1.Text + "',Sdt='" + sdtTextBox1.Text + "' where MaKH='" + maKHTextBox.Text + "'";
                    cn.ThucThiDl(sql);
                    MessageBox.Show("Cập nhật thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.kHACHHANGTableAdapter.Fill(this.qLsieuthiDataSet.KHACHHANG);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi! Chưa cập nhật được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (maKHTextBox.Text == "" | tenKHTextBox.Text == "" | diachiTextBox1.Text == "" | sdtTextBox1.Text == "" )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường thông tin!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string sql = "insert into KHACHHANG values('" + maKHTextBox.Text + "',N'" + tenKHTextBox.Text + "',N'" + diachiTextBox1.Text + "','" +sdtTextBox1.Text + "')";
                    cn.ThucThiDl(sql);
                    MessageBox.Show("Thêm thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.kHACHHANGTableAdapter.Fill(this.qLsieuthiDataSet.KHACHHANG);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi! Chưa thêm được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void kHACHHANGDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                maKHTextBox.Text = kHACHHANGDataGridView.CurrentRow.Cells[0].Value.ToString().Trim();
                tenKHTextBox.Text = kHACHHANGDataGridView.CurrentRow.Cells[1].Value.ToString().Trim();
                diachiTextBox1.Text = kHACHHANGDataGridView.CurrentRow.Cells[2].Value.ToString().Trim();
                sdtTextBox1.Text = kHACHHANGDataGridView.CurrentRow.Cells[3].Value.ToString().Trim();
            }
            catch (Exception)
            {

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                try
                {
                    string sql = "select * from KHACHHANG where MaKH like N'%" + textBox3.Text + "%' or TenKH like N'%" + textBox3.Text + "%' or Diachi like N'%" + textBox3.Text + "%' or Sdt like N'%" + textBox3.Text + "%'";
                    kHACHHANGDataGridView.DataSource = cn.XemDL(sql);
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
                kHACHHANGDataGridView.DataSource = cn.XemDL("select * from KHACHHANG");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                try
                {
                    string sql = "select * from NCC where MaNCC like N'%" + textBox5.Text + "%' or TenNCC like N'%" + textBox5.Text + "%' or Diachi like N'%" + textBox5.Text + "%' or Sdt like N'%" + textBox5.Text + "%'";
                    nCCDataGridView.DataSource = cn.XemDL(sql);
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                nCCDataGridView.DataSource = cn.XemDL("select * from NCC");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (maNCCTextBox1.Text == "" | tenNCCTextBox.Text == "" | diachiTextBox2.Text == "" | sdtTextBox2.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường thông tin!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string sql = "insert into NCC values('" + maNCCTextBox1.Text + "',N'" + tenNCCTextBox.Text + "',N'" + diachiTextBox2.Text + "','" + sdtTextBox2.Text + "')";
                    cn.ThucThiDl(sql);
                    MessageBox.Show("Thêm thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.nCCTableAdapter.Fill(this.qLsieuthiDataSet.NCC);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi! Chưa thêm được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (maNCCTextBox1.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần cập nhật!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (maNCCTextBox1.Text == "" | tenNCCTextBox.Text == "" | diachiTextBox2.Text == "" | sdtTextBox2.Text == "")
            {
                MessageBox.Show("Các trường thông tin không được phép rỗng! Vui lòng nhập lại!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {
                    string sql = "update NCC set TenNCC=N'" + tenNCCTextBox.Text + "',Diachi=N'" + diachiTextBox2.Text + "',Sdt='" + sdtTextBox2.Text + "' where MaNCC='" + maNCCTextBox1.Text + "'";
                    cn.ThucThiDl(sql);
                    MessageBox.Show("Cập nhật thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.nCCTableAdapter.Fill(this.qLsieuthiDataSet.NCC);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi! Chưa cập nhật được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (maNCCTextBox1.Text != "")
            {
                try
                {
                    string sql = "delete NCC where MaNCC = '" + maNCCTextBox1.Text + "'";
                    cn.ThucThiDl(sql);
                    MessageBox.Show("Xóa thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nCCDataGridView.DataSource = cn.XemDL("select * from NCC");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi! Chưa xóa được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                try
                {
                    string sql = "select * from TAIKHOAN where TenTK like N'%" + textBox4.Text + "%' or MK like N'%" + textBox4.Text + "%' or CV like N'%" + textBox4.Text + "%' or Fullname like N'%" + textBox4.Text + "%'";
                    tAIKHOANDataGridView.DataSource = cn.XemDL(sql);
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                tAIKHOANDataGridView.DataSource = cn.XemDL("select * from TAIKHOAN");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (tenTKTextBox.Text == "" | mKTextBox.Text == "" | cVTextBox.Text == "" | fullnameTextBox.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường thông tin!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string sql = "insert into TAIKHOAN  values('" + tenTKTextBox.Text + "','" + mKTextBox.Text + "',N'" + cVTextBox.Text + "',N'" + fullnameTextBox.Text + "')";
                    cn.ThucThiDl(sql);
                    MessageBox.Show("Thêm thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.tAIKHOANTableAdapter.Fill(this.qLsieuthiDataSet.TAIKHOAN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi! Chưa thêm được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (tenTKTextBox.Text == "")
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần cập nhật!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (tenTKTextBox.Text == "" | mKTextBox.Text == "" | cVTextBox.Text == "" | fullnameTextBox.Text == "")
            {
                MessageBox.Show("Các trường thông tin không được phép rỗng! Vui lòng nhập lại!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {
                    string sql = "update TAIKHOAN set MK=N'" + mKTextBox.Text + "',CV=N'" + cVTextBox.Text + "',Fullname='" + fullnameTextBox.Text + "' where TenTK='" + tenTKTextBox.Text + "'";
                    cn.ThucThiDl(sql);
                    MessageBox.Show("Cập nhật thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.tAIKHOANTableAdapter.Fill(this.qLsieuthiDataSet.TAIKHOAN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi! Chưa cập nhật được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (tenTKTextBox.Text != "")
            {
                try
                {
                    string sql = "delete TAIKHOAN where TenTK = '" + tenTKTextBox.Text + "'";
                    cn.ThucThiDl(sql);
                    MessageBox.Show("Xóa thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tAIKHOANDataGridView.DataSource = cn.XemDL("select * from TAIKHOAN");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi! Chưa xóa được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void sPDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                maSPTextBox.Text = sPDataGridView.CurrentRow.Cells[0].Value.ToString().Trim();
                tenSPTextBox.Text = sPDataGridView.CurrentRow.Cells[1].Value.ToString().Trim();
                maNCCTextBox.Text = sPDataGridView.CurrentRow.Cells[2].Value.ToString().Trim();
                soluongTextBox.Text = sPDataGridView.CurrentRow.Cells[3].Value.ToString().Trim();
                giaTextBox.Text = sPDataGridView.CurrentRow.Cells[4].Value.ToString().Trim();
                ghichuTextBox.Text = sPDataGridView.CurrentRow.Cells[5].Value.ToString().Trim();

            }
            catch (Exception)
            {

            }
        }

        private void nCCDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tAIKHOANDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tenTKTextBox.Text = tAIKHOANDataGridView.CurrentRow.Cells[0].Value.ToString().Trim();
                mKTextBox.Text = tAIKHOANDataGridView.CurrentRow.Cells[1].Value.ToString().Trim();
                cVTextBox.Text = tAIKHOANDataGridView.CurrentRow.Cells[2].Value.ToString().Trim();
                fullnameTextBox.Text = tAIKHOANDataGridView.CurrentRow.Cells[3].Value.ToString().Trim();
            }
            catch (Exception)
            {

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

        private void giaTextBox_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (giaTextBox.Text == "")
                this.errorProvider1.Clear();
            else
            {

                if (char.IsDigit(control.Text[control.Text.Length - 1]))
                    this.errorProvider1.Clear();
                else
                    this.errorProvider1.SetError(control, "Vui lòng nhập giá trị số !");

            }
        }

        private void tenKHTextBox_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (tenKHTextBox.Text == "")
                this.errorProvider1.Clear();
            else
            {

                if (char.IsDigit(control.Text[control.Text.Length - 1]))
                    this.errorProvider1.SetError(control, "Họ tên không chứa giá trị số !");
                else        
                    this.errorProvider1.Clear();
            }
        }

        private void diachiTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void sdtTextBox1_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (sdtTextBox1.Text == "")
                this.errorProvider1.Clear();
            else
            {

                if (char.IsDigit(control.Text[control.Text.Length - 1]))
                    this.errorProvider1.Clear();
                else
                    this.errorProvider1.SetError(control, "Vui lòng nhập giá trị số !");

            }
        }

        private void sdtTextBox2_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (sdtTextBox2.Text == "")
                this.errorProvider1.Clear();
            else
            {

                if (char.IsDigit(control.Text[control.Text.Length - 1]))
                    this.errorProvider1.Clear();
                else
                    this.errorProvider1.SetError(control, "Vui lòng nhập giá trị số !");

            }
        }

        private void tenNCCTextBox_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (tenNCCTextBox.Text == "")
                this.errorProvider1.Clear();
            else
            {

                if (char.IsDigit(control.Text[control.Text.Length - 1]))
                    this.errorProvider1.SetError(control, "Tên NCC không chứa giá trị số !");
                else
                    this.errorProvider1.Clear();
            }
        }

        private void fullnameTextBox_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (fullnameTextBox.Text == "")
                this.errorProvider1.Clear();
            else
            {

                if (char.IsDigit(control.Text[control.Text.Length - 1]))
                    this.errorProvider1.SetError(control, "Không chứa giá trị số !");
                else
                    this.errorProvider1.Clear();
            }
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.ForeColor = Color.Blue;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Đăng Xuất!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        private void btnInluong_Click(object sender, EventArgs e)
        {
            Inluong inluong = new Inluong();
            inluong.Show();
        }

        private void nHANVIENDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                maNVTextBox.Text = nHANVIENDataGridView.CurrentRow.Cells[0].Value.ToString().Trim();
                hotenTextBox.Text = nHANVIENDataGridView.CurrentRow.Cells[1].Value.ToString().Trim();
                ngaysinhTextBox.Text = nHANVIENDataGridView.CurrentRow.Cells[2].Value.ToString().Trim();
                diachiTextBox.Text = nHANVIENDataGridView.CurrentRow.Cells[3].Value.ToString().Trim();
                sdtTextBox.Text = nHANVIENDataGridView.CurrentRow.Cells[4].Value.ToString().Trim();
                chucvuTextBox.Text = nHANVIENDataGridView.CurrentRow.Cells[5].Value.ToString().Trim();
                luongcbTextBox.Text = nHANVIENDataGridView.CurrentRow.Cells[6].Value.ToString().Trim();
                phucapTextBox.Text = nHANVIENDataGridView.CurrentRow.Cells[7].Value.ToString().Trim();
                thuongTextBox.Text = nHANVIENDataGridView.CurrentRow.Cells[8].Value.ToString().Trim();
                luongTextBox.Text = nHANVIENDataGridView.CurrentRow.Cells[9].Value.ToString().Trim();

            }
            catch (Exception)
            {

            }
        }

        private void kHACHHANGDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                maKHTextBox.Text = kHACHHANGDataGridView.CurrentRow.Cells[0].Value.ToString().Trim();
                tenKHTextBox.Text = kHACHHANGDataGridView.CurrentRow.Cells[1].Value.ToString().Trim();
                diachiTextBox1.Text = kHACHHANGDataGridView.CurrentRow.Cells[2].Value.ToString().Trim();
                sdtTextBox1.Text = kHACHHANGDataGridView.CurrentRow.Cells[3].Value.ToString().Trim();
            }
            catch (Exception)
            {

            }
        }

        private void nCCDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                maNCCTextBox.Text = nCCDataGridView.CurrentRow.Cells[0].Value.ToString().Trim();
                tenNCCTextBox.Text = nCCDataGridView.CurrentRow.Cells[1].Value.ToString().Trim();
                diachiTextBox2.Text = nCCDataGridView.CurrentRow.Cells[2].Value.ToString().Trim();
                sdtTextBox2.Text = nCCDataGridView.CurrentRow.Cells[3].Value.ToString().Trim();
            }
            catch (Exception)
            {

            }
        }

        private void tAIKHOANDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tenTKTextBox.Text = tAIKHOANDataGridView.CurrentRow.Cells[0].Value.ToString().Trim();
                mKTextBox.Text = tAIKHOANDataGridView.CurrentRow.Cells[1].Value.ToString().Trim();
                cVTextBox.Text = tAIKHOANDataGridView.CurrentRow.Cells[2].Value.ToString().Trim();
                fullnameTextBox.Text = tAIKHOANDataGridView.CurrentRow.Cells[3].Value.ToString().Trim();
            }
            catch (Exception)
            {

            }
        }
    }
}
