namespace TcpServer.MsgProcessors
{
    public class TextMessageProcessor : MessageProcessor
    {
        public override RequestDTO ParseRequest(string input)
        {
            string[] parts = input.Split(' ');

            if (parts.Length != 3)
            {
                throw new ArgumentException("Invalid input format");
            }

            string method = parts[0];
            int number1 = int.Parse(parts[1]);
            int number2 = int.Parse(parts[2]);

            RequestDTO request = new RequestDTO(method, number1, number2);
            return request;
        }

        public override string FormatResponse(int result) => result.ToString();
    }
}
