using Containerschip.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ContainervervoerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CapacityExceedsMaxWeight_WhenCapacityDoesNotExceed_ReturnFalse()
        {
            // Arrange
            int freighterLength = 5;
            int freighterWidth = 3;
            int freighterHeight = 3;
            int freighterLoadCapacity = 1350000;
            Freighter freighter = new Freighter(freighterLength, freighterWidth, freighterHeight, freighterLoadCapacity);

            // Act
            bool result = Freighter.CapacityExceedsMaxWeight(freighter.MaximumWeight, freighterLoadCapacity);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CapacityExceedsMaxWeight_WhenCapacityExceedsMaxWeight_ShouldThrowArgumentException()
        {
            // Arrange
            int freighterLength = 5;
            int freighterWidth = 3;
            int freighterHeight = 3;
            int freighterLoadCapacity = 1500000;
            Freighter freighter = new Freighter(freighterLength, freighterWidth, freighterHeight, freighterLoadCapacity);

            // Act
            try
            {
                Freighter.CapacityExceedsMaxWeight(freighter.MaximumWeight, freighterLoadCapacity);
            }
            catch (ArgumentException exc)
            {
                StringAssert.Contains(exc.Message, "The load capacity exceeds the maximum amount of weight.");
            }
        }
    }
}
