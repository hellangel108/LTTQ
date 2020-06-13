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
            FormWork work = new FormWork();
            do
            {
                FormDangNhap dn = new FormDangNhap();
                Application.Run(dn);
                if (dn.DialogResult == DialogResult.OK)
                {
                    work = new FormWork(dn.username);
                    Application.Run(work);
                }
            } while (work.DialogResult == DialogResult.OK);
        }
    }
}
