using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLib
{
    /// <summary>
    /// Abstrakt baseklasse for alle køretøjer i billetsystemet.
    /// </summary>
    public abstract class Vehicle
    {
        private string _licenseplate;
        /// <summary>
        /// Nummerpladen for køretøjet.
        /// </summary>
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
        public bool HasBrobizz { get; set; }
        /// <summary>
        /// Datoen for passage.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Returnerer prisen for køretøjet.
        /// </summary>
        /// <returns>Prisen som double.</returns>
        public abstract double Price();

        /// <summary>
        /// Returnerer køretøjstypen.
        /// </summary>
        /// <returns>Køretøjstypen som streng.</returns>
        public abstract string VehicleType();
    }
}
