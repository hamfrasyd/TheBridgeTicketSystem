using BridgeLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StoreBaeltTicketLibrary.Models
{
    /// <summary>
    /// Represents a car crossing the Storebælt Bridge.
    /// Inherits from the <see cref="Car"/> class and applies Storebælt-specific pricing.
    /// </summary>
    public class StoreBaeltCar : Car
    {
        /// <summary>
        /// Calculates and returns the price for a car crossing Storebælt.
        /// The standard price is 230 kr.
        /// If traveling on a weekend (Saturday or Sunday), a 15% discount is applied.
        /// If Brobizz is used, an additional 10% discount is applied after the weekend discount.
        /// </summary>
        /// <returns>
        /// A <see cref="double"/> representing the calculated ticket price:
        /// - 230 kr on weekdays without Brobizz.
        /// - 195.5 kr (15% discount) on weekends without Brobizz.
        /// - 207 kr (10% Brobizz discount) on weekdays with Brobizz.
        /// - 175.95 kr (both discounts combined) on weekends with Brobizz.
        /// </returns>
        public override double Price()
        {
            double basePrice = 230;

            // Apply a 15% discount if the trip is on a weekend
            if (Date.DayOfWeek == DayOfWeek.Saturday || Date.DayOfWeek == DayOfWeek.Sunday) 
            {
                basePrice *= 0.85; // 15% weekendrabat
            }

            // Apply a 10% Brobizz discount (on top of weekend discount, if it's weekend)
            if (HasBrobizz is true)
            {
                return basePrice * 0.9;
            }
            else
            {
                return basePrice;
            }
        }
    }
}
