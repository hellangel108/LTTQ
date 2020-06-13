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
    public partial class UserControlKhachHang : UserControl
    {
        public UserControlKhachHang()
        {
            InitializeComponent();
        }

        void XuatThongTinTop10()
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            string[] name = bus.Top15_KhachHang();
            lblKH1.Text = name[0];
            lblKH2.Text = name[1];
            lblKH3.Text = name[2];
            lblKH4.Text = name[3];
            lblKH5.Text = name[4];
            lblKH6.Text = name[5];
            lblKH7.Text = name[6];
            lblKH8.Text = name[7];
            lblKH9.Text = name[8];
        }
        void XuatThongTin()
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            string makh = bus.getThongTinKH(0, 0);
            DTO_KhachHang[] KH = bus.search_KhachHang(makh);
            lblHoTen.Text = KH[0].HOTEN;
            lblDiaChi.Text = KH[0].DIACHI;
            lblDiemTL.Text = TranDateFormat.SubString(KH[0].DIEMTL);
            lblGioiTinh.Text = KH[0].GIOITINH;
            lblLoaiThe.Text = KH[0].LOAIKH;
            lblNgDK.Text = TranDateFormat.SubString(KH[0].NGDK);
            lblNgSinh.Text = TranDateFormat.SubString(KH[0].NGSINH);
            lblMaKH.Text = KH[0].MAKH;
        }

        private void UserControlKhachHang_Load(object sender, EventArgs e)
        {
            XuatThongTin();
            XuatThongTinTop10();
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox16_Click(object sender, EventArgs e)
        {
            FormThemKhachHang frmThem = new FormThemKhachHang();
            frmThem.ShowDialog();
            XuatThongTin();
        }

        private void PictureBox13_Click(object sender, EventArgs e)
        {
            FormCapNhatKH frmCapNhat = new FormCapNhatKH(lblMaKH.Text);
            frmCapNhat.ShowDialog();
            XuatThongTin();
        }

        private void PictureBox14_Click(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DialogResult res = MessageBox.Show("Bạn có chắc xóa khách hàng " + lblHoTen.Text + " ra khỏi cửa hàng không",
                "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;
            if (bus.xoaKhachHang(lblMaKH.Text))
                MessageBox.Show("Bạn đã xóa " + lblHoTen.Text + " thành công");
            else MessageBox.Show("Có vấn đề xảy ra! Không thành công");
            XuatThongTin();
        }

        private void PictureBox17_Click(object sender, EventArgs e)
        {
            FormDanhSachKH frmDS = new FormDanhSachKH();
            frmDS.ShowDialog();
        }

        private void PictureBox18_Click(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_KhachHang[] KH =  bus.search_KhachHang(txtTimKiem.Text);
            if (KH[0].MAKH != txtTimKiem.Text && KH[0].HOTEN != txtTimKiem.Text)
            {
                MessageBox.Show("Không có kết quả tương ứng");
                return;
            }

            lblHoTen.Text = KH[0].HOTEN;
            lblDiaChi.Text = KH[0].DIACHI;
            lblDiemTL.Text = TranDateFormat.SubString(KH[0].DIEMTL);
            lblGioiTinh.Text = KH[0].GIOITINH;
            lblLoaiThe.Text = KH[0].LOAIKH;
            lblNgDK.Text = TranDateFormat.SubString(KH[0].NGDK);
            lblNgSinh.Text = TranDateFormat.SubString(KH[0].NGSINH);
            lblMaKH.Text = KH[0].MAKH;

        }
    }
}
