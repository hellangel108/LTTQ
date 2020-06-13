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
    public partial class FormChiTietHoaDon : DevExpress.XtraEditors.XtraForm
    {
        string mahd;
        public FormChiTietHoaDon()
        {
            InitializeComponent();
        }
        public FormChiTietHoaDon(string Mahd)
        {
            InitializeComponent();
            this.mahd = Mahd;
        }

        private void FormChiTietHoaDon_Load(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DataTable temp = bus.InHoaDon(mahd);
            if (temp.Rows.Count == 0)
            {
                MessageBox.Show("Lỗi! Hoá đơn này không chứa bất kì sản phẩm nào!");
                lblKhachHang.Text = "";
                lblNhanVien.Text = "";
                return;
            }
            lblKhachHang.Text = temp.Rows[0].ItemArray[11].ToString();
            lblNhanVien.Text = temp.Rows[0].ItemArray[12].ToString();
            temp.Columns.Remove(temp.Columns[0]);
            temp.Columns.Remove(temp.Columns[0]);
            temp.Columns.Remove(temp.Columns[0]);
            temp.Columns.Remove(temp.Columns[0]);
            temp.Columns.Remove(temp.Columns[0]);
            temp.Columns.Remove(temp.Columns[0]);
            temp.Columns.Remove(temp.Columns[0]);
            temp.Columns.Remove(temp.Columns[4]);
            temp.Columns.Remove(temp.Columns[4]);
            gridHoaDon.DataSource = temp;
            label5.Text = mahd;
            foreach (DataGridViewTextBoxColumn col in this.gridHoaDon.Columns)
            {
                switch (col.HeaderText)
                {
                    case "TenSP":
                        col.HeaderText = "Tên sản phẩm";
                        break;
                    case "SOLUONG":
                        col.HeaderText = "Số lượng";
                        break;
                    case "GIATIEN":
                        col.HeaderText = "Giá tiền";
                        break;
                    case "TONGTIENHANG1":
                        col.HeaderText = "Tổng cộng";
                        break;
                    case "TENKH":
                        col.HeaderText = "Khách hàng";
                        break;
                    case "TENNV":
                        col.HeaderText = "Nhân viên";
                        break;
                }
            }
        }
    }
}