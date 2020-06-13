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
            // TODO: This line of code loads data into the 'qLBHDataSet1.NHACUNGCAP' table. You can move, or remove it, as needed.
            this.nHACUNGCAPTableAdapter.Fill(this.qLBHDataSet1.NHACUNGCAP);

        }
    }
}