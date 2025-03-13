using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TcpServer.DataTransferObjects;

namespace TcpServer.Protocol
{
    public class JsonProtocolHandler : IProtocolHandler
    {
        public RequestDto ReadRequest(NetworkStream stream)
        {
            StreamReader reader = new StreamReader(stream);
            string json = reader.ReadToEnd();
            return JsonSerializer.Deserialize<RequestDto>(json);
        }

        public void WriteResponse(NetworkStream stream, ResponseDto response)
        {
            StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
            string json = JsonSerializer.Serialize(response);
            writer.Write(json);
        }
    }
}
