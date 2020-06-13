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
    public partial class UserControlPanelSanPham : UserControl
    {
        private long DonGia = 0;
        private string Ma = "";
        private int SoLuong = 0;
        public UserControlPanelSanPham(string ma, string TenSP, string SoLuong, long DonGia)
        {
            InitializeComponent();
            Ma = ma;
            this.SoLuong = int.Parse(SoLuong);
            lblSoLuong.Text = "x" + SoLuong;
            lblTenSP.Text = TenSP;

            if (System.IO.File.Exists(Application.StartupPath + "/HinhSanPham/" + ma + ".jpg"))
                picAnhSP.Image = Image.FromFile(Application.StartupPath + "/HinhSanPham/" + ma + ".jpg");
            else
                picAnhSP.Image = Image.FromFile(Application.StartupPath + "/HinhSanPham/" + ma + ".png");
            this.DonGia = DonGia;
        }

        private void UserControlPanelSanPham_Load(object sender, EventArgs e)
        {

        }

        private void PicAnhSP_Click(object sender, EventArgs e)
        {

        }

        private void LblTenSP_Click(object sender, EventArgs e)
        {

        }

        private void Panel8_Paint(object sender, PaintEventArgs e)
        {

        }
        void TangGiamSoLuongSP(DTO_SanPham SP, int soluong)
        {
            SP.SLUONG = (int.Parse(SP.SLUONG) + soluong) + "";
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            bus.suaData(SP);
        }
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_SanPham[] sp = bus.search_SANPHAM(Ma);
            TangGiamSoLuongSP(sp[0], SoLuong);
            this.Dispose();
            UserControlThuNgan.ThanhTien -= DonGia;
            UserControlThuNgan.txtTemp.Text = "a";
            UserControlThuNgan.txtTemp.Text = "b";
        }
    }
}
