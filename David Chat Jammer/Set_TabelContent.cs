using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;


namespace David_Chat_Jammer
{
    class Set_TabelContent
    {
        public static int SetDatabaseEntrys(string sConnectionString, List<string> sToModify,string sLoeschnachricht)
        {
            foreach (var item in sToModify)
            {
                
              
                string sCommand = "UPDATE [David TeamBoards Database].[dbo].[messages] SET MessageText= '"+ sLoeschnachricht+"' WHERE MessageID='" + item + "'";

                SqlConnection MyConnection = new SqlConnection(sConnectionString);
                SqlCommand SQLMyCommand = new SqlCommand(sCommand, MyConnection);
                MyConnection.Open();

                SQLMyCommand.ExecuteNonQuery();
                MyConnection.Close();


                
            }
            return sToModify.Count();
        }
    }
}
