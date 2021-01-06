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
    public partial class frmGiay : Form
    {
        QLCuaHangBanGiayDataContext db = new QLCuaHangBanGiayDataContext();
        public frmGiay()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmGiay_Load(object sender, EventArgs e)
        {
            hienThi();
        }
        public void hienThi()
        {
            dataGridViewGiay.Rows.Clear();
            var giay = from Giay in db.Giays
                       select new
                       {
                           Giay.magiay,
                           Giay.tengiay,
                           Giay.thuonghieu,
                           Giay.loai,
                           Giay.giaban,
                           Giay.gianhap,
                           Giay.soluongcon
                       };
            foreach (var item in giay)
            {
                DataGridViewRow dongmoi = (DataGridViewRow)dataGridViewGiay.Rows[0].Clone();
                dongmoi.Cells[0].Value = item.magiay;
                dongmoi.Cells[1].Value = item.tengiay;
                dongmoi.Cells[2].Value = item.thuonghieu;
                dongmoi.Cells[3].Value = item.loai;
                dongmoi.Cells[4].Value = item.giaban;
                dongmoi.Cells[5].Value = item.gianhap;
                dongmoi.Cells[6].Value = item.soluongcon;
                dongmoi.Cells[7].Value = "Xóa";
                dongmoi.Cells[8].Value = "chọn";
                dataGridViewGiay.Rows.Add(dongmoi);
            }

        }
        //clear
        public void clear()
        {
            txtGiaBan.Text = "";
            txtGiaNhap.Text = "";
            txtLoai.Text = "";
            txtMaGiay.Text = "";
            txtSLCon.Text = "";
            txtTenGiay.Text = "";
            txtTH.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {


                Giay giayMoi = new Giay();
                if (txtTenGiay.Text != "")
                {
                    giayMoi.tengiay = txtTenGiay.Text;
                    if (txtLoai.Text != "")
                    {
                        giayMoi.loai = txtLoai.Text;
                    
                    if (txtTH.Text != "")
                    {
                        giayMoi.thuonghieu = txtTH.Text;
                        if (txtGiaBan.Text != "")
                        {
                            if (int.Parse(txtGiaBan.Text) > 0)
                            {
                                giayMoi.giaban = int.Parse(txtGiaBan.Text);
                                if (txtGiaNhap.Text != "")
                                {
                                    if (int.Parse(txtGiaNhap.Text) > 0)
                                    {
                                        giayMoi.gianhap = int.Parse(txtGiaNhap.Text);
                                        if (txtSLCon.Text != "")
                                        {
                                            if (int.Parse(txtSLCon.Text) > 0)
                                            {
                                                giayMoi.soluongcon = int.Parse(txtSLCon.Text);
                                                db.Giays.InsertOnSubmit(giayMoi);
                                                db.SubmitChanges();
                                                clear();
                                                hienThi();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Số lượng không hợp lệ");
                                            }

                                        }
                                        else
                                        {
                                            MessageBox.Show("Số lượng không bỏ trống");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Giá nhập không hợp lệ");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Giá nhập không bỏ trống");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Giá bán không hợp lệ ");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Giá không được bỏ trống");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thương hiệu không được bỏ trống");
                    }
                }
                else
                {
                    MessageBox.Show("Loại không được bỏ trống");
                }
            }
                else
                {
                    MessageBox.Show("Tên không được bỏ trống");
                }
            }
            catch
            {
                MessageBox.Show("Dữ liệu không hợp lệ");
            }
           
        }
        //Lấy mã của tài khoản đăng nhập và hiển thị tên của nhân viên
        public frmGiay(int ma) : this()
        {

            nhanVien nvht = db.nhanViens.SingleOrDefault(n => n.manv == ma);
            txtMa.Text = nvht.manv.ToString();
            txtTen.Text = nvht.tennv;
        }
        private void bntThoat_Click(object sender, EventArgs e)
        {
            int manvht = int.Parse(txtMa.Text);
            taiKhoan tkht = db.taiKhoans.SingleOrDefault(t => t.manv == manvht);
            frmMain send = new frmMain(manvht);
            send.Tag = tkht;
            this.Visible = false;
            send.ShowDialog();
        }

        private void dataGridViewGiay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int maSp = int.Parse(dataGridViewGiay.Rows[e.RowIndex].Cells[0].Value.ToString());
            Giay spXoaSua = db.Giays.SingleOrDefault(kh => kh.magiay == maSp);
            if (e.ColumnIndex == 7)
            {
                DialogResult rs = MessageBox.Show("Bạn có muốn xóa", "Thông báo", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    try
                    {
                        db.Giays.DeleteOnSubmit(spXoaSua);
                        db.SubmitChanges();
                        hienThi();
                    }
                    catch
                    {
                        MessageBox.Show("Sản phẩm đã tồn tại trong hóa đơn");
                    }
                }
            }
            else if (e.ColumnIndex == 8)
            {
                txtMaGiay.Text = spXoaSua.magiay.ToString();
                txtTenGiay.Text = spXoaSua.tengiay;
                txtLoai.Text = spXoaSua.loai;
                txtTH.Text = spXoaSua.thuonghieu;
                txtGiaBan.Text = spXoaSua.giaban.ToString();
                txtGiaNhap.Text = spXoaSua.gianhap.ToString();
                txtSLCon.Text = spXoaSua.soluongcon.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
                Giay giayMoi = db.Giays.SingleOrDefault(gi => gi.magiay == int.Parse(txtMaGiay.Text));
            if (txtTenGiay.Text != "")
            {
                giayMoi.tengiay = txtTenGiay.Text;
                if (txtLoai.Text != "")
                {
                    giayMoi.loai = txtLoai.Text;
                
                if (txtTH.Text != "")
                {
                    giayMoi.thuonghieu = txtTH.Text;
                    if (txtGiaBan.Text != "")
                    {
                        if (int.Parse(txtGiaBan.Text) > 0)
                        {
                            giayMoi.giaban = int.Parse(txtGiaBan.Text);
                            if (txtGiaNhap.Text != "")
                            {
                                if (int.Parse(txtGiaNhap.Text) > 0)
                                {
                                    giayMoi.gianhap = int.Parse(txtGiaNhap.Text);
                                    if (txtSLCon.Text != "")
                                    {
                                        if (int.Parse(txtSLCon.Text) > 0)
                                        {
                                            giayMoi.soluongcon = int.Parse(txtSLCon.Text);
                                            db.SubmitChanges();
                                            clear();
                                            hienThi();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Số lượng không hợp lệ");
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("Số lượng không bỏ trống");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Giá nhập không hợp lệ");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Giá nhập không bỏ trống");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Giá bán không hợp lệ ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Giá không được bỏ trống");
                    }
                }

                else
                {
                    MessageBox.Show("Thương hiệu không được bỏ trống");
                }
            }

            else
            {
                MessageBox.Show("Loại không được bỏ trống");
            }
        }
                else
                {
                    MessageBox.Show("Tên không được bỏ trống");
                }
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hienThi();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            dataGridViewGiay.Rows.Clear();
            var sql = from kh in db.Giays where kh.tengiay.Contains(txtTenTim.Text) select kh;
            if (sql.Count() == 0)
            {
                MessageBox.Show("Không tìm thấy");

            }
            else
            {
                foreach (var item in sql)
                {
                    DataGridViewRow dongMoi = (DataGridViewRow)dataGridViewGiay.Rows[0].Clone();
                    dongMoi.Cells[0].Value = item.magiay;
                    dongMoi.Cells[1].Value = item.tengiay;
                    dongMoi.Cells[2].Value = item.thuonghieu;
                    dongMoi.Cells[3].Value = item.loai;
                    dongMoi.Cells[4].Value = item.giaban;
                    dongMoi.Cells[5].Value = item.gianhap;
                    dongMoi.Cells[6].Value = item.soluongcon;

                    dongMoi.Cells[7].Value = "Xóa";
                    dongMoi.Cells[8].Value = "Sửa";
                    dataGridViewGiay.Rows.Add(dongMoi);
                }
            }
        }
    }
    }
