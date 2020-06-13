using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stelia_DTO;

namespace Stelia
{
    public partial class FormNhapPhieuTra_TraHang : DevExpress.XtraEditors.XtraForm
    {
        public string SOLUONG = "", THANHTIEN = "";

        private void picThemVaoGo_Click(object sender, EventArgs e)
        {
            try
            {
                int.Parse(txtSoLuong.Text);
            }
            catch
            {
                MessageBox.Show("Số lượng phải nhập bằng số");
                txtSoLuong.Text = "1";
                return;
            }
            if (int.Parse(txtSoLuong.Text) <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ");
                txtSoLuong.Text = "1";
                return;
            }
            try
            {
                int.Parse(txtGiaTri.Text);
            }
            catch
            {
                MessageBox.Show("Tiền hàng phải nhập bằng số");
                txtGiaTri.Text = "1";
                return;
            }
            if (int.Parse(txtSoLuong.Text) <= 0)
            {
                MessageBox.Show("Số tiền không hợp lệ");
                txtGiaTri.Text = "1";
                return;
            }
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_SanPham[] sp = bus.search_SANPHAM(lblTenSP.Text);
            int SoLuong = int.Parse(sp[0].SLUONG);
            if (int.Parse(txtSoLuong.Text) > SoLuong)
            {
                MessageBox.Show("Số lượng chỉ tối đa là " + SoLuong + " sản phẩm");
                txtSoLuong.Text = SoLuong + "";
                return;
            }
            SOLUONG = txtSoLuong.Text;
            THANHTIEN = txtGiaTri.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        public FormNhapPhieuTra_TraHang(string masp)
        {
            InitializeComponent();
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_SanPham[] SP = bus.search_SANPHAM(masp);
            string ma = SP[0].MASP;
            if (System.IO.File.Exists(Application.StartupPath + "/HinhSanPham/" + ma + ".jpg"))
                picAnhSP.Image = Image.FromFile(Application.StartupPath + "/HinhSanPham/" + ma + ".jpg");
            else
                picAnhSP.Image = Image.FromFile(Application.StartupPath + "/HinhSanPham/" + ma + ".png");
            lblTenSP.Text = SP[0].TENSP;
        }
    }
}