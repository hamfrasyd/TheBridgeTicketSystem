using MathTcpServer.DataTransferObjects;

namespace MathTcpServer.Protocols
{
    /// <summary>
    /// Handles client-server communication using a plain text protocol.
    /// </summary>
    public class TextProtocolHandler : IProtocolHandler
    {
        /// <summary>
        /// Reads a plain text formatted request from the stream.
        /// </summary>
        /// <param name="reader">The stream reader to read text input from.</param>
        /// <param name="writer">The stream writer to write prompts or error messages to.</param>
        /// <returns>A <see cref="RequestDto"/> representing the client's request.</returns>
        public RequestDto ReadRequest(StreamReader reader, StreamWriter writer)
        {
            writer.WriteLine("Write Method: 'add', 'subtract' or 'random'");   // 0 Ask for method
            string method = reader.ReadLine();                                 // 1 Read method
            
            writer.WriteLine("Input numbers: [first number] [space] [second number]");         // 2  Ask for numbers
            string numbers = reader.ReadLine();                                // 3 Read the numbers

            string[] choppedNumbers = numbers.Split(' ');

            return new RequestDto {
                Method = method,
                FirstNumber = int.Parse(choppedNumbers[0]),
                SecondNumber = int.Parse(choppedNumbers[1])
            };
        }

        /// <summary>
        /// Writes a plain text formatted response to the stream.
        /// </summary>
        /// <param name="writer">The stream writer to write the response to.</param>
        /// <param name="response">The <see cref="ResponseDto"/> to send as a response.</param>
        public void WriteResponse(StreamWriter writer, ResponseDto response)
        {
            writer.WriteLine(response.Error ?? response.Result.ToString());
        }
    }
}
