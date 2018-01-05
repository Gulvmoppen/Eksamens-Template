using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Server_Template
{
    class Server
    {
        private readonly int PORT;

        public Server()
        {
            
        }


        public Server(int port)
        {
            PORT = port;
        }

        public void Start()
        {
            TcpListener listener = null;
            try
            {
                listener = new TcpListener(IPAddress.Loopback, PORT);
                listener.Start();
                Console.WriteLine("EchoServer Startet... ");
                while (true)
                {
                    Console.WriteLine("Venter på forbindelse til client");
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("Client er nu accepteret... ");
                    StreamReader reader = new StreamReader(client.GetStream());
                    StreamWriter writer = new StreamWriter(client.GetStream());
                    string s = string.Empty;
                    while (!(s = reader.ReadLine()).Equals("Exit") || (s == null))
                    {
                        Console.WriteLine("Fra Client -> " + s);
                        writer.WriteLine(" Fra Server -> " + s);
                        writer.Flush();
                    }
                    reader.Close();
                    writer.Close();
                    client.Close();

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            finally
            {
                if (listener != null)
                {
                    listener.Stop();
                }
            }
            Console.ReadLine();
        }
    }
}
