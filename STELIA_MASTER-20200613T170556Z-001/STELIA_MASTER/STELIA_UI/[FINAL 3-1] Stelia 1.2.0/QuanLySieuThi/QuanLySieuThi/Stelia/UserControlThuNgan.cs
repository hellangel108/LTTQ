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
            TongTienHang = 0;
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
            lbl4.BackColor = Green_Main;
            dateNgHD.DateTime = DateTime.Today;
            txtTimKiem.Text = "a";
            txtTimKiem.Text = "";
            lbl1.BackColor = Green_Main;
            DTO_NhanVien[] nv = new Stelia_BUS.Stelia_BUS().search_NhanVien(ThongTinDangNhap.Username);
            if(ThongTinDangNhap.Username=="admin")
            {
                lblNhanVien.Text = "admin";
                return;
            }
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
                txtSoLuong.Text = "1";
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

            FormWork.check = 1;
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
                lblTienThua.Text = "0";
                //MessageBox.Show("Vui lòng nhập đúng số (không bao gồm chữ cái và kí tự đặc biệt)");
            }
        }

        private void picTaoHoaDon_Click(object sender, EventArgs e)
        {
            if(flowGioHang.Controls.Count < 1)
            {
                PushNoti noti = new PushNoti("Warning", "Thêm hàng hoá vào giỏ hàng trước khi in hoá đơn!");
                noti.Width = this.Width;
                this.Controls.Add(noti);
                noti.Show();
                noti.ShowNoti();
                return;
            }
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            string mahd = "";
            if (bus.getDataTable("HOADON") == null)
            {
                mahd = "HD0000000001";
                return;
            }
            string str = bus.getThongTinHD(0, bus.getDataTable("HOADON").Rows.Count - 1);
            str = str.Remove(0, 2);
            int temp = str.Length;
            str = (Convert.ToInt32(str) + 1).ToString();
            while (str.Length < temp)
            {
                str = "0" + str;
            }
            mahd = "HD";
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
            if (txtMaKH.Text != "")
            {
                DTO_KhachHang[] kh = new Stelia_BUS.Stelia_BUS().search_KhachHang(txtMaKH.Text);
                kh[0].DIEMTL = (Convert.ToDouble(kh[0].DIEMTL) + Convert.ToDouble(ThanhTien / 100)).ToString();
                bus.suaData(kh[0]);
            }
            if (ThongTinDangNhap.Username == "admin")
            {
                ResetAfterPrint();
                return;
            }
            DTO_NhanVien[] nv = new Stelia_BUS.Stelia_BUS().search_NhanVien(ThongTinDangNhap.Username);
            nv[0].DOANHTHU = (Convert.ToDouble(nv[0].DOANHTHU) + Convert.ToDouble(ThanhTien)).ToString();
            nv[0].SLHD = (Convert.ToInt32(nv[0].SLHD) + 1).ToString();
            bus.suaData(nv[0]);
            ResetAfterPrint();
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            lblTienThua.Text = "0";
            txtTienKhach.Text = "0";
            try
            {
                ThanhTien = TongTienHang - long.Parse(txtGiamGia.Text);
            }
            catch (Exception ex)
            {
                txtGiamGia.Text = "0";
            }
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
                PushNoti noti = new PushNoti("Success", "Thêm khách hàng thành công!");
                noti.Width = this.Width;
                this.Controls.Add(noti);
                noti.Show();
                noti.ShowNoti();
                txtMaKH.Text = themkh.MaKH;
            }   
        }

        private void pictureBoxDanhSachSP_Click(object sender, EventArgs e)
        {
            FormThuNganDSSP sp = new FormThuNganDSSP();
            sp.ShowDialog();
            txtTimKiem.Text = sp.MaSP;
        }
        private void ResetAfterPrint()
        {
            DonGia = 0;
            SoLuong = 0;
            TongTienHang = 0;
            ThanhTien = 0;
            lblTienThua.Text = "0";
            txtTienKhach.Text = "0";
            txtGiamGia.Text = "0";
            flowGioHang.Controls.Clear();
            txtMaKH.Text = "";
            dateNgHD.DateTime = DateTime.Today;
            txtSoLuong.Text = "";
            txtTimKiem.Text = "";
            lblDonGia.Text = "";
            lblTongTienHang.Text = "";
            FormWork.check = 0;
        }

        private void flowGioHang_ControlRemoved(object sender, ControlEventArgs e)
        {
            int dem = 0;
            foreach (UserControlPanelSanPham sp in flowGioHang.Controls)
            {
                dem++;
            }
            if (dem == 0)
                FormWork.check = 0;
        }

        private void picReset_Click(object sender, EventArgs e)
        {
            foreach (UserControlPanelSanPham sp in flowGioHang.Controls)
            {
                sp.Xoa();
            }
            flowGioHang.Controls.Clear();
        }

        private void PicScan_Click(object sender, EventArgs e)
        {
            WebcamBarcodeDemo.Form1 frmScan = new WebcamBarcodeDemo.Form1();
            frmScan.ShowDialog();
            List<string> kq = frmScan.MaVach;
            if (kq.Count == 0) return;
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            for (int i=0; i<kq.Count; i++)
            {
                string ma = bus.QuetMa_SP(kq[i]);
                DTO_SanPham[] SP = bus.search_SANPHAM(ma);
                if (SP[0].MASP == ma)
                {
                    txtTimKiem.Text = ma;
                    txtSoLuong.Text = "1";
                    PicThemVaoGo_Click(sender, e);
                }
            }
            frmScan.Dispose();
        }
    }
}
