using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace QotdClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip;
            if (args.Length > 0 && IPAddress.TryParse(args[0], out ip))
            {

            }
            else
            {
                ip = IPAddress.Loopback;
            }

            try
            {
                var client = new Socket(SocketType.Stream, ProtocolType.Tcp);
                client.Connect(ip, 17);
                byte[] bytes = new byte[500];
                client.Receive(bytes);
                Console.WriteLine(System.Text.Encoding.ASCII.GetString(bytes));
            }
            catch (SocketException)
            {
                Console.WriteLine("Error: " + (args.Length > 0 ? ip.ToString() : "The current computer") + " is not hosting a Quote of the Day server.");
            }
        }
    }
}
