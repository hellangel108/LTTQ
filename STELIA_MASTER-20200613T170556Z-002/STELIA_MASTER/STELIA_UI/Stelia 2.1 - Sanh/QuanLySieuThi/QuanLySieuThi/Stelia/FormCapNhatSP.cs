﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stelia_BUS;
using Stelia_DTO;

namespace Stelia
{
    public partial class FormCapNhatSP : DevExpress.XtraEditors.XtraForm
    {
        private string MaNCC = "";
        public FormCapNhatSP(string MaSP)
        {
            InitializeComponent();
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_SanPham[] SP = bus.search_SANPHAM(MaSP);
            lblMaSP.Text = SP[0].MASP;
            txtTenSP.Text = SP[0].TENSP;
            lblNCC.Text = bus.getTenNCC(SP[0].MANCC);
            txtGiaBan.Text = TranDateFormat.SubString(SP[0].DONGIA);
            txtLoiNhuan.Text = TranDateFormat.SubString(SP[0].LOINHUAN);
            txtTrangThai.Text = SP[0].TRANGTHAI;
            txtSoLuong.Text = TranDateFormat.SubString(SP[0].SLUONG);
            string ma = lblMaSP.Text;
            if (System.IO.File.Exists(Application.StartupPath + "/HinhSanPham/" + ma + ".jpg"))
                picAnhSP.Image = Image.FromFile(Application.StartupPath + "/HinhSanPham/" + ma + ".jpg");
            else
                picAnhSP.Image = Image.FromFile(Application.StartupPath + "/HinhSanPham/" + ma + ".png");
            MaNCC = SP[0].MANCC;
        }

        private void FormCapNhatSP_Load(object sender, EventArgs e)
        {
            
        }

        private void CapNhat_Click(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_SanPham SP = new DTO_SanPham();
            SP.MASP = lblMaSP.Text;
            SP.TENSP = txtTenSP.Text;
            SP.DONGIA = txtGiaBan.Text;
            SP.SLUONG = txtSoLuong.Text;
            SP.MANCC = MaNCC;
            SP.LOINHUAN = txtLoiNhuan.Text;
            SP.TRANGTHAI = txtTrangThai.Text;
            if (bus.suaData(SP))
            {
                MessageBox.Show("Bạn đã cập nhật sản phẩm thành công");
                Close();
            }
            else MessageBox.Show("Có vấn đề xảy ra! Không thành công");
        }
    }
}