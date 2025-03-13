using System.Net.Sockets;
using System.Net;
using TcpServer.Protocol;
using TcpServer.DataTransferObjects;
using TcpServer.MathThings;

public class TCPServer
{
    private readonly int _port;
    private readonly IProtocolHandler _protocolHandler;

    public TCPServer(int port, bool useJson = false)
    {
        _port = port;
        _protocolHandler = useJson ? new JsonProtocolHandler() : new TextProtocolHandler();
    }

    public void Start()
    {
        TcpListener listener = new TcpListener(IPAddress.Loopback, _port);
        listener.Start();
        Console.WriteLine($"Server kører på port {_port}");

        try
        {
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                HandleClient(client);
            }
        }
        finally
        {
            listener.Stop();
        }
    }

    private void HandleClient(TcpClient client)
    {
        try
        {
            using (NetworkStream stream = client.GetStream())
            {
                RequestDto request = _protocolHandler.ReadRequest(stream);
                ResponseDto response = ProcessRequest(request);
                _protocolHandler.WriteResponse(stream, response);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fejl: {ex.Message}");
        }
        finally
        {
            client.Close();
        }
    }

    private ResponseDto ProcessRequest(RequestDto request)
    {
        try
        {
            int result = MathService.Calculate(
                request.Method,
                request.Number1,
                request.Number2
            );
            return new ResponseDto { Result = result };
        }
        catch (ArgumentException ex)
        {
            return new ResponseDto { Error = ex.Message };
        }
        catch (Exception ex)
        {
            return new ResponseDto { Error = "Serverfejl: " + ex.Message };
        }
    }
}
