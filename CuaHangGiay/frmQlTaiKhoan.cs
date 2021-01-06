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
    public partial class frmQlTaiKhoan : Form
    {
        QLCuaHangBanGiayDataContext data = new QLCuaHangBanGiayDataContext();
        
        public frmQlTaiKhoan()
        {
            InitializeComponent();
        }
        //Lấy mã tài khoản hiện thời
       
        public frmQlTaiKhoan(int ma):this()
        {
            txtManv.Text =ma.ToString();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void frmTaoTaiKhoan_Load(object sender, EventArgs e)
        {
            loadCombobox();
            HienThi();
        }
        private void loadCombobox()
        {
            var sql = from nv in data.nhanViens select nv;
            cbMaNV.DataSource = sql;
            cbMaNV.DisplayMember = "manv";
            cbMaNV.ValueMember = "manv";
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
                    taiKhoan tkMoi = new taiKhoan();
                    tkMoi.manv = int.Parse(cbMaNV.SelectedValue.ToString());
            if(txtMatKhau.Text=="")
            {
                MessageBox.Show("Không được để trống");
                
            }
            else
            {
                if (txtMatKhau.Text == txtRePass.Text)
                {
                    tkMoi.matkhau = txtRePass.Text;
                    try
                    {
                        data.taiKhoans.InsertOnSubmit(tkMoi);
                        data.SubmitChanges();
                        MessageBox.Show("Tạo tài khoản thành công");
                        HienThi();
                        txtMatKhau.Text = "";
                        txtRePass.Text = "";
                    }
                    catch
                    {
                        data.taiKhoans.DeleteOnSubmit(tkMoi);
                        MessageBox.Show("Tài khoản đã tồn tại");
                    }
                }
                else
                {
                    MessageBox.Show("Xác nhận mật khẩu không khớp");
                }
            }
                   
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            int maNVHT = int.Parse(txtManv.Text);
            taiKhoan tkht = data.taiKhoans.SingleOrDefault(t => t.manv == maNVHT);
            frmMain send = new frmMain(maNVHT);
            send.Tag = tkht;
            this.Visible = false;
            send.ShowDialog();

        }
        //Lấy danh sách tài khoản
        private void HienThi()
        {
            dgTaiKhoan.Rows.Clear();
            var sql = from tk in data.taiKhoans select tk;
            foreach (var item in sql)
            {

                DataGridViewRow dongMoi = (DataGridViewRow)dgTaiKhoan.Rows[0].Clone();
                dongMoi.Cells[0].Value = item.manv;
                dongMoi.Cells[1].Value = item.matkhau;
                dongMoi.Cells[2].Value = "Xóa";
                dgTaiKhoan.Rows.Add(dongMoi);
            }
        }

        private void dgTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int manv=int.Parse(dgTaiKhoan.Rows[e.RowIndex].Cells[0].Value.ToString());
            taiKhoan tkxoa = data.taiKhoans.SingleOrDefault(t => t.manv == manv);
            if(e.ColumnIndex==2)
            {
                if (tkxoa.manv != 1)
                {
                    DialogResult rs = MessageBox.Show("Bạn có muốn xóa", "Thông báo", MessageBoxButtons.YesNo);
                    if(rs==DialogResult.Yes)
                    {
                        data.taiKhoans.DeleteOnSubmit(tkxoa);
                        data.SubmitChanges();
                        HienThi();
                    }
                }
                else
                {
                    MessageBox.Show("Không thể xóa tài khoản admin");
                }
            }
        }
    }
}
