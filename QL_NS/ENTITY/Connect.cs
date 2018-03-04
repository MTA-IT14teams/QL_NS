using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QL_NS.ENTITY
{
   public static class Connect
    {
        public static bool isConnect = false;
       public static SqlConnection myconnect = new SqlConnection(ConnectString.StringConnect);
    }
}
