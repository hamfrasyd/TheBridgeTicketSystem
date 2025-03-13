using System.Text.Json;

namespace TcpServer.MsgProcessors
{
    public class JsonMessageProcessor : MessageProcessor
    {
        public override RequestDTO ParseRequest(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Ingen data modtaget.");
            }
            try
            {
                RequestDTO request = JsonSerializer.Deserialize<RequestDTO>(input);
                if (request == null)
                {
                    throw new ArgumentException("Anmodningen kunne ikke fortolkes.");
                }
                return request;
            }
            catch (JsonException jEx)
            {
                throw new ArgumentException("Invalid JSON format: " + jEx.Message);
            }
        }

        public override string FormatResponse(int result) =>
            JsonSerializer.Serialize(new { Result = result });
    }
}
