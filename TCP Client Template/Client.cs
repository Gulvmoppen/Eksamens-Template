using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Client_Template
{
    class Client
    {
        private readonly int PORT;

        public Client()
        {
            
        }

        public Client( int port)
        {
            PORT = port;
        }

        public void Start()
        {
            // Eksempel med Class Library
            // Car Tesla = new Car();
            // Tesla.Color = "red";
            // Tesla.Model = "S";
            // Tesla.RegNr = "EL23400";

            // Car Tesla2 = new Car();
            // Tesla2.Color = "blue";
            // Tesla2.Model = "S";
            // Tesla2.Regnr = "EB20600";

            // List<Car> carList = new List<Car>;
            // carList.Add(Tesla);
            // carList.Add(Tesla2);
            List<String> stringList = new List<string>();
            stringList.Add("Mombo");
            stringList.Add("Jombo");

            TcpClient client = new TcpClient("localhost", PORT);
            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());
            string s = String.Empty;
            while (!s.Equals("Exit"))
            {
                Console.WriteLine("sender en string til serveren: ");
                s = Console.ReadLine();
                Console.WriteLine(s);

                // Henter information
                Console.WriteLine("Liste af informationer");
                foreach (var st in stringList)
                {
                    writer.WriteLine("Info: " + st);
                }
                writer.Flush();
                string server_string = reader.ReadLine();
                Console.WriteLine(server_string);
            }
            reader.Close();
            writer.Close();
            client.Close();

            Console.ReadLine();
        }
        
    }
}
