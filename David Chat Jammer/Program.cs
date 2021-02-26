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
        private static string _sConnString;
        private static string _sLoeschnachricht;
        private static List<string> _lsIDs;
        private static string _sComand;
        private static int _waitTime;

        static void Main(string[] args)
        {
            int deletedEntries; //Chose english variable names => easier to share, 0 is default value, so does not need to be initialized
            _waitTime = 0;
            
            _waitTime = TryGetWaitTime();
            
            // Connection String anfragen
            _sConnString = MSSQL_Access.GetConnectionString();
            _sLoeschnachricht = ConfigurationManager.AppSettings["Message"];
            _lsIDs = new List<string>();
            _sComand = "SELECT * FROM [David TeamBoards Database].[dbo].[messages]";

            WriteTitleBanner();

          

            Thread messageDeleterThread = new Thread(new ThreadStart(DeleteMessageEntries));
            messageDeleterThread.Start();

            //Liste aller Datenbankeinträge, welche den Zielstring enthalten
            

        }

        //is this fine without thread? does this block the main thread? Should this be a seperate thread?
        private static void DeleteMessageEntries()
        {
            List<string> LsIDs;
            int deletedEntries;
            while (true)
            {
                Console.WriteLine("Rufe neue Nachrichten ab: ");
                LsIDs = Get_TableContent.GetDatabaseEntrys(_sConnString, _sComand, _sLoeschnachricht);

                //Console.WriteLine("Entferne Nachrichtentexte:");
                //Übergibt die Liste der zu Modifizierenden Einträge um diese anzupassen.
                deletedEntries = Set_TabelContent.SetDatabaseEntrys(_sConnString, LsIDs, _sLoeschnachricht);
                Console.WriteLine(deletedEntries + " Einträge entfernt. Wartemodus aktiviert");

                //Console.ReadLine();

                Thread.Sleep(_waitTime);
            }
        }


        private static void WriteTitleBanner()
        {
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("------------------------David Chat Jammer-------------------------------");
            Console.WriteLine("------------------------------------------------------------------------");
        }

        private static int TryGetWaitTime()
        {
            int waitTime = 0; 
            try
            {
                waitTime = Int32.Parse(ConfigurationManager.AppSettings["WaitTime"]);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Fehler beim Lesen der Datei 'David Chat Jammer.exe.config' XML Formatierungsvorgaben werden nicht eingehalten");
            }

            return waitTime;
        }
    }
}
