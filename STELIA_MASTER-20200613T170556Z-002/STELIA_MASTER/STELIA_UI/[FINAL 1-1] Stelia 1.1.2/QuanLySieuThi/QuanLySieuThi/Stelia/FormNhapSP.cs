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
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            if (bus.getDataTable("SANPHAM") == null)
            {
                txtMaSP.Text = "SP001";
                return;
            }
            try
            {
                string str = bus.getThongTinSP(0, bus.getDataTable("SANPHAM").Rows.Count - 1);
                str = str.Remove(0, 2);
                int temp = str.Length;
                str = (Convert.ToInt32(str) + 1).ToString();
                while (str.Length < temp)
                {
                    str = "0" + str;
                }
                string masp = "SP";
                masp += str;
                txtMaSP.Text = masp;
            }
            catch (Exception ex) { }
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

            string error = CheckThongTin.check_Nhap(sp);
            if (error != "")
            {
                PushNoti noti1 = new PushNoti("Error", error);
                noti1.Width = this.Width;
                this.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
                return;
            }

            if (bus.themData(sp) == false)
            {
                PushNoti noti1 = new PushNoti("Error", "Có lỗi xảy ra, thêm không thành công!");
                noti1.Width = this.Width;
                noti1.Height = 30;
                this.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
                //MessageBox.Show("Bạn đã cập nhật thành công");
                return;
            }
            else
            {
            }
            string desAnh = Application.StartupPath + "/HinhSanPham/" + sp.MASP + ".jpg";
            if (fileAnh != "")
            {
                if (File.Exists(desAnh))
                    File.Delete(desAnh);
                File.Copy(fileAnh, desAnh);
            }
            DialogResult = DialogResult.OK;
            Close();
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