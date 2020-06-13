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
    public partial class FormDanhSachNCC : DevExpress.XtraEditors.XtraForm
    {
        public FormDanhSachNCC()
        {
            InitializeComponent();
        }

        private void FormDanhSachNCC_Load(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            this.dataGridView1.DataSource = bus.getDataTable("NHACUNGCAP");
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
    }
}