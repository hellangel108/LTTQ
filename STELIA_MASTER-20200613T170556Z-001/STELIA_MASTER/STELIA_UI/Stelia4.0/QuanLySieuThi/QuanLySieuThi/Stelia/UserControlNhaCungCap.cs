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
        private DTO_NhaCungCap[] list_NCC;

        void TaoTop3NCC()
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            string[] name = bus.Top3_NCC();
            lblTop1.Text = TranDateFormat.GetLastName(name[0]);
            lblTop2.Text = TranDateFormat.GetLastName(name[1]);
            lblTop3.Text = TranDateFormat.GetLastName(name[2]);
        }
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
            TaoTop3NCC();
            lbl1.BackColor = lbl2.BackColor = lbl3.BackColor = lbl5.BackColor = lbl6.BackColor = Color.FromArgb(39, 174, 96);
            lblTop1.BackColor = Color.FromArgb(243,208,55);
            lblTop2.BackColor = Color.FromArgb(213,90,48);
            lblTop3.BackColor = Color.FromArgb(22,175,84);
            XuatThongTinNguoiDau();
            txtTimKiem.Text = " ";
            txtTimKiem.Text = "";
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

            string ma = NCC.MANCC;
            if (System.IO.File.Exists(Application.StartupPath + "/HinhAnhNCC/" + ma + ".jpg"))
                picNCC.Image = Image.FromFile(Application.StartupPath + "/HinhAnhNCC/" + ma + ".jpg");
            else
                picNCC.Image = Image.FromFile(Application.StartupPath + "/HinhAnhNCC/" + ma + ".png");
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
            if (frm.DialogResult == DialogResult.OK)
            {
                PushNoti noti1 = new PushNoti("Success", "Thêm nhà cung cấp thành công!");
                noti1.Width = this.Width;
                this.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
            }
        }

        private void PictureBox17_Click(object sender, EventArgs e)
        {
            FormDanhSachSP_NCC frm = new FormDanhSachSP_NCC(LblMaNCC.Text);
            frm.ShowDialog();
        }
        void GhepNCC(PictureBox pic, Label lbl, DTO_NhaCungCap ncc)
        {
            if (ncc == null)
            {
                pic.Image = null;
                lbl.Text = "";
                return;
            }
            lbl.Text = ncc.TENNCC;
            string ma = ncc.MANCC;
            if (System.IO.File.Exists(Application.StartupPath + "/HinhAnhNCC/" + ma + ".jpg"))
                pic.Image = Image.FromFile(Application.StartupPath + "/HinhAnhNCC/" + ma + ".jpg");
            else
                pic.Image = Image.FromFile(Application.StartupPath + "/HinhAnhNCC/" + ma + ".png");
            
        }
        void hienthi_DSNCC(DTO_NhaCungCap[] ncc)
        {
            int length = ncc.Length;
            DTO_NhaCungCap NCC;
            if (length <= 0) NCC = null; else NCC = ncc[0];
            GhepNCC(picNCC1, lblTenNCC1, NCC);

            if(length <= 1) NCC = null; else NCC = ncc[1];
            GhepNCC(picNCC2, lblTenNCC2, NCC);

            if(length <= 2) NCC = null; else NCC = ncc[2];
            GhepNCC(picNCC3, lblTenNCC3, NCC);

            if(length <= 3) NCC = null; else NCC = ncc[3];
            GhepNCC(picNCC4, lblTenNCC4, NCC);

            if(length <= 4) NCC = null; else NCC = ncc[4];
            GhepNCC(picNCC5, lblTenNCC5, NCC);

            if(length <= 5) NCC = null; else NCC = ncc[5];
            GhepNCC(picNCC6, lblTenNCC6, NCC);

        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            list_NCC = bus.search_NhaCungCap(txtTimKiem.Text);
            hienthi_DSNCC(list_NCC);
        }

        #region Click_HienThiNCC
        private void PicNCC1_Click(object sender, EventArgs e)
        {
            if (list_NCC.Length <= 0) return;
            XuatThongTin(list_NCC[0]);
        }

        private void PicNCC2_Click(object sender, EventArgs e)
        {
            if (list_NCC.Length <= 1) return;
            XuatThongTin(list_NCC[1]);
        }

        private void PicNCC3_Click(object sender, EventArgs e)
        {
            if (list_NCC.Length <= 2) return;
            XuatThongTin(list_NCC[2]);
        }

        private void PicNCC4_Click(object sender, EventArgs e)
        {
            if (list_NCC.Length <= 3) return;
            XuatThongTin(list_NCC[3]);
        }

        private void PicNCC5_Click(object sender, EventArgs e)
        {
            if (list_NCC.Length <= 4) return;
            XuatThongTin(list_NCC[4]);
        }

        private void PicNCC6_Click(object sender, EventArgs e)
        {
            if (list_NCC.Length <= 5) return;
            XuatThongTin(list_NCC[5]);
        }
        #endregion

        private void Pic_List_NCC_Click(object sender, EventArgs e)
        {
            FormDanhSachNCC frm = new FormDanhSachNCC();
            frm.ShowDialog();
        }
    }
}
