using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Windows.Forms;

namespace David_Chat_Jammer
{
    class MessageDeleter
    {
        private readonly string _sConnString;
        private readonly string _deleteMessage;
        private readonly string _command;
        private readonly int _waitTime;

        public MessageDeleter(string Command)
        {
            _waitTime = TryGetWaitTime();
            _sConnString = MSSQL_Access.GetConnectionString();
            _deleteMessage = ConfigurationManager.AppSettings["Message"];
            _command = Command;
        }

        public void StartDeleting()
        {
            Thread messageDeleterThread = new Thread(new ThreadStart(DeleteMessageEntries));
            messageDeleterThread.Start();
        }


        private void DeleteMessageEntries()
        {
            List<string> LsIDs;
            int deletedEntries;
            while (true)
            {
                Console.WriteLine("Rufe neue Nachrichten ab: ");
                LsIDs = Get_TableContent.GetDatabaseEntrys(_sConnString, _command, _deleteMessage);
                
                //Console.WriteLine("Entferne Nachrichtentexte:");
                //Übergibt die Liste der zu Modifizierenden Einträge um diese anzupassen.
                deletedEntries = Set_TabelContent.SetDatabaseEntrys(_sConnString, LsIDs, _deleteMessage);
                Console.WriteLine(deletedEntries + " Einträge entfernt. Wartemodus aktiviert");

                //Console.ReadLine();

                Thread.Sleep(_waitTime);
            }
        }

        private static int TryGetWaitTime()
        {
            var waitTime = 0; 
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