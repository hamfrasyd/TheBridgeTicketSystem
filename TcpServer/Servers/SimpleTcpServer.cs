using TcpServer.MsgProcessors;

namespace TcpServer.Servers
{
    public class SimpleTcpServer : TcpServer
    {
        public SimpleTcpServer(int port) : base(port, new TextMessageProcessor()) 
        { }
    }
}
