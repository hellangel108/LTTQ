using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace Stelia
{
    public partial class UserControlHoaDon : UserControl
    {
        public UserControlHoaDon()
        {
            InitializeComponent();
        }

        void Init(string mahd, string makh, string manv, string nglap)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DataTable list = bus.searchHoaDon(mahd, makh, manv, nglap);
            gridHoaDon.DataSource = list;
            foreach (DataGridViewTextBoxColumn col in this.gridHoaDon.Columns)
            {
                switch (col.HeaderText)
                {
                    case "MAHD":
                        col.HeaderText = "Mã hoá đơn";
                        break;
                    case "MANV":
                        col.HeaderText = "Mã nhân viên";
                        break;
                    case "MAKH":
                        col.HeaderText = "Mã khách hàng";
                        break;
                    case "NGHD":
                        col.HeaderText = "Ngày tạo hoá đơn";
                        break;
                    case "GIAMGIA":
                        col.HeaderText = "Giảm giá";
                        break;
                    case "TONGTIENHANG":
                        col.HeaderText = "Tổng tiền hàng";
                        break;
                    case "THANHTIEN":
                        col.HeaderText = "Thành tiền";
                        break;
                }
            }
        }
        private void UserControlHoaDon_Load(object sender, EventArgs e)
        {
            lbl1.BackColor = Color.FromArgb(39, 174, 96);
            Init("","","","");
        }

        private void PicSearch_Click(object sender, EventArgs e)
        {
            if (dateNgHD.Text == "")
            {
                Init(txtMaHD.Text, txtMaKH.Text, txtMaNV.Text, "");
                return;
            }
            Init(txtMaHD.Text, txtMaKH.Text, txtMaNV.Text, DateChange.ToString(dateNgHD.DateTime));
        }

        private void pictureBoxDanhSach_Click(object sender, EventArgs e)
        {
            FormThuNganDSKH dskh = new FormThuNganDSKH();
            dskh.ShowDialog();
            txtMaKH.Text = dskh.MaKH;
        }

        private void picReset_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = "";
            txtMaKH.Text = "";
            txtMaNV.Text = "";
            dateNgHD.Text = "";
            Init(txtMaHD.Text, txtMaKH.Text, txtMaNV.Text, dateNgHD.Text);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DataGridViewRow currow = gridHoaDon.SelectedCells[0].OwningRow;
            Bill bill = new Bill();
            bill.DataSource = new Stelia_BUS.Stelia_BUS().InHoaDon(currow.Cells[0].Value.ToString());
            bill.ShowPreviewDialog();
        }

        private void gridHoaDon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridViewRow currow = gridHoaDon.SelectedCells[0].OwningRow;
            Bill bill = new Bill();
            bill.DataSource = new Stelia_BUS.Stelia_BUS().InHoaDon(currow.Cells[0].Value.ToString());
            bill.ShowPreviewDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DataGridViewRow currow = gridHoaDon.SelectedCells[0].OwningRow;
            FormChiTietHoaDon ct = new FormChiTietHoaDon(currow.Cells[0].Value.ToString());
            ct.ShowDialog();
        }
    }
}
