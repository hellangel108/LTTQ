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

namespace Stelia
{
    public partial class FormDanhSachKH : DevExpress.XtraEditors.XtraForm
    {
        public FormDanhSachKH()
        {
            InitializeComponent();
        }

        private void FormDanhSachKH_Load(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            this.dataGridView1.DataSource = bus.getDataTable("KHACHHANG");
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
    }
}