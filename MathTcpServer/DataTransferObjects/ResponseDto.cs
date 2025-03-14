namespace MathTcpServer.DataTransferObjects
{
    /// <summary>
    /// Represents the data transfer object for server responses.
    /// </summary>
    public class ResponseDto
    {
        /// <summary>
        /// Gets or sets the result of the math operation, if the operation was successful.
        /// </summary>
        public int? Result { get; set; }

        /// <summary>
        /// Gets or sets the error message if an error occurred.
        /// </summary>
        public string? Error { get; set; }
    }
}
