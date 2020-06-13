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
    public partial class FormCapNhatKH : DevExpress.XtraEditors.XtraForm
    {
        static private string MaKH = "";
        string DTL = "0";
        public FormCapNhatKH(string st)
        {
            InitializeComponent();
            MaKH = st;
            StartPosition = FormStartPosition.CenterScreen;
            lbl1.BackColor = lbl2.BackColor = Color.FromArgb(39, 174, 96);
        }
        
        private void FormCapNhatKH_Load(object sender, EventArgs e)
        {
            txtMaKH.ReadOnly = true;
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_KhachHang[] KH =  bus.search_KhachHang(MaKH);
            txtHoTen.Text = KH[0].HOTEN;
            txtLoaiThe.Text = KH[0].LOAIKH;
            txtGioiTinh.Text = KH[0].GIOITINH;
            txtDiaChi.Text = KH[0].DIACHI;
            dateNgDK.Text = TranDateFormat.SubString(KH[0].NGDK);
            dateNgSinh.Text = TranDateFormat.SubString(KH[0].NGSINH);
            txtMaKH.Text = KH[0].MAKH;
            DTL = KH[0].DIEMTL;

            string ma = KH[0].MAKH;

            if (System.IO.File.Exists(Application.StartupPath + "/HinhKhachHang/" + ma + ".jpg"))
                picAnh.Image = Image.FromFile(Application.StartupPath + "/HinhKhachHang/" + ma + ".jpg");
            else
             if (System.IO.File.Exists(Application.StartupPath + "/HinhKhachHang/" + ma + ".png"))
                picAnh.Image = Image.FromFile(Application.StartupPath + "/HinhKhachHang/" + ma + ".png");
            else picAnh.Image = Image.FromFile(Application.StartupPath + "/HinhKhachHang/" + "None.jpg");
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_KhachHang KH = new DTO_KhachHang();
            KH.HOTEN = txtHoTen.Text;
            KH.GIOITINH = txtGioiTinh.Text;
            KH.LOAIKH = txtLoaiThe.Text;
            KH.NGSINH = DateChange.ToString(dateNgSinh.DateTime);
            KH.NGDK = DateChange.ToString(dateNgDK.DateTime);
            //KH.NGSINH = TranDateFormat.Trans(dateNgSinh.Text);
            //KH.NGDK = TranDateFormat.Trans(dateNgDK.Text);
            KH.MAKH = MaKH;
            KH.DIACHI = txtDiaChi.Text;
            KH.DIEMTL = DTL;

            if (bus.suaData(KH))
            {
                PushNoti noti = new PushNoti("Success", "Bạn đã cập nhật thành công");
                noti.Width = 800;
                this.Controls.Add(noti);
                noti.Show();
                noti.ShowNoti();
            }
            else
            {
                PushNoti noti = new PushNoti("Error", "Có lỗi xảy ra, cập nhật không thành công!");
                noti.Width = 800;
                this.Controls.Add(noti);
                noti.Show();
                noti.ShowNoti();
            }
        }
    }
}