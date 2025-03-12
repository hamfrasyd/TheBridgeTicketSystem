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
    public class MCTests
    {
        [TestMethod()]
        public void MC_Price_Test()
        {
            //Arrange
            MC mc = new MC();

            //Act
            double result = mc.Price();

            //Assert
            Assert.AreEqual(120, result);
        }

        [TestMethod()]
        public void MC_Price_WithBrobizz_Test()
        {
            //Arrange
            MC mc = new MC();
            mc.HasBrobizz = true;

            //Act
            double result = mc.Price();

            //Assert
            Assert.AreEqual(108, result);
        }

        [TestMethod()]
        public void MC_VehicleType_Test()
        {
            //Arrange
            MC mc = new MC();

            //Act
            string result = mc.VehicleType();

            //Assert
            Assert.AreEqual("MC", result);
        }

    }
}