namespace BridgeLib.Models
{
    /// <summary>
    /// Represents a motorcycle in the ticketing system.
    /// Inherits from the <see cref="Vehicle"/> class.
    /// </summary>
    public class MC : Vehicle
    {

        /// <summary>
        /// Calculates and returns the price for a motorcycle.
        /// The standard price is 120 kr.
        /// If Brobizz is used, a 10% discount is applied.
        /// </summary>
        /// <returns>
        /// A <see cref="double"/> representing the calculated ticket price for a motorcycle.
        /// </returns>
        public override double Price()
        {
            double basePrice = 120;
            if (HasBrobizz is true)
            {
                return basePrice * 0.9;
            }
            else
            {
                return basePrice;
            }
        }

        /// <summary>
        /// Returns the vehicle type as a string.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> representing the vehicle type, which is "MC" for motorcycles.
        /// </returns>
        public override string VehicleType()
        {
            return "MC";
        }

    }
}
