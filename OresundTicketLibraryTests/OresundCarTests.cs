using OresundTicketLibrary.Models;

namespace OresundTicketLibrary.Tests
{
    [TestClass()]
    public class OresundCarTests
    {
        [TestMethod()]
        public void OresundCar_Price_WithBrobizz()
        {
            //Arrange
            OresundCar car = new OresundCar { HasBrobizz = true };

            //Act
            double result = car.Price();

            //Assert
            Assert.AreEqual(178, result);
        }

        [TestMethod()]
        public void OresundCar_VehicleType()
        {
            //Arrange
            OresundCar car = new OresundCar();

            //Act
            string result = car.VehicleType();

            //Assert
            Assert.AreEqual("Oresund Car", result);
        }
    }
}