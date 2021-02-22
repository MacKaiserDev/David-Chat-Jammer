using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace David_Chat_Jammer
{
    class MSSQL_Access
    {
        //Diese Datei liest den ConnectionString auf der App.Config aus und gibt eidese zurück
        public static string GetConnectionString()
        {
            string sConnectString = ConfigurationManager.AppSettings["ConnectionString"];
            return sConnectString;
        }
    }
}
