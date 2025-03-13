namespace BridgeLib.Models
{
    /// <summary>
    /// Abstract base class for all vehicles in the ticketing system.
    /// Defines common properties and methods shared by all vehicle types,
    /// ensuring consistency across implementations.
    /// </summary>
    public abstract class Vehicle
    {
        private string _licenseplate;
        /// <summary>
        /// Gets or sets the license plate of the vehicle.
        /// The license plate must not exceed 7 characters; otherwise, an exception is thrown.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when the license plate length exceeds 7 characters.
        /// </exception>
        public string Licenseplate
        {
            get 
            { 
                return _licenseplate; 
            }
            set
            {
                if (value.Length > 7)
                {
                    throw new ArgumentException("Nummerpladen må ikke være længere end 7 tegn.");
                }
                _licenseplate = value;
            }
        }

        /// <summary>
        /// Indicates whether the vehicle has a Brobizz, 
        /// which provides a discount on ticket prices.
        /// </summary>
        public bool HasBrobizz { get; set; }

        /// <summary>
        /// Gets or sets the date when the vehicle passes through the toll or ticketing system.
        /// Can be used for logging or pricing adjustments based on time.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Abstract method that must be implemented by subclasses to determine 
        /// the price of a vehicle's ticket.
        /// </summary>
        /// <returns>
        /// A <see cref="double"/> representing the ticket price of the vehicle.
        /// </returns>
        public abstract double Price();

        /// <summary>
        /// Abstract method that must be implemented by subclasses 
        /// to define the type of vehicle.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> representing the vehicle type.
        /// </returns>
        public abstract string VehicleType();
    }
}
