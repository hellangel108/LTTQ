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

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormDanhSachSP_NCC_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLBHDataSet.SANPHAM' table. You can move, or remove it, as needed.
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            grid.DataSource = bus.list_SanPham_NCC(MaNCC);
        }

        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}