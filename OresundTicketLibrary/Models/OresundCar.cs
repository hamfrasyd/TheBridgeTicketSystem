using BridgeLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OresundTicketLibrary.Models
{
    /// <summary>
    /// Represents a car crossing the Øresund Bridge.
    /// Inherits from the <see cref="Car"/> class and overrides pricing specific to the Øresund toll system.
    /// </summary>
    public class OresundCar : Car
    {

        /// <summary>
        /// Calculates and returns the price for a car corssing Øresund.
        /// The standard price is 460 kr.
        /// If Brobizz is used, a fixed discounted price of 178 kr applies.
        /// </summary>
        /// <returns>
        /// A <see cref="double"/> representing the ticket price:
        /// - 460 kr for a standard crossing.
        /// - 178 kr if Brobizz is used.
        /// </returns>
        public override double Price()
        {
            if (HasBrobizz is true)
            {
                return 178;
            }
            return 460;
        }


        /// <summary>
        /// Returns the vehicle type as a string.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> representing the vehicle type, which is "Oresund Car".
        /// </returns>
        public override string VehicleType()
        {
            return "Oresund Car";
        }
    }
}
