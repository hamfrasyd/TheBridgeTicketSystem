using BridgeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StoreBaeltTicketLibrary
{
    public class StoreBaeltCar : Car
    {
        public override double Price()
        {
            double basePrice = 230;
            if (Date.DayOfWeek == DayOfWeek.Saturday || Date.DayOfWeek == DayOfWeek.Sunday)
            {
                basePrice *= 0.85; // 15% weekendrabat
            }
            if (HasBrobizz is true)
            {
                return basePrice * 0.9; // Brobizz efter weekendrabat
            }
            else
            {
                return basePrice;
            }
        }
    }
}
