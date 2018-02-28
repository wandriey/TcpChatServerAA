using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpChatServerAA
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dette er vores Server

            //Starter serveren og venter på at en client forbinder 
            TcpListener serverSocket = new TcpListener(6789);
            serverSocket.Start();
            Console.WriteLine("Serveren er startet");

                TcpClient ConnectionSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("Server activated by client");
            
       



            //Gør serveren istand til at læse beskeder.
            Stream ns = ConnectionSocket.GetStream();
            StreamReader streamReader = new StreamReader(ns);
            string message = streamReader.ReadLine();

            Console.WriteLine($"Server: {message}");



            //Gør serveren istand til at skrive beskeder.
            StreamWriter streamWriter = new StreamWriter(ns);
            streamWriter.AutoFlush = true;

            string messageTilbage = Console.ReadLine();
            streamWriter.WriteLine(messageTilbage);



            //holder programmet åben
            Console.ReadLine();

            ns.Close();
            ConnectionSocket.Close();
            serverSocket.Stop();
        }
    }
}
