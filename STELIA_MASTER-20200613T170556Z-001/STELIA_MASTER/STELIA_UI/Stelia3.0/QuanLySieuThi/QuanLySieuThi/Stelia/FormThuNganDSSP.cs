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
    public partial class FormThuNganDSSP : DevExpress.XtraEditors.XtraForm
    {
        public string MaSP;
        public FormThuNganDSSP()
        {
            InitializeComponent();
            Reset();
        }
        void Reset()
        {
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

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new Stelia_BUS.Stelia_BUS().timKiemNhanh_KhachHang(txtTimKiem.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow currow = dataGridView1.SelectedCells[0].OwningRow;
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_KhachHang[] KH = bus.search_KhachHang(currow.Cells[0].Value.ToString());
            MaSP = KH[0].MAKH;
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
            DTO_KhachHang[] KH = bus.search_KhachHang(currow.Cells[0].Value.ToString());
            MaSP = KH[0].MAKH;
            Close();
        }
    }
}