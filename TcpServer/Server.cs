using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TcpServer
{
    /// <summary>
    /// Represents a TCP server handling basic mathematical operations and random number generation.
    /// </summary>
    public class Server
    {
        private readonly int PORTNUMMER;
        private readonly string NAME;

        /// <summary>
        /// Initializes a new instance of the TCP server.
        /// </summary>
        /// <param name="port">The port number to listen on (default: 7).</param>
        /// <param name="name">The name of the server (default: "Dummy Server").</param>
        public Server(int port = 7, string name = "Dummy Server")
        {
            PORTNUMMER = port;
            NAME = name;
        }

        /// <summary>
        /// Starts the TCP server and begins listening for client connections.
        /// </summary>
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, PORTNUMMER);
            server.Start();
            Console.WriteLine("Server started at port " + PORTNUMMER);

            while (true)
            {
                TcpClient socket = server.AcceptTcpClient();
                Task.Run(() =>
                {
                    TcpClient tempSocket = socket;
                    DoOneClient(tempSocket);
                });
            }
        }

        /// <summary>
        /// Handles communication with a single client connection. 
        /// </summary>
        /// <param name="socket">The TCP client connection to handle.</param>
        private static void DoOneClient(TcpClient socket)
        {
            StreamReader reader = new StreamReader(socket.GetStream());
            StreamWriter writer = new StreamWriter(socket.GetStream()) { AutoFlush = true };

            try
            {
                // 1. Read command
                string command = ReadCommand(reader);

                // 2. Ask for a number
                SendResponse(writer, "Input numbers");

                // 3. Read the numbers
                int[] numbers = ReadNumbers(reader);

                // 4. Calculate the result
                string result = CalculateResult(command, numbers[0], numbers[1]);

                // 5. Send the result
                SendResponse(writer, result);
            }
            catch (Exception ex)
            {
                // Send error msgs to the client
                SendResponse(writer, "Error: " + ex.Message);
            }
            finally
            {
                socket?.Close();
            }
        }

        /// <summary>
        /// Reads and validates the commands from the client.
        /// </summary>
        /// <param name="reader">The stream reader for client input.</param>
        /// <returns>The received command as a <see cref="string"/></returns>
        /// <exception cref="ArgumentException">Thrown when no command is received.</exception>
        private static string ReadCommand(StreamReader reader)
        {
            string? command = reader.ReadLine();
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentException("No command received");
            }
            return command;
        }


        /// <summary>
        /// Sends a response message to the client.
        /// </summary>
        /// <param name="writer">The stream writer for client output.</param>
        /// <param name="message">The message to send.</param>
        private static void SendResponse(StreamWriter writer, string message)
        {
            writer.WriteLine(message);
        }


        /// <summary>
        /// Reads and parses two integers from the client input.
        /// </summary>
        /// <param name="reader">The stream reader for client input.</param>
        /// <returns>An int array containing two parsed integers.</returns>
        /// <exception cref="ArgumentException">Thrown for invalid or missing numbers.</exception>
        private static int[] ReadNumbers(StreamReader reader)
        {
            string? input = reader.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("No numbers received");
            }

            string[] numbers = input.Split(' ');

            if (numbers.Length != 2)
            {
                throw new ArgumentException("Please send exactly two numbers");
            }

            int[] tallene = { int.Parse(numbers[0]), int.Parse(numbers[1]) };

            return tallene;
        }

        /// <summary>
        /// Calculates the result based on the received command and numbers.
        /// Supported operations: add, subtract, random.
        /// </summary>
        /// <param name="command">The operation to perform.</param>
        /// <param name="tal1">The first number for the calculation.</param>
        /// <param name="tal2">The second number for the calculation.</param>
        /// <returns>The calculation result as a <see cref="string"/>.</returns>
        /// <exception cref="ArgumentException">Thrown for unknown commands.</exception>
        private static string CalculateResult(string command, int tal1, int tal2)
        {
            switch (command.ToLower())
            {
                case "add":
                    return (tal1 + tal2).ToString();
                case "subtract":
                    return (tal1 - tal2).ToString();
                case "random":
                    Random random = new Random();
                    return random.Next(0, 100).ToString();
                default:
                    throw new ArgumentException("Unknown command");
            }
        }

    }
}
