Versio: 0.1
Author: Stefan Kaiser
Programmiersprache: C#

Diese Anwenung liest die David Teamboards Database aus und ersetzt in der Tabelle dbo.Messages den Chatnachrichtentext durch den in der "David Chat Jammer.exe.config" definierten Text. 
Da der David Client bei offenen Chat die Nachrichten zwischenspeichert wird die �nderung in der Datenbank erst nach erneuten Aufruf des Chats in David sichtbar. 

Wichtig: 

Da Anwendung im Usermodus arbeitet, muss am Rechner stets ein User angemeldet sein, in dem die Anwendung l�uft.
Es werden keine backups der modifizierten Eintr�ge der Datenbank vorgenommen. Die Nutzung erfolgt auf eigene Gefahr.  

Konfiguration der Anwendung:

In der Datei "David Chat Jammer.exe.config" k�nnen die Einstellungen der Anwendung nach belieben angepasst werden. Die Datei kann mit einem normalen Texteditor ge�ffnet werden. 

Datennutzung:

Bei Verwendung der Anwendung werden weder Nutzungsstatistiken erzeugt noch versendet. 
