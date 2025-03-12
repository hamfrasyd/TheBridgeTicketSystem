using BridgeLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OresundTicketLibrary.Models
{
    /// <summary>
    /// Represents a motorcycle crossing the Øresund Bridge.
    /// Inherits from the <see cref="MC"/> class and applies Øresund-specific pricing.
    /// </summary>
    public class OresundMC : MC
    {
        /// <summary>
        /// Calculates and returns the price for an Øresund MC crossing.
        /// The standard price is 235 kr.
        /// If Brobizz is used, a fixed discounted price of 92 kr applies.
        /// </summary>
        /// <returns>
        /// A <see cref="double"/> representing the ticket price:
        /// - 235 kr for a standard crossing.
        /// - 92 kr if Brobizz is used.
        /// </returns>
        public override double Price()
        {
            if (HasBrobizz is true)
            {
                return 92;
            }
            return 235;
        }


        /// <summary>
        /// Returns the vehicle type as a string.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> representing the vehicle type, which is "Oresund MC".
        /// </returns>
        public override string VehicleType()
        {
            return "Oresund MC";
        }
    }
}
