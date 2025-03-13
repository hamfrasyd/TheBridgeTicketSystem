using MathTcpServer.DataTransferObjects;
using System.Net.Sockets;
using System.Text.Json;

namespace MathTcpServer.Protocols
{
    public class JsonProtocolHandler : IProtocolHandler
    {
        public RequestDto ReadRequest(StreamReader reader, StreamWriter writer)
        {
            //{"Method":"Random","FirstNumber":10,"SecondNumber":20}
            writer.Write("Write input in JSON Format fx. ");
            writer.WriteLine(JsonSerializer.Serialize(new RequestDto { Method = "Random", FirstNumber = 10, SecondNumber = 20 }));


            string? json = reader.ReadLine();
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentException("Ingen data modtaget.");
            }

            try
            {
                RequestDto? request = JsonSerializer.Deserialize<RequestDto>(json);
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

        public void WriteResponse(StreamWriter writer, ResponseDto response)
        {
            string json = JsonSerializer.Serialize(response);
            writer.WriteLine(json);
        }
    }
}
