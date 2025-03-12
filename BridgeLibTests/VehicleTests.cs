using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BridgeLib.Models;

namespace BridgeLib.Tests
{
    [TestClass()]
    public class VehicleTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Vehicle_Licenseplate_ThrowsException()
        {
            //Arrange
            Car car = new Car();

            //Arrange
            car.Licenseplate = "BG345678";

            //Assert - Catched by exception
        }
    }
}