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
    public partial class FormChiTietDiemDanh : DevExpress.XtraEditors.XtraForm
    {
        public FormChiTietDiemDanh()
        {
            InitializeComponent();
        }
        public void Load_Grid()
        {
            string date = "";
            try
            {
                date = DateChange.ToString(dateNgDD.DateTime);
            }
            catch (Exception ex)
            {
                dateNgDD.DateTime = DateTime.Today;
                date = DateChange.ToString(dateNgDD.DateTime);
            }
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            gridDiemDanh.DataSource = bus.timKiemNhanhDiemDanh(date);
            foreach (DataGridViewTextBoxColumn col in this.gridDiemDanh.Columns)
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

        private void FormChiTietDiemDanh_Load(object sender, EventArgs e)
        {
            dateNgDD.DateTime = DateTime.Today;
            Load_Grid();
        }

        private void dateNgDD_EditValueChanged(object sender, EventArgs e)
        {
            Load_Grid();
        }
    }
}