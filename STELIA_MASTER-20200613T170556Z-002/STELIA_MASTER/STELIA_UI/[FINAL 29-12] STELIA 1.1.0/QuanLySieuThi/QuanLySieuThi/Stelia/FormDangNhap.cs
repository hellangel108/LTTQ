using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Stelia
{
    public partial class FormDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public string username;
        private int dem = 0;
        public FormDangNhap()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            dem = 0;
        }

        private void TxtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void FormDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();
            }
        }

        private void TxtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void DangNhap()
        {
            if (CheckDN(txtTaiKhoan.Text, txtMatKhau.Text))
            {
                username = txtTaiKhoan.Text;
                Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
                if(username == "admin")
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                if (bus.timKiemNhanh_NhanVien(username).Rows.Count != 0)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                if(bus.timKiemNhanh_KhachHang(username).Rows.Count !=0)
                {
                    DialogResult = DialogResult.Yes;
                    Close();
                }
            }
            else MessageBox.Show("Tài khoản không đúng");
        }
        private bool CheckDN(string user, string password)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DataTable infotable = bus.getDataTable("TAIKHOAN");
            foreach(DataRow row in infotable.Rows)
            {
                if (user == row[0].ToString())
                {
                    if(password == row[1].ToString())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        private void TxtTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtMatKhau_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();
            }
        }
    }
}