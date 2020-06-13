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
    public partial class UserControlTongQuanMain : UserControl
    {
        private int Width, Height;
        private Color MauBangHoatDong = Color.FromArgb(39,174,96);
        private DTO_SanPham[] List10Products;
        private int soluong = 0;
        private string[] st;
        public UserControlTongQuanMain(int W, int H)
        {
            InitializeComponent();
            Width = W;
            Height = H;
            Init_ComboBoxThoiGian();
            Init_ComboBoxTieuChi();
            Init_Label();
            Init_BangThongTinDangNhap();
            Init_Today_Panel();
        }
        void XuatDuLieuSP(PictureBox pic, Label name, DTO_SanPham sp)
        {
            if (sp == null)
            {
                pic.Image = null;
                name.Text = "";
                return;
            }
            if (System.IO.File.Exists(Application.StartupPath + "/HinhSanPham/" + sp.MASP + ".jpg"))
                pic.Image = Image.FromFile(Application.StartupPath + "/HinhSanPham/" + sp.MASP + ".jpg");
            else
                if (System.IO.File.Exists(Application.StartupPath + "/HinhSanPham/" + sp.MASP + ".png"))
                pic.Image = Image.FromFile(Application.StartupPath + "/HinhSanPham/" + sp.MASP + ".png");
            else
                pic.Image = Image.FromFile(Application.StartupPath + "/HinhSanPham/None" + ".png");
            name.Text = sp.TENSP;
            //MessageBox.Show(Application.StartupPath + "/HinhSanPham/" + sp.MASP + ".jpg");
        }

        void Init_Top10()
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            soluong = st.Length;
            DTO_SanPham SP = null;
            if (soluong > 0) SP = bus.search_SANPHAM(st[0])[0];
            XuatDuLieuSP(pic1, lblSP1, SP);

            SP = null;
            if (soluong > 1) SP = bus.search_SANPHAM(st[1])[0];
            XuatDuLieuSP(pic2, lblSP2, SP);

            SP = null;
            if (soluong > 2) SP = bus.search_SANPHAM(st[2])[0];
            XuatDuLieuSP(pic3, lblSP3, SP);

            SP = null;
            if (soluong > 3) SP = bus.search_SANPHAM(st[3])[0];
            XuatDuLieuSP(pic4, lblSP4, SP);

            SP = null;
            if (soluong > 4) SP = bus.search_SANPHAM(st[4])[0];
            XuatDuLieuSP(pic5, lblSP5, SP);

            SP = null;
            if (soluong > 5) SP = bus.search_SANPHAM(st[5])[0];
            XuatDuLieuSP(pic6, lblSP6, SP);

            SP = null;
            if (soluong > 6) SP = bus.search_SANPHAM(st[6])[0];
            XuatDuLieuSP(pic7, lblSP7, SP);

            SP = null;
            if (soluong > 7) SP = bus.search_SANPHAM(st[7])[0];
            XuatDuLieuSP(pic8, lblSP8, SP);

            SP = null;
            if (soluong > 8) SP = bus.search_SANPHAM(st[8])[0];
            XuatDuLieuSP(pic9, lblSP9, SP);

            SP = null;
            if (soluong > 9) SP = bus.search_SANPHAM(st[9])[0];
            XuatDuLieuSP(pic10, lblSP10, SP);
        }
        void Init_Label()
        {
            lbl1.BackColor = lbl2.BackColor = lbl3.BackColor = lbl10.BackColor= label8.BackColor = Color.FromArgb(39,174,96);
        }
        void Init_ComboBoxThoiGian()
        {
            string[] time = {"Hôm nay","Hôm qua", "Tháng này", "Tháng trước"};
            cbxThoiGian.Items.AddRange(time);
            cbxThoiGian.Font = new Font("Arial", 15, FontStyle.Regular);
            cbxThoiGian.ForeColor = Color.DodgerBlue;
            string[] time2 = { "Hôm nay", "Tuần này", "Tháng này" };
            cbxThoiGianTieuChi.Items.AddRange(time2);
            cbxThoiGianTieuChi.Font = cbxThoiGian.Font;
            cbxThoiGianTieuChi.ForeColor = Color.DodgerBlue;

        }
        void Init_ComboBoxTieuChi()
        {
            string[] tieuchi = { "Theo Doanh Thu", "Theo Số Lượng" };
            cbxTieuChi.Items.AddRange(tieuchi);
            cbxTieuChi.Font = new Font("Arial", 15, FontStyle.Regular);
            cbxTieuChi.ForeColor = Color.DodgerBlue;
        }
        void Init_BangThongTinDangNhap()
        {
            if (ThongTinDangNhap.Username == "admin")
            {
                textBoxHoTen.Text = "admin";
                lblNgSinh.Text = "";
                lblChucVu.Text = "admin";
                lblNgVaoLam.Text = "";
                lblGioiTinh.Text = "";
                simpleButton1.Visible = false;
                picAnh.Image = Image.FromFile(Application.StartupPath + "/HinhNhanVien/" + "None.png");
                return;
            }
            string ma = ThongTinDangNhap.Username;
            if (System.IO.File.Exists(Application.StartupPath + "/HinhNhanVien/" + ma + ".jpg"))
                picAnh.Image = Image.FromFile(Application.StartupPath + "/HinhNhanVien/" + ma + ".jpg");
            else
                 if (System.IO.File.Exists(Application.StartupPath + "/HinhNhanVien/" + ma + ".png"))
                picAnh.Image = Image.FromFile(Application.StartupPath + "/HinhNhanVien/" + ma + ".png");
            else picAnh.Image = Image.FromFile(Application.StartupPath + "/HinhNhanVien/" + "None.png");
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_NhanVien[] nv = bus.search_NhanVien(ThongTinDangNhap.Username);
            textBoxHoTen.Text = nv[0].HOTEN;
            textBoxHoTen.ForeColor = Color.Black;
            lblNgSinh.Text = TranDateFormat.SubString(nv[0].NGSINH);
            lblChucVu.Text = nv[0].CHUCVU;
            lblNgVaoLam.Text = TranDateFormat.SubString(nv[0].NGAYVL);
            lblGioiTinh.Text = nv[0].GIOITINH;
        }

        private void ResourcesComboBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CbxThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            switch(cbxThoiGian.SelectedIndex)
            {
                case 0:
                    labelBangDoanhThu.Text = "DOANH THU THUẦN HÔM NAY";
                    labelDoanhThuLon.Text = bus.doanhThuTheoNgay(DateChange.ToString(DateTime.Today)) + " VND";
                    break;
                case 1:
                    labelBangDoanhThu.Text = "DOANH THU THUẦN HÔM QUA";
                    labelDoanhThuLon.Text = bus.doanhThuTheoNgay(DateChange.ToString(DateTime.Today.AddDays(-1))) + " VND";
                    break;
                case 2:
                    labelBangDoanhThu.Text = "DOANH THU THUẦN THÁNG NÀY";
                    labelDoanhThuLon.Text = bus.doanhThuTheoThang(DateTime.Today.Month.ToString(), DateTime.Today.Year.ToString()) + " VND";
                    break;
                case 3:
                    labelBangDoanhThu.Text = "DOANH THU THUẦN THÁNG TRƯỚC";
                    labelDoanhThuLon.Text = bus.doanhThuTheoThang(DateTime.Today.AddMonths(-1).Month.ToString(), DateTime.Today.AddMonths(-1).Year.ToString()) + " VND";
                    break;
            }
        }

        #region
        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FlowLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox12_Click(object sender, EventArgs e)
        {

        }
        #endregion
        private void UserControlTongQuanMain_Load(object sender, EventArgs e)
        {
            //Init_ComboBoxThoiGian();
            //Init_ComboBoxTieuChi();
            Init_Label();
            Init_BangThongTinDangNhap();
            Init_Today_Panel();
            cbxThoiGian.SelectedIndex = 1;
            cbxThoiGian.SelectedIndex = 0;
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            st = bus.top10_maSP_BanChayTheoSoLuong_TheoThang();
            Init_Top10();
            cbxThoiGianTieuChi.SelectedIndex = 2;
            cbxTieuChi.SelectedIndex = 1;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(kq == DialogResult.Yes)
            {
                foreach(Form f in Application.OpenForms)
                {
                    f.DialogResult = DialogResult.OK;
                    f.Close();
                    return;
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_DiemDanh dd = new DTO_DiemDanh(ThongTinDangNhap.Username, DateChange.ToString(DateTime.Today));
            string error = CheckThongTin.check_Nhap(dd);
            if (error != "")
            {
                PushNoti noti1 = new PushNoti("Error", error);
                noti1.Width = this.panel15.Width;
                this.panel15.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
                return;
            }
            if (bus.themData(dd))
            {
                PushNoti noti1 = new PushNoti("Success", "Điểm danh thành công!");
                noti1.Width = this.panel15.Width;
                this.panel15.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
            }
        }

        private void FlowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CbxThoiGianTieuChi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            if (cbxTieuChi.Text == "Theo Doanh Thu")
            {
                if (cbxThoiGianTieuChi.Text == "Hôm nay")
                {
                    st = bus.top10_maSP_BanChayTheoDoanhThu_TheoNgay();
                    Init_Top10();
                }
                if (cbxThoiGianTieuChi.Text == "Tuần này")
                {
                    st = bus.top10_maSP_BanChayTheoDoanhThu_TheoTuan();
                    Init_Top10();
                }
                if (cbxThoiGianTieuChi.Text == "Tháng này")
                {
                    st = bus.top10_maSP_BanChayTheoDoanhThu_TheoThang();
                    Init_Top10();
                }
            }
            else
            {
                if (cbxThoiGianTieuChi.Text == "Hôm nay")
                {
                    st = bus.top10_maSP_BanChayTheoSoLuong_TheoNgay();
                    Init_Top10();
                }
                if (cbxThoiGianTieuChi.Text == "Tuần này")
                {
                    st = bus.top10_maSP_BanChayTheoSoLuong_TheoTuan();
                    Init_Top10();
                }
                if (cbxThoiGianTieuChi.Text == "Tháng này")
                {
                    st = bus.top10_maSP_BanChayTheoSoLuong_TheoThang();
                    Init_Top10();
                }
            }
        }

        private void CbxTieuChi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            if (cbxTieuChi.Text == "Theo Doanh Thu")
            {
                if (cbxThoiGianTieuChi.Text == "Hôm nay")
                {
                    st = bus.top10_maSP_BanChayTheoDoanhThu_TheoNgay();
                    Init_Top10();
                }
                if (cbxThoiGianTieuChi.Text == "Tuần này")
                {
                    st = bus.top10_maSP_BanChayTheoDoanhThu_TheoTuan();
                    Init_Top10();
                }
                if (cbxThoiGianTieuChi.Text == "Tháng này")
                {
                    st = bus.top10_maSP_BanChayTheoDoanhThu_TheoThang();
                    Init_Top10();
                }
            }
            else
            {
                if (cbxThoiGianTieuChi.Text == "Hôm nay")
                {
                    st = bus.top10_maSP_BanChayTheoSoLuong_TheoNgay();
                    Init_Top10();
                }
                if (cbxThoiGianTieuChi.Text == "Tuần này")
                {
                    st = bus.top10_maSP_BanChayTheoSoLuong_TheoTuan();
                    Init_Top10();
                }
                if (cbxThoiGianTieuChi.Text == "Tháng này")
                {
                    st = bus.top10_maSP_BanChayTheoSoLuong_TheoThang();
                    Init_Top10();
                }
            }
        }

        private void Init_Today_Panel()
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DateTime dt = DateTime.Today;
            label3.Text = bus.doanhThuTheoNgay(DateChange.ToString(dt)) + " VND";
            label4.Text = bus.soLuongTheoNgay(DateChange.ToString(dt));
        }
    }
}
