using MathTcpServer.DataTransferObjects;
using System.Net.Sockets;

namespace MathTcpServer.Protocols
{
    interface IProtocolHandler
    {
        RequestDto ReadRequest(StreamReader reader, StreamWriter writer);
        void WriteResponse(StreamWriter writer, ResponseDto response);
    }
}
