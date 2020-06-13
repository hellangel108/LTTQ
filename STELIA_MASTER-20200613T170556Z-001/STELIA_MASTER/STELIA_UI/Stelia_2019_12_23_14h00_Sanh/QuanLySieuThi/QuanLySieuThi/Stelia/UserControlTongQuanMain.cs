using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Init_BangHoatDong();
            Init_Label();
        }
        void Init_Label()
        {
            lbl1.BackColor = lbl2.BackColor = lbl3.BackColor = lbl4.BackColor = lbl10.BackColor=  Color.FromArgb(39,174,96);
        }
        void Init_BangHoatDong()
        {
            pnlHoatDongNhanVien.BackColor = MauBangHoatDong;
            pnlHoatDong1.BackColor = MauBangHoatDong;
            pnlHoatDong2.BackColor = MauBangHoatDong;
            pnlHoatDong3.BackColor = MauBangHoatDong;
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

        private void FlowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
