using MathTcpServer.Servers;
using MathTcpServer.Servers.Types;

namespace MathTcpServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TcpServer textServer = new TcpServer(6666, ServerType.Text);
            //textServer.Start();

            TcpServer jsonServer = new TcpServer(7777, ServerType.JSON);
            jsonServer.Start();
        }
    }
}
