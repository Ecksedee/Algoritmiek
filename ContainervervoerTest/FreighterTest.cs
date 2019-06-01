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
                unsortedContainers.Add(new Container(Container.MaxWeight, Containerschip.Models.Type.Standard));
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
                unsortedContainers.Add(new Container(Container.MaxWeight, Containerschip.Models.Type.Standard));
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
                unsortedContainers.Add(new Container(Container.MaxWeight, Containerschip.Models.Type.Standard));
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
        public void SortCooledContainers_WhenContainersGiven_ShouldSortCooledContainers()
        {
            // Assert
            int freighterLength = 5;
            int freighterWidth = 5;
            int freighterHeight = 3;
            int freighterLoadCapacity = 900000;
            Freighter freighter = new Freighter(freighterLength, freighterWidth, freighterHeight, freighterLoadCapacity);

            List<Container> unsortedCooledContainer = new List<Container>();
            var cooled = Containerschip.Models.Type.Cooled;

            unsortedCooledContainer.Add(new Container(1, cooled));
            unsortedCooledContainer.Add(new Container(2, cooled));
            unsortedCooledContainer.Add(new Container(3, cooled));
            unsortedCooledContainer.Add(new Container(4, cooled));
            unsortedCooledContainer.Add(new Container(5, cooled));
            unsortedCooledContainer.Add(new Container(6, cooled));
            unsortedCooledContainer.Add(new Container(7, cooled));
            unsortedCooledContainer.Add(new Container(8, cooled));
            unsortedCooledContainer.Add(new Container(9, cooled));
            unsortedCooledContainer.Add(new Container(10, cooled));

            unsortedCooledContainer.OrderByDescending(x => x.Weight);

            Container[,,] expectedContainersSorted = new Container[5, 5, 3] { { { new Container(1, cooled), new Container(6, cooled), null }, { new Container(3, cooled), new Container(8, cooled), null }, { new Container(5, cooled), new Container(10, cooled), null }, { new Container(4, cooled), new Container(9, cooled), null }, { new Container(2, cooled), new Container(7, cooled), null } }, { { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null } } };
            Algorithm algorithm = new Algorithm(freighter);

            // Act
            Container[,,] actualContainersSorted = algorithm.SortCooledContainers(unsortedCooledContainer);

            // Assert
            string expectedArrayToString = "";
            foreach (var s in expectedContainersSorted.Cast<Container>())
            {
                expectedArrayToString += s;
            }

            string actualArrayToString = "";
            foreach (var s in actualContainersSorted.Cast<Container>())
            {
                actualArrayToString += s;
            }

            Assert.AreEqual(expectedArrayToString, actualArrayToString);
        }

        //[TestMethod]
        public void Sort_WhenContainersGiven_ShouldSortStandardContainers()
        {
            // Arrange
            int freighterLength = 5;
            int freighterWidth = 5;
            int freighterHeight = 3;
            int freighterLoadCapacity = 900000;
            Freighter freighter = new Freighter(freighterLength, freighterWidth, freighterHeight, freighterLoadCapacity);
            List<Container> unsortedContainer = new List<Container>();
            for (int i = 1; i < 10; i++)
            {
                unsortedContainer.Add(new Container(i, Containerschip.Models.Type.Standard));
            }
            var cooledType = Containerschip.Models.Type.Standard;

            Container[,,] expectedContainersSorted = new Container[5, 5, 3] { { { new Container(1, cooledType), new Container(6, cooledType), null }, { new Container(3, cooledType), new Container(8, cooledType), null }, { new Container(5, cooledType), new Container(10, cooledType), null }, { new Container(4, cooledType), new Container(9, cooledType), null }, { new Container(2, cooledType), new Container(7, cooledType), null } }, { { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null }, {null, null, null } } };

            Algorithm algorithm = new Algorithm(freighter);

            // Act
            algorithm.Sort(unsortedContainer);

            // Assert
            Assert.AreEqual(expectedContainersSorted, freighter.Containers);
        }
    }
}
