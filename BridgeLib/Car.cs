using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLib
{
    /// <summary>
    /// Repræsenterer en bil i billetsystemet.
    /// </summary>
    public class Car : Vehicle
    {
        /// <summary>
        /// Returnerer prisen for en bil, som er fastsat til 230 kr.
        /// </summary>
        /// <returns>Prisen af for en bil.</returns>
        public override double Price()
        {
            double basePrice = 230;
            if (HasBrobizz is true)
            {
                return basePrice * 0.9;
            }
            return basePrice;
        }

        /// <summary>
        /// Returnerer køretøjstypen som "Car".
        /// </summary>
        /// <returns>Strengen "Car".</returns>
        public override string VehicleType()
        {
            return "Car";
        }



    }
}
