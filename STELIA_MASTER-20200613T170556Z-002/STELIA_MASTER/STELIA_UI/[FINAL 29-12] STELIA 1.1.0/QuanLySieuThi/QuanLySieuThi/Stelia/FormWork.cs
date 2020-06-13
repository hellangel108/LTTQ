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
using Stelia_BUS;
using Stelia_DTO;

namespace Stelia
{
    public partial class FormWork : DevExpress.XtraEditors.XtraForm
    {
        private Color Green_Default = Color.FromArgb(39, 174, 96);
        private Color Green_Hover = Color.FromArgb(33,148,82);
        private UserControlNhanVien USCNhanVien = new UserControlNhanVien();
        private UserControlNhapHang USCNhapHang = new UserControlNhapHang();
        private UserControlTongQuanMain USCTongQuan = new UserControlTongQuanMain(1918,913);
        private UserControlHangHoa USCHangHoa = new UserControlHangHoa();
        private UserControlNhaCungCap USCNCC = new UserControlNhaCungCap();
        private UserControlKhachHang USCKH = new UserControlKhachHang();
        private UserControlTraHang USCTraHang = new UserControlTraHang();
        private UserControlTraHangTaiQuay USCTraQuay = new UserControlTraHangTaiQuay();
        private UserControlThuNgan USCThuNgan = new UserControlThuNgan();
        private UserControlHoaDon USCHoaDon = new UserControlHoaDon();
        private UserControlDoanhThuCuoiNgay USCCuoiNgay = new UserControlDoanhThuCuoiNgay();
        public static string username;
        //private UserControlHangHoa US
        public static int check = 0;
        public FormWork()
        {
            InitializeComponent();
            pnlUserControl.Controls.Add(USCTongQuan);
        }

        public FormWork(string username)
        {
            InitializeComponent();
            btnQuanLiTaiKhoan.Visible = false;
            if (username == "admin")
            {
                simpleButton1.Text = username;
                ThongTinDangNhap.Username = username;
                ThongTinDangNhap.ChucVu = "admin";
                btnQuanLiTaiKhoan.Visible = true;
            }
            else
            {
                Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
                DTO_NhanVien[] nv = bus.search_NhanVien(username);
                ThongTinDangNhap.Username = username;
                ThongTinDangNhap.ChucVu = nv[0].CHUCVU;
                simpleButton1.Text = nv[0].HOTEN;
                if(ThongTinDangNhap.ChucVu == "Quản lí kho")
                {
                    Disable_Moderator_Kho();
                }
                if (ThongTinDangNhap.ChucVu == "Quản lí nhân sự")
                {
                    Disable_Moderator_Nhan_Su();
                }
                if(ThongTinDangNhap.ChucVu == "Thu ngân")
                {
                    Disable_Moderator_Kho();
                    Disable_Moderator_Nhan_Su();
                    Enable_Thu_Ngan();
                }
                if(ThongTinDangNhap.ChucVu == "Tạp vụ" || ThongTinDangNhap.ChucVu == "Bảo vệ")
                {
                    Disable_Moderator_Kho();
                    Disable_Moderator_Nhan_Su();
                    btnBaoCao.Enabled = false;
                    btnQuanLy.Enabled = false;
                }
            }
            pnlUserControl.Controls.Add(USCTongQuan);
            USCTongQuan.Dispose();
            USCTongQuan = new UserControlTongQuanMain(1918, 913);
            pnlUserControl.Controls.Add(USCTongQuan);
        }
        private void Disable_Moderator_Kho()
        {
            btnQuanLy_KhachHang.Enabled = false;
            btnQuanLy_NhanVien.Enabled = false;
            btnBaoCao_DoanhThuCuoiNgay.Enabled = false;
            btnTongQuan_DoanhThuCuoiNgay.Enabled = false;
            btnTongQuan_NhanVien.Enabled = false;
            btnTongQuan_KhachHang.Enabled = false;
        }
        private void Disable_Moderator_Nhan_Su()
        {
            btnQuanLy_HangHoa.Enabled = false;
            btnBaoCao_DoanhThuCuoiNgay.Enabled = false;
            btnTongQuan_DoanhThuCuoiNgay.Enabled = false;
            btnTongQuan_Kho.Enabled = false;
            btnKhoHang.Enabled = false;
            btnBaoCao.Enabled = false;
        }
        private void Enable_Thu_Ngan()
        {
            btnThuNgan.Enabled = true;
            btnQuanLy_HoaDon.Enabled = true;
            btnQuanLy_KhachHang.Enabled = true;
            btnKhoHang.Enabled = true;
            btnKho_Nhaphang.Enabled = false;
            btnKho_TraHang.Enabled = false;
        }
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            if (CheckIs1())
                return;
            Application.Exit();
        }

        void Init_SimpleButton(SimpleButton btn, int loai)
        {
            btn.BackColor = Green_Default;
            btn.ForeColor = Color.White;
            btnTabTongQuan.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            btn.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            btn.AppearanceHovered.BackColor = Green_Hover;
            btn.Appearance.BackColor = Green_Default;
            btn.Appearance.Options.UseBackColor = true;
            btn.AppearancePressed.BackColor = Green_Hover;
            btn.AllowFocus = false;

            if (loai == 1)
            {
                btn.Appearance.BackColor = Green_Hover;
                btn.AppearanceHovered.BackColor = Green_Default;
                btn.AppearancePressed.BackColor = Green_Default;
            }
        }

        void Init_Allbutton()
        {
            simpleButton1.BackColor = Color.White;
            simpleButton1.ForeColor = Color.Black;
            simpleButton1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            simpleButton1.AppearanceHovered.BackColor = Color.White;
            simpleButton1.Appearance.BackColor = Color.White;
            simpleButton1.Appearance.Options.UseBackColor = true;
            Init_SimpleButton(btnTabTongQuan,0);
            Init_SimpleButton(btnThuNgan,0);
            Init_SimpleButton(btnQuanLy,0);
            Init_SimpleButton(btnKhoHang,0);
            Init_SimpleButton(btnBaoCao,0);
            Init_SimpleButton(btnQuanLiTaiKhoan, 0);
            Init_SimpleButton(btnDangXuat, 0);
            Init_SimpleButton(btnDoiMK, 0);
            Init_SimpleButton(btnTongQuan_ThuNgan,1);
            Init_SimpleButton(btnTongQuan_KhachHang,1);
            Init_SimpleButton(btnTongQuan_NhanVien,1);
            Init_SimpleButton(btnTongQuan_Kho,1);
            Init_SimpleButton(btnTongQuan_DoanhThuCuoiNgay,1);
            Init_SimpleButton(btnTongQuan_ThongBao,1);
            Init_SimpleButton(btnThuNgan_BanHang, 1);
            Init_SimpleButton(btnThuNgan_TimKiemMaVach, 1);
            Init_SimpleButton(btnQuanLy_HoaDon, 1);
            Init_SimpleButton(btnQuanLy_NhanVien, 1);
            Init_SimpleButton(btnQuanLy_HangHoa, 1);
            Init_SimpleButton(btnQuanLy_KhachHang, 1);
            Init_SimpleButton(btnQuanLy_NhaCungCap, 1);
            Init_SimpleButton(btnKho_Nhaphang, 1);
            Init_SimpleButton(btnKho_TraHang, 1);
            Init_SimpleButton(btnBaoCao_DoanhThuCuoiNgay, 1);
            Init_SimpleButton(btnBaoCao_NhapHang, 1);
            Init_SimpleButton(btnBaoCao_TraHang, 1);
        }
        void ResetColorTab()
        {
            btnTabTongQuan.Appearance.BackColor = Green_Default;
            btnThuNgan.Appearance.BackColor = Green_Default;
            btnQuanLy.Appearance.BackColor = Green_Default;
            btnKhoHang.Appearance.BackColor = Green_Default;
            btnBaoCao.Appearance.BackColor = Green_Default;
            pnlButtonTongQuan.Visible = false;
            pnlThuNgân.Visible = false;
            pnlQuanLy.Visible = false;
            pnlKhoHang.Visible = false;
            pnlBaoCao.Visible = false;
        }
        void Init_AllPanelTab()
        {
            pnlThuNgân.Location = new Point(198,0);
            pnlQuanLy.Location = new Point(336, 0);
            pnlKhoHang.Location = new Point(474, 0);
            pnlBaoCao.Location = new Point(612, 0);
        }
        private void FormWork_Load(object sender, EventArgs e)
        {
            pnlTab.BackColor = Green_Default;
            Init_Allbutton();
            Init_AllPanelTab();
        }

        private void BtnTabTongQuan_Click(object sender, EventArgs e)
        {
            if (CheckIs1())
                return;
            ClearPanelUser();
            USCTongQuan.Dispose();
            USCTongQuan = new UserControlTongQuanMain(1918, 913);
            pnlUserControl.Controls.Add(USCTongQuan);
            ResetColorTab();
            //pnlButtonTongQuan.Visible = true;
            btnTabTongQuan.Appearance.BackColor = Green_Hover;
        }

        private void BtnTongQuan_KiemKho_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnThuNgan_Click(object sender, EventArgs e)
        {
            if (check == 1)
                return;
            //ResetColorTab();
            //pnlThuNgân.Visible = true;
            btnThuNgan.Appearance.BackColor = Green_Hover;
            ClearPanelUser();
            USCThuNgan.Dispose();
            USCThuNgan = new UserControlThuNgan();
            pnlUserControl.Controls.Add(USCThuNgan);
            ResetColorTab();
        }
        private void BtnQuanLy_Click(object sender, EventArgs e)
        {
            if (CheckIs1())
                return;
            bool temp = pnlQuanLy.Visible;
            ResetColorTab();
            pnlQuanLy.Visible = !temp;
            btnQuanLy.Appearance.BackColor = Green_Hover;
        }

        private void BtnKhoHang_Click(object sender, EventArgs e)
        {
            if (CheckIs1())
                return;
            bool temp = pnlKhoHang.Visible;
            ResetColorTab();
            pnlKhoHang.Visible = !temp;
            btnKhoHang.Appearance.BackColor = Green_Hover;
        }

        private void BtnBaoCao_Click(object sender, EventArgs e)
        {
            if (CheckIs1())
                return;
            bool temp = pnlBaoCao.Visible;
            ResetColorTab();
            pnlBaoCao.Visible = !temp;
            btnBaoCao.Appearance.BackColor = Green_Hover;
        }

        void ClearPanelUser()
        {
            foreach (var x in pnlUserControl.Controls)
                if (!(x is Panel))
                    pnlUserControl.Controls.Remove(x as UserControl);
        }

        private void BtnTongQuan_NhanVien_Click(object sender, EventArgs e)
        {
            ClearPanelUser();
            USCNhanVien.Dispose();
            USCNhanVien = new UserControlNhanVien();
            pnlUserControl.Controls.Add(USCNhanVien);
            ResetColorTab();
        }

        private void BtnQuanLy_NhanVien_Click(object sender, EventArgs e)
        {
            ClearPanelUser();
            USCNhanVien.Dispose();
            USCNhanVien = new UserControlNhanVien();
            pnlUserControl.Controls.Add(USCNhanVien);
            ResetColorTab();
        }

        private void BtnBaoCao_NhapHang_Click(object sender, EventArgs e)
        {
            ClearPanelUser();
            USCNhapHang.Dispose();
            USCNhapHang = new UserControlNhapHang();
            pnlUserControl.Controls.Add(USCNhapHang);
            ResetColorTab();
        }

        private void BtnKho_Nhaphang_Click(object sender, EventArgs e)
        {
            ClearPanelUser();
            USCNhapHang.Dispose();
            USCNhapHang = new UserControlNhapHang();
            pnlUserControl.Controls.Add(USCNhapHang);
            ResetColorTab();
            USCNhapHang.NhapPhieuNhap();
        }

        private void BtnQuanLy_HangHoa_Click(object sender, EventArgs e)
        {
            ClearPanelUser();
            USCHangHoa.Dispose();
            USCHangHoa = new UserControlHangHoa();
            pnlUserControl.Controls.Add(USCHangHoa);
            ResetColorTab();
        }

        private void PnlUserControl_Click(object sender, EventArgs e)
        {
            ResetColorTab();
        }

        private void BtnQuanLy_NhaCungCap_Click(object sender, EventArgs e)
        {
            ClearPanelUser();
            USCNCC.Dispose();
            USCNCC = new UserControlNhaCungCap();
            pnlUserControl.Controls.Add(USCNCC);
            ResetColorTab();
        }

        private void PnlButtonTongQuan_Leave(object sender, EventArgs e)
        {
            ResetColorTab();
        }

        private void BtnTongQuan_ThongBao_Click(object sender, EventArgs e)
        {
            ClearPanelUser();
            USCTongQuan.Dispose();
            USCTongQuan = new UserControlTongQuanMain(1918,913);
            pnlUserControl.Controls.Add(USCTongQuan);
            ResetColorTab();
        }

        private void BtnTongQuan_KhachHang_Click(object sender, EventArgs e)
        {
            ClearPanelUser();
            USCKH.Dispose();
            USCKH = new UserControlKhachHang();
            pnlUserControl.Controls.Add(USCKH);
            ResetColorTab();
        }

        private void BtnQuanLy_KhachHang_Click(object sender, EventArgs e)
        {
            ClearPanelUser();
            USCKH.Dispose();
            USCKH = new UserControlKhachHang();
            pnlUserControl.Controls.Add(USCKH);
            ResetColorTab();
        }

        private void BtnTongQuan_Kho_Click(object sender, EventArgs e)
        {
            ClearPanelUser();
            USCHangHoa.Dispose();
            USCHangHoa = new UserControlHangHoa();
            pnlUserControl.Controls.Add(USCHangHoa);
            ResetColorTab();
        }

        private void BtnBaoCao_TraHang_Click(object sender, EventArgs e)
        {
            ClearPanelUser();
            USCTraHang.Dispose();
            USCTraHang = new UserControlTraHang();
            pnlUserControl.Controls.Add(USCTraHang);
            ResetColorTab();
        }

        private void BtnKho_TraHang_Click(object sender, EventArgs e)
        {
            ClearPanelUser();
            USCTraHang.Dispose();
            USCTraHang = new UserControlTraHang();
            pnlUserControl.Controls.Add(USCTraHang);
            ResetColorTab();
            USCTraHang.NhapPhieuTra();
        }

        private void BtnKho_Trataiquay_Click(object sender, EventArgs e)
        {
            ClearPanelUser();
            USCTraQuay.Dispose();
            USCTraQuay = new UserControlTraHangTaiQuay();
            pnlUserControl.Controls.Add(USCTraQuay);
            ResetColorTab();
        }

        private void BtnTongQuan_ThuNgan_Click(object sender, EventArgs e)
        {
            ClearPanelUser();
            USCThuNgan.Dispose();
            USCThuNgan = new UserControlThuNgan();
            pnlUserControl.Controls.Add(USCThuNgan);
            ResetColorTab();
        }
        public bool CheckIs1()
        {
            if (check == 1)
            {
                MessageBox.Show("Bạn đang nhập mới một hoá đơn. Vui lòng xoá toàn bộ sản phẩm khỏi giỏ hàng trước khi thực hiện thao tác này!","Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (CheckIs1())
                return;
            DialogResult kq = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                foreach (Form f in Application.OpenForms)
                {
                    f.DialogResult = DialogResult.OK;
                    f.Close();
                    return;
                }
            }
        }

        private void btnQuanLiTaiKhoan_Click(object sender, EventArgs e)
        {
            if (CheckIs1())
                return;
            FormQuanLiTaiKhoan ql = new FormQuanLiTaiKhoan();
            ql.ShowDialog();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            if (CheckIs1())
                return;
            FormCapNhatMatKhau mk = new FormCapNhatMatKhau();
            mk.ShowDialog();
        }

        private void BtnQuanLy_HoaDon_Click(object sender, EventArgs e)
        {
            ClearPanelUser();
            USCHoaDon.Dispose();
            USCHoaDon = new UserControlHoaDon();
            pnlUserControl.Controls.Add(USCHoaDon);
            ResetColorTab();
        }

        private void btnBaoCao_DoanhThuCuoiNgay_Click(object sender, EventArgs e)
        {
            ClearPanelUser();
            USCCuoiNgay.Dispose();
            USCCuoiNgay = new UserControlDoanhThuCuoiNgay();
            pnlUserControl.Controls.Add(USCCuoiNgay);
            ResetColorTab();
        }
    }
}