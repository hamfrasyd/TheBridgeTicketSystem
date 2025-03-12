using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLib
{
    /// <summary>
    /// Repræsenterer en motorcykel i billetsystemet.
    /// </summary>
    public class MC : Vehicle
    {
        /// <summary>
        /// Returnerer prisen for en motorcykel, som er fastsat til 120 kr.
        /// </summary>
        /// <returns>Prisen for en motorcykel.</returns>
        public override double Price()
        {
            double basePrice = 120;
            if (HasBrobizz is true)
            {
                return basePrice * 0.9;
            }
            return basePrice;
        }
        /// <summary>
        /// Returnerer køretøjstypen som "MC".
        /// </summary>
        /// <returns>Strengen "MC".</returns>
        public override string VehicleType()
        {
            return "MC";
        }

    }
}
