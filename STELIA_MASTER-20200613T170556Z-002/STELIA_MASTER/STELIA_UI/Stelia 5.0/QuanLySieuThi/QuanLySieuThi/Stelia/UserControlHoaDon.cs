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
    public partial class UserControlHoaDon : UserControl
    {
        public UserControlHoaDon()
        {
            InitializeComponent();
        }

        void Init(string mahd, string makh, string manv, string nglap)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DataTable list = bus.searchHoaDon(mahd, makh, manv, nglap);
            gridHoaDon.DataSource = list;

        }
        private void UserControlHoaDon_Load(object sender, EventArgs e)
        {
            lbl1.BackColor = Color.FromArgb(39, 174, 96);
            Init("","","","");
        }

        private void PicSearch_Click(object sender, EventArgs e)
        {
            Init(txtMaHD.Text, txtMaKH.Text, txtMaNV.Text, dateNgHD.Text);
        }
    }
}
