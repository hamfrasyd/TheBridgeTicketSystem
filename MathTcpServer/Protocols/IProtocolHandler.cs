using MathTcpServer.DataTransferObjects;

namespace MathTcpServer.Protocols
{
    interface IProtocolHandler
    {
        RequestDto ReadRequest(StreamReader reader, StreamWriter writer);
        void WriteResponse(StreamWriter writer, ResponseDto response);
    }
}
