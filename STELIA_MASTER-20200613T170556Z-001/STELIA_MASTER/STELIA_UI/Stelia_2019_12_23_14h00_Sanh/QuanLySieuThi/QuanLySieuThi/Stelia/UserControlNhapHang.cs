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

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserControlNhapHang_Load(object sender, EventArgs e)
        {
            dataGridView1.Font = new Font("Time New Roman", 12, FontStyle.Regular);
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
