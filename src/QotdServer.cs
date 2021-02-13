using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace QotdServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //RFC 865 says the the QOTD should be limited to 500 chars.
            //This is a check for that.
            string t = File.ReadAllText("message.txt");
            string message = t.Length < 500 ? t : "";
            //Start the listener. If the program is closed, it'll automatically stop.
            sock.Bind(new IPEndPoint(IPAddress.Any, 17));
            sock.Listen(100);

            while (true)
            {
                
                var client = sock.Accept();
                client.Send(System.Text.Encoding.ASCII.GetBytes(message));
            }
        }
    }
}
