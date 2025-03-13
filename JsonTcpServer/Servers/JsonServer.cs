using System.Net;
using System.Net.Sockets;
using System.Text.Json;

namespace JsonTcpServer.Servers
{
    /// <summary>
    /// Represents a TCP server that handles JSON-based requests for mathematical operations 
    /// and random number generation.
    /// </summary>
    public class JsonServer
    {
        private readonly int PORTNUMMER;
        private readonly string NAME;

        /// <summary>
        /// Initializes a new instance of the JSON TCP server.
        /// </summary>
        /// <param name="port">The port number on which the server listens (default is 5000).</param>
        /// <param name="name">The name of the server (default is "JSON Dummy Server").</param>
        public JsonServer(int port = 777, string name = "JSON Dummy Server")
        {
            PORTNUMMER = port;
            NAME = name;
        }

        /// <summary>
        /// Starts the server and listens for client connections.
        /// </summary>
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, PORTNUMMER);
            server.Start();
            Console.WriteLine("JSON TCP Server started at port " + PORTNUMMER);

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
        /// Handles communication with a single client.
        /// </summary>
        /// <param name="client">The connected TCP client.</param>
        /// <param name="client">Klientforbindelsen.</param>
        private static void DoOneClient(TcpClient client)
        {

            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());
            writer.AutoFlush = true;

            try
            {
                //{"method": "Random", "Tal1": 10, "Tal2": 20}
                SendJsonResponse(writer, $"Write input in Json Format"); // 0 Ask for Json input (Mathematical Command and Numbers)

                RequestDTO request = ReadJsonRequest(reader);            // 1, 2 & 3 Read JSON-input from client

                string result = CalculateResult(request.method,          // 4.1 Calculate result based on the Mathematical Command and Numbers
                                                request.Tal1,
                                                request.Tal2);

                SendJsonResponse(writer, result);                         // 4.2 Send the result back as Json object
            }
            catch (Exception ex)
            {
                // If error occurs, send an error msg to the client in JSON format.
                SendJsonResponse(writer, "Fejl: " + ex.Message);
            }
            finally
            {
                client?.Close();
            }
        }


        /// <summary>
        /// Reads the JSON request from the client and converts it into a RequestDTO.
        /// </summary>
        /// <param name="reader">The StreamReader used to read client input.</param>
        /// <returns>
        /// A <see cref="RequestDTO"/> containing the mathematical command and numbers.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when no data is received or when the data cannot be parsed.
        /// </exception>
        private static RequestDTO ReadJsonRequest(StreamReader reader)
        {
            string? json = reader.ReadLine();
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentException("Ingen data modtaget.");
            }

            try
            {
                RequestDTO? request = JsonSerializer.Deserialize<RequestDTO>(json);
                if (request == null)
                {
                    throw new ArgumentException("Anmodningen kunne ikke fortolkes.");
                }
                return request;
            }
            catch (JsonException)
            {
                throw new ArgumentException("Ugyldigt JSON-format.");
            }

        }

        /// <summary>
        /// Serializes the given response string into JSON format and writes the resulting JSON to the provided StreamWriter.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="StreamWriter"/> used to send the serialized JSON response to the client.
        /// </param>
        /// <param name="response">
        /// The response string to be serialized. Note that if this string is already a JSON-formatted string,
        /// the serialization process will add additional quotes and escape characters.
        /// </param>
        private static void SendJsonResponse(StreamWriter writer, string response)
        {
            string jsonResponse = JsonSerializer.Serialize(response);
            writer.WriteLine(jsonResponse);
        }

        /// <summary>
        /// Calculates the result of a mathematical operation based on the specified command and numbers.
        /// Supported operations are: "add", "subtract", and "random".
        /// </summary>
        /// <param name="command">The mathematical command to perform (e.g., "add").</param>
        /// <param name="tal1">The first number for the calculation.</param>
        /// <param name="tal2">The second number for the calculation.</param>
        /// <returns>
        /// The result of the calculation as a string.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when an unknown command is provided.
        /// </exception>
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
                    int lower = Math.Min(tal1, tal2);
                    int upper = Math.Max(tal1, tal2);

                    // random.Next er eksklusiv for øvre grænse, så vi tilføjer 1 for at inkludere den
                    return random.Next(lower, upper + 1).ToString();
                default:
                    throw new ArgumentException("Ukendt kommando: " + command);
            }
        }
        public record RequestDTO(string method, int num1, int num2);

    }
}
