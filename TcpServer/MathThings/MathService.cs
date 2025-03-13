namespace TcpServer.MathThings
{
    public static class MathService
    {
        /// <summary>
        /// Calculates the result of a mathematical operation based on the specified command and numbers.
        /// Supported operations are: "add", "subtract", and "random".
        /// </summary>
        /// <param name="command">The mathematical command to perform (e.g., "add").</param>
        /// <param name="num1">The first number for the calculation.</param>
        /// <param name="num2">The second number for the calculation.</param>
        /// <returns>
        /// The result of the calculation as a string.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when an unknown command is provided.
        /// </exception>
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

                    // random.Next er eksklusiv for øvre grænse, så vi tilføjer 1 for at inkludere den
                    return random.Next(lower, upper + 1);
                default:
                    throw new ArgumentException("Ukendt kommando: " + command);
            }
        }
    }
}
