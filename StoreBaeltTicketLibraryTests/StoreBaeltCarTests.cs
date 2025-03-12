using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreBaeltTicketLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBaeltTicketLibrary.Tests
{
    [TestClass()]
    public class StoreBaeltCarTests
    {
        [TestMethod()]
        public void StoreBaeltCar_Price_Weekend_WithBrobizz()
        {
            //Arrange
            StoreBaeltCar storeBaeltCar = new StoreBaeltCar { Date = new DateTime(2025, 3, 8), HasBrobizz = true }; //Saturday

            //Act
            double result = storeBaeltCar.Price();

            //Assert
            Assert.AreEqual(175.95000000000002, result);
        }

        [TestMethod()]
        public void StoreBaeltCar_Price_Weekday_WithBrobizz()
        {
            //Arrange
            StoreBaeltCar storeBaeltCar = new StoreBaeltCar { Date = new DateTime(2025, 3, 10), HasBrobizz = true }; //Monday

            //Act
            double result = storeBaeltCar.Price();

            //Assert
            Assert.AreEqual(207, result);
        }

        [TestMethod()]
        public void StoreBaeltCar_Price_Weekend_NoBrobizz()
        {
            //Arrange
            StoreBaeltCar storeBaeltCar = new StoreBaeltCar { Date = new DateTime(2025, 3, 8), HasBrobizz = false }; // Saturday

            //Act
            double result = storeBaeltCar.Price();

            //Assert
            Assert.AreEqual(195.5, result);
        }

        [TestMethod()]
        public void StoreBaeltCar_Price_Weekday_NoBrobizz()
        {
            //Arrange
            StoreBaeltCar storeBaeltCar = new StoreBaeltCar { Date = new DateTime(2025, 3, 10), HasBrobizz = false }; // Monday

            //Act
            double result = storeBaeltCar.Price();

            //Assert
            Assert.AreEqual(230, result);
        }

    }
}