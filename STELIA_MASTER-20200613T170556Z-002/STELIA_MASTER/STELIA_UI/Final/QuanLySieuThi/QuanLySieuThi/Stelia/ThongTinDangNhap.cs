using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelia
{
    static class ThongTinDangNhap
    {
        private static string username, chucvu;
        public static string Username
        {
            get { return username; }
            set { username = value; }
        }
        public static string ChucVu
        {
            get { return chucvu; }
            set { chucvu = value; }
        }
    }
}
