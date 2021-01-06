using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CuaHangGiay
{
    public partial class frmKhachHang : Form
    {
        QLCuaHangBanGiayDataContext data = new QLCuaHangBanGiayDataContext();
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void HienThi()
        {
            dgKh.Rows.Clear();
            var sql = from kh in data.khachHangs select kh;
            foreach(var item in sql)
            {
                DataGridViewRow dongMoi = (DataGridViewRow)dgKh.Rows[0].Clone();
                dongMoi.Cells[0].Value = item.makh;
                dongMoi.Cells[1].Value = item.tenkh;
                dongMoi.Cells[2].Value = item.sodt;
                dongMoi.Cells[3].Value = item.diachi;
                dongMoi.Cells[4].Value = "Xóa";
                dongMoi.Cells[5].Value = "Chọn";
                dgKh.Rows.Add(dongMoi);
            }
        }
        public void Clear()
        {
            txtTenKH.Text = "";
            txtDC.Text = "";
            txtSDT.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkKhachHang())
            {
                try
                {
                    khachHang k = new khachHang();
                    k.tenkh = txtTenKH.Text;
                    k.diachi = txtDC.Text;
                    k.sodt = txtSDT.Text;
                    data.khachHangs.InsertOnSubmit(k);
                    data.SubmitChanges();
                    Clear();
                    MessageBox.Show("Thêm thành công");
                    HienThi();
                    clear();
                }
                catch
                {
                    MessageBox.Show("Dữ liệu không hợp lệ hoặc bỏ trống");
                }
            }           
        }


        public Boolean checkPhone()
        {
            Boolean flag = false;
            string phoneRex = @"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$";
            Regex re = new Regex(phoneRex);
            if (re.IsMatch(txtSDT.Text))
            {
                flag = true;
            }
            return flag;
        }

        public Boolean checkKhachHang()
        {
            Boolean flag = false;
            if(txtTenKH.TextLength != 0)
            {
                if(txtSDT.TextLength != 0)
                {
                    if (checkPhone())
                    {                     
                        if(txtDC.TextLength != 0)
                        {
                            flag = true;
                        }
                        else
                        {
                            MessageBox.Show("Địa chỉ không được để trống!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại không đúng!");
                    }                   
                }
                else
                {
                    MessageBox.Show("Số điện thoại không được để trống!");
                }
            }
            else
            {
                MessageBox.Show("Tên khách hàng không được để trống!");
            }
            return flag;
        }

        private void dgKh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
                int maKH = int.Parse(dgKh.Rows[e.RowIndex].Cells[0].Value.ToString());
                khachHang khXoaSua = data.khachHangs.SingleOrDefault(kh=>kh.makh==maKH);
                if(e.ColumnIndex==4)
                {
                    DialogResult rs = MessageBox.Show("Bạn có muốn xóa", "Thông báo", MessageBoxButtons.YesNo);
                    if(rs==DialogResult.Yes)
                    {
                    try
                    {
                        data.khachHangs.DeleteOnSubmit(khXoaSua);
                        data.SubmitChanges();
                        HienThi();
                    }
                    catch
                    {
                        MessageBox.Show("Khách đã mua hàng nên không thể xóa");
                    } 
                    }
                }
                else if(e.ColumnIndex==5)
                {
                    txtMaKH.Text = khXoaSua.makh.ToString();
                    txtDC.Text = khXoaSua.diachi;
                    txtTenKH.Text = khXoaSua.tenkh;
                    txtSDT.Text = khXoaSua.sodt;
                }
            }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (checkKhachHang())
            {
                try
                {
                    khachHang kh = data.khachHangs.SingleOrDefault(k => k.makh == int.Parse(txtMaKH.Text));
                    kh.tenkh = txtTenKH.Text;
                    kh.diachi = txtDC.Text;
                    kh.sodt = txtSDT.Text;
                    data.SubmitChanges();
                    MessageBox.Show("Sửa thành công");
                    HienThi();
                    clear();
                }
                catch
                {
                    MessageBox.Show("Dữ liệu không được bỏ trống ");
                }
            }
        }

        private void bntThoat_Click(object sender, EventArgs e)
        {
            int manvht = int.Parse(txtMa.Text);
            taiKhoan tkht = data.taiKhoans.SingleOrDefault(t => t.manv == manvht);
            frmMain send = new frmMain(manvht);
            send.Tag = tkht;
            this.Visible = false;
            send.ShowDialog();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            dgKh.Rows.Clear();
            var sql = from kh in data.khachHangs where kh.tenkh.Contains(txtTenTim.Text) select kh;
            if(sql.Count()==0)
            {
                MessageBox.Show("Không tìm thấy");

            }
            else
            {
                foreach (var item in sql)
                {
                    DataGridViewRow dongMoi = (DataGridViewRow)dgKh.Rows[0].Clone();
                    dongMoi.Cells[0].Value = item.makh;
                    dongMoi.Cells[1].Value = item.tenkh;
                    dongMoi.Cells[2].Value = item.sodt;
                    dongMoi.Cells[3].Value = item.diachi;
                    dongMoi.Cells[4].Value = "Xóa";
                    dongMoi.Cells[5].Value = "Sửa";
                    dgKh.Rows.Add(dongMoi);
                }
            }
        }
        //Lấy mã của tài khoản đăng nhập và hiển thị tên của nhân viên
        public frmKhachHang(int ma) : this()
        {

            nhanVien nvht = data.nhanViens.SingleOrDefault(n => n.manv == ma);
            txtMa.Text = nvht.manv.ToString();
            txtTen.Text = nvht.tennv;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            HienThi();
        }
        public void clear()
        {
            txtMaKH.Text = "";
            txtSDT.Text = "";
            txtSDT.Text = "";
            txtTenKH.Text = "";
            txtDC.Text = "";
                
        }
            
    }
    
}
