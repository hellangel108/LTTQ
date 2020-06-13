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

namespace Stelia
{
    public partial class FormThemKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public FormThemKhachHang()
        {
            InitializeComponent();
        }

        
        private void FormThemKhachHang_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            txtDiaChi.Text = txtDiemTL.Text = txtGioiTinh.Text = txtHoTen.Text = txtLoaiThe.Text = txtMaKH.Text = "";
            dateNgDK.Text = dateNgSinh.Text = "";
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_KhachHang KH = new DTO_KhachHang();
            KH.HOTEN = txtHoTen.Text;
            KH.MAKH = txtMaKH.Text;
            KH.GIOITINH = txtGioiTinh.Text;
            KH.LOAIKH = txtLoaiThe.Text;
            //KH.NGDK = TranDateFormat.Trans(dateNgDK.Text);
            //KH.NGSINH = TranDateFormat.Trans(dateNgSinh.Text);
            KH.NGDK = DateChange.ToString(dateNgDK.DateTime);
            KH.NGSINH = DateChange.ToString(dateNgSinh.DateTime);
            KH.DIACHI = txtDiaChi.Text;
            KH.DIEMTL = txtDiemTL.Text;

            if (bus.themData(KH) == false)
            {
                MessageBox.Show("Có lỗi xảy ra! Mời bạn xem lại");
                return;
            }
            MessageBox.Show("Đã thêm thành công!");
            Close();
        }
    }
}