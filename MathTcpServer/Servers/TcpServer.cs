using MathTcpServer.Protocols;
using System.Net.Sockets;
using System.Net;
using MathTcpServer.MathStuff;
using MathTcpServer.DataTransferObjects;
using MathTcpServer.Servers.Types;

namespace MathTcpServer.Servers
{
    /// <summary>
    /// Represents a TCP server that processes math requests using a specified protocol.
    /// </summary>
    public class TcpServer
    {
        private readonly int _port;
        private readonly IProtocolHandler _protocolHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpServer"/> class.
        /// </summary>
        /// <param name="port">The port number on which the server will listen for incoming connections.</param>
        /// <param name="type">The type of protocol to use for communication.</param>
        /// <exception cref="ArgumentException">Thrown when an unsupported server type is provided.</exception>
        public TcpServer(int port, ServerType type)
        {
            _port = port;
            switch (type)
            {
                case ServerType.Text:
                    _protocolHandler = new TextProtocolHandler();
                    break;
                case ServerType.JSON:
                    _protocolHandler = new JsonProtocolHandler();
                    break;
                default:
                    throw new ArgumentException("Unsupported server type.", nameof(type));
            }
        }

        /// <summary>
        /// Starts the TCP server and begins accepting incoming client connections.
        /// </summary>
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, _port);
            server.Start();
            Console.WriteLine($"Server running on port {_port}");

            while (true)
            {
                TcpClient socket = server.AcceptTcpClient();
                Task.Run(() =>
                {
                    TcpClient tempSocket = socket;

                    HandleClient(tempSocket);
                });
            }
        }

        /// <summary>
        /// Handles communication with a connected client.
        /// </summary>
        /// <param name="socket">The TCP client representing the connected client.</param>
        private void HandleClient(TcpClient socket)
        {
            StreamReader reader = new StreamReader(socket.GetStream());
            StreamWriter writer = new StreamWriter(socket.GetStream());
            writer.AutoFlush = true;

            try
            {
                RequestDto request = _protocolHandler.ReadRequest(reader, writer);
                ResponseDto response = ProcessRequest(request);
                _protocolHandler.WriteResponse(writer, response);   // 4.2 Send the result

            }
            catch (Exception ex)
            {
                writer.WriteLine(new ResponseDto { Error = ex.Message });
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                reader.Close();
                writer.Close();
                socket.Close();
            }
        }

        /// <summary>
        /// Processes the client's request by performing the specified math operation.
        /// </summary>
        /// <param name="request">The <see cref="RequestDto"/> containing the operation and numbers.</param>
        /// <returns>
        /// A <see cref="ResponseDto"/> containing either the result of the operation or an error message.
        /// </returns>
        private ResponseDto ProcessRequest(RequestDto request)
        {
            try
            {
                int result = MathService.Calculate( request.Method, request.FirstNumber, request.SecondNumber); // 4.1 Calculate the result
                return new ResponseDto { Result = result };
            }
            catch (ArgumentException ex)
            {
                return new ResponseDto { Error = ex.Message };
            }
            catch (Exception ex)
            {
                return new ResponseDto { Error = "Server error: " + ex.Message };
            }
        }
    }
}
