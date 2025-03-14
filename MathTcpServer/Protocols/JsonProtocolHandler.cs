using MathTcpServer.DataTransferObjects;
using System.Text.Json;

namespace MathTcpServer.Protocols
{
    /// <summary>
    /// Handles client-server communication using the JSON protocol.
    /// </summary>
    public class JsonProtocolHandler : IProtocolHandler
    {
        /// <summary>
        /// Reads a JSON formatted request from the stream.
        /// </summary>
        /// <param name="reader">The stream reader to read JSON input from.</param>
        /// <param name="writer">The stream writer to write prompts or error messages to.</param>
        /// <returns>A <see cref="RequestDto"/> representing the client's request.</returns>
        /// <exception cref="ArgumentException">Thrown when no data is received or when the data cannot be parsed as valid JSON.</exception>
        public RequestDto ReadRequest(StreamReader reader, StreamWriter writer)
        {
            //{"Method":"Random","FirstNumber":10,"SecondNumber":20}
            writer.Write("Write input in JSON Format e.g. ");
            writer.WriteLine(JsonSerializer.Serialize(new RequestDto { Method = "Random", FirstNumber = 10, SecondNumber = 20 }));

            string? json = reader.ReadLine();
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentException("No data received.");
            }

            try
            {
                RequestDto? request = JsonSerializer.Deserialize<RequestDto>(json);
                if (request == null)
                {
                    throw new ArgumentException("Request could not be parsed.");
                }
                return request;
            }
            catch (JsonException)
            {
                throw new ArgumentException("Invalid JSON format.");
            }
        }

        /// <summary>
        /// Writes a JSON formatted response to the stream.
        /// </summary>
        /// <param name="writer">The stream writer to write the response to.</param>
        /// <param name="response">The <see cref="ResponseDto"/> to send as a response.</param>
        public void WriteResponse(StreamWriter writer, ResponseDto response)
        {
            string json = JsonSerializer.Serialize(response);
            writer.WriteLine(json);
        }
    }
}
