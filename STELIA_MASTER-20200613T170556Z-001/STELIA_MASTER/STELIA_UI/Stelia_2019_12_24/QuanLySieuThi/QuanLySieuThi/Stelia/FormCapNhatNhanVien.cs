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
using System.ComponentModel.DataAnnotations;
using System.IO;
using DevExpress.XtraLayout.Helpers;
using DevExpress.XtraLayout;
using Stelia_DTO;
using Stelia_BUS;

namespace Stelia
{
    public partial class FormCapNhatNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public string MaNV = "";

        public FormStartPosition FormStartPosition { get; }

        public FormCapNhatNhanVien(string st)
        {
            InitializeComponent();
            MaNV = st;
            FormStartPosition = FormStartPosition.CenterScreen;
        }

        private void FormCapNhatNhanVien_Load(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_NhanVien[] NV = bus.search_NhanVien(MaNV);
            DTO_NhanVien nhanvien = NV[0];
            txtHoTen.Text = nhanvien.HOTEN;
            txtChucVu.Text = nhanvien.CHUCVU;
            txtGioiTinh.Text = nhanvien.GIOITINH;
            txtLuong.Text = TranDateFormat.SubString(nhanvien.LUONG + "");
            txtMaNV.Text = MaNV;
            txtMaNV.ReadOnly = true;
            dateNgSinh.Text = TranDateFormat.SubString(nhanvien.NGSINH);
            dateNgVaoLam.Text = TranDateFormat.SubString(nhanvien.NGAYVL);
        }

        private void WindowsUIButtonPanelCloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            //string Ngsinh = TranDateFormat.Trans(dateNgSinh.Text);
            //string NgVaoLam = TranDateFormat.Trans(dateNgVaoLam.Text);
            string Ngsinh = DateChange.ToString(dateNgSinh.DateTime);
            string NgVaoLam = DateChange.ToString(dateNgVaoLam.DateTime);
            DTO_NhanVien NV = new DTO_NhanVien(txtMaNV.Text, txtHoTen.Text, Ngsinh, txtChucVu.Text,
                NgVaoLam, txtGioiTinh.Text, txtLuong.Text, "0", "0");

            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            if (bus.suaData(NV) == false)
            {
                //MessageBox.Show("Có lỗi xảy ra! Không thành công");
                PushNoti noti = new PushNoti("Error", "Có lỗi xảy ra! Sửa không thành công!");
                noti.Width = 800;
                noti.Height = 30;
                this.labelControl.Controls.Add(noti);
                noti.Show();
                noti.ShowNoti();
                return;
            }
            else
            {
                PushNoti noti1 = new PushNoti("Success", "Cập nhật thông tin thành công!");
                noti1.Width = 800;
                noti1.Height = 30;
                this.labelControl.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
                //MessageBox.Show("Bạn đã cập nhật thành công");
            }
            //Close();
        }
    }
}