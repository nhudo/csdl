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
    public partial class FrmThemNCC : Form
    {
        public FrmThemNCC()
        {
            InitializeComponent();
        }
        Conection cn = new Conection();
        private void button1_Click(object sender, EventArgs e)
        {
            if (manccTextBox2.Text == "" | tennccTextBox.Text == "" | diachitextBox4.Text == "" | sdttextBox2.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường thông tin!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string sqlthemkh = "insert into NCC values('" + manccTextBox2.Text + "',N'" + tennccTextBox.Text + "',N'" + diachitextBox4.Text + "','" + sdttextBox2.Text + "')";
                    cn.ThucThiDl(sqlthemkh);
                    MessageBox.Show("Thêm thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Lỗi! Chưa thêm được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tennccTextBox_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (tennccTextBox.Text == "")
                this.errorProvider1.Clear();
            else
            {

                if (char.IsDigit(control.Text[control.Text.Length - 1]))
                    this.errorProvider1.SetError(control, "Tên NCC không chứa giá trị số !");
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
    }
}
