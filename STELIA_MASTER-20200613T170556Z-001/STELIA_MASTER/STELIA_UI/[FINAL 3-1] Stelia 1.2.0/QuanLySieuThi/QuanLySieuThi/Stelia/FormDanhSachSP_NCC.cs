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
    public partial class FormDanhSachSP_NCC : DevExpress.XtraEditors.XtraForm
    {
        private string MaNCC = "";
        public FormDanhSachSP_NCC(string ma)
        {
            InitializeComponent();
            MaNCC = ma;
        }

        private void FormDanhSachSP_NCC_Load(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            grid.DataSource = bus.list_SanPham_NCC(MaNCC);
            foreach (DataGridViewTextBoxColumn col in this.grid.Columns)
            {
                switch (col.HeaderText)
                {
                    case "MASP":
                        col.HeaderText = "Mã sản phẩm";
                        break;
                    case "TENSP":
                        col.HeaderText = "Tên sản phẩm";
                        break;
                    case "MANCC":
                        col.HeaderText = "Nhà cung cấp";
                        break;
                    case "DONGIA":
                        col.HeaderText = "Đơn giá";
                        break;
                    case "LOINHUAN":
                        col.HeaderText = "Lợi nhuận";
                        break;
                    case "SLUONG":
                        col.HeaderText = "Số lượng";
                        break;
                    case "TRANGTHAI":
                        col.HeaderText = "Trạng thái";
                        break;
                }
            }
        }
    }
}