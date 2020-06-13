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
    public partial class UserControlNhanVien : UserControl
    {
        PushNoti noti = new PushNoti();
        public UserControlNhanVien()
        {
            InitializeComponent();
            dataGridView1.DataSource = new Stelia_BUS.Stelia_BUS().timKiemNhanh_NhanVien(txtTimKiem.Text);
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
                    case "CHUCVU":
                        col.HeaderText = "Chức vụ";
                        break;
                    case "NGAYVL":
                        col.HeaderText = "Ngày vào làm";
                        break;
                    case "GIOITINH":
                        col.HeaderText = "Giới tính";
                        break;
                    case "LUONG":
                        col.HeaderText = "Lương";
                        break;
                    case "SLHD":
                        col.HeaderText = "Số lượng hoá đơn";
                        break;
                    case "DOANHTHU":
                        col.HeaderText = "Doanh thu";
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
                DTO_NhanVien[] NV = bus.search_NhanVien(currow.Cells[0].Value.ToString());
                lblHoTen.Text = NV[0].HOTEN;
                lblChucVu.Text = NV[0].CHUCVU;
                lblDoanhThu.Text = TranDateFormat.SubString(NV[0].DOANHTHU);
                lblGioiTinh.Text = NV[0].GIOITINH;
                lblNgSinh.Text = TranDateFormat.SubString(NV[0].NGSINH);
                lblNgVaoLam.Text = TranDateFormat.SubString(NV[0].NGAYVL);
                lblSoHD.Text = TranDateFormat.SubString(NV[0].SLHD);
                lblMaNV.Text = NV[0].MANV;
                lblLuong.Text = TranDateFormat.SubString(NV[0].LUONG);
                noti.Hide();
            }
            catch (Exception e)
            {
                lblHoTen.Text = "";
                lblChucVu.Text = "";
                lblDoanhThu.Text = "";
                lblGioiTinh.Text = "";
                lblNgSinh.Text = "";
                lblNgVaoLam.Text = "";
                lblSoHD.Text = "";
                lblMaNV.Text = "";
                lblLuong.Text = "";
                noti = new PushNoti("Error", "Không tìm thấy tên này");
                noti.Width = this.Width;
                this.Controls.Add(noti);
                noti.Show();
                noti.ShowNoti();
            }
            finally
            {
                DataGridViewRow currow = dataGridView1.SelectedCells[0].OwningRow;
                Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
                DTO_NhanVien[] NV = bus.search_NhanVien(currow.Cells[0].Value.ToString());
                string ma = NV[0].MANV;

                if (System.IO.File.Exists(Application.StartupPath + "/HinhNhanVien/" + ma + ".jpg"))
                    picAnh.Image = Image.FromFile(Application.StartupPath + "/HinhNhanVien/" + ma + ".jpg");
                else
                 if (System.IO.File.Exists(Application.StartupPath + "/HinhNhanVien/" + ma + ".png"))
                    picAnh.Image = Image.FromFile(Application.StartupPath + "/HinhNhanVien/" + ma + ".png");
                else picAnh.Image = Image.FromFile(Application.StartupPath + "/HinhNhanVien/" + "None.jpg");
            }
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox16_Click(object sender, EventArgs e)
        {
            FormNhapNhanVien frmNhapNV = new FormNhapNhanVien();
            frmNhapNV.ShowDialog();
            Reset();
        }

        private void Label10_Click(object sender, EventArgs e)
        {
        }
        void KhoiTaoTop3()
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            string[] name = bus.Top3_NhanVieN();
            lblTop1.Text = TranDateFormat.GetLastName(name[0]);
            lblTop2.Text = TranDateFormat.GetLastName(name[1]);
            lblTop3.Text = TranDateFormat.GetLastName(name[2]);
        }
        void Reset()
        {
            lblTop1.BackColor = Color.FromArgb(243, 208, 55);
            lblTop2.BackColor = Color.FromArgb(213, 90, 48);
            lblTop3.BackColor = Color.FromArgb(22, 175, 84);

            string st = txtTimKiem.Text;
            txtTimKiem.Text = " ";
            txtTimKiem.Text = st;
            ShowSelectedRow();
        }
        private void UserControlNhanVien_Load(object sender, EventArgs e)
        {
            lbl1.BackColor = lbl2.BackColor = lbl3.BackColor = Color.FromArgb(39, 174, 96);
            Reset();
            KhoiTaoTop3();
            KhoiTaoChart();
        }

        private void KhoiTaoChart()
        {
            DataTable temp = new Stelia_BUS.Stelia_BUS().getDataTable("NHANVIEN");
            DataColumn col = new DataColumn("LastName");
            col.DataType = System.Type.GetType("System.String");
            temp.Columns.Add(col);
            foreach (DataRow row in temp.Rows)
            {
                row["LastName"] = TranDateFormat.GetLastName(row[1].ToString());
            }
            chartControl1.DataSource = temp;
        }

        private void PictureBox13_Click(object sender, EventArgs e)
        {
            if (lblMaNV.Text == "")
            {
                PushNoti noti1 = new PushNoti("Error", "Chọn một nhân viên để sửa!");
                noti1.Width = this.Width;
                this.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
                return;
            }
            FormCapNhatNhanVien frmCapNhat = new FormCapNhatNhanVien(lblMaNV.Text);
            frmCapNhat.ShowDialog();
            Reset();
        }

        private void PictureBox14_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc xóa nhân viên " + lblHoTen.Text + " ra khỏi cửa hàng", "Hỏi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.No) return;
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            //MessageBox.Show(lblMaNV.Text);
            if (bus.xoaNhanVien(lblMaNV.Text) == false)
                MessageBox.Show("Việc xóa xảy ra một số vấn đề! Không thành công");
            else MessageBox.Show("Đã xóa nhân viên" + lblHoTen.Text + "ra khỏi cửa hàng");
            Reset();
        }

        private void PictureBox17_Click(object sender, EventArgs e)
        {
            FormDanhSachNV frmDS = new FormDanhSachNV();
            frmDS.ShowDialog();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new Stelia_BUS.Stelia_BUS().timKiemNhanh_NhanVien(txtTimKiem.Text);
            ShowSelectedRow();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            ShowSelectedRow();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowSelectedRow();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            ShowSelectedRow();
        }

        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
