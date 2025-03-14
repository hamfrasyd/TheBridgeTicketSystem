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

        /// <summary>
        /// Returns a string that represents the current response.
        /// </summary>
        /// <returns>
        /// A formatted string containing the result and error message (if there is any).
        /// </returns>
        public override string ToString()
        {
            return $"Result: {Result},  Error: {Error}";
        }
    }
}
