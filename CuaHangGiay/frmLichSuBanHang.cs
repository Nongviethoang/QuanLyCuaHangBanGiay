using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangGiay
{
    public partial class frmLichSuBanHang : Form
    {
        QLCuaHangBanGiayDataContext data = new QLCuaHangBanGiayDataContext();
        int maHoaDon = 0;
        string tenNhanVien = "";
        string ngayLap = "";
        string tongTien = "";
        int thanhTien =0;
        string tenSp = "";
        int donGia = 0;
        int soluong = 0;
        int manv = 0;
        int giamGia = 0;
        public frmLichSuBanHang()
        {
            InitializeComponent();
        }
        //Lấy mã của tài khoản đăng nhập và hiển thị tên của nhân viên
        public frmLichSuBanHang(int ma) : this()
        {

            nhanVien nvht = data.nhanViens.SingleOrDefault(n => n.manv == ma);
            txtMaNV.Text = nvht.manv.ToString();
            txtTenNV.Text = nvht.tennv;
        }
        private void frmLichSuBanHang_Load(object sender, EventArgs e)
        {
            HienThi();
        }
        private void HienThi()
        {
            //var ls = from hd in data.hoaDonBanHangs
            //         join nv in data.nhanViens on hd.manv equals nv.manv
            //         join ct in data.chiTietHoaDons on hd.mahdbh equals ct.mahdbh
            //         join sp in data.Giays on ct.magiay equals sp.magiay
            //         select new
            //         {
            //             hd.mahdbh,
            //             hd.ngayban,
            //             hd.nhanVien.tennv,
            //             hd.khachHang.tenkh,
            //             hd.tongtien
            //         };
            var ls = from hd in data.hoaDonBanHangs
                     select new
                     {
                         hd.mahdbh,
                         hd.ngayban,
                         hd.nhanVien.tennv,
                         hd.khachHang.tenkh,
                         hd.tongtien
                     };
           foreach(var item in ls)
            {
                DataGridViewRow dongMoi = (DataGridViewRow)dataGridViewLSBH.Rows[0].Clone();
                dongMoi.Cells[0].Value = item.mahdbh;
                dongMoi.Cells[1].Value = item.ngayban;
                dongMoi.Cells[2].Value = item.tennv;
                dongMoi.Cells[3].Value = item.tenkh;
                dongMoi.Cells[4].Value = item.tongtien;
                dongMoi.Cells[5].Value = "In hóa đơn";
                dataGridViewLSBH.Rows.Add(dongMoi);
            }

        }
        //private List<chiTietHoaDon> getDetailBill(int maHD)
        //{
        //    var listCTHD = from ctht in data.chiTietHoaDons select ctht;
        //    List<chiTietHoaDon> list = new List<chiTietHoaDon>();
        //    foreach(var item in listCTHD)
        //    {
        //        if(item.mahdbh==maHD)
        //        {
        //            list.Add(item);
        //        }
        //    }
        //    return list;
           
        //}

        private void dataGridViewLSBH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int maHD = int.Parse(dataGridViewLSBH.Rows[e.RowIndex].Cells[0].Value.ToString());
            hoaDonBanHang hd = data.hoaDonBanHangs.SingleOrDefault(h => h.mahdbh == maHD);
            if(e.ColumnIndex==5)
            {
                maHoaDon = int.Parse(hd.mahdbh.ToString());
                ppdHoaDon.Document = pdHoaDon;
                ppdHoaDon.ShowDialog();
                
            }
        
        }

        private void dataGridViewLSBH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewCTHD.Rows.Clear();
            if (e.RowIndex > 0)
            {
                int mahd = int.Parse(dataGridViewLSBH.Rows[e.RowIndex].Cells[0].Value.ToString());
                var sqlCT = from ct in data.chiTietHoaDons
                            join hd in data.hoaDonBanHangs on ct.mahdbh equals hd.mahdbh
                            join sp in data.Giays on ct.magiay equals sp.magiay
                            where ct.mahdbh == mahd
                            select new
                            {
                                ct.Giay.tengiay,
                                ct.soluong,
                                ct.Giay.giaban,
                                ct.hoaDonBanHang.giamgia
                            };
                foreach(var ct in sqlCT)
                {
                    DataGridViewRow dongMoi = (DataGridViewRow)dataGridViewCTHD.Rows[0].Clone();
                    dongMoi.Cells[0].Value = ct.tengiay;
                    dongMoi.Cells[1].Value = ct.soluong;
                    dongMoi.Cells[2].Value = ct.giaban;
                    dongMoi.Cells[3].Value = ct.giamgia;
                    dataGridViewCTHD.Rows.Add(dongMoi);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            int manvht = int.Parse(txtMaNV.Text);
            taiKhoan tkht = data.taiKhoans.SingleOrDefault(t => t.manv == manvht);
            frmQuanLyHoaDon send = new frmQuanLyHoaDon(manvht);
            send.Tag = tkht;
            this.Visible = false;
            send.ShowDialog();
        }

        private void pdHoaDon_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Lấy id của hóa đơn
            var hd = data.hoaDonBanHangs.SingleOrDefault(h => h.mahdbh == maHoaDon);
            //Lấy bề rộng của giấy in
            var width = pdHoaDon.DefaultPageSettings.PaperSize.Width;
            
                e.Graphics.DrawString("CỬA HÀNG THẾ GIỚI GIÀY",new System.Drawing.Font("Couriar New",25,FontStyle.Bold),
                    Brushes.Black,new Point(200,50));
            e.Graphics.DrawString(string.Format("Mã hóa đơn:{0}",hd.mahdbh), new System.Drawing.Font("Couriar New", 20, FontStyle.Bold),
                Brushes.Black, new Point(100, 100));
            e.Graphics.DrawString(string.Format("Ngày lập:{0}", hd.ngayban), new System.Drawing.Font("Couriar New", 20, FontStyle.Bold),
                Brushes.Black, new Point(310, 100));
            e.Graphics.DrawString("Tên SP", new System.Drawing.Font("Couriar New", 20, FontStyle.Bold),
                    Brushes.Black, new Point(100, 150));
            e.Graphics.DrawString("Số lượng", new System.Drawing.Font("Couriar New", 20, FontStyle.Bold),
                   Brushes.Black, new Point(250, 150));
            e.Graphics.DrawString("Đơn giá", new System.Drawing.Font("Couriar New", 20, FontStyle.Bold),
                   Brushes.Black, new Point(400, 150));
            e.Graphics.DrawString("Thành tiền", new System.Drawing.Font("Couriar New", 20, FontStyle.Bold),
                   Brushes.Black, new Point(550, 150));
            var sql = from cthd in data.chiTietHoaDons
                      where cthd.mahdbh == maHoaDon
                      select new
                      {
                          tenSp = cthd.Giay.tengiay,
                          soluong = cthd.soluong,
                          donGia = cthd.Giay.giaban,
                          giamGia=cthd.hoaDonBanHang.giamgia*0.01,
                          thanhTien = cthd.soluong * cthd.Giay.giaban,
                      };
            int y = 200;
            foreach(var item in sql)
            {
                e.Graphics.DrawString(item.tenSp, new System.Drawing.Font("Couriar New", 20, FontStyle.Regular),
                    Brushes.Black, new Point(100, y));
                e.Graphics.DrawString(item.soluong.ToString(), new System.Drawing.Font("Couriar New", 20, FontStyle.Regular),
                  Brushes.Black, new Point(270, y));
                e.Graphics.DrawString(item.donGia.ToString(), new System.Drawing.Font("Couriar New", 20, FontStyle.Regular),
                 Brushes.Black, new Point(400, y));
                e.Graphics.DrawString((item.thanhTien-(item.thanhTien*item.giamGia)).ToString(), new System.Drawing.Font("Couriar New", 20, FontStyle.Regular),
                       Brushes.Black, new Point(550, y));
                y += 50;
            }
            e.Graphics.DrawString(string.Format("Tổng:{0}",hd.tongtien), new System.Drawing.Font("Couriar New", 20, FontStyle.Regular),
                      Brushes.Black, new Point(100, y+20));
            e.Graphics.DrawString("Xin cảm ơn quý khách", new System.Drawing.Font("Couriar New", 20, FontStyle.Bold),
                   Brushes.Black, new Point(200, y+50));
            var tenNV = from h in data.hoaDonBanHangs
                        where h.mahdbh == maHoaDon
                        select new
                        {
                            tenNV = h.nhanVien.tennv,
                            manv = h.manv

                        };
            foreach(var item in tenNV)
            {
                e.Graphics.DrawString(string.Format("Nhân viên bán hàng :({0}){1}",item.manv,item.tenNV), new System.Drawing.Font("Couriar New", 20, FontStyle.Bold),
                  Brushes.Black, new Point(100, y + 100));
            }
        }
    }
}
