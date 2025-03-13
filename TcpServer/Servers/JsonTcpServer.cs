using TcpServer.MsgProcessors;

namespace TcpServer.Servers
{
    public class JsonTcpServer : TcpServer
    {
        public JsonTcpServer(int port) : base(port, new JsonMessageProcessor())
        { }
    }
}
