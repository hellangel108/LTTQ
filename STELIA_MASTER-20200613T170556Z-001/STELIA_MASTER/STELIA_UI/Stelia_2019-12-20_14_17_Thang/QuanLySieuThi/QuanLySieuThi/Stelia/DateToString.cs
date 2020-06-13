using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelia
{
    public class DateChange
    {
        static public string ToString(DateTime dt)
        {
            return dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString();
        }
    }
}
