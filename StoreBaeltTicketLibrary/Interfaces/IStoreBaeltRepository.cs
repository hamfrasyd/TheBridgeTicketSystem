using BridgeLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBaeltTicketLibrary.Interfaces
{
    interface IStoreBaeltRepository
    {
        void AddTicket(Vehicle ticket);
        List<Vehicle> GetAllTickets();
        List<Vehicle> GetTicketsByLicenseplate(string licenseplate);
    }
}
