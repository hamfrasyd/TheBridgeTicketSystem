using BridgeLib.Models;
using StoreBaeltTicketLibrary.Interfaces;

namespace StoreBaeltTicketLibrary.Repository
{
    /// <summary>
    /// Repository class for managing vehicle tickets at Storebæltsbroen.
    /// Implements the <see cref="IStoreBaeltRepository"/> interface to provide
    /// methods for adding and retrieving tickets.
    /// </summary>
    public class StoreBaeltRepository : IStoreBaeltRepository
    {
        private static List<Vehicle> _tickets = new List<Vehicle>();

        /// <summary>
        /// Adds a vehicle ticket to the repository.
        /// </summary>
        /// <param name="ticket">The <see cref="Vehicle"/> object representing the ticket to add.</param>
        public void AddTicket(Vehicle ticket)
        {
            _tickets.Add(ticket);
        }

        /// <summary>
        /// Retrieves all vehicle tickets stored in the repository.
        /// </summary>
        /// <returns>
        /// A list of <see cref="Vehicle"/> objects representing all stored tickets.
        /// </returns>
        public List<Vehicle> GetAllTickets()
        {
            return _tickets;
        }

        /// <summary>
        /// Retrieves all vehicle tickets associated with a specific license plate.
        /// </summary>
        /// <param name="licenseplate">The license plate string to filter tickets by.</param>
        /// <returns>
        /// A list of <see cref="Vehicle"/> objects matching the specified license plate.
        /// </returns>
        public List<Vehicle> GetTicketsByLicenseplate(string licenseplate)
        {
            return _tickets.Where(t => t.Licenseplate == licenseplate).ToList();
        }
    }
}
