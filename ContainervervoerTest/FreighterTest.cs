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
        public void WeightExceedsLimitst_WhenWeightDoesNotExceed_ReturnFalse()
        {
            // Arrange
            int freighterLength = 5;
            int freighterWidth = 3;
            int freighterHeight = 3;
            int freighterLoadCapacity = 900000;
            Freighter freighter = new Freighter(freighterLength, freighterWidth, freighterHeight, freighterLoadCapacity);
            List<Container> unsortedContainers = new List<Container>();

            for (int i = 0; i < 30; i++)
            {
                unsortedContainers.Add(new Container(Container.MaximumWeight, Containerschip.Models.Type.Standard));
            }

            int totalContainerWeight = unsortedContainers.Sum(x => x.Weight);

            // Act 
            bool result = Freighter.WeightFailsLimits(freighter.MaximumWeight, freighter.MinimumWeight, freighter.LoadCapacity, totalContainerWeight);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WeightExceedsMaxWeight_WhenWeightExceedsLoadCapacity_ShouldThrowArgumentException()
        {
            // Arrange
            int freighterLength = 5;
            int freighterWidth = 3;
            int freighterHeight = 3;
            int freighterLoadCapacity = 900000;
            Freighter freighter = new Freighter(freighterLength, freighterWidth, freighterHeight, freighterLoadCapacity);
            List<Container> unsortedContainers = new List<Container>();

            for (int i = 0; i < 31; i++)
            {
                unsortedContainers.Add(new Container(Container.MaximumWeight, Containerschip.Models.Type.Standard));
            }

            int totalContainerWeight = unsortedContainers.Sum(x => x.Weight);

            // Act
            try
            {
                Freighter.WeightFailsLimits(freighter.MaximumWeight, freighter.MinimumWeight, freighter.LoadCapacity, totalContainerWeight);
            }
            catch (ArgumentException exc)
            {
                // Assert

                StringAssert.Contains(exc.Message, String.Format("The current weight of {0} kg exceeds the maximum load capacity of the freighter of {1} Kg", totalContainerWeight, freighter.LoadCapacity));
            }
        }

        [TestMethod]
        public void WeightExceedsMaxWeight_WhenWeightUnderCapacityOverMaxWeight_ShouldThrowArgumentException()
        {
            // Arrange
            int freighterLength = 5;
            int freighterWidth = 3;
            int freighterHeight = 3;
            int freighterLoadCapacity = 1500000;
            Freighter freighter = new Freighter(freighterLength, freighterWidth, freighterHeight, freighterLoadCapacity);
            List<Container> unsortedContainers = new List<Container>();

            for (int i = 0; i < 24; i++)
            {
                unsortedContainers.Add(new Container(Container.MaximumWeight, Containerschip.Models.Type.Standard));
            }

            int totalContainerWeight = unsortedContainers.Sum(x => x.Weight);

            // Act
            try
            {
                Freighter.WeightFailsLimits(freighter.MaximumWeight, freighter.MinimumWeight, freighter.LoadCapacity, totalContainerWeight);
            }
            catch (ArgumentException exc)
            {
                // Assert

                StringAssert.Contains(exc.Message, String.Format("The current weight: {0} kg fails to reach the minimum amount of {1} kg required.", totalContainerWeight, freighter.MinimumWeight));
            }
        }

        [TestMethod]
        public void Sort_WhenContainersGiven_ShouldSortStandardContainers()
        {
            // Arrange
            int freighterLength = 5;
            int freighterWidth = 3;
            int freighterHeight = 3;
            int freighterLoadCapacity = 900000;
            Freighter freighter = new Freighter(freighterLength, freighterWidth, freighterHeight, freighterLoadCapacity);
            List<Container> unsortedContainer = new List<Container>();
            for (int i = 1; i < 10; i++)
            {
                unsortedContainer.Add(new Container(i, Containerschip.Models.Type.Standard));
            }
            var normaltype = Containerschip.Models.Type.Standard;

            Container[,,] expectedContainersSorted = new Container[1, 5, 2] { { { new Container(1, normaltype), new Container(2, normaltype) }, { new Container(4, normaltype), new Container(3, normaltype) }, { new Container(5, normaltype), new Container(6, normaltype) }, { new Container(7, normaltype), new Container(8, normaltype) }, { new Container(9, normaltype), new Container(10, normaltype) }, } };

            Algorithm algorithm = new Algorithm(freighter);

            // Act
            algorithm.Sort(unsortedContainer);

            // Assert
            Assert.AreEqual(expectedContainersSorted, freighter.Containers);
        }
    }
}
