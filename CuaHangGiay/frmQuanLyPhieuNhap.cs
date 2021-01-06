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
    public partial class frmQuanLyPhieuNhap : Form
    {
        QLCuaHangBanGiayDataContext data = new QLCuaHangBanGiayDataContext();
        double tongTien = 0;
        public frmQuanLyPhieuNhap()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmQuanLyPhieuNhap_Load(object sender, EventArgs e)
        {
            TenSP();
            TenNCC();
            txtNgayLap.Text = DateTime.Now.ToString();
        }
        
        private void TenNCC()
        {
            var sqlTenNCC = from kh in data.nhacungcaps select kh;
            cbTenNCC.DataSource = sqlTenNCC;
            cbTenNCC.DisplayMember = "tenncc";
            cbTenNCC.ValueMember = "mancc";
            nhacungcap khht = sqlTenNCC.SingleOrDefault(kh => kh.mancc == int.Parse(cbTenNCC.SelectedValue.ToString()));
            txtSDTNCC.Text = khht.dienthoai;


        }

        private void cbNV_SelectedIndexChanged(object sender, EventArgs e)
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
        private void TenSP()
        {
            var sqlTenSp = from sp in data.Giays select sp;
            cbSP.DataSource = sqlTenSp;
            cbSP.DisplayMember = "tengiay";
            cbSP.ValueMember = "magiay";
            Giay g = data.Giays.SingleOrDefault(d => d.magiay == int.Parse(cbSP.SelectedValue.ToString()));
            txtGiaNhap.Text = g.gianhap.ToString();
            //txtThanhTien.Text = (g.gianhap * int.Parse(txtSoLuong.Text)).ToString();
        }

        private void cbSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Giay sp = data.Giays.SingleOrDefault(g => g.magiay == int.Parse(cbSP.SelectedValue.ToString()));
                txtGiaNhap.Text = sp.gianhap.ToString();
                int soluong = int.Parse(txtSoLuong.Text);
                double giaban = double.Parse(txtGiaNhap.Text);
                txtThanhTien.Text = (soluong * giaban).ToString();
            }
            catch
            {
            }
        }

        private void cbTenNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               nhacungcap khht = data.nhacungcaps.SingleOrDefault(kh => kh.mancc ==int.Parse(cbTenNCC.SelectedValue.ToString()));
                txtSDTNCC.Text = khht.dienthoai ;
            }
            catch
            {
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txtSoLuong.Text) < 1)
                {
                    MessageBox.Show("Số lượng không hợp lệ");
                }
                else
                {
                    Giay sp = data.Giays.SingleOrDefault(g => g.magiay == int.Parse(cbSP.SelectedValue.ToString()));

                    sp.soluongcon = sp.soluongcon + int.Parse(txtSoLuong.Text);
                    DataGridViewRow dongMoi = (DataGridViewRow)dataGridViewPhieuNhap.Rows[0].Clone();
                    dongMoi.Cells[0].Value = cbSP.SelectedValue.ToString();
                    dongMoi.Cells[1].Value = cbSP.Text;
                    dongMoi.Cells[2].Value = txtSoLuong.Text;
                    dongMoi.Cells[3].Value = txtGiaNhap.Text;
                    dongMoi.Cells[4].Value = txtThanhTien.Text;
                    dongMoi.Cells[5].Value = "Xóa";

                    dataGridViewPhieuNhap.Rows.Add(dongMoi);

                    double tien = double.Parse(txtThanhTien.Text);
                    tongTien += tien;
                    txtTongTien.Text = tongTien.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Dữ liệu không hợp lệ");
            }
        
            
        }

        private void btnLapPhieuNhap_Click(object sender, EventArgs e)
        {
            try
            {
                phieunhap   pnMoi = new phieunhap();
                pnMoi.manv = int.Parse(txtMaNV.Text);
                pnMoi.mancc = int.Parse(cbTenNCC.SelectedValue.ToString());
                pnMoi.ngaynhap = txtNgayLap.Text;
                pnMoi.tongtien = float.Parse(txtTongTien.Text);
                data.phieunhaps.InsertOnSubmit(pnMoi);
                for (int i = 0; i < dataGridViewPhieuNhap.RowCount - 1; i++)
                {
                    chiTietPhieuNhap ctht = new chiTietPhieuNhap();
                    ctht.magiay = int.Parse(dataGridViewPhieuNhap.Rows[i].Cells[0].Value.ToString());
                    ctht.maphieunhap = pnMoi.maphieunhap;
                    ctht.soluong = int.Parse(dataGridViewPhieuNhap.Rows[i].Cells[2].Value.ToString());
                    
                    pnMoi.chiTietPhieuNhaps.Add(ctht);
                }
                
                //Lưu vào cơ sở dữ liệu
                data.SubmitChanges();
                MessageBox.Show("Thêm phiếu nhập thành công");
                dataGridViewPhieuNhap.Rows.Clear();
                txtTongTien.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu không hợp lệ" + ex.Message);
            }
        }

        private void btnLSPN_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewPhieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                double tien = double.Parse(dataGridViewPhieuNhap.Rows[e.RowIndex].Cells[3].Value.ToString());
                string tensp = dataGridViewPhieuNhap.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTongTien.Text = (tongTien - tien).ToString();
                dataGridViewPhieuNhap.Rows.RemoveAt(e.RowIndex);
            }
        }
        public void duyet(DataGridView dt)
        {
            for (int i = 0; i < dt.RowCount - 1; i++)
            {

                for (int j = i + 1; j < dt.RowCount - 1; j++)
                {
                    int x = int.Parse(dataGridViewPhieuNhap.Rows[i].Cells[0].Value.ToString());
                    int y = int.Parse(dataGridViewPhieuNhap.Rows[j].Cells[0].Value.ToString());
                    if (x == y)
                    {
                        int slt = int.Parse(dataGridViewPhieuNhap.Rows[i].Cells[2].Value.ToString());
                        int sls = int.Parse(dataGridViewPhieuNhap.Rows[j].Cells[2].Value.ToString());
                        int sl = sls + slt;
                        dataGridViewPhieuNhap.Rows[i].Cells[2].Value = sl;
                        dataGridViewPhieuNhap.Rows[i].Cells[4].Value = int.Parse(dataGridViewPhieuNhap.Rows[i].Cells[4].Value.ToString()) + int.Parse(dataGridViewPhieuNhap.Rows[j].Cells[4].Value.ToString());
                        dataGridViewPhieuNhap.Rows.RemoveAt(j);
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            duyet(dataGridViewPhieuNhap);
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
        //Lấy mã của tài khoản đăng nhập và hiển thị tên của nhân viên
        public frmQuanLyPhieuNhap(int ma) : this()
        {

            nhanVien nvht = data.nhanViens.SingleOrDefault(n => n.manv == ma);
            txtMaNV.Text = nvht.manv.ToString();
            txtTenNV.Text = nvht.tennv;
        }

        private void btnInPN_Click(object sender, EventArgs e)
        {
            int manvht = int.Parse(txtMaNV.Text);
            taiKhoan tkht = data.taiKhoans.SingleOrDefault(t => t.manv == manvht);
            frmLichSuNhapHang send = new frmLichSuNhapHang(manvht);
            send.Tag = tkht;
            this.Visible = false;
            send.ShowDialog();
        }

        private void txtNgayLap_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
