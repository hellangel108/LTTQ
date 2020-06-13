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
            picUnderlineGio.Visible = picUnderlineNgay.Visible = picUnderlineThu.Visible = false;
            Init_ComboBoxThoiGian();
            Init_ComboBoxTieuChi();
            Init_Label();
            Init_BangThongTinDangNhap();
        }
        void Init_Label()
        {
            lbl1.BackColor = lbl2.BackColor = lbl3.BackColor = lbl10.BackColor=  Color.FromArgb(39,174,96);
        }
        void Init_ComboBoxThoiGian()
        {
            string[] time = {"Hôm nay","Hôm qua", "7 ngày qua", "Tháng này", "Tháng trước"};
            cbxThoiGian.Items.AddRange(time);
            cbxThoiGian.Font = new Font("Arial", 15, FontStyle.Regular);
            cbxThoiGian.ForeColor = Color.DodgerBlue;
            cbxThoiGianTieuChi.Items.AddRange(time);
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
                return;
            }
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_NhanVien[] nv = bus.search_NhanVien(ThongTinDangNhap.Username);
            textBoxHoTen.Text = nv[0].HOTEN;
            textBoxHoTen.ForeColor = Color.Black;
            lblNgSinh.Text = TranDateFormat.SubString(nv[0].NGSINH);
            lblChucVu.Text = nv[0].CHUCVU;
            lblNgVaoLam.Text = TranDateFormat.SubString(nv[0].NGAYVL);
            lblGioiTinh.Text = nv[0].GIOITINH;
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LblNgay_Click(object sender, EventArgs e)
        {
            picUnderlineNgay.Visible = true;
            picUnderlineGio.Visible = false;
            picUnderlineThu.Visible = false;
        }

        private void LblGio_Click(object sender, EventArgs e)
        {
            picUnderlineNgay.Visible = false;
            picUnderlineGio.Visible = true;
            picUnderlineThu.Visible = false;
        }

        private void LblThu_Click(object sender, EventArgs e)
        {
            picUnderlineNgay.Visible = false;
            picUnderlineGio.Visible = false;
            picUnderlineThu.Visible = true;
        }

        private void ResourcesComboBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CbxThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            picUnderlineGio.Visible = picUnderlineNgay.Visible = picUnderlineThu.Visible = false;
            Init_ComboBoxThoiGian();
            Init_ComboBoxTieuChi();
            Init_Label();
            Init_BangThongTinDangNhap();
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

        private void FlowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
