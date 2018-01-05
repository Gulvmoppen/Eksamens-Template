using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Eksamens_Template
{
    class UDPReciever
    {
        private readonly int PORT;
        public UDPReciever(int port)
        {
            PORT = port;
        }

        public void Start()
        {
            //Modtager (Reciever)
            byte[] buffer = new byte[2048];

            UdpClient udp = new UdpClient(PORT);
            IPEndPoint senderEP = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("send meddelelse: ");
            buffer = udp.Receive(ref senderEP);
            Console.WriteLine($"UDP length of datagram = {buffer.Length}");
            Console.WriteLine($"Afsender er {senderEP.Address}, port {senderEP.Port}");

            //Conventer bytes til string
            String incommingStr = Encoding.ASCII.GetString(buffer);
            Console.WriteLine(incommingStr);

            //Send tilbage
            String outgoingStr = incommingStr.ToUpper();
            byte[] outbuffer = Encoding.ASCII.GetBytes(outgoingStr);

            udp.Send(outbuffer, outbuffer.Length, senderEP);

        }
    }
}
