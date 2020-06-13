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
    public partial class UserControlNhaCungCap : UserControl
    {
        public UserControlNhaCungCap()
        {
            InitializeComponent();
        }

        void XuatThongTinNguoiDau()
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            string st =  bus.getThongTinKH(0, 0);
            DTO_NhaCungCap[] NCC = bus.search_NhaCungCap(st);
            XuatThongTin(NCC[0]);
        }

        private void UserControlNhaCungCap_Load(object sender, EventArgs e)
        {
            lbl1.BackColor = lbl2.BackColor = lbl3.BackColor = lbl5.BackColor = Color.FromArgb(39, 174, 96);
            lblTop1.BackColor = Color.FromArgb(243,208,55);
            lblTop2.BackColor = Color.FromArgb(213,90,48);
            lblTop3.BackColor = Color.FromArgb(22,175,84);
            XuatThongTinNguoiDau();

        }

        void XuatThongTin(DTO_NhaCungCap NCC)
        {
            LblMaNCC.Text = NCC.MANCC;
            LblTen.Text = NCC.TENNCC;
            LblNGHT.Text = NCC.NGHT;
            LblSDT.Text = NCC.SDT;
            LblMD.Text = NCC.MUCDOCC;
            LblTrangThai.Text = NCC.TRANGTHAI;
            LblDiaChi.Text = NCC.DIACHI;
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pic_UpdateNCC_click(object sender, EventArgs e)
        {
            FormCapNhatNhaCungCap form = new FormCapNhatNhaCungCap(LblMaNCC.Text);
            form.ShowDialog();
        }

        private void Label17_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox14_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc xóa nhà cung cấp " + LblTen.Text + " ra khỏi cửa hàng", "Hỏi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.No) return;
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            //MessageBox.Show(lblMaNV.Text);
            if (bus.xoaNhaCungCap(LblMaNCC.Text) == false)
                MessageBox.Show("Việc xóa xảy ra một số vấn đề! Không thành công");
            else MessageBox.Show("Đã xóa nhà cung cấp " + LblTen.Text + "ra khỏi cửa hàng");
            //Reset();
        }

        private void PictureBox9_Click(object sender, EventArgs e)
        {
            FormNhapNCC frm = new FormNhapNCC();
            frm.ShowDialog();
        }

        private void PictureBox17_Click(object sender, EventArgs e)
        {

        }
    }
}
