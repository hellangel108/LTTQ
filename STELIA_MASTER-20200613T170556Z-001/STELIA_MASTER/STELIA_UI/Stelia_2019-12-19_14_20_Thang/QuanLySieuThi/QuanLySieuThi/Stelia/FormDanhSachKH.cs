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
        }
    }
}