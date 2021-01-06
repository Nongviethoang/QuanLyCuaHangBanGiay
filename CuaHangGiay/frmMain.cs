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
    public partial class frmMain : Form
    {
        QLCuaHangBanGiayDataContext data = new QLCuaHangBanGiayDataContext();
       
        public frmMain()
        {
            InitializeComponent();

        }
        //Lấy mã của tài khoản đăng nhập và hiển thị tên của nhân viên
        
        public frmMain(int ma):this()
        {
            
            nhanVien nvht = data.nhanViens.SingleOrDefault(n => n.manv == ma);
            txtManv.Text = nvht.manv.ToString();
            txtTenNV.Text = nvht.tennv;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            if(int.Parse(txtManv.Text)!=1)
            {
                btnQLTaiKhoan.Visible = false;
            }
           
        }
        private void button4_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            new frmDangNhap().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int manvht = int.Parse(txtManv.Text);
            taiKhoan tkht = data.taiKhoans.SingleOrDefault(t => t.manv == manvht);
            frmQlTaiKhoan send = new frmQlTaiKhoan(manvht);
            send.Tag = tkht;
            this.Visible = false;
            send.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            int manvht = int.Parse(txtManv.Text);
            taiKhoan tkht = data.taiKhoans.SingleOrDefault(t => t.manv == manvht);
            frmDoiMatKhau send = new frmDoiMatKhau(manvht);
            send.Tag = tkht;
            this.Visible = false;
            send.ShowDialog();
        }

        private void btnQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            int manvht = int.Parse(txtManv.Text);
            taiKhoan tkht = data.taiKhoans.SingleOrDefault(t => t.manv == manvht);
            frmQuanLyHoaDon send = new frmQuanLyHoaDon(manvht);
            send.Tag = tkht;
            this.Visible = false;
            send.ShowDialog();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            int manvht = int.Parse(txtManv.Text);
            taiKhoan tkht = data.taiKhoans.SingleOrDefault(t => t.manv == manvht);
            frmNhanVien send = new frmNhanVien(manvht);
            send.Tag = tkht;
            this.Visible = false;
            send.ShowDialog();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            int manvht = int.Parse(txtManv.Text);
            taiKhoan tkht = data.taiKhoans.SingleOrDefault(t => t.manv == manvht);
            frmGiay send = new frmGiay(manvht);
            send.Tag = tkht;
            this.Visible = false;
            send.ShowDialog();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            int manvht = int.Parse(txtManv.Text);
            taiKhoan tkht = data.taiKhoans.SingleOrDefault(t => t.manv == manvht);
            frmKhachHang send = new frmKhachHang(manvht);
            send.Tag = tkht;
            this.Visible = false;
            send.ShowDialog();
        }

        private void btnNhaCC_Click(object sender, EventArgs e)
        {
            int manvht = int.Parse(txtManv.Text);
            taiKhoan tkht = data.taiKhoans.SingleOrDefault(t => t.manv == manvht);
            frmNhaCungCap send = new frmNhaCungCap(manvht);
            send.Tag = tkht;
            this.Visible = false;
            send.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int manvht = int.Parse(txtManv.Text);
            taiKhoan tkht = data.taiKhoans.SingleOrDefault(t => t.manv == manvht);
            frmQuanLyPhieuNhap send = new frmQuanLyPhieuNhap(manvht);
            send.Tag = tkht;
            this.Visible = false;
            send.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
