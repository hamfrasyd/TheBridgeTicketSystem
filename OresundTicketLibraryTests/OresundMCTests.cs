using Microsoft.VisualStudio.TestTools.UnitTesting;
using OresundTicketLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OresundTicketLibrary.Tests
{
    [TestClass()]
    public class OresundMCTests
    {
        [TestMethod()]
        public void OresundCar_Price_WithBrobizz()
        {
            //Arrange
            OresundMC mc = new OresundMC { HasBrobizz = true };

            //Act
            double result = mc.Price();

            //Assert
            Assert.AreEqual(92, result);
        }

        [TestMethod()]
        public void OresundCar_VehicleType()
        {
            //Arrange
            OresundMC mc = new OresundMC();

            //Act
            string result = mc.VehicleType();

            //Assert
            Assert.AreEqual("Oresund MC", result);
        }
    }
}