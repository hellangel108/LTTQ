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
    public partial class FormNhapPhieuTra : DevExpress.XtraEditors.XtraForm
    {
        public FormNhapPhieuTra()
        {
            InitializeComponent();
            dateNgNhap.DateTime = DateTime.Today;
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            if (bus.getDataTable("PHIEUTRA") == null)
            {
                txtMaPT.Text = "PT0001";
                return;
            }
            try
            {
                string str = bus.getThongTinPT(0, bus.getDataTable("PHIEUTRA").Rows.Count - 1);
                str = str.Remove(0, 2);
                int temp = str.Length;
                str = (Convert.ToInt32(str) + 1).ToString();
                while (str.Length < temp)
                {
                    str = "0" + str;
                }
                string mapn = "PT";
                mapn += str;
                txtMaPT.Text = mapn;
            }
            catch (Exception ex) { }
        }
        public void Reset_MaNCC()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                txtMaNCC.Enabled = false;
                pictureBoxDanhSach.Enabled = false;
            }
            else
            {
                txtMaNCC.Enabled = true;
                pictureBoxDanhSach.Enabled = true;
            }
        }
        private void picThemMoi_Click(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            if (bus.timkiem_NhaCungCap(txtMaNCC.Text).Rows.Count != 1)
            {
                PushNoti noti = new PushNoti("Error", "Vui lòng chọn mã NCC có trong cơ sở dữ liệu");
                noti.Width = this.Width;
                this.Controls.Add(noti);
                noti.Show();
                noti.ShowNoti();
                return;
            }
            FormNhapPhieuTra_ChonHang chon = new FormNhapPhieuTra_ChonHang(txtMaNCC.Text);
            chon.ShowDialog();
            DTO_SanPham[] sp = bus.search_SANPHAM(chon.MaSP);
            if(chon.DialogResult == DialogResult.OK)
            {
                this.dataGridView1.Rows.Add(chon.MaSP, sp[0].TENSP, chon.SL, chon.GiaTien);
            }
            Reset_MaNCC();
        }

        private void pictureBoxDanhSach_Click(object sender, EventArgs e)
        {
            FormNhapPhieuNhap_NCC ncc = new FormNhapPhieuNhap_NCC();
            ncc.ShowDialog();
            if (ncc.DialogResult == DialogResult.OK)
                txtMaNCC.Text = ncc.mancc;
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Không có chi tiết nào để xoá!");
                return;
            }
            DialogResult kq = MessageBox.Show("Bạn có chắc xóa sản phẩm đang chọn ra khỏi phiếu trả", "Hỏi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.No) return;
            DataGridViewRow currow = dataGridView1.SelectedCells[0].OwningRow;
            dataGridView1.Rows.Remove(currow);
            if(dataGridView1.Rows.Count == 0)
            {
                txtMaNCC.Enabled = true;
                pictureBoxDanhSach.Enabled = true;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            if(dataGridView1.Rows.Count == 0)
            {
                PushNoti noti1 = new PushNoti("Error", "Chưa có chi tiết phiếu trả!");
                noti1.Width = this.Width;
                this.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
            }
            DTO_PhieuTra PT = new DTO_PhieuTra(txtMaPT.Text, txtMaNCC.Text, DateChange.ToString(dateNgNhap.DateTime), "0", "0", richTextBox1.Text);
            string error = CheckThongTin.check_Nhap(PT);
            if (error != "")
            {
                PushNoti noti1 = new PushNoti("Error", error);
                noti1.Width = this.Width;
                this.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
                return;
            }
            if (bus.themData(PT) == false)
            {
                PushNoti noti1 = new PushNoti("Error", "Thêm phiếu trả không thành công!");
                noti1.Width = this.Width;
                this.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
                return;
            }
            int SL = 0;
            int GT = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DTO_CTPhieuTra ctpn = new DTO_CTPhieuTra(PT.MAPT, row.Cells[0].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString());
                SL += int.Parse(row.Cells[2].Value.ToString());
                GT += int.Parse(row.Cells[3].Value.ToString());
                DTO_SanPham[] sp = bus.search_SANPHAM(row.Cells[0].Value.ToString());
                sp[0].SLUONG = (int.Parse(sp[0].SLUONG) - int.Parse(row.Cells[2].Value.ToString())).ToString();
                bus.suaData(sp[0]);
                bus.themData(ctpn);
            }
            PT.TONGSL = SL.ToString();
            PT.TONGTIEN = GT.ToString();
            bus.suaData(PT);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc muốn làm mới phiếu trả?", "Hỏi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.No) return;
            dateNgNhap.DateTime = DateTime.Today;
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            if (bus.getDataTable("PHIEUTRA") == null)
            {
                txtMaPT.Text = "PT0001";
                return;
            }
            try
            {
                string str = bus.getThongTinPT(0, bus.getDataTable("PHIEUTRA").Rows.Count - 1);
                str = str.Remove(0, 2);
                int temp = str.Length;
                str = (Convert.ToInt32(str) + 1).ToString();
                while (str.Length < temp)
                {
                    str = "0" + str;
                }
                string mapn = "PT";
                mapn += str;
                txtMaPT.Text = mapn;
            }
            catch (Exception ex) { }
            txtMaNCC.Text = "";
            richTextBox1.Text = "";
            dataGridView1.Rows.Clear();
            txtMaNCC.Enabled = true;
            pictureBoxDanhSach.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}