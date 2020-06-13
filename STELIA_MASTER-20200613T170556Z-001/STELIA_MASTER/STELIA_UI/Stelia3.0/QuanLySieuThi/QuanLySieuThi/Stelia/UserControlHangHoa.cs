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
    public partial class UserControlHangHoa : UserControl
    {
        #region 
        private int number_Page = 1;
        private int current_Page = 1;
        private DTO_SanPham[] list_SP; 
        private Color Green_Main = Color.FromArgb(39, 174, 96);
        #endregion
        public UserControlHangHoa()
        {
            InitializeComponent();
        }

        #region Bỏ
        private void NavBarControl2_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc ngừng kinh doanh sản phẩm " + lblTenSP.Text + " này không?",
                "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.No) return;

            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_SanPham SP = bus.search_SANPHAM(lblMaSP.Text)[0];
            SP.TRANGTHAI = "Ngừng kinh doanh";
            if (bus.suaData(SP))
            {
                MessageBox.Show("Bạn đã cập nhật sản phẩm thành công");
            }
            else MessageBox.Show("Có vấn đề xảy ra! Không thành công");

            string str = txtTimKiem.Text;
            txtTimKiem.Text = "a";
            txtTimKiem.Text = str;
            HienThiTrang(current_Page);
            lblPage.Text = current_Page + "/" + number_Page;
            lblTrangThai.Text = "Ngừng kinh doanh";
            
        }
        #endregion

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
        void HienThiTrang(int number_Page)
        {
            int Pos_Start = 12 * (number_Page - 1);
            int Pos_End = list_SP.Length-Pos_Start;
            DTO_SanPham SP = list_SP[Pos_Start];
            if (Pos_End <= 0) SP = null; 
            XuatDuLieuSP(pic1, lblSP1, SP);
            if (Pos_End <= 1) SP = null;
                else SP = list_SP[Pos_Start + 1];
            XuatDuLieuSP(pic2, lblSP2, SP);
            
            if (Pos_End <= 2) SP = null;
                else SP = list_SP[Pos_Start + 2];
            XuatDuLieuSP(pic3, lblSP3, SP);
            
            if (Pos_End <= 3) SP = null;
                else SP = list_SP[Pos_Start + 3];
            XuatDuLieuSP(pic4, lblSP4, SP);
            
            if (Pos_End <= 4) SP = null;
            else SP = list_SP[Pos_Start + 4];
            XuatDuLieuSP(pic5, lblSP5, SP);
            
            if (Pos_End <= 5) SP = null;
            else SP = list_SP[Pos_Start + 5];
            XuatDuLieuSP(pic6, lblSP6, SP);
            
            if (Pos_End <= 6) SP = null;
            else SP = list_SP[Pos_Start + 6];
            XuatDuLieuSP(pic7, lblSP7, SP);
            
            if (Pos_End <= 7) SP = null;
            else SP = list_SP[Pos_Start + 7];
            XuatDuLieuSP(pic8, lblSP8, SP);
            
            if (Pos_End <= 8) SP = null;
            else SP = list_SP[Pos_Start + 8];
            XuatDuLieuSP(pic9, lblSP9, SP);
            
            if (Pos_End <= 9) SP = null;
            else SP = list_SP[Pos_Start + 9];
            XuatDuLieuSP(pic10, lblSP10,SP);
           
            if (Pos_End <= 10) SP = null;
            else SP = list_SP[Pos_Start + 10];
            XuatDuLieuSP(pic11, lblSP11,SP);
            
            if (Pos_End <= 11) SP = null;
            else SP = list_SP[Pos_Start + 11];
            XuatDuLieuSP(pic12, lblSP12,SP);
        }

        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            list_SP = bus.search_SANPHAM(txtTimKiem.Text);
            HienThiTrang(1);
            current_Page = 1;
            number_Page = list_SP.Length / 12 + 1;
            lblPage.Text = "1/" + number_Page;
        }

        private void NextPage_Click(object sender, EventArgs e)
        {
            if (current_Page == number_Page) return;
            current_Page++;
            lblPage.Text = current_Page + "/" + number_Page;
            HienThiTrang(current_Page);
        }

        private void BackPage_Click(object sender, EventArgs e)
        {
            if (current_Page == 1) return;
            current_Page--;
            lblPage.Text = current_Page + "/" + number_Page;
            HienThiTrang(current_Page);
        }

        private void ResetTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = " ";
            txtTimKiem.Text = "";
        }

        void XuatThongTinSP(DTO_SanPham SP)
        {
            lblTenSP.Text = SP.TENSP;
            lblMaSP.Text = SP.MASP;
            lblSoLuong.Text = TranDateFormat.SubString(SP.SLUONG);
            lblTrangThai.Text = SP.TRANGTHAI;
            lblLoiNhuan.Text = TranDateFormat.SubString(SP.LOINHUAN);
            lblGiaBan.Text = TranDateFormat.SubString(SP.DONGIA);
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            lblNCC.Text = bus.getTenNCC(SP.MANCC);
            string ma = lblMaSP.Text;
            if (System.IO.File.Exists(Application.StartupPath + "/HinhSanPham/" + ma + ".jpg"))
                picAnhSP.Image = Image.FromFile(Application.StartupPath + "/HinhSanPham/" + ma + ".jpg");
            else
                if (System.IO.File.Exists(Application.StartupPath + "/HinhSanPham/" + ma+ ".png"))
                picAnhSP.Image = Image.FromFile(Application.StartupPath + "/HinhSanPham/" + ma + ".png");
            else
                picAnhSP.Image = Image.FromFile(Application.StartupPath + "/HinhSanPham/None" + ".png");
        }
        void Init_Color()
        {
            lblThanh1.BackColor = lblThanh2.BackColor = lblThanh3.BackColor
                = lblThanh4.BackColor = lblThanh5.BackColor = Green_Main;
        }
        private void UserControlHangHoa_Load(object sender, EventArgs e)
        {
            Init_Color();
            txtTimKiem.Text = " ";
            txtTimKiem.Text = "";
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_SanPham[] SP = bus.search_SANPHAM("a");
            XuatThongTinSP(SP[0]);
        }

        void Click_Cell_SP(int index)
        {
            DTO_SanPham SP = list_SP[(current_Page - 1) * 12 + index - 1];
            XuatThongTinSP(SP);
        }

        #region Pick Products
        private void Pic1_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic.Image == null) return;
            Click_Cell_SP(1);
        }

        private void Pic2_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic.Image == null) return;
            Click_Cell_SP(2);
        }

        private void Pic3_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic.Image == null) return;
            Click_Cell_SP(3);
        }

        private void Pic4_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic.Image == null) return;
            Click_Cell_SP(4);
        }

        private void Pic5_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic.Image == null) return;
            Click_Cell_SP(5);
        }

        private void Pic6_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic.Image == null) return;
            Click_Cell_SP(6);
        }

        private void Pic7_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic.Image == null) return;
            Click_Cell_SP(7);
        }

        private void Pic8_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic.Image == null) return;
            Click_Cell_SP(8);
        }

        private void Pic9_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic.Image == null) return;
            Click_Cell_SP(9);
        }

        private void Pic10_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic.Image == null) return;
            Click_Cell_SP(10);
        }

        private void Pic11_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic.Image == null) return;
            Click_Cell_SP(11);
        }

        private void Pic12_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic.Image == null) return;
            Click_Cell_SP(12);
        }
        #endregion

        private void CapNhat_Click(object sender, EventArgs e)
        {
            FormCapNhatSP frmCapNhat = new FormCapNhatSP(lblMaSP.Text);
            frmCapNhat.ShowDialog();
            string temp = txtTimKiem.Text;
            txtTimKiem.Text = " ";
            txtTimKiem.Text = temp;
            HienThiTrang(current_Page);
            lblPage.Text = current_Page + "/" + number_Page;

            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_SanPham[] SP =  bus.search_SANPHAM(lblMaSP.Text);
            XuatThongTinSP(SP[0]);
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DialogResult res = MessageBox.Show("Bạn có chắc xóa sản phẩm " + lblTenSP.Text + " không",
                "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;
            if (bus.xoaSanPham(lblMaSP.Text))
                MessageBox.Show("Bạn đã xóa " + lblTenSP.Text + " thành công");
            else
            {
                MessageBox.Show("Có vấn đề xảy ra! Không thành công");
                return;
            }
            string temp = txtTimKiem.Text;
            txtTimKiem.Text = " ";
            txtTimKiem.Text = temp;
            HienThiTrang(current_Page);
            lblPage.Text = current_Page + "/" + number_Page;

            DTO_SanPham[] SP = bus.search_SANPHAM(bus.getThongTinSP(0,0));
            XuatThongTinSP(SP[0]);
        }

        private void PicThemMoi_Click(object sender, EventArgs e)
        {
            FormNhapSP frm = new FormNhapSP();
            frm.ShowDialog();
            string temp = txtTimKiem.Text;
            txtTimKiem.Text = " ";
            txtTimKiem.Text = temp;
            HienThiTrang(current_Page);
            lblPage.Text = current_Page + "/" + number_Page;

            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_SanPham[] SP = bus.search_SANPHAM(lblMaSP.Text);
            XuatThongTinSP(SP[0]);
        }
    }
}
