using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_NS.ENTITY
{
   public static class ConnectString
    {
        public static string ServerName = string.Empty;
        public static string DatabaseName = string.Empty;
        public static string UserName = string.Empty;
        public static string Password = string.Empty;
        public static bool WinAuthentication = false;//true wwindows false aql
        public static string StringConnect = string.Empty;

        public static void TaoChuoiKetNoi()
        {
            string Temp = string.Empty;
            Temp = "Data Source =" + ServerName + ";";
            Temp += "Initial Catalog =" + DatabaseName + ";";
            if (WinAuthentication == true)
            {
                Temp += "Integrated security = true";
            }
            else
            {
                Temp += "Integrated Security = false; User ID = " + UserName + "; Password = " + Password;
            }

            StringConnect = Temp;
        }
    }
}
