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
    public partial class frmNhanVien : Form
    {
        QLCuaHangBanGiayDataContext data = new QLCuaHangBanGiayDataContext();
        public frmNhanVien()
        {
            InitializeComponent();
        }
        //Lấy mã của tài khoản đăng nhập và hiển thị tên của nhân viên
        public frmNhanVien(int ma) : this()
        {

            nhanVien nvht = data.nhanViens.SingleOrDefault(n => n.manv == ma);
            txtMa.Text = nvht.manv.ToString();
            txtTen.Text = nvht.tennv;
        }
      
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkNhanVien())
            {
                try
                {
                    nhanVien nv = new nhanVien();
                    nv.tennv = txtTennv.Text;
                    nv.ngaysinh = dtNgaySinh.Text;
                    nv.gioitinh = cbGt.Text;
                    nv.diachi = txtDC.Text;
                    nv.sodienthoai = txtSDT.Text;
                    nv.email = txtEmail.Text;
                    data.nhanViens.InsertOnSubmit(nv);
                    data.SubmitChanges();
                    MessageBox.Show("Thêm thành công!");
                    HienThi();
                    clear();
                }
                catch
                {
                    MessageBox.Show("Dữ liệu không hợp lệ");
                }
            }
            
        }
        //clear
        public Boolean checkEmail()
        {
            Boolean flag = false;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(txtEmail.Text))
            {
                flag = true;
            }
            return flag;
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

        public Boolean checkNhanVien()
        {
            Boolean flag = false;
                if(txtTennv.TextLength != 0)
                {
                    if(cbGt.SelectedItem != null)
                    {                
                        if (txtDC.TextLength != 0)
                        {
                            if(txtSDT.TextLength != 0)
                            {
                                if (checkPhone())
                                {
                                    if (txtEmail.TextLength != 0)
                                    {
                                        if (checkEmail())
                                        {
                                            flag = true;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Email khong dung dinh dang");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Email không được để trống");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Số điện thoại không đúng");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Số điện thoại không được để trống!");
                            }
                        }
                        else
                        {
                             MessageBox.Show("Địa chỉ không được để trống");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hãy chọn giới tính!");
                    }
                }
                else
                {
                    MessageBox.Show("Tên không được để trống!");
                }
            return flag;
        }

        private void HienThi()
        {
            dgNV.Rows.Clear();
            var sql = from nv in data.nhanViens select nv;
            foreach(var item in sql)
            {
                
                    DataGridViewRow dongMoi = (DataGridViewRow)dgNV.Rows[0].Clone();
                    dongMoi.Cells[0].Value = item.manv;
                    dongMoi.Cells[1].Value = item.tennv;
                    dongMoi.Cells[2].Value = item.gioitinh;
                    dongMoi.Cells[3].Value = item.ngaysinh;
                    dongMoi.Cells[4].Value = item.diachi;
                    dongMoi.Cells[5].Value = item.sodienthoai;
                    dongMoi.Cells[6].Value = item.email;
                    dongMoi.Cells[7].Value = "Xóa";
                    dongMoi.Cells[8].Value = "Chọn";
                    dgNV.Rows.Add(dongMoi);
              
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

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void dgNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            
            int manv = int.Parse(dgNV.Rows[e.RowIndex].Cells[0].Value.ToString());
            nhanVien nvXoaSua = data.nhanViens.SingleOrDefault(kh => kh.manv == manv);
            if (e.ColumnIndex == 7)
            {
                DialogResult rs = MessageBox.Show("Bạn có muốn xóa", "Thông báo", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                       


                            data.nhanViens.DeleteOnSubmit(nvXoaSua);
                            data.SubmitChanges();
                            HienThi();
                      
                }
            }
            else if (e.ColumnIndex == 8)
            {
                txtManv.Text = nvXoaSua.manv.ToString();
                txtDC.Text = nvXoaSua.diachi;
                txtTennv.Text = nvXoaSua.tennv;
                txtSDT.Text = nvXoaSua.sodienthoai;
                cbGt.Text = nvXoaSua.gioitinh;
                txtEmail.Text = nvXoaSua.email;

            }
            }
            catch(Exception er)
            { MessageBox.Show("Nhân viên đã có tài khoản nên không thể xóa"); }
       
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (checkNhanVien())
            {
                try
                {
                    nhanVien nv = data.nhanViens.SingleOrDefault(n => n.manv == int.Parse(txtManv.Text));
                    nv.tennv = txtTennv.Text;
                    nv.gioitinh = cbGt.Text;
                    nv.ngaysinh = dtNgaySinh.Text;
                    nv.diachi = txtDC.Text;
                    nv.sodienthoai = txtSDT.Text;
                    nv.email = txtEmail.Text;
                    data.SubmitChanges();
                    HienThi();
                    clear();
                }
                catch
                {
                    MessageBox.Show("Dữ liệu không hợp lệ");
                }
            }
        }
        //clear
        public void clear()
        {
            txtManv.Text = "";
            txtTennv.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            dtNgaySinh.Text = DateTime.Now.ToString();
            txtDC.Text = "";
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            dgNV.Rows.Clear();
            var sql = from nv in data.nhanViens where nv.tennv.Contains(txtTim.Text) select nv;
            if(sql.Count()==0)
            {
                MessageBox.Show("Không có kết quả");
            }
            else
            {
                foreach (var item in sql)
                {

                    DataGridViewRow dongMoi = (DataGridViewRow)dgNV.Rows[0].Clone();
                    dongMoi.Cells[0].Value = item.manv;
                    dongMoi.Cells[1].Value = item.tennv;
                    dongMoi.Cells[2].Value = item.gioitinh;
                    dongMoi.Cells[3].Value = item.ngaysinh;
                    dongMoi.Cells[4].Value = item.diachi;
                    dongMoi.Cells[5].Value = item.sodienthoai;
                    dongMoi.Cells[6].Value = item.email;
                    dongMoi.Cells[7].Value = "Xóa";
                    dongMoi.Cells[8].Value = "Chọn";
                    dgNV.Rows.Add(dongMoi);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HienThi();
        }
    }
}
