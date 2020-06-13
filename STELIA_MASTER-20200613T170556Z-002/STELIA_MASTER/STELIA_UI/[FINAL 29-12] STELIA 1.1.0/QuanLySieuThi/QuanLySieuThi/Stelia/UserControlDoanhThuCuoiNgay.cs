using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stelia
{
    public partial class UserControlDoanhThuCuoiNgay : UserControl
    {
        public UserControlDoanhThuCuoiNgay()
        {
            InitializeComponent();
            dateNgHD.DateTime = DateTime.Today;
        }
        void Init(string mahd, string makh, string manv, string nglap)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DataTable list = bus.searchHoaDon(mahd, makh, manv, nglap);
            list.Columns.Remove(list.Columns[3]);
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
        private void Init_Today_Panel()
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            label3.Text = bus.doanhThuTheoNgay(DateChange.ToString(dateNgHD.DateTime)) + " VND";
            label4.Text = bus.soLuongTheoNgay(DateChange.ToString(dateNgHD.DateTime));
        }
        private void Init_Chart()
        {
            chartControl1.DataSource = new Stelia_BUS.Stelia_BUS().top5_maSP_BanChayTheoDoanhThu(DateChange.ToString(dateNgHD.DateTime));
        }

        private void UserControlDoanhThuCuoiNgay_Load(object sender, EventArgs e)
        {
            dateNgHD.DateTime = DateTime.Today;
            Init_Today_Panel();
            Init("", "", "", DateChange.ToString(dateNgHD.DateTime));
            Init_Chart();
        }

        private void dateNgHD_EditValueChanged(object sender, EventArgs e)
        {
            Init_Today_Panel();
            Init("", "", "", DateChange.ToString(dateNgHD.DateTime));
            Init_Chart();
        }
    }
}
