namespace MathTcpServer.DataTransferObjects
{
    /// <summary>
    /// Represents the data transfer object for client requests.
    /// </summary
    public class RequestDto
    {
        /// <summary>
        /// Gets or sets the math operation to perform (e.g., "add", "subtract", "random").
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets the first number for the math operation.
        /// </summary>
        public int FirstNumber { get; set; }

        /// <summary>
        /// Gets or sets the second number for the math operation.
        /// </summary>
        public int SecondNumber { get; set; }
    }
}
