using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Server_Tetris
{
    class Program
    {
        static TcpListener server = null;
        static String DateTrimise;
        static NetworkStream[] DateNetwork = new NetworkStream[2];
        static Thread[] t = new Thread[2];
        static int Scor1 = 0, Scor2 = 0;
        static int contor = 1;
        static void Main(string[] args)
        {
            server = new TcpListener(System.Net.IPAddress.Any, 3000);
            server.Start();
            int counter = 0;
            while (counter < 2)
            {
                TcpClient client = server.AcceptTcpClient();
                System.Console.WriteLine("Client " + counter + " connected");
                t[counter] = new Thread(new ThreadStart(() => functie(client, counter - 1)));
                t[counter].Start();
                counter++;
            }
        }
        static void functie(TcpClient client, int ThreadNr)
        {

            /* int ThreadNr = 0;
             for (int i = 0; i < t.Length; i++)
             {
                 if (!t[i].IsAlive)
                 {
                     ThreadNr = i - 1;
                     break;
                 }

             }
             TcpClient client = server.AcceptTcpClient();*/
            DateNetwork[ThreadNr] = client.GetStream();
            StreamWriter scriere = new StreamWriter(DateNetwork[ThreadNr]);
            scriere.AutoFlush = true;
            scriere.WriteLine((ThreadNr + 1).ToString());
            while (true)
            {
                try
                {
                    DateNetwork[ThreadNr] = client.GetStream();
                    StreamReader citireServer = new StreamReader(DateNetwork[ThreadNr]);
                    string text = citireServer.ReadLine();
                    /*                   MethodInvoker m = new MethodInvoker(() => serverForm.textBox1.Text += (text + Environment.NewLine)); 
                                        serverForm.Invoke(m);*/
                    if (text[0] == 'S')
                    {
                        text = text.Replace('S', ' ');
                        text = text.Trim();
                        if (contor == 1)
                            Scor1 = int.Parse(text);
                        else
                        {
                            Scor2 = int.Parse(text);
                            if (Scor1 > Scor2)
                            {
                                scriere = new StreamWriter(DateNetwork[0]);
                                scriere.AutoFlush = true;
                                scriere.WriteLine("F1");
                                scriere = new StreamWriter(DateNetwork[1]);
                                scriere.AutoFlush = true;
                                scriere.WriteLine("F1");
                            }
                            if (Scor1 < Scor2)
                            {
                                scriere = new StreamWriter(DateNetwork[0]);
                                scriere.AutoFlush = true;
                                scriere.WriteLine("F2");
                                scriere = new StreamWriter(DateNetwork[1]);
                                scriere.AutoFlush = true;
                                scriere.WriteLine("F2");
                            }
                            if (Scor1 == Scor2)
                            {
                                scriere = new StreamWriter(DateNetwork[0]);
                                scriere.AutoFlush = true;
                                scriere.WriteLine("F0");
                                scriere = new StreamWriter(DateNetwork[1]);
                                scriere.AutoFlush = true;
                                scriere.WriteLine("F0");
                            }
                            contor = 0;
                        }
                        contor++;
                        text = "S";
                    }
                    if (text == "C")
                    {
                        scriere = new StreamWriter(DateNetwork[0]);
                        scriere.AutoFlush = true;
                        scriere.WriteLine("C");
                    }
                    if (ThreadNr == 0)
                    {
                        scriere = new StreamWriter(DateNetwork[1]);
                        scriere.AutoFlush = true;
                        scriere.WriteLine(text);
                    }
                    else
                    {
                        scriere = new StreamWriter(DateNetwork[0]);
                        scriere.AutoFlush = true;
                        scriere.WriteLine(text);
                    }
                }
                finally { }
            }
        }
    }
}
