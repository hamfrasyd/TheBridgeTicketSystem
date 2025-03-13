namespace TcpServer.MsgProcessors
{
    public abstract class MessageProcessor
    {
        public abstract RequestDTO ParseRequest(string input);
        public abstract string FormatResponse(int result);
    }
}
