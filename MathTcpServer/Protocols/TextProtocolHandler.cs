using MathTcpServer.DataTransferObjects;
using System.Net.Sockets;

namespace MathTcpServer.Protocols
{
    public class TextProtocolHandler : IProtocolHandler
    {
        public RequestDto ReadRequest(StreamReader reader, StreamWriter writer)
        {
            writer.WriteLine("Write method: 'add', 'subtract' or 'random'");   // 0 Ask for method
            string method = reader.ReadLine();                                 // 1 Read method
            
            writer.WriteLine("Input numbers: [num1] [space] [num 2]");         // 2  Ask for numbers
            string numbers = reader.ReadLine();                                // 3 Read the numbers

            string[] choppedNumbers = numbers.Split(' ');

            return new RequestDto
            {
                Method = method,
                FirstNumber = int.Parse(choppedNumbers[0]),
                SecondNumber = int.Parse(choppedNumbers[1])
            };
        }

        public void WriteResponse(StreamWriter writer, ResponseDto response)
        {
            writer.WriteLine(response.Error ?? response.Result.ToString());
        }
    }
}
