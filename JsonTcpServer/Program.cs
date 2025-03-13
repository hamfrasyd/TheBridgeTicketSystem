using JsonTcpServer.Servers;
namespace JsonTcpServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            JsonServer jsonServer = new JsonServer();
            jsonServer.Start();


            Console.ReadKey();
        }
    }
}
