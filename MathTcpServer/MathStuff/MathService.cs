namespace MathTcpServer.MathStuff
{
    /// <summary>
    /// Provides methods for performing mathematical operations.
    /// </summary>
    public static class MathService
    {
        /// /// <summary>
        /// Calculates the result of a mathematical operation based on the specified command and numbers.
        /// Supported operations are: "add", "subtract", and "random".
        /// </summary>
        /// <param name="command">The mathematical command to perform (e.g., "add", "subtract", "random").</param>
        /// <param name="num1">The first number for the calculation.</param>
        /// <param name="num2">The second number for the calculation.</param>
        /// <returns>The result of the calculation as an <see cref="int"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when an unknown command is provided.</exception>
        public static int Calculate(string command, int num1, int num2)
        {
            switch (command.ToLower())
            {
                case "add":
                    return num1 + num2;
                case "subtract":
                    return num1 - num2;
                case "random":
                    Random random = new Random();
                    int lower = Math.Min(num1, num2);
                    int upper = Math.Max(num1, num2);

                // random.Next is exclusive of the upper bound; adding 1 includes it.
                return random.Next(lower, upper + 1);
                default:
                    throw new ArgumentException("Unknown command: " + command);
            }
        }
    }
}
