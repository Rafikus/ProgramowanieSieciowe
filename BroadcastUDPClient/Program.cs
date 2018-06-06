using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BroadcastClient
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient client = new UdpClient { ExclusiveAddressUse = false };

            IPEndPoint localEp = new IPEndPoint(IPAddress.Any, 2222);

            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            client.ExclusiveAddressUse = false;

            client.Client.Bind(localEp);

            client.EnableBroadcast = true;

            Console.WriteLine("Listening this will never quit so you will need to ctrl-c it");

            while (true)
            {
                Byte[] data = client.Receive(ref localEp);
                string strData = Encoding.Unicode.GetString(data);
                Console.WriteLine(strData);
            }
        }
    }
}