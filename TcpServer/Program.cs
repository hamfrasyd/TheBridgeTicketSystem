﻿namespace TcpServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            TcpServer server = new TcpServer(21);
            server.Start();

            Console.ReadKey();

        }
    }
}
