using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MulticastUDPServer
{
    class Program
    {
        static void Main()
        {
            UdpClient udpclient = new UdpClient();

            IPAddress multicastaddress = IPAddress.Parse("239.0.0.222");
            udpclient.JoinMulticastGroup(multicastaddress);
            IPEndPoint remoteep = new IPEndPoint(multicastaddress, 2222);

            Console.WriteLine("Press ENTER to start sending messages");
            Console.ReadLine();

            for (int i = 0; i <= 8000; i++)
            {
                var buffer = Encoding.Unicode.GetBytes(i.ToString());
                udpclient.Send(buffer, buffer.Length, remoteep);
                Console.WriteLine("Sent " + i);
            }

            Console.WriteLine("All Done! Press ENTER to quit.");
            Console.ReadLine();
        }
    }
}