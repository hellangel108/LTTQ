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
    public partial class UserControlHangHoa : UserControl
    {
        public UserControlHangHoa()
        {
            InitializeComponent();
        }

        private void UserControlHangHoa_Load(object sender, EventArgs e)
        {
            //navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinNavigationPaneViewInfoRegistrator("Blueprint");
            pnlTimKiem.BackColor = Color.FromArgb(39, 174, 96);
        }

        private void NavBarControl2_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
