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
    public partial class FormNhapPhieuNhap_NCC : DevExpress.XtraEditors.XtraForm
    {
        public string mancc;
        public FormNhapPhieuNhap_NCC()
        {
            InitializeComponent();
            Reset();
        }
        void Reset()
        {
            dataGridView1.DataSource = new Stelia_BUS.Stelia_BUS().timkiem_NhaCungCap(txtTimKiem.Text);
            foreach (DataGridViewTextBoxColumn col in this.dataGridView1.Columns)
            {
                switch (col.HeaderText)
                {
                    case "MANCC":
                        col.HeaderText = "Mã nhà cung cấp";
                        break;
                    case "TENNCC":
                        col.HeaderText = "Tên nhà cung cấp";
                        break;
                    case "NGHT":
                        col.HeaderText = "Ngày hợp tác";
                        break;
                    case "DIACHI":
                        col.HeaderText = "Địa chỉ";
                        break;
                    case "SDT":
                        col.HeaderText = "Số điện thoại";
                        break;
                    case "MUCDOCC":
                        col.HeaderText = "Mức độ";
                        break;
                    case "TRANGTHAI":
                        col.HeaderText = "Trạng thái";
                        break;
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new Stelia_BUS.Stelia_BUS().timKiemNhanh_KhachHang(txtTimKiem.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow currow = dataGridView1.SelectedCells[0].OwningRow;
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_NhaCungCap[] NCC = bus.search_NhaCungCap(currow.Cells[0].Value.ToString());
            mancc = NCC[0].MANCC;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridViewRow currow = dataGridView1.SelectedCells[0].OwningRow;
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_NhaCungCap[] NCC = bus.search_NhaCungCap(currow.Cells[0].Value.ToString());
            mancc = NCC[0].MANCC;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
