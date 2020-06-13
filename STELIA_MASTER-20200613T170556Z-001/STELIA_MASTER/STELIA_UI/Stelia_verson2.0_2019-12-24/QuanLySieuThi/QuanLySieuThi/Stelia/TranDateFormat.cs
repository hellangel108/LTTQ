using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stelia
{
    public class TranDateFormat
    {
        static public string Trans(string st)
        {
            string res = "";
            res += st[3];
            res += st[4];
            res += "/" + st[0] + st[1];

            for (int i = 5; i < st.Length; i++)
                res += st[i];
            return res;
        }

        static public string SubString(string st)
        {
            string res = "";
            for (int i = 0; i < st.Length; i++)
                if (st[i] == '.' || st[i] == ' ')
                    return res;
                else res += st[i];
            return res;
        }

        static public string GetLastName(string st)
        {
            string res = "";
            if (st == null) return res;
            int vt = -1;
            for (int i = st.Length-1; i >= 0; i--)
                if (st[i] == ' ')
                {
                    vt = i;
                    break;
                }
            for (int i = vt + 1; i < st.Length; i++)
                res += st[i];
            return res;
        }
    }
}
