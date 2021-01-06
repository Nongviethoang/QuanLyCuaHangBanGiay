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
    public partial class frmNhaCungCap : Form
    {
        QLCuaHangBanGiayDataContext data = new QLCuaHangBanGiayDataContext();
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            HienThi();
        }
        private void HienThi()
        {
            dataGridViewNCC.Rows.Clear();
            var sql = from ncc in data.nhacungcaps select ncc;
            foreach(var item in sql)
            {

                DataGridViewRow dongMoi = (DataGridViewRow)dataGridViewNCC.Rows[0].Clone();
                dongMoi.Cells[0].Value = item.mancc;
                dongMoi.Cells[1].Value = item.tenncc;
                dongMoi.Cells[2].Value = item.dienthoai;
                dongMoi.Cells[3].Value = item.email;
                dongMoi.Cells[4].Value = item.diachi;
                dongMoi.Cells[5].Value = "Xóa";
                dongMoi.Cells[6].Value = "Chọn";
                dataGridViewNCC.Rows.Add(dongMoi);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkNCC())
            {
                try
                {
                    nhacungcap ncc = new nhacungcap();
                    ncc.tenncc = txtTenNCC.Text;
                    ncc.dienthoai = txtDT.Text;
                    ncc.diachi = txtDiaChi.Text;
                    ncc.email = txtEmail.Text;
                    data.nhacungcaps.InsertOnSubmit(ncc);
                    data.SubmitChanges();
                    MessageBox.Show("Thêm thành công");
                    HienThi();
                    clear();
                }
                catch
                {
                    MessageBox.Show("Dữ liệu không hợp lệ");
                }
            }
        }
        public void clear()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDT.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
        }
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
            if (re.IsMatch(txtDT.Text))
            {
                flag = true;
            }
            return flag;
        }

        public Boolean checkNCC()
        {
            Boolean flag = false;
            if(txtTenNCC.TextLength != 0)
            {
                if(txtDT.TextLength != 0)
                {
                    if (checkPhone())
                    {
                        if(txtEmail.TextLength != 0)
                        {
                            if (checkEmail())
                            {
                                if(txtDiaChi.TextLength != 0)
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
                                MessageBox.Show("Email chưa đúng!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Email không được để trống!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại chưa đúng!");
                    }
                }
                else
                {
                    MessageBox.Show("Số điện thoại không được để trống!");
                }
            }
            else
            {
                MessageBox.Show("Tên NCC không để trống!");
            }
            return flag;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (checkNCC())
            {
                try
                {
                    nhacungcap ncc = data.nhacungcaps.SingleOrDefault(n => n.mancc == int.Parse(txtMaNCC.Text));
                    ncc.tenncc = txtTenNCC.Text;
                    ncc.diachi = txtDiaChi.Text;
                    ncc.dienthoai = txtDT.Text;
                    ncc.email = txtEmail.Text;
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

        private void bntThoat_Click(object sender, EventArgs e)
        {
            int manvht = int.Parse(txtMa.Text);
            taiKhoan tkht = data.taiKhoans.SingleOrDefault(t => t.manv == manvht);
            frmMain send = new frmMain(manvht);
            send.Tag = tkht;
            this.Visible = false;
            send.ShowDialog();
        }

        private void dataGridViewNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int mancc = int.Parse(dataGridViewNCC.Rows[e.RowIndex].Cells[0].Value.ToString());
                nhacungcap nccXoaSua = data.nhacungcaps.SingleOrDefault(kh => kh.mancc == mancc);
                if (e.ColumnIndex == 5)
                {
                    DialogResult rs = MessageBox.Show("Bạn có muốn xóa", "Thông báo", MessageBoxButtons.YesNo);
                    if (rs == DialogResult.Yes)
                    {
                        data.nhacungcaps.DeleteOnSubmit(nccXoaSua);
                        data.SubmitChanges();
                        HienThi();
                    }
                }
                else if (e.ColumnIndex == 6)
                {
                    txtMaNCC.Text = nccXoaSua.mancc.ToString();
                    txtDiaChi.Text = nccXoaSua.diachi;
                    txtTenNCC.Text = nccXoaSua.tenncc;
                    txtDT.Text = nccXoaSua.dienthoai;

                    txtEmail.Text = nccXoaSua.email;

                }
            }
            catch
            {
                MessageBox.Show("Nhà cung cấp đã cung cấp sản phẩm nên không thể xóa");
            }
        }
        //Lấy mã của tài khoản đăng nhập và hiển thị tên của nhân viên
        public frmNhaCungCap(int ma) : this()
        {

            nhanVien nvht = data.nhanViens.SingleOrDefault(n => n.manv == ma);
            txtMa.Text = nvht.manv.ToString();
            txtTen.Text = nvht.tennv;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            HienThi();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            dataGridViewNCC.Rows.Clear();
            var sql = from nv in data.nhacungcaps where nv.tenncc.Contains(textBox1.Text) select nv;
            if (sql.Count() == 0)
            {
                MessageBox.Show("Không có kết quả");
            }
            else
            {
                foreach (var item in sql)
                {

                    DataGridViewRow dongMoi = (DataGridViewRow)dataGridViewNCC.Rows[0].Clone();
                    dongMoi.Cells[0].Value = item.mancc;
                    dongMoi.Cells[1].Value = item.tenncc;
                    dongMoi.Cells[2].Value = item.dienthoai;
                    dongMoi.Cells[3].Value = item.email;
                    dongMoi.Cells[4].Value = item.diachi;
                    dongMoi.Cells[5].Value = "Xóa";
                    dongMoi.Cells[6].Value = "Chọn";
                    dataGridViewNCC.Rows.Add(dongMoi);

                }
            }
        }
    }
}
