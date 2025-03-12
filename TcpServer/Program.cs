namespace TcpServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Server server = new Server(21); // Du kan ændre porten her
            server.Start();
            Console.ReadKey();
        }
    }
}
