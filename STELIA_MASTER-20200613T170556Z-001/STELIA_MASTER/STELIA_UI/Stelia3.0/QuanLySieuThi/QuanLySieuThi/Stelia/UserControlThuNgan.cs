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
using DevExpress.XtraReports.UI;

namespace Stelia
{
    public partial class UserControlThuNgan : UserControl
    {
        private int DonGia = 0;
        private int SoLuong = 0;
        private string MaSP = "SP001";
        private Color Green_Main = Color.FromArgb(39, 174, 96);
        public static long TongTienHang = 0;
        public static long ThanhTien = 0;
        public static TextBox txtTemp = new TextBox();

        public UserControlThuNgan()
        {
            InitializeComponent();
            txtTemp.TextChanged += TxtTemp_TextChanged;
            ThanhTien = 0;
            lblTongTienHang.TextChanged += lblTongTienHang_TextChanged;
            lblTienThua.TextChanged += LblTienThua_TextChanged;
        }

        private void LblTienThua_TextChanged(object sender, EventArgs e)
        {
            if (long.Parse(lblTienThua.Text) < 0) lblTienThua.Text = "Không đủ tiền";
        }

        private void lblTongTienHang_TextChanged(object sender, EventArgs e)
        {
            lblTienThua.Text = "0";
            txtTienKhach.Text = "0";
            ThanhTien = TongTienHang - long.Parse(txtGiamGia.Text);
            lblThanhTien.Text = ThanhTien.ToString();
        }

        private void TxtTemp_TextChanged(object sender, EventArgs e)
        {
            lblTongTienHang.Text = TongTienHang + "";
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
            dateNgHD.DateTime = DateTime.Today;
            txtTimKiem.Text = "a";
            txtTimKiem.Text = "";
            lbl1.BackColor = Green_Main;
            DTO_NhanVien[] nv = new Stelia_BUS.Stelia_BUS().search_NhanVien(ThongTinDangNhap.Username);
            lblNhanVien.Text = nv[0].HOTEN;
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
            TongTienHang += long.Parse(lblDonGia.Text);
            lblTongTienHang.Text = TongTienHang.ToString();

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
                //MessageBox.Show("Vui lòng nhập đúng số (không bao gồm chữ cái và kí tự đặc biệt)");
            }
        }

        private void picTaoHoaDon_Click(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            string str = bus.getThongTinHD(0, bus.getDataTable("HOADON").Rows.Count - 1);
            str = str.Remove(0, 2);
            str = (Convert.ToInt32(str) + 1).ToString();
            string mahd = "HD0000000000";
            mahd = mahd.Remove(mahd.Length - str.Length);
            mahd += str;
            DTO_HoaDon hd = new DTO_HoaDon(mahd, ThongTinDangNhap.Username, txtMaKH.Text, DateChange.ToString(dateNgHD.DateTime), lblTongTienHang.Text, txtGiamGia.Text, lblThanhTien.Text);
            bus.themData(hd);
            foreach(UserControlPanelSanPham sp in flowGioHang.Controls)
            {
                sp.ThemData(mahd);
            }
            Bill bill = new Bill();
            bill.DataSource = new Stelia_BUS.Stelia_BUS().InHoaDon(mahd);
            bill.ShowPreviewDialog();
            bill.PrintDialog();
            if (ThongTinDangNhap.Username == "admin")
                return;
            DTO_NhanVien[] nv = new Stelia_BUS.Stelia_BUS().search_NhanVien(ThongTinDangNhap.Username);
            nv[0].DOANHTHU += ThanhTien;
            nv[0].SLHD += 1;
            bus.suaData(nv[0]);
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            lblTienThua.Text = "0";
            txtTienKhach.Text = "0";
            ThanhTien = TongTienHang - long.Parse(txtGiamGia.Text);
            lblThanhTien.Text = ThanhTien.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormThuNganDSKH dskh = new FormThuNganDSKH();
            dskh.ShowDialog();
            txtMaKH.Text = dskh.MaKH;
        }

        private void pictureBoxThemKH_Click(object sender, EventArgs e)
        {
            FormThemKhachHang themkh = new FormThemKhachHang();
            themkh.ShowDialog();
            if(themkh.DialogResult == DialogResult.OK)
            {
                PushNoti noti = new PushNoti("Succes", "Thêm khách hàng thành công!");
                noti.Width = this.Width;
                this.Controls.Add(noti);
                noti.Show();
                noti.ShowNoti();
                txtMaKH.Text = themkh.MaKH;
            }   
        }
    }
}
