using MathTcpServer.Servers;
using MathTcpServer.Servers.Types;

namespace MathTcpServer
{
    /// <summary>
    /// The entry point of the MathTcpServer application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main method that starts the TCP server.
        /// </summary>
        static void Main(string[] args)
        {
            // Start the text-based server on port 6666 in a separate task.
            Task.Run(() =>
            {
                TcpServer textServer = new TcpServer(6666, ServerType.Text);
                textServer.Start();
            });

            // Start the JSON-based server on port 7777 in a separate task.
            Task.Run(() =>
            {
                TcpServer jsonServer = new TcpServer(7777, ServerType.JSON);
                jsonServer.Start();
            });

            Console.WriteLine("Both servers are running. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
