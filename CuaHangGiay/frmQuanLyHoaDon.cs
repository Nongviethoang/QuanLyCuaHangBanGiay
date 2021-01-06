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
    public partial class frmQuanLyHoaDon : Form
    {
        QLCuaHangBanGiayDataContext data = new QLCuaHangBanGiayDataContext();
        double tongTien = 0;
        List<chiTietHoaDon> list = new List<chiTietHoaDon>();
        public frmQuanLyHoaDon()
        {
            InitializeComponent();
        }
        private void frmQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            TenSP();
            TenKH();
            txtNgayLap.Text = DateTime.Now.ToString();
           
        }
        //Hiện thị số điện thoại của khách hàng khi chọn tên khách hàng
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                khachHang khht = data.khachHangs.SingleOrDefault(kh => kh.makh == Int32.Parse(cbKH.SelectedValue.ToString()));
                txtSDT.Text = khht.sodt;
            }
            catch{
            }
            
     
        }
        //Hiện thị mã nhân viên
       
        private void label3_Click(object sender, EventArgs e)
        {

        }

       
        //Hàm lấy tên của khách hàng hiển thị lên textbox
        private void TenKH()
        {
            var sqlTenKH = from kh in data.khachHangs select kh;
            cbKH.DataSource = sqlTenKH;
            cbKH.DisplayMember = "tenkh";
            cbKH.ValueMember = "makh";
            khachHang khht = sqlTenKH.SingleOrDefault(kh => kh.makh == int.Parse(cbKH.SelectedValue.ToString()));
            txtSDT.Text = khht.sodt;


        }
        //Hiển thị tên sản phẩm
        private void TenSP()
        {
            var sqlTenSp = from sp in data.Giays select sp;
            cbSP.DataSource = sqlTenSp;
            cbSP.DisplayMember = "tengiay";
            cbSP.ValueMember = "magiay";
            Giay g = data.Giays.SingleOrDefault(d => d.magiay == int.Parse(cbSP.SelectedValue.ToString()));
            txtGiaBan.Text = g.giaban.ToString();
            txtThanhTien.Text = (g.giaban * int.Parse(txtSoLuong.Text)).ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int soluong = int.Parse(txtSoLuong.Text);
                
                if (soluong < 1)
                {
                    MessageBox.Show("Số lượng không được âm hoặc bằng 0");
                }
                else
                {
                    //Kiểm tra số lượng hàng còn có đủ số lượng để bán
                    Giay sp = data.Giays.SingleOrDefault(g => g.magiay == soluong);
                    if (sp.soluongcon < soluong)
                    {
                        //Không đủ thì đưa ra thông báo
                        MessageBox.Show("Số lượng không đủ");
                    }

                    else
                    {
                        double tien = double.Parse(txtThanhTien.Text);
                        tongTien += tien;
                        txtTongTien.Text = tongTien.ToString();

                        sp.soluongcon = sp.soluongcon - soluong;

                        DataGridViewRow dongMoi = (DataGridViewRow)dataGridViewHoaDon.Rows[0].Clone();
                        dongMoi.Cells[0].Value = cbSP.SelectedValue.ToString();
                        dongMoi.Cells[1].Value = cbSP.Text;
                        dongMoi.Cells[2].Value = soluong;
                        dongMoi.Cells[3].Value = txtGiaBan.Text;
                        dongMoi.Cells[4].Value = txtThanhTien.Text;
                        dongMoi.Cells[5].Value = "Xóa";
                        dataGridViewHoaDon.Rows.Add(dongMoi);

                    }
                }
            }
            catch
            {
                MessageBox.Show("Dữ liệu không hợp lệ");
            }
            
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        //Hiển thị thành tiền khi chọn tên sản phẩm
        private void cbSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               Giay sp = data.Giays.SingleOrDefault(g => g.magiay == int.Parse(cbSP.SelectedValue.ToString()));
                txtGiaBan.Text = sp.giaban.ToString();
                int soluong = int.Parse(txtSoLuong.Text);
                double giaban = double.Parse(txtGiaBan.Text);
                try
                {
                    double giamGia = double.Parse(txtGiamGia.Text)*0.01;
                    if(giamGia>=0)
                    {
                        txtThanhTien.Text = (soluong * giaban-(soluong*giamGia*giaban)).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Mã giảm giá không thể âm");
                        txtGiamGia.Text = "0";
                    }
                    
                }
                catch
                {
                    MessageBox.Show("Mã giảm không hợp lệ");
                    txtGiamGia.Text = "0";
                }
               
            }
            catch
            {
            }
        }
        //Xóa sửa thông tin sản phẩm khách hàng định mua
        private void dataGridViewHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==5)
            {
                double tien = double.Parse(dataGridViewHoaDon.Rows[e.RowIndex].Cells[4].Value.ToString());
                string tensp = dataGridViewHoaDon.Rows[e.RowIndex].Cells[0].Value.ToString();
                double TongTien = double.Parse(txtTongTien.Text);
                txtTongTien.Text = (TongTien - tien).ToString();
                dataGridViewHoaDon.Rows.RemoveAt(e.RowIndex);
            }
            
        }
        //Lập hóa đơn mới
        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                hoaDonBanHang hdMoi = new hoaDonBanHang();
                hdMoi.manv = int.Parse(txtMaNV.Text);
                hdMoi.makh = int.Parse(cbKH.SelectedValue.ToString());
                hdMoi.ngayban = txtNgayLap.Text;
                hdMoi.giamgia = int.Parse(txtGiamGia.Text);

                double tt = 0;
                for (int i = 0; i < dataGridViewHoaDon.RowCount - 1; i++)
                {
                    double tien = double.Parse(dataGridViewHoaDon.Rows[i].Cells[4].Value.ToString());
                    tt += tien;
                }
                if (tt == 0)
                {
                    MessageBox.Show("Chưa mua gì");
                }
                else
                {
                    hdMoi.tongtien = tt;
                    data.hoaDonBanHangs.InsertOnSubmit(hdMoi);
                    //Thêm các hóa đơn chi tiết
                    for (int i = 0; i < dataGridViewHoaDon.RowCount - 1; i++)
                    {

                        chiTietHoaDon ctht = new chiTietHoaDon();
                        ctht.magiay = int.Parse(dataGridViewHoaDon.Rows[i].Cells[0].Value.ToString());
                        ctht.mahdbh = hdMoi.mahdbh;
                        ctht.soluong = int.Parse(dataGridViewHoaDon.Rows[i].Cells[2].Value.ToString());
                        //thêm vào hóa đơn  mới
                        hdMoi.chiTietHoaDons.Add(ctht);
                    }
                    //Lưu vào cơ sở dữ liệu
                    data.SubmitChanges();
                    MessageBox.Show("Thêm hóa đơn thành công. Tổng tiền:"+tt);
                    dataGridViewHoaDon.Rows.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Dữ liệu không hợp lệ");
            }
        }
        private void txtNgayLap_TextChanged(object sender, EventArgs e)
        {

        } 
        private void txtTenNV_TextChanged(object sender, EventArgs e)
        {
           
        }
        //Hiển thị tên nhân viên theo mã nhân viên
        private void cbManv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                nhanVien nvht = data.nhanViens.SingleOrDefault(n => n.manv == Int32.Parse(txtMaNV.ToString()));
                txtTenNV.Text = nvht.tennv;
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int manvht = int.Parse(txtMaNV.Text);
            taiKhoan tkht = data.taiKhoans.SingleOrDefault(t => t.manv == manvht);
            frmLichSuBanHang send = new frmLichSuBanHang(manvht);
            send.Tag = tkht;
            this.Visible = false;
            send.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridViewHoaDon.Rows.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int manvht = int.Parse(txtMaNV.Text);
            taiKhoan tkht = data.taiKhoans.SingleOrDefault(t => t.manv == manvht);
            frmMain send = new frmMain(manvht);
            send.Tag = tkht;
            this.Visible = false;
            send.ShowDialog();
        }
        public void duyet(DataGridView dt)
        {
            for(int i=0;i<dt.RowCount-1;i++)
            {

                for (int j = i + 1; j < dt.RowCount - 1; j++)
                {
                    int x = int.Parse(dataGridViewHoaDon.Rows[i].Cells[0].Value.ToString());
                    int y=int.Parse(dataGridViewHoaDon.Rows[j].Cells[0].Value.ToString());
                    if(x==y)
                    {
                        int slt = int.Parse(dataGridViewHoaDon.Rows[i].Cells[2].Value.ToString());
                        int sls = int.Parse(dataGridViewHoaDon.Rows[j].Cells[2].Value.ToString());
                        int sl = sls + slt;
                        dataGridViewHoaDon.Rows[i].Cells[2].Value = sl;
                        dataGridViewHoaDon.Rows[i].Cells[4].Value = int.Parse(dataGridViewHoaDon.Rows[i].Cells[4].Value.ToString())+int.Parse(dataGridViewHoaDon.Rows[j].Cells[4].Value.ToString());
                        dataGridViewHoaDon.Rows.RemoveAt(j);
        }
                    
                }
            }
        }
        //DUyệt xem các sản phẩm cùng mã
        private void button4_Click(object sender, EventArgs e)
        {
            duyet(dataGridViewHoaDon);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //Lấy mã của tài khoản đăng nhập và hiển thị tên của nhân viên
        public frmQuanLyHoaDon(int ma) : this()
        {

            nhanVien nvht = data.nhanViens.SingleOrDefault(n => n.manv == ma);
            txtMaNV.Text = nvht.manv.ToString();
            txtTenNV.Text = nvht.tennv;
        }
    }
}

