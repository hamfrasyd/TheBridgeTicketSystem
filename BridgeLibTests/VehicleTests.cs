﻿using BridgeLib.Models;

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