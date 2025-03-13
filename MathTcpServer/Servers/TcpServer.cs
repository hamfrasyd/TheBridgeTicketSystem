using MathTcpServer.Protocols;
using System.Net.Sockets;
using System.Net;
using MathTcpServer.MathStuff;
using MathTcpServer.DataTransferObjects;
using MathTcpServer.Servers.Types;

namespace MathTcpServer.Servers
{
    public class TcpServer
    {
        private readonly int _port;
        private readonly IProtocolHandler _protocolHandler;

        public TcpServer(int port, ServerType type)
        {
            _port = port;
            switch (type)
            {
                case (ServerType.Text):
                    _protocolHandler = new TextProtocolHandler();
                    break;
                case (ServerType.JSON):
                    _protocolHandler = new JsonProtocolHandler();
                    break;
            }
        }

        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, _port);
            server.Start();
            Console.WriteLine($"Server kører på port {_port}");

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
                writer.WriteLine($"Fejl: {ex.Message}");
                Console.WriteLine($"Fejl: {ex.Message}");
            }
            finally
            {
                reader.Close();
                writer.Close();
                socket.Close();
            }
        }

        private ResponseDto ProcessRequest(RequestDto request)
        {
            try
            {
                int result = MathService.Calculate(                 // 4.1 Calculate the result
                    request.Method,
                    request.FirstNumber,
                    request.SecondNumber
                );
                return new ResponseDto
                { 
                    Result = result 
                };
            }
            catch (ArgumentException ex)
            {
                return new ResponseDto
                {
                    Error = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                { 
                    Error = "Serverfejl: " + ex.Message
                };
            }
        }
    }
}
