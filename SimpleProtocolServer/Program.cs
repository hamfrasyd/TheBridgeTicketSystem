using SimpleProtocolServer;

namespace SimpelProtokolServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //TransmissionControlProtocolServer server = new TransmissionControlProtocolServer(21);
            //server.Start();

            // Start JSON serveren i dit hovedprogram
            var jsonServer = new JsonServer();
            jsonServer.Start();


            Console.ReadKey();
        }
    }
}
