using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using System.Threading;
using System.Configuration;
using System.Windows.Forms;

namespace David_Chat_Jammer
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteTitleBanner();
            var databaseEntriesToDelete = "SELECT * FROM [David TeamBoards Database].[dbo].[messages]";
            MessageDeleter messageDeleter = new MessageDeleter(databaseEntriesToDelete);
            messageDeleter.StartDeleting();
        }


        
        private static void WriteTitleBanner()
        {
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("------------------------David Chat Jammer-------------------------------");
            Console.WriteLine("------------------------------------------------------------------------");
        }
    }
}
