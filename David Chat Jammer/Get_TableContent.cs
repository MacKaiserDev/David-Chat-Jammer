using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace David_Chat_Jammer
{
    class Get_TableContent
    {

        //Funktion liest aus der [David TeamBoards Database] die Zeilen aus, welche nicht der Vordefinierten Zeichenfolge "sZielstring" entsprechen
        //und ersetzt diese. Die Zeichenfolge kann in der App.COnfig festgelegt werden. 
        //Der "sZielstring" wir der Program.cs übergeben. 

        public static List<string> GetDatabaseEntrys(string sConnectionString,string sCommand,string sZielstring)
        {
            bool Debug = bool.Parse(ConfigurationManager.AppSettings["Debug"]);

            List<string> LsIDs = new List<string>();

            SqlConnection OpferSQL = new SqlConnection(sConnectionString);
            SqlCommand MyCommand = new SqlCommand(sCommand, OpferSQL);
            try
            {
                Console.WriteLine("Verbinde...");
                OpferSQL.Open();
                SqlDataReader Reader = MyCommand.ExecuteReader();

                while (Reader.Read())
                {


                    //Debaugausgabe
                    if (Debug)
                    {
                        #region Debugausgabe
                        Console.WriteLine("MessageID: " + Reader.GetInt64(0) +
                                                              " ConversationID: " + Reader.GetInt32(1) +
                                                              " SenderID: " + Reader.GetInt32(2) +
                                                              " MessageText: " + Reader.GetString(3) +
                                                              " MessageTime: " + Reader.GetInt64(4) +
                                                              " FromMobileDevice: " + Reader.GetByte(5) +
                                                              " Subject: " + Reader.GetString(6) +
                                                              " AttachCount: " + Reader.GetInt32(7) +
                                                              " SystemMessage: " + Reader.GetInt32(8) +
                                                              " ClientID: " + Reader.GetString(9) +
                                                              " Prority: " + Reader.GetInt32(10)
                                                              );
                        #endregion
                    }

                    if (Reader.GetString(3).Equals(sZielstring)==false)
                    {
                        //Fügt die TabellenID der Einträge in der der Messagetext nicht "Nachricht entfernt" entspricht einer Liste hinzu
                        Console.WriteLine("Tabelleneintrag mit ID: " + Reader.GetInt64(0) + " Der Liste der zu modifizierten Nachrichten hinzugefügt. ");
                        LsIDs.Add(Reader.GetInt64(0).ToString());
                        

                    }

                }

                OpferSQL.Close();




            }
            catch (ConnectionException)
            {

                throw;
            }




            return LsIDs;
        }
    }
}
