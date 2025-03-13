namespace TcpServer.DataTransferObjects
{
    /// <summary>
    /// Represents the JSON request that is sent from the client
    /// Expected format e.g.: {"Method": "add", "Number1": 3, "Number2": 4}
    /// </summary>
    public class RequestDto
    {
        public string Method { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
    }
}
