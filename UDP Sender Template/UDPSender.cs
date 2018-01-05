using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDP_Sender_Template
{
    class UDPSender
    {
        private readonly int PORT;

        public UDPSender(int port)
        {
            PORT = port;
        }

        public void Start()
        {
            // Eksempel med Class Library
            // Car bil = new Car("Tesla", "red", "EL23400");

            //Objektet til tekst
            // var biltekst = bil.ToString();
            var tekst = "Hej";

            //Sender
            byte[] buffer = Encoding.ASCII.GetBytes(tekst /*biltekst*/);

            UdpClient udp = new UdpClient();

            IPEndPoint OtherEp = new IPEndPoint(IPAddress.Broadcast, PORT);
            udp.Send(buffer, buffer.Length, OtherEp);

            IPEndPoint RecieverEP = new IPEndPoint(IPAddress.Any, 0);
            byte[] reciverbuffer = udp.Receive(ref RecieverEP);
            Console.WriteLine($"Længde af modtaget udp datagram = {reciverbuffer.Length}");
            String incomingStr = Encoding.ASCII.GetString(reciverbuffer);
            Console.WriteLine(incomingStr);

        }

        
    }
}
