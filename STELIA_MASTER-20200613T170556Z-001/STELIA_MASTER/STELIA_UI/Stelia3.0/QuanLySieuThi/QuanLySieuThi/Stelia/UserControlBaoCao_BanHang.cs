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
    public partial class UserControlBaoCao_BanHang : UserControl
    {
        private static UserControlBaoCao_BanHang _instance;
        public static UserControlBaoCao_BanHang instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControlBaoCao_BanHang();
                return _instance;
            }
        }
        public UserControlBaoCao_BanHang()
        {
            InitializeComponent();
        }

        private void UserControlBaoCao_BanHang_Load(object sender, EventArgs e)
        {

        }

        private void ChooseNV_MouseClick(object sender, MouseEventArgs e)
        {
            if (ChooseNV.Text == "Chọn nhân viên")
                ChooseNV.Text = "";
        }
    }
}
