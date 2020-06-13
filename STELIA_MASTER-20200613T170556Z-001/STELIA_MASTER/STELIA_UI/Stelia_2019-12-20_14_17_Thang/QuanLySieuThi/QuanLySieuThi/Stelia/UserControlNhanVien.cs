using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stelia_BUS;
using Stelia_DTO;

namespace Stelia
{
    public partial class UserControlNhanVien : UserControl
    {
        public UserControlNhanVien()
        {
            InitializeComponent();
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox16_Click(object sender, EventArgs e)
        {
            FormNhapNhanVien frmNhapNV = new FormNhapNhanVien();
            frmNhapNV.ShowDialog();
            Reset();
        }

        private void Label10_Click(object sender, EventArgs e)
        {
        }
        void KhoiTaoNhanVienMoi()
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            string[] name = bus.Top10_NhanVien();
            lblNV1.Text = name[0];
            lblNV2.Text = name[1];
            lblNV3.Text = name[2];
            lblNV4.Text = name[3];
            lblNV5.Text = name[4];
            lblNV6.Text = name[5];
            lblNV7.Text = name[6];
            lblNV8.Text = name[7];
            lblNV9.Text = name[8];
        }
        void KhoiTaoTop3()
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            string[] name = bus.Top3_NhanVieN();
            lblTop1.Text = TranDateFormat.GetLastName(name[0]);
            lblTop2.Text = TranDateFormat.GetLastName(name[1]);
            lblTop3.Text = TranDateFormat.GetLastName(name[2]);
        }
        void Reset()
        {
            lblTop1.BackColor = Color.FromArgb(243, 208, 55);
            lblTop2.BackColor = Color.FromArgb(213, 90, 48);
            lblTop3.BackColor = Color.FromArgb(22, 175, 84);

            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            string MaNV = bus.getThongTinNV(0, 0);

            DTO_NhanVien[] NV = bus.search_NhanVien(MaNV);
            lblHoTen.Text = NV[0].HOTEN;
            lblChucVu.Text = NV[0].CHUCVU;
            lblDoanhThu.Text = TranDateFormat.SubString(NV[0].DOANHTHU);
            lblGioiTinh.Text = NV[0].GIOITINH;
            lblNgSinh.Text = TranDateFormat.SubString(NV[0].NGSINH);
            lblNgVaoLam.Text = TranDateFormat.SubString(NV[0].NGAYVL);
            lblMaNV.Text = NV[0].MANV;
            lblLuong.Text = TranDateFormat.SubString(NV[0].LUONG);
        }
        private void UserControlNhanVien_Load(object sender, EventArgs e)
        {
            Reset();
            KhoiTaoTop3();
            KhoiTaoNhanVienMoi();
            KhoiTaoChart();
        }

        private void KhoiTaoChart()
        {
            chartControl1.DataSource = new Stelia_BUS.Stelia_BUS().getDataTable("NHANVIEN");
        }

        private void PictureBox13_Click(object sender, EventArgs e)
        {
            FormCapNhatNhanVien frmCapNhat = new FormCapNhatNhanVien(lblMaNV.Text);
            frmCapNhat.ShowDialog();
            Reset();
        }

        private void PictureBox14_Click(object sender, EventArgs e)
        {
            DialogResult kq =  MessageBox.Show("Bạn có chắc xóa nhân viên " + lblHoTen.Text + " ra khỏi cửa hàng","Hỏi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.No) return;
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            //MessageBox.Show(lblMaNV.Text);
            if (bus.xoaNhanVien(lblMaNV.Text) == false)
                MessageBox.Show("Việc xóa xảy ra một số vấn đề! Không thành công");
            else MessageBox.Show("Đã xóa nhân viên" + lblHoTen.Text + "ra khỏi cửa hàng");
            Reset();
        }

        private void PictureBox17_Click(object sender, EventArgs e)
        {
            FormDanhSachNV frmDS = new FormDanhSachNV();
            frmDS.ShowDialog();
        }

        private void SearchControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UserControlNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void PictureBox18_Click(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_NhanVien[] NV = bus.search_NhanVien(txtTimKiem.Text);
            if (NV[0].MANV != txtTimKiem.Text && NV[0].HOTEN != txtTimKiem.Text)
            {
                PushNoti noti = new PushNoti("Error", "Không tìm thấy");
                noti.Width = this.Width;
                this.Controls.Add(noti);
                noti.Show();
                return;
            }
            lblHoTen.Text = NV[0].HOTEN;
            lblChucVu.Text = NV[0].CHUCVU;
            lblDoanhThu.Text = TranDateFormat.SubString(NV[0].DOANHTHU);
            lblGioiTinh.Text = NV[0].GIOITINH;
            lblNgSinh.Text = TranDateFormat.SubString(NV[0].NGSINH);
            lblNgVaoLam.Text = TranDateFormat.SubString(NV[0].NGAYVL);
            lblMaNV.Text = NV[0].MANV;
            lblLuong.Text = TranDateFormat.SubString(NV[0].LUONG);
            PushNoti noti2 = new PushNoti("Success", "Đã tìm thấy thông tin");
            noti2.Width = this.Width;
            this.Controls.Add(noti2);
            noti2.Show();
        }
    }
}
