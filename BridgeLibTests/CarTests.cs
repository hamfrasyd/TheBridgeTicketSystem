using Microsoft.VisualStudio.TestTools.UnitTesting;
using BridgeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLib.Tests
{
    [TestClass()]
    public class CarTests
    {
        [TestMethod()]
        public void Car_Price_Test()
        {
            //Arrange
            Car car = new Car();

            //Act
            double result = car.Price();

            //Assert
            Assert.AreEqual(230, result);
        }

        [TestMethod()]
        public void Car_VehicleType_Test()
        {
            //Arrange
            Car car = new Car();

            //Act
            string result = car.VehicleType();
            //Assert
            Assert.AreEqual("Car", result);
        }
    }
}