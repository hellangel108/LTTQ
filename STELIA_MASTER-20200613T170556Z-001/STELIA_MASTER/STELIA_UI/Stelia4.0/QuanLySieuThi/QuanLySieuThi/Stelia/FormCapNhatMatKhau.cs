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
using Stelia_DTO;

namespace Stelia
{
    public partial class FormCapNhatMatKhau : DevExpress.XtraEditors.XtraForm
    {
        public FormCapNhatMatKhau()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            txtMKC.Text = "";
            txtMKM.Text = "";
            txtNL.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMKM.Text == "" || txtNL.Text == "")
                MessageBox.Show("Không thể bỏ trống!");
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DataTable infotable = bus.getDataTable("TAIKHOAN");
            foreach (DataRow row in infotable.Rows)
            {
                if (ThongTinDangNhap.Username == row[0].ToString())
                {
                    if (txtMKC.Text == row[1].ToString())
                    {
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng!");
                        return;
                    }
                }
            }
            if(txtMKM.Text != txtNL.Text)
            {
                MessageBox.Show("Nhập lại không giống với mật khẩu mới, vui lòng kiểm tra lại!");
                return;
            }
            DTO_TaiKhoan tk = new DTO_TaiKhoan(ThongTinDangNhap.Username, txtMKM.Text);
            bus.suaData(tk);
            MessageBox.Show("Thay đổi mật khẩu thành công!");
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}