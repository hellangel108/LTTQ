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
        //private UserControlHangHoa USC
        public FormWork()
        {
            InitializeComponent();
            pnlUserControl.Controls.Add(USCTongQuan);
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
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
            Init_SimpleButton(btnTabTongQuan,0);
            Init_SimpleButton(btnThuNgan,0);
            Init_SimpleButton(btnQuanLy,0);
            Init_SimpleButton(btnKhoHang,0);
            Init_SimpleButton(btnBaoCao,0);
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
            Init_SimpleButton(btnKho_Trataiquay, 1);
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
            ClearPanelUser();
            USCTongQuan.Dispose();
            USCTongQuan = new UserControlTongQuanMain(1918, 913);
            pnlUserControl.Controls.Add(USCTongQuan);
            ResetColorTab();
            pnlButtonTongQuan.Visible = true;
            btnTabTongQuan.Appearance.BackColor = Green_Hover;
        }

        private void BtnTongQuan_KiemKho_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnThuNgan_Click(object sender, EventArgs e)
        {
            ResetColorTab();
            pnlThuNgân.Visible = true;
            btnThuNgan.Appearance.BackColor = Green_Hover;
        }

        private void BtnQuanLy_Click(object sender, EventArgs e)
        {
            ResetColorTab();
            pnlQuanLy.Visible = true;
            btnQuanLy.Appearance.BackColor = Green_Hover;
        }

        private void BtnKhoHang_Click(object sender, EventArgs e)
        {
            ResetColorTab();
            pnlKhoHang.Visible = true;
            btnKhoHang.Appearance.BackColor = Green_Hover;
        }

        private void BtnBaoCao_Click(object sender, EventArgs e)
        {
            ResetColorTab();
            pnlBaoCao.Visible = true;
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
    }
}