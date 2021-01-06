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
    public partial class frmLichSuNhapHang : Form
    {
        QLCuaHangBanGiayDataContext data = new QLCuaHangBanGiayDataContext();
        int maPN = 0;
        string tenNhanVien = "";
        string ngayLap = "";
        string tongTien = "";
        int thanhTien = 0;
        string tenSp = "";
        int donGia = 0;
        int soluong = 0;
        int manv = 0;
        string tenNCC = "";
        //Lấy mã của tài khoản đăng nhập và hiển thị tên của nhân viên
        public frmLichSuNhapHang(int ma) : this()
        {

            nhanVien nvht = data.nhanViens.SingleOrDefault(n => n.manv == ma);
            txtMa.Text = nvht.manv.ToString();
            txtTen.Text = nvht.tennv;
        }
        public frmLichSuNhapHang()
        {
            InitializeComponent();
        }

        private void lsnhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void HienThi()
        {
            lsnhap.Rows.Clear();
            var ls = from pn in data.phieunhaps
                     select new
                     {
                         pn.maphieunhap,
                         pn.ngaynhap,
                         pn.nhanVien.tennv,
                         pn.nhacungcap.tenncc,
                         pn.tongtien
                     };
            foreach (var item in ls)
            {
                DataGridViewRow dongMoi = (DataGridViewRow)lsnhap.Rows[0].Clone();
                dongMoi.Cells[0].Value = item.maphieunhap;
                dongMoi.Cells[1].Value = item.tennv;
                dongMoi.Cells[2].Value = item.tenncc;
                dongMoi.Cells[3].Value = item.ngaynhap;
                dongMoi.Cells[4].Value = item.tongtien;
                dongMoi.Cells[5].Value = "In phiếu";
                lsnhap.Rows.Add(dongMoi);
            }
        }

        private void lsnhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int manvht = int.Parse(txtMa.Text);
            taiKhoan tkht = data.taiKhoans.SingleOrDefault(t => t.manv == manvht);
            frmQuanLyPhieuNhap send = new frmQuanLyPhieuNhap(manvht);
            send.Tag = tkht;
            this.Visible = false;
            send.ShowDialog();
        }

        private void frmLichSuNhapHang_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HienThi();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int ma = int.Parse(lsnhap.Rows[e.RowIndex].Cells[0].Value.ToString());
            phieunhap pn = data.phieunhaps.SingleOrDefault(h => h.maphieunhap == ma);
            if (e.ColumnIndex == 5)
            {
                maPN = int.Parse(pn.maphieunhap.ToString());
                ppdPhieuNhap.Document = PDPhieuNhap;
                ppdPhieuNhap.ShowDialog();

            }

        }

        private void lsnhap_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dgchitietPN.Rows.Clear();
            if (e.RowIndex > 0)
            {
                int mapn = int.Parse(lsnhap.Rows[e.RowIndex].Cells[0].Value.ToString());
                var sqlCT = from ct in data.chiTietPhieuNhaps
                            join pn in data.phieunhaps on ct.maphieunhap equals pn.maphieunhap
                            join sp in data.Giays on ct.magiay equals sp.magiay
                            where ct.maphieunhap == mapn
                            select new
                            {
                                ct.Giay.tengiay,
                                ct.soluong,
                                ct.Giay.gianhap,
                            };
                foreach (var ct in sqlCT)
                {
                    DataGridViewRow dongMoi = (DataGridViewRow)dgchitietPN.Rows[0].Clone();
                    dongMoi.Cells[0].Value = ct.tengiay;
                    dongMoi.Cells[1].Value = ct.soluong;
                    dongMoi.Cells[2].Value = ct.gianhap;
                    dongMoi.Cells[3].Value = ct.gianhap * ct.soluong;
                    dgchitietPN.Rows.Add(dongMoi);
                }
            }
        }

        private void PDPhieuNhap_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Lấy id của phiếu nhập
            var pn = data.phieunhaps.SingleOrDefault(h => h.maphieunhap == maPN);
            //Lấy bề rộng của giấy in
            var width = PDPhieuNhap.DefaultPageSettings.PaperSize.Width;

            e.Graphics.DrawString("Phiếu nhập hàng", new System.Drawing.Font("Couriar New", 25, FontStyle.Bold),
                Brushes.Black, new Point(200, 50));
            e.Graphics.DrawString(string.Format("Ngày lập:{0}", pn.ngaynhap), new System.Drawing.Font("Couriar New", 20, FontStyle.Bold),
                Brushes.Black, new Point(100, 100));
            e.Graphics.DrawString(string.Format("Số:{0}", pn.maphieunhap), new System.Drawing.Font("Couriar New", 20, FontStyle.Bold),
                Brushes.Black, new Point(600, 100));
            e.Graphics.DrawString("Tên SP", new System.Drawing.Font("Couriar New", 20, FontStyle.Bold),
                    Brushes.Black, new Point(100, 150));
            e.Graphics.DrawString("Số lượng", new System.Drawing.Font("Couriar New", 20, FontStyle.Bold),
                   Brushes.Black, new Point(250, 150));
            e.Graphics.DrawString("Giá bán", new System.Drawing.Font("Couriar New", 20, FontStyle.Bold),
                   Brushes.Black, new Point(400, 150));
            e.Graphics.DrawString("Thành tiền", new System.Drawing.Font("Couriar New", 20, FontStyle.Bold),
                   Brushes.Black, new Point(550, 150));
            var sql = from ctpn in data.chiTietPhieuNhaps
                      where ctpn.maphieunhap == maPN
                      select new
                      {
                          tenSp = ctpn.Giay.tengiay,
                          soluong = ctpn.soluong,
                          donGia = ctpn.Giay.gianhap,
                          thanhTien = ctpn.soluong * ctpn.Giay.giaban,
                          

                      };
            int y = 200;
            foreach (var item in sql)
            {
                e.Graphics.DrawString(item.tenSp, new System.Drawing.Font("Couriar New", 20, FontStyle.Regular),
                    Brushes.Black, new Point(100, y));
                e.Graphics.DrawString(item.soluong.ToString(), new System.Drawing.Font("Couriar New", 20, FontStyle.Regular),
                  Brushes.Black, new Point(270, y));
                e.Graphics.DrawString(item.donGia.ToString(), new System.Drawing.Font("Couriar New", 20, FontStyle.Regular),
                 Brushes.Black, new Point(400, y));
                e.Graphics.DrawString(item.thanhTien.ToString(), new System.Drawing.Font("Couriar New", 20, FontStyle.Regular),
                       Brushes.Black, new Point(550, y));
                y += 50;
            }
            e.Graphics.DrawString(string.Format("Tổng số tiền:{0}", pn.tongtien), new System.Drawing.Font("Couriar New", 20, FontStyle.Regular),
                      Brushes.Black, new Point(100, y + 20));
            var tenNV = from h in data.phieunhaps
                        where h.maphieunhap == maPN
                        select new
                        {
                            tenNV = h.nhanVien.tennv,
                            manv = h.manv,
                            tenNCC=h.nhacungcap.tenncc
                            

                        };
            foreach (var item in tenNV)
            {
                e.Graphics.DrawString(string.Format("Người lập :({0}){1}", item.manv, item.tenNV), new System.Drawing.Font("Couriar New", 20, FontStyle.Bold),
                  Brushes.Black, new Point(100, y + 100));
                e.Graphics.DrawString(string.Format("Nhà cung cấp :{0}", item.tenNCC), new System.Drawing.Font("Couriar New", 20, FontStyle.Bold),
                 Brushes.Black, new Point(100, y + 180));
            }
        }
    }
    
}
