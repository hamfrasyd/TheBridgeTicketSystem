using System.Net.Sockets;
using TcpServer.DataTransferObjects;
namespace TcpServer.Protocol
{
    interface IProtocolHandler
    {
        RequestDto ReadRequest(NetworkStream stream);
        void WriteResponse(NetworkStream stream, ResponseDto response);
    }
}
