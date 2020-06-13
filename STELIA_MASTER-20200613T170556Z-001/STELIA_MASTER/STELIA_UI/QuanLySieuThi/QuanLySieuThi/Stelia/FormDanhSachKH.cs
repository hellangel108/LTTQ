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
            // TODO: This line of code loads data into the 'qLBHDataSet3.KHACHHANG' table. You can move, or remove it, as needed.
            this.kHACHHANGTableAdapter.Fill(this.qLBHDataSet3.KHACHHANG);

        }
    }
}