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
    public partial class UserControlThuNgan : UserControl
    {
        private int DonGia = 0;
        private int SoLuong = 0;
        private string MaSP = "SP001";
        private Color Green_Main = Color.FromArgb(39, 174, 96);
        public static long ThanhTien = 0;
        public static TextBox txtTemp = new TextBox();

        public UserControlThuNgan()
        {
            InitializeComponent();
            txtTemp.TextChanged += TxtTemp_TextChanged;
            ThanhTien = 0;
            lblThanhTien.TextChanged += LblThanhTien_TextChanged;
            lblTienThua.TextChanged += LblTienThua_TextChanged;
        }

        private void LblTienThua_TextChanged(object sender, EventArgs e)
        {
            if (long.Parse(lblTienThua.Text) < 0) lblTienThua.Text = "Không đủ tiền";
        }

        private void LblThanhTien_TextChanged(object sender, EventArgs e)
        {
            lblTienThua.Text = "0";
            txtTienKhach.Text = "0";
        }

        private void TxtTemp_TextChanged(object sender, EventArgs e)
        {
            lblThanhTien.Text = ThanhTien + "";
            string st = txtTimKiem.Text;
            txtTimKiem.Text = "a";
            txtTimKiem.Text = st;
        }


        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_SanPham[] SP = bus.search_SANPHAM(txtTimKiem.Text);

            string ma = SP[0].MASP;
            if (System.IO.File.Exists(Application.StartupPath + "/HinhSanPham/" + ma + ".jpg"))
                picAnhSP.Image = Image.FromFile(Application.StartupPath + "/HinhSanPham/" + ma + ".jpg");
            else
                picAnhSP.Image = Image.FromFile(Application.StartupPath + "/HinhSanPham/" + ma + ".png");

            lblSoLuong.Text = "x" + SP[0].SLUONG;
            lblTenSP.Text = SP[0].TENSP;
           // MessageBox.Show(SP[0].DONGIA);
            DonGia = int.Parse(TranDateFormat.SubString(SP[0].DONGIA));
            SoLuong = int.Parse(TranDateFormat.SubString(SP[0].SLUONG));
            MaSP = SP[0].MASP;
            txtSoLuong.Text = "";
            lblDonGia.Text = "0";
        }

        private void UserControlThuNgan_Load(object sender, EventArgs e)
        {
            txtTimKiem.Text = "a";
            txtTimKiem.Text = "";
            lbl1.BackColor = Green_Main;
        }

        private void TxtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text == "" || txtSoLuong.Text == "-")
            {
                lblDonGia.Text = "0";
                return;
            }
            try
            {
                lblDonGia.Text = DonGia * long.Parse(txtSoLuong.Text) + "";
            } catch (Exception ex)
            {
                MessageBox.Show("Số lượng phải bắt đầu bằng số");
                lblSoLuong.Text = "1";
                return;
            }
            if (int.Parse(txtSoLuong.Text) <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ");
                txtSoLuong.Text = "1";
            }
            if (int.Parse(txtSoLuong.Text) > SoLuong)
            {
                MessageBox.Show("Số lượng chỉ tối đa là " + SoLuong + " sản phẩm");
                txtSoLuong.Text = SoLuong + "";
            }
        }

        void TangGiamSoLuongSP(DTO_SanPham SP, int soluong)
        {
            SP.SLUONG = (int.Parse(SP.SLUONG) + soluong) + "";
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            bus.suaData(SP);
        }

        private void PicThemVaoGo_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Bạn cần phải nhập số lượng");
                return;
            }
            UserControlPanelSanPham ussp = new UserControlPanelSanPham(MaSP, lblTenSP.Text, txtSoLuong.Text, long.Parse(lblDonGia.Text));
            flowGioHang.Controls.Add(ussp);
            ThanhTien += long.Parse(lblDonGia.Text);
            lblThanhTien.Text = ThanhTien.ToString();

            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_SanPham[] sp = bus.search_SANPHAM(MaSP);

            TangGiamSoLuongSP(sp[0], -int.Parse(txtSoLuong.Text));
            string st = txtTimKiem.Text;
            txtTimKiem.Text = "a";
            txtTimKiem.Text = st;
        }

        private void FlowGioHang_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtTienKhach_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblTienThua.Text = (long.Parse(txtTienKhach.Text) - long.Parse(lblThanhTien.Text)) + "";
            }
            catch (Exception ex1)
            {
                //MessageBox.Show("Nhập sai số tiền khách");
            }
        }

        private void LblThanhTien_Click(object sender, EventArgs e)
        {

        }
    }
}
