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
        private string fileAnh;
        public string MaKH;
        public FormThemKhachHang()
        {
            InitializeComponent();
            MaKH = null;
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            if (bus.getDataTable("KHACHHANG").Rows.Count == 0)
            {
                txtMaKH.Text = "KH0001";
                return;
            }
            string str = bus.getThongTinKH(0, bus.getDataTable("KHACHHANG").Rows.Count - 1);
            str = str.Remove(0, 2);
            int temp = str.Length;
            str = (Convert.ToInt32(str) + 1).ToString();
            while (str.Length < temp)
            {
                str = "0" + str;
            }
            string makh = "KH";
            makh += str;
            txtMaKH.Text = makh;
        }

        
        private void FormThemKhachHang_Load(object sender, EventArgs e)
        {
            lbl1.BackColor = lbl2.BackColor = Color.FromArgb(39, 174, 96);
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            txtDiaChi.Text = txtDiemTL.Text = cbxGioiTinh.Text = txtHoTen.Text = cbxLoaiThe.Text = txtMaKH.Text = "";
            dateNgDK.Text = dateNgSinh.Text = "";
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_KhachHang KH = new DTO_KhachHang();
            KH.HOTEN = txtHoTen.Text;
            KH.MAKH = txtMaKH.Text;
            KH.GIOITINH = cbxGioiTinh.Text;
            KH.LOAIKH = cbxLoaiThe.Text;
            //KH.NGDK = TranDateFormat.Trans(dateNgDK.Text);
            //KH.NGSINH = TranDateFormat.Trans(dateNgSinh.Text);
            KH.NGDK = DateChange.ToString(dateNgDK.DateTime);
            KH.NGSINH = DateChange.ToString(dateNgSinh.DateTime);
            KH.DIACHI = txtDiaChi.Text;
            KH.DIEMTL = txtDiemTL.Text;

            if (bus.themData(KH) == false)
            {
                PushNoti noti = new PushNoti("Error", "Có lỗi xảy ra, thêm khách hàng không thành công!");
                noti.Width = 800;
                this.Controls.Add(noti);
                noti.Show();
                noti.ShowNoti();
                return;
            }
            MaKH = KH.MAKH;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileAnh = dlg.FileName;
            }
            else return;
            picAnh.Image = Image.FromFile(fileAnh);
        }
    }
}