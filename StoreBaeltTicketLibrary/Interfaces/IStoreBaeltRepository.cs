using BridgeLib.Models;

namespace StoreBaeltTicketLibrary.Interfaces
{
    interface IStoreBaeltRepository
    {
        void AddTicket(Vehicle ticket);
        List<Vehicle> GetAllTickets();
        List<Vehicle> GetTicketsByLicenseplate(string licenseplate);
    }
}
