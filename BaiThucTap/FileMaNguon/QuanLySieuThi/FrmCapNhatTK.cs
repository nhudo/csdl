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
    public partial class FrmCapNhatTK : Form
    {
        public FrmCapNhatTK()
        {
            InitializeComponent();
            foreach (Form f in Application.OpenForms)
                openForms.Add(f);
        }
        Conection cn = new Conection();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCapNhatTK_Load(object sender, EventArgs e)
        {
            string sql2 = "select * from TAIKHOAN where TenTK='" + FrmDangNhap.name +"'";
            textBox1.Text = cn.XemDL(sql2).Rows[0][0].ToString().Trim();
            textBox3.Text = cn.XemDL(sql2).Rows[0][2].ToString().Trim();
            textBox4.Text = cn.XemDL(sql2).Rows[0][3].ToString().Trim();
        }
        List<Form> openForms = new List<Form>();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu để xác thực!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox2.Text.Trim() == "" | textBox4.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin cần cập nhật!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (textBox5.Text == FrmDangNhap.passdoi)
                    {
                        string sql = "update TAIKHOAN set  MK='" + textBox2.Text + "',Fullname=N'" + textBox4.Text + "' where TenTK=N'" + textBox1.Text + "'";
                        cn.ThucThiDl(sql);
                        MessageBox.Show("Cập nhật thành công! Vui lòng đăng nhập lại hệ thống!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        foreach (Form f in openForms)
                        {
                            if (f.Name == "FrmAdmin" | f.Name == "FrmNhanVien" | f.Name == "FrmNVKho")
                            {
                                f.Close();
                            }
                        }
                        FrmDangNhap dn = new FrmDangNhap();
                        dn.Show();
                        this.Hide();
                    }
                    else
                        MessageBox.Show("Sai Mật khẩu! Vui lòng kiểm tra lại!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi! Chưa cập nhật được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if(textBox5.Text!="")
            {
                textBox2.Enabled = true;
                textBox4.Enabled = true;
            }
            else
            {
                textBox2.Enabled = false;
                textBox4.Enabled = false;
            }
        }
        }
    }

