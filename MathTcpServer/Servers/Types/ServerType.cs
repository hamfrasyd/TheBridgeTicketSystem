namespace MathTcpServer.Servers.Types
{
    /// <summary>
    /// Enumerates the supported types of TCP servers.
    /// </summary>
    public enum ServerType
    {
        /// <summary>
        /// A server that communicates using plain text.
        /// </summary>
        Text = 1,

        /// <summary>
        /// A server that communicates using JSON.
        /// </summary>
        JSON = 2,
    }
}
