using Containerschip.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContainervervoerTest
{
    [TestClass]
    public class FreighterTest
    {
        [TestMethod]
        public void WeightExceedsMaxWeight_WhenWeightDoesNotExceed_ReturnFalse()
        {
            // Arrange
            int freighterLength = 5;
            int freighterWidth = 3;
            int freighterHeight = 3;
            int freighterLoadCapacity = 900000;
            Freighter freighter = new Freighter(freighterLength, freighterWidth, freighterHeight, freighterLoadCapacity);
            List<Container> unsortedContainers = new List<Container>();

            for (int i = 0; i < 45; i++)
            {
                unsortedContainers.Add(new Container(Container.MaximumWeight, Containerschip.Models.Type.Standard));
            }

            int totalContainerWeight = unsortedContainers.Sum(x => x.Weight);


            // Act 
            bool result = Freighter.WeightExceedsMaxWeight(freighter.MaximumWeight, totalContainerWeight);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WeightExceedsMaxWeight_WhenWeightExceedsMaxWeight_ShouldThrowArgumentException()
        {
            // Arrange
            int freighterLength = 5;
            int freighterWidth = 3;
            int freighterHeight = 3;
            int freighterLoadCapacity = 900000;
            Freighter freighter = new Freighter(freighterLength, freighterWidth, freighterHeight, freighterLoadCapacity);
            List<Container> unsortedContainers = new List<Container>();

            for (int i = 0; i < 45; i++)
            {
                unsortedContainers.Add(new Container(Container.MaximumWeight, Containerschip.Models.Type.Standard));
            }

            int totalContainerWeight = unsortedContainers.Sum(x => x.Weight);

            // Act
            try
            {
                Freighter.WeightExceedsMaxWeight(freighter.MaximumWeight, totalContainerWeight);
            }
            catch (ArgumentException exc)
            {
                StringAssert.Contains(exc.Message, "The total weight of the containers exceeds the maximum weight of the ship of " + freighter.MaximumWeight + "Kg");
            }
        }
    }
}
