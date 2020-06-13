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
    public partial class UserControlNhapHang : UserControl
    {
        public UserControlNhapHang()
        {
            InitializeComponent();
        }

        private void DateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void Reset()
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            dataGridView1.DataSource = bus.getDataTable("PHIEUNHAP");
            foreach (DataGridViewTextBoxColumn col in this.dataGridView1.Columns)
            {
                switch (col.HeaderText)
                {
                    case "MAPN":
                        col.HeaderText = "Mã phiếu nhập";
                        break;
                    case "MANCC":
                        col.HeaderText = "Mã nhà cung cấp";
                        break;
                    case "NGNHAP":
                        col.HeaderText = "Ngày nhập";
                        break;
                    case "TONGSL":
                        col.HeaderText = "Tổng số lượng";
                        break;
                    case "TONGTIEN":
                        col.HeaderText = "Tổng giá trị";
                        break;
                    case "GHICHU":
                        col.HeaderText = "Ghi chú";
                        break;
                }
            }
        }
        private void UserControlNhapHang_Load(object sender, EventArgs e)
        {
            dataGridView1.Font = new Font("Time New Roman", 12, FontStyle.Regular);
            Reset();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
