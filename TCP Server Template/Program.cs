using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Server_Template
{
    class Program
    {
        private const int PORT = 1111;
        static void Main(string[] args)
        {
            Server server = new Server(PORT);
            server.Start();
            Console.ReadLine();
        }
    }
}
