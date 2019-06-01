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
        public void WeightExceedsLimits_WhenWeightDoesNotExceed_ReturnFalse()
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

            // Act 
            bool result = freighter.WeightFailsLimits(unsortedContainers);

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
                freighter.WeightFailsLimits(unsortedContainers);
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
                freighter.WeightFailsLimits(unsortedContainers);
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
            unsortedCooledContainer.Add(new Container(11, cooled));
            unsortedCooledContainer.Add(new Container(12, cooled));
            unsortedCooledContainer.Add(new Container(13, cooled));
            unsortedCooledContainer.Add(new Container(14, cooled));
            unsortedCooledContainer.Add(new Container(15, cooled));

            Container[,,] expectedContainersSorted = new Container[5, 5, 3] { { { new Container(15, cooled), new Container(10, cooled), new Container(5, cooled) }, { new Container(13, cooled), new Container(8, cooled), new Container(3, cooled) }, { new Container(11, cooled), new Container(6, cooled), new Container(1, cooled) }, { new Container(12, cooled), new Container(7, cooled), new Container(2, cooled) }, { new Container(14, cooled), new Container(9, cooled), new Container(4, cooled) } }, { { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null } } };

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

        [TestMethod]
        public void SortCooledContainers_WhenContainersWeightExceedsLimitOnTop_ShouldThrowArgument()
        {
            // Assert
            int freighterLength = 5;
            int freighterWidth = 3;
            int freighterHeight = 10;
            int freighterLoadCapacity = 900000;
            Freighter freighter = new Freighter(freighterLength, freighterWidth, freighterHeight, freighterLoadCapacity);

            List<Container> unsortedCooledContainer = new List<Container>();
            var cooled = Containerschip.Models.Type.Cooled;

            unsortedCooledContainer.Add(new Container(30000, cooled));
            unsortedCooledContainer.Add(new Container(30000, cooled));
            unsortedCooledContainer.Add(new Container(30000, cooled));
            unsortedCooledContainer.Add(new Container(30000, cooled));
            unsortedCooledContainer.Add(new Container(30000, cooled));
            unsortedCooledContainer.Add(new Container(30000, cooled));
            unsortedCooledContainer.Add(new Container(30000, cooled));
            unsortedCooledContainer.Add(new Container(30000, cooled));
            unsortedCooledContainer.Add(new Container(30000, cooled));
            unsortedCooledContainer.Add(new Container(30000, cooled));
            unsortedCooledContainer.Add(new Container(30000, cooled));
            unsortedCooledContainer.Add(new Container(30000, cooled));
            unsortedCooledContainer.Add(new Container(30000, cooled));
            unsortedCooledContainer.Add(new Container(30000, cooled));
            unsortedCooledContainer.Add(new Container(30000, cooled));
            unsortedCooledContainer.Add(new Container(30000, cooled));
            unsortedCooledContainer.Add(new Container(30000, cooled));
            unsortedCooledContainer.Add(new Container(30000, cooled));

            Algorithm algorithm = new Algorithm(freighter);

            // Act
            try
            {
                algorithm.SortCooledContainers(unsortedCooledContainer);
            }
            catch (ArgumentException exc)
            {
                // Assert

                StringAssert.Contains(exc.Message, String.Format("The containers could not be sorted because the maximum weight on top of one or more containers exceeds the limit of " + Container.MaxWeightOnTop + " kg"));
            }
        }

        [TestMethod]
        public void WeightOnTop_WhenPlaceGiven_ShouldReturnWeightOnTop()
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
            unsortedCooledContainer.Add(new Container(11, cooled));
            unsortedCooledContainer.Add(new Container(12, cooled));
            unsortedCooledContainer.Add(new Container(13, cooled));
            unsortedCooledContainer.Add(new Container(14, cooled));
            unsortedCooledContainer.Add(new Container(15, cooled));

            Algorithm algorithm = new Algorithm(freighter);
            int expectedResult = 15;

            // Act

            algorithm.SortCooledContainers(unsortedCooledContainer);
            int actualResult = algorithm.WeightOnTopOfLowest(0, 0);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void WeightOnTop_WhenNotAllSpotsFilled_ShouldReturnWeightOnTop()
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
            unsortedCooledContainer.Add(new Container(5, cooled));
            unsortedCooledContainer.Add(new Container(6, cooled));
            unsortedCooledContainer.Add(new Container(7, cooled));
            unsortedCooledContainer.Add(new Container(8, cooled));
            unsortedCooledContainer.Add(new Container(9, cooled));
            unsortedCooledContainer.Add(new Container(10, cooled));
            unsortedCooledContainer.Add(new Container(11, cooled));
            unsortedCooledContainer.Add(new Container(12, cooled));
            unsortedCooledContainer.Add(new Container(13, cooled));
            unsortedCooledContainer.Add(new Container(14, cooled));
            unsortedCooledContainer.Add(new Container(15, cooled));

            Algorithm algorithm = new Algorithm(freighter);
            int expectedResult = 6;

            // Act

            algorithm.SortCooledContainers(unsortedCooledContainer);
            int actualResult = algorithm.WeightOnTopOfLowest(2, 0);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
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
