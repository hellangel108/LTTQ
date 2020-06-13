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
    public partial class UserControlNhaCungCap : UserControl
    {
        public UserControlNhaCungCap()
        {
            InitializeComponent();
        }

        private void UserControlNhaCungCap_Load(object sender, EventArgs e)
        {
            lbl1.BackColor = lbl2.BackColor = lbl3.BackColor = lbl5.BackColor = Color.FromArgb(39, 174, 96);
            lblTop1.BackColor = Color.FromArgb(243,208,55);
            lblTop2.BackColor = Color.FromArgb(213,90,48);
            lblTop3.BackColor = Color.FromArgb(22,175,84); 
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
