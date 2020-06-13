using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;

namespace Stelia
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormDangNhap dn = new FormDangNhap();
            Application.Run(dn);
            if (dn.DialogResult == DialogResult.OK)
                Application.Run(new FormWork());
        }
    }
}
