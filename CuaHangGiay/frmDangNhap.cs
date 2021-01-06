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
    public partial class frmDangNhap : Form
    {
        QLCuaHangBanGiayDataContext data = new QLCuaHangBanGiayDataContext();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

                var sql = from tk in data.taiKhoans select tk;
                foreach (var item in sql)
                {
                    if (item.manv==int.Parse(comboBoxMaNV.SelectedValue.ToString())&&item.matkhau==txtMatKhau.Text)
                    {
                    int ma = int.Parse(comboBoxMaNV.SelectedValue.ToString());
                    frmMain send = new frmMain(ma);
                    send.Tag = item;
                    MessageBox.Show("Đăng nhập thành công");
                    this.Visible = false;
                    send.ShowDialog();
                    }
             
                }
        }
        private void loadCombobox()
        {
            var sql = from  nv in data.nhanViens select nv;
            comboBoxMaNV.DataSource = sql;
            comboBoxMaNV.DisplayMember = "manv";
            comboBoxMaNV.ValueMember = "manv";
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            loadCombobox();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
