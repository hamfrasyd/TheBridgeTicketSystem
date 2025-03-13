using TcpServer.Servers;

namespace TcpServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Start tekstbaseret server
            TCPServer textServer = new TCPServer(7000);
            textServer.Start();

            // Start JSON server
            TCPServer jsonServer = new TCPServer(7001, useJson: true);
            jsonServer.Start();

            Console.ReadKey();

        }
    }
}
