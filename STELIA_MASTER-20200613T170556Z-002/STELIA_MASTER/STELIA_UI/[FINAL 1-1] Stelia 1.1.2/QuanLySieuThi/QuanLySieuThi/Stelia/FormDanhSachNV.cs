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
using System.ComponentModel.DataAnnotations;
using System.IO;
using DevExpress.XtraLayout.Helpers;
using DevExpress.XtraLayout;

namespace Stelia
{
    public partial class FormDanhSachNV : DevExpress.XtraEditors.XtraForm
    {
        public FormDanhSachNV()
        {
            InitializeComponent();
        }
        private void FormDanhSachNV_Load(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            this.dataGridView1.DataSource = bus.getDataTable("NHANVIEN");
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
    }
}