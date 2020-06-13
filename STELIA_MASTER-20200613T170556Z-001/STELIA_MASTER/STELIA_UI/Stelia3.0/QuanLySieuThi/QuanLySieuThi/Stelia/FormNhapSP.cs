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
using Stelia_BUS;
using Stelia_DTO;
using System.IO;

namespace Stelia
{
    public partial class FormNhapSP : DevExpress.XtraEditors.XtraForm
    {
        private string fileAnh = "";
        public FormNhapSP()
        {
            InitializeComponent();
        }

        private void FormNhapSP_Load(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_NhaCungCap[] NCC = bus.search_NhaCungCap("");
            for (int i = 0; i < NCC.Length; i++)
                cbxNCC.Items.Add(NCC[i].TENNCC);
            lblThanh.BackColor = Color.FromArgb(39, 174, 96);
        }

        private void PicThemMoi_Click(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_SanPham sp = new DTO_SanPham();
            sp.MASP = txtMaSP.Text;
            sp.TENSP = txtTenSP.Text;
            DTO_NhaCungCap[] ncc = bus.search_NhaCungCap(sp.TENSP);
            sp.MANCC = ncc[0].MANCC;
            sp.DONGIA = txtGiaBan.Text;
            sp.LOINHUAN = txtLoiNhuan.Text;
            sp.SLUONG = txtSoLuong.Text;
            sp.TRANGTHAI = txtTrangThai.Text;

            if (CheckThongTin.check_Nhap(sp) != "")
            {
                MessageBox.Show(CheckThongTin.check_Nhap(sp), "Sai", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (bus.themData(sp) == false)
            {
                MessageBox.Show("Có vấn đề xảy ra! Thất bại");
                return;
            }
            else MessageBox.Show("Bạn đã thêm sản phẩm thành công");
            string desAnh = Application.StartupPath + "/HinhSanPham/" + sp.MASP + ".jpg";
            if (File.Exists(desAnh))
                File.Delete(desAnh);
            File.Copy(fileAnh, desAnh); 
        }

        private void PicChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileAnh = dlg.FileName;
            }
            else return;
            picAnhSP.Image = Image.FromFile(fileAnh);
        }
    }
}