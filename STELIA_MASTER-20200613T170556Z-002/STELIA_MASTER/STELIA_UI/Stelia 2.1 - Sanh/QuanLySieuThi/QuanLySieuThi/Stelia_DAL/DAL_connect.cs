using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Stelia_DAL
{
    public class DAL_connect
    {
        public SqlConnection connect = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename="+ Application.StartupPath.Remove(Application.StartupPath.LastIndexOf("Stelia")) + "Stelia_DAL" + @"\QLBH.mdf;Integrated Security = True");
    }
}
