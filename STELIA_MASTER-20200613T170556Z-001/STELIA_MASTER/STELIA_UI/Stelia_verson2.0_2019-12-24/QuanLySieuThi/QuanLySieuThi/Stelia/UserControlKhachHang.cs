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
    public partial class UserControlKhachHang : UserControl
    {
        PushNoti noti = new PushNoti();
        public UserControlKhachHang()
        {
            InitializeComponent();
            dataGridView1.DataSource = new Stelia_BUS.Stelia_BUS().timKiemNhanh_KhachHang(txtTimKiem.Text);
            foreach (DataGridViewTextBoxColumn col in this.dataGridView1.Columns)
            {
                switch (col.HeaderText)
                {
                    case "MANV":
                        col.HeaderText = "Mã nhân viên";
                        break;
                    case "HOTEN":
                        col.HeaderText = "Họ tên";
                        break;
                    case "NGSINH":
                        col.HeaderText = "Ngày sinh";
                        break;
                    case "DIACHI":
                        col.HeaderText = "Địa chỉ";
                        break;
                    case "NGDK":
                        col.HeaderText = "Ngày đăng kí";
                        break;
                    case "GIOITINH":
                        col.HeaderText = "Giới tính";
                        break;
                    case "LOAIKH":
                        col.HeaderText = "Loại khách hàng";
                        break;
                    case "DIEMTL":
                        col.HeaderText = "Điểm tích luỹ";
                        break;
                }
            }
        }
        private void ShowSelectedRow()
        {
            try
            {
                DataGridViewRow currow = dataGridView1.SelectedCells[0].OwningRow;
                Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
                DTO_KhachHang[] KH = bus.search_KhachHang(currow.Cells[0].Value.ToString());
                lblHoTen.Text = KH[0].HOTEN;
                lblDiaChi.Text = KH[0].DIACHI;
                lblDiemTL.Text = TranDateFormat.SubString(KH[0].DIEMTL);
                lblGioiTinh.Text = KH[0].GIOITINH;
                lblLoaiThe.Text = KH[0].LOAIKH;
                lblNgDK.Text = TranDateFormat.SubString(KH[0].NGDK);
                lblNgSinh.Text = TranDateFormat.SubString(KH[0].NGSINH);
                lblMaKH.Text = KH[0].MAKH;
                noti.Hide();
            }
            catch(Exception e)
            {
                lblHoTen.Text = "";
                lblDiaChi.Text = "";
                lblDiemTL.Text = "";
                lblGioiTinh.Text = "";
                lblLoaiThe.Text = "";
                lblNgDK.Text = "";
                lblNgSinh.Text = "";
                lblMaKH.Text = "";
                noti = new PushNoti("Error", "Không tìm thấy tên này");
                noti.Width = this.Width;
                this.Controls.Add(noti);
                noti.Show();
                noti.ShowNoti();
            }
        }

        void XuatThongTinTop10()
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            string[] name = bus.Top15_KhachHang();
            lblKH1.Text = name[0];
            lblKH2.Text = name[1];
            lblKH3.Text = name[2];
            lblKH4.Text = name[3];
            lblKH5.Text = name[4];
            lblKH6.Text = name[5];
            lblKH7.Text = name[6];
            lblKH8.Text = name[7];
            lblKH9.Text = name[8];
        }

        private void UserControlKhachHang_Load(object sender, EventArgs e)
        {
            ShowSelectedRow();
            XuatThongTinTop10();
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox16_Click(object sender, EventArgs e)
        {
            FormThemKhachHang frmThem = new FormThemKhachHang();
            frmThem.ShowDialog();
            ShowSelectedRow();
        }

        private void PictureBox13_Click(object sender, EventArgs e)
        {
            if (lblMaKH.Text == "")
            {
                PushNoti noti1 = new PushNoti("Error", "Chọn một khách hàng để sửa!");
                noti1.Width = this.Width;
                this.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
                return;
            }
            FormCapNhatKH frmCapNhat = new FormCapNhatKH(lblMaKH.Text);
            frmCapNhat.ShowDialog();
            ShowSelectedRow();
        }

        private void PictureBox14_Click(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DialogResult res = MessageBox.Show("Bạn có chắc xóa khách hàng " + lblHoTen.Text + " ra khỏi cửa hàng không",
                "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;
            if (bus.xoaKhachHang(lblMaKH.Text))
                MessageBox.Show("Bạn đã xóa " + lblHoTen.Text + " thành công");
            else MessageBox.Show("Có vấn đề xảy ra! Không thành công");
            ShowSelectedRow();
        }

        private void PictureBox17_Click(object sender, EventArgs e)
        {
            FormDanhSachKH frmDS = new FormDanhSachKH();
            frmDS.ShowDialog();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new Stelia_BUS.Stelia_BUS().timKiemNhanh_KhachHang(txtTimKiem.Text);
            ShowSelectedRow();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            ShowSelectedRow();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            ShowSelectedRow();
        }
    }
}
