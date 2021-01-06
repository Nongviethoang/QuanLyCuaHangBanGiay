using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangGiay
{
    public partial class frmDoiMatKhau : Form
    {
        QLCuaHangBanGiayDataContext data = new QLCuaHangBanGiayDataContext();
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        //Lấy mã tài khoản hiện thời
        public frmDoiMatKhau(int ma) : this()
        {
            txtMaNV.Text = ma.ToString();
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int maNVHT = int.Parse(txtMaNV.Text);
            taiKhoan tkht = data.taiKhoans.SingleOrDefault(t => t.manv == maNVHT);
            frmMain send = new frmMain(maNVHT);
            send.Tag = tkht;
            this.Visible = false;
            send.ShowDialog();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            taiKhoan tkSua = data.taiKhoans.SingleOrDefault(tk => tk.manv == int.Parse(txtMaNV.Text));
            if (txtMatKhau.Text != "")
            {
            if (txtMatKhau.Text == txtRePass.Text)
            {
                tkSua.matkhau = txtRePass.Text;
                data.SubmitChanges();
                    txtMatKhau.Text = "";
                    txtRePass.Text = "";
                MessageBox.Show("Đổi mật khẩu thành công");
            }
                else
                {
                    MessageBox.Show("Xác nhận mật khẩu không khớp");
                }
        }
            else
            {
                MessageBox.Show("Không được để trống");
            }
        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
