using MathTcpServer.DataTransferObjects;

namespace MathTcpServer.Protocols
{
    interface IProtocolHandler
    {
        /// <summary>
        /// Reads a request from the specified stream.
        /// </summary>
        /// <param name="reader">The stream reader to read input from.</param>
        /// <param name="writer">The stream writer to write prompts or messages to.</param>
        /// <returns>A <see cref="RequestDto"/> representing the client's request.</returns>
        RequestDto ReadRequest(StreamReader reader, StreamWriter writer);

        /// <summary>
        /// Writes a response to the specified stream.
        /// </summary>
        /// <param name="writer">The stream writer to write the response to.</param>
        /// <param name="response">The <see cref="ResponseDto"/> to send as a response.</param>
        void WriteResponse(StreamWriter writer, ResponseDto response);
    }
}
