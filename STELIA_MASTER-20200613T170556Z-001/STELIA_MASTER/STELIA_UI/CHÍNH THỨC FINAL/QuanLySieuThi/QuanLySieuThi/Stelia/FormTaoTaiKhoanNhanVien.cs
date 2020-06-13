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
    public partial class FormTaoTaiKhoanNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public FormTaoTaiKhoanNhanVien()
        {
            InitializeComponent();
        }
        public FormTaoTaiKhoanNhanVien(string username)
        {
            InitializeComponent();
            label2.Text = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtMK.Text == "")
            {
                MessageBox.Show("Mật khẩu không thể rỗng!");
                return;
            }
            DTO_TaiKhoan tk = new DTO_TaiKhoan(label2.Text, txtMK.Text);
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            if(!bus.themData(tk))
            {
                PushNoti noti1 = new PushNoti("Error", "Thêm tài khoản không thành công!");
                noti1.Width = this.Width;
                this.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}