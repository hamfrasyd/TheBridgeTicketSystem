namespace BridgeLib.Models
{
    /// <summary>
    /// Represents a car in the ticketing system.
    /// Inherits from the <see cref="Vehicle"/> class.
    /// </summary>
    public class Car : Vehicle
    {
        /// <summary>
        /// Calculates and returns the price for a car.
        /// The standard price is 230 kr.
        /// If Brobizz is used, a 10% discount is applied.
        /// </summary>
        /// <returns>
        /// A <see cref="double"/> representing the calculated ticket price for a car.
        /// </returns>
        public override double Price()
        {
            double basePrice = 230;
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
        /// A <see cref="string"/> representing the vehicle type, which is "Car" for cars.
        /// </returns>
        public override string VehicleType()
        {
            return "Car";
        }



    }
}
