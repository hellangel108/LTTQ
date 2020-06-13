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
        private string fileAnh = "";
        public FormNhapNhanVien()
        {
            InitializeComponent();
            comboBoxChucVu.SelectedIndex = 3;
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
            txtHoTen.Text = txtGioiTinh.Text = txtLuong.Text = txtMaNV.Text = "";
            dateNgSinh.Text = dateNgVaoLam.Text = "";
            comboBoxChucVu.SelectedIndex = 3;
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            //string Ngsinh = TranDateFormat.Trans(dateNgSinh.Text);
            //string NgVaoLam = TranDateFormat.Trans(dateNgVaoLam.Text);
            string Ngsinh = DateChange.ToString(dateNgSinh.DateTime);
            string NgVaoLam = DateChange.ToString(dateNgVaoLam.DateTime);
            if ((comboBoxChucVu.Text == "Quản lí" || comboBoxChucVu.Text == "Quản lí nhân sự") && ThongTinDangNhap.ChucVu == "Quản lí nhân sự")
            {
                PushNoti noti1 = new PushNoti("Error", "Bạn không có quyền tạo nhân viên với chức vụ này. Vui lòng sử dụng một tài khoản cấp cao hơn");
                noti1.Width = this.Width;
                this.labelControl.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
                return;
            }
            if (comboBoxChucVu.Text == "Quản lí" && ThongTinDangNhap.ChucVu == "Quản lí")
            {
                PushNoti noti1 = new PushNoti("Error", "Bạn không có quyền tạo nhân viên với chức vụ này. Vui lòng sử dụng một tài khoản cấp cao hơn");
                noti1.Width = this.Width;
                this.labelControl.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
                return;
            }
            DTO_NhanVien NV = new DTO_NhanVien(txtMaNV.Text, txtHoTen.Text, Ngsinh, comboBoxChucVu.SelectedItem.ToString(),
                NgVaoLam, txtGioiTinh.Text, txtLuong.Text, "0", "0");

            string error = CheckThongTin.check_Nhap(NV);
            if (error != "")
            {
                PushNoti noti1 = new PushNoti("Error", error);
                noti1.Width = this.Width;
                this.labelControl.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
                return;
            }

            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            if (bus.themData(NV) == false)
            {
                PushNoti noti1 = new PushNoti("Error", "Thêm nhân viên không thành công!");
                noti1.Width = this.Width;
                this.labelControl.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
                return;
            }
            else
            {
                
            }
            string desAnh = Application.StartupPath + "/HinhNhanVien/" + txtMaNV.Text + ".jpg";
            if (File.Exists(desAnh))
                File.Delete(desAnh);
            File.Copy(fileAnh, desAnh);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileAnh = dlg.FileName;
            }
            else return;
            pictureBox1.Image = Image.FromFile(fileAnh);
        }
    }
}