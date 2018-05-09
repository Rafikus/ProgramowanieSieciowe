using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UnicastUDPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient(2222);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 2222);

            while (true)
            {
                byte[] msg = udpClient.Receive(ref groupEP);
                Console.WriteLine(Encoding.UTF8.GetString(msg));
                udpClient.Send(msg, msg.Length, groupEP);
            }
        }
    }
}
