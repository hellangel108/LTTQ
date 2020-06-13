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
        void Init_Label()
        {
            lbl1.BackColor = lbl2.BackColor = lbl3.BackColor = lbl10.BackColor=  Color.FromArgb(39,174,96);
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
                    labelBangDoanhThu.Text = "Doanh thu thuần hôm nay";
                    labelDoanhThuLon.Text = bus.doanhThuTheoNgay(DateChange.ToString(DateTime.Today));
                    break;
                case 1:
                    labelBangDoanhThu.Text = "Doanh thu thuần hôm qua";
                    labelDoanhThuLon.Text = bus.doanhThuTheoNgay(DateChange.ToString(DateTime.Today.AddDays(-1)));
                    break;
                case 2:
                    labelBangDoanhThu.Text = "Doanh thu thuần tháng này";
                    labelDoanhThuLon.Text = bus.doanhThuTheoThang(DateTime.Today.Month.ToString(), DateTime.Today.Year.ToString());
                    break;
                case 3:
                    labelBangDoanhThu.Text = "Doanh thu thuần tháng trước";
                    labelDoanhThuLon.Text = bus.doanhThuTheoThang(DateTime.Today.AddMonths(-1).Month.ToString(), DateTime.Today.AddMonths(-1).Year.ToString());
                    break;
            }
        }

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

        private void UserControlTongQuanMain_Load(object sender, EventArgs e)
        {
            //Init_ComboBoxThoiGian();
            //Init_ComboBoxTieuChi();
            Init_Label();
            Init_BangThongTinDangNhap();
            Init_Today_Panel();
            cbxThoiGian.SelectedIndex = 1;
            cbxThoiGian.SelectedIndex = 0;
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

        private void Init_Today_Panel()
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DateTime dt = DateTime.Today;
            label3.Text = bus.doanhThuTheoNgay(DateChange.ToString(dt));
            label4.Text = bus.soLuongTheoNgay(DateChange.ToString(dt));
        }
    }
}
