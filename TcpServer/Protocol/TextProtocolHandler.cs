using System.Net.Sockets;
using TcpServer.DataTransferObjects;

namespace TcpServer.Protocol
{
    public class TextProtocolHandler : IProtocolHandler
    {
        public RequestDto ReadRequest(NetworkStream stream)
        {
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };

            string method = reader.ReadLine();
            writer.WriteLine("Input numbers");

            string numbers = reader.ReadLine();
            string[] parts = numbers.Split(' ');

            return new RequestDto
            {
                Method = method,
                Number1 = int.Parse(parts[0]),
                Number2 = int.Parse(parts[1])
            };
        }

        public void WriteResponse(NetworkStream stream, ResponseDto response)
        {
            StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
            writer.WriteLine(response.Error ?? response.Result.ToString());
        }
    }
}
