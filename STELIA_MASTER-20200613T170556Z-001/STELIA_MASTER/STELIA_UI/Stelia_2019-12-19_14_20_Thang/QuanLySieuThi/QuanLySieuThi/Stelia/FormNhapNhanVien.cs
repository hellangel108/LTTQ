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
    public partial class FormNhapNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public FormNhapNhanVien()
        {
            InitializeComponent();
        }

        private void WindowsUIButtonPanelCloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormNhapNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = txtChucVu.Text = txtGioiTinh.Text = txtLuong.Text = txtMaNV.Text = "";
            dateNgSinh.Text = dateNgVaoLam.Text = "";
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            //string Ngsinh = TranDateFormat.Trans(dateNgSinh.Text);
            //string NgVaoLam = TranDateFormat.Trans(dateNgVaoLam.Text);
            string Ngsinh = DateChange.ToString(dateNgSinh.DateTime);
            string NgVaoLam = DateChange.ToString(dateNgVaoLam.DateTime);
            DTO_NhanVien NV = new DTO_NhanVien(txtMaNV.Text, txtHoTen.Text, Ngsinh, txtChucVu.Text,
                NgVaoLam, txtGioiTinh.Text, txtLuong.Text, "0", "0");

            string error = CheckThongTin.check_Nhap(NV);
            if (error != "")
            {
                MessageBox.Show(error);
                return;
            }

            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            if (bus.themData(NV) == false)
            {
                MessageBox.Show("Thêm nhân viên không thành công");
                return;
            }
            else MessageBox.Show("Bạn đã thêm nhân viên thành công");
            Close();
        }
    }
}