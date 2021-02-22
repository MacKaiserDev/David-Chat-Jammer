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
            int iEntfernteEintraege = 0;
            int iWaitTime = 0;
            try
            {
                iWaitTime = Int32.Parse(ConfigurationManager.AppSettings["WaitTime"]);
            }
            catch (Exception)
            {

                MessageBox.Show("Fehler beim Lesen der Datei 'David Chat Jammer.exe.config' XML Formatierungsvorgaben werden nicht eingehalten");
            }
            
            // Connection String anfragen
            string sConnString = MSSQL_Access.GetConnectionString();
            string sLoeschnachricht = ConfigurationManager.AppSettings["Message"];

            List<string> LsIDs = new List<string>();

            string sComand = "SELECT * FROM [David TeamBoards Database].[dbo].[messages]";

            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("------------------------David Chat Jammer-------------------------------");
            Console.WriteLine("------------------------------------------------------------------------");

            while (true)
            {

                Console.WriteLine("Rufe neue Nachrichten ab: ");
                LsIDs = Get_TableContent.GetDatabaseEntrys(sConnString, sComand, sLoeschnachricht);

                //Console.WriteLine("Entferne Nachrichtentexte:");
                //Übergibt die Liste der zu Modifizierenden Einträge um diese anzupassen.
                iEntfernteEintraege= Set_TabelContent.SetDatabaseEntrys(sConnString, LsIDs, sLoeschnachricht);
                Console.WriteLine(iEntfernteEintraege+" Einträge entfernt. Wartemodus aktiviert");

                //Console.ReadLine();
                
                Thread.Sleep(iWaitTime);
            }


            //Liste aller Datenbankeinträge, welche den Zielstring enthalten
            

        }
    }
}
