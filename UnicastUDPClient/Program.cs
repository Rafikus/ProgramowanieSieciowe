using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UnicastUDPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            EndPoint groupEP = new IPEndPoint(ipAddress, 2222);

            while (true)
            {
                byte[] msg = Encoding.UTF8.GetBytes(Console.ReadLine()?.ToCharArray());
                Console.WriteLine($"Sending {Encoding.UTF8.GetString(msg)}");
                socket.SendTo(msg, groupEP);
                socket.ReceiveFrom(msg, ref groupEP);
                Console.WriteLine($"Recieved {Encoding.UTF8.GetString(msg)}");
            }
        }
    }
}
