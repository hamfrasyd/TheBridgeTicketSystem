using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace JsonTcPServer
{
    /// <summary>
    /// Represents a JSON TCP server handling operations through structured requests
    /// </summary>
    public class JsonServer
    {
        private readonly int PORTNUMMER;
        private readonly string NAME;

        /// <summary>
        /// Initializes a new instance of the JSON TCP server
        /// </summary>
        /// <param name="port">The port number to listen on (default: 7077)</param>
        /// <param name="name">The name of the server (default: "JSON Server")</param>
        public JsonServer(int port = 7077, string name = "JSON Server")
        {
            PORTNUMMER = port;
            NAME = name;
        }

        /// <summary>
        /// Starts the JSON server and begins listening for client connections
        /// </summary>
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, PORTNUMMER);
            server.Start();
            Console.WriteLine("Server started at port " + PORTNUMMER);

            while (true)
            {
                TcpClient socket = server.AcceptTcpClient();
                HandleJsonClient(socket);
            }
        }

        /// <summary>
        /// Handles communication with a single client connection
        /// </summary>
        /// <param name="socket">The TCP client connection to handle</param>
        private void HandleJsonClient(TcpClient socket)
        {
            StreamReader reader = new StreamReader(socket.GetStream());
            StreamWriter writer = new StreamWriter(socket.GetStream());
            writer.AutoFlush = true;

            try
            {
                // Read JSON request
                string jsonInput = reader.ReadLine();
                if (string.IsNullOrEmpty(jsonInput))
                {
                    SendJsonError(writer, "Empty request");
                    return;
                }

                // Parse JSON
                JsonRequest? request = JsonSerializer.Deserialize<JsonRequest>(jsonInput);
                if (request == null || string.IsNullOrEmpty(request.Method) || !request.Number1.HasValue || !request.Number2.HasValue)
                {
                    SendJsonError(writer, "Invalid JSON format");
                    return;
                }

                // Calculate result
                string result = CalculateResult(request.Method, request.Number1.Value, request.Number2.Value);
                SendJsonResponse(writer, result);
            }
            catch (Exception ex)
            {
                SendJsonError(writer, ex.Message);
            }
            finally
            {
                socket.Close();
            }
        }

        /// <summary>
        /// Sends a JSON formatted response to the client
        /// </summary>
        private void SendJsonResponse(StreamWriter writer, string result)
        {
            var response = new JsonResponse { Result = result };
            string jsonOutput = JsonSerializer.Serialize(response);
            writer.WriteLine(jsonOutput);
        }

        /// <summary>
        /// Sends a JSON formatted error message to the client
        /// </summary>
        private void SendJsonError(StreamWriter writer, string error)
        {
            var response = new JsonResponse { Error = error };
            string jsonOutput = JsonSerializer.Serialize(response);
            writer.WriteLine(jsonOutput);
        }

        /// <summary>
        /// Calculates the result based on the received command and numbers
        /// </summary>
        private string CalculateResult(string command, int tal1, int tal2)
        {
            switch (command.ToLower())
            {
                case "add":
                    return (tal1 + tal2).ToString();
                case "subtract":
                    return (tal1 - tal2).ToString();
                case "random":
                    int min = Math.Min(tal1, tal2);
                    int max = Math.Max(tal1, tal2);
                    return new Random().Next(min, max + 1).ToString();
                default:
                    throw new ArgumentException("Unknown command");
            }
        }

        // JSON data classes
        private class JsonRequest
        {
            public string? Method { get; set; }
            public int? Number1 { get; set; }
            public int? Number2 { get; set; }
        }

        private class JsonResponse
        {
            public string? Result { get; set; }
            public string? Error { get; set; }
        }
    }
}