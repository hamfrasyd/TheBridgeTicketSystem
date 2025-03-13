namespace JsonTcpServer
{
    /// <summary>
    /// Repræsenterer den JSON-forespørgsel, som klienten sender.
    /// Forventet format fx: {"Method": "add", "Tal1": 3, "Tal2": 4}
    /// </summary>
    public record RequestDTO(string method, int Tal1, int Tal2);
}
