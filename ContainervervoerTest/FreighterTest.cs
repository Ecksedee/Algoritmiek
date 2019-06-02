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
            Freighter freighter = new Freighter(freighterWidth, freighterLength, freighterHeight, freighterLoadCapacity);
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
            Freighter freighter = new Freighter(freighterWidth, freighterLength, freighterHeight, freighterLoadCapacity);
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
            Freighter freighter = new Freighter(freighterWidth, freighterLength, freighterHeight, freighterLoadCapacity);
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
            Freighter freighter = new Freighter(freighterWidth, freighterLength, freighterHeight, freighterLoadCapacity);

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

            Container[,,] expectedContainersSorted = new Container[5, 5, 3] { { { new Container(15, cooled), new Container(9, cooled), new Container(5, cooled) }, { new Container(13, cooled), new Container(7, cooled), new Container(3, cooled) }, { new Container(11, cooled), new Container(6, cooled), new Container(1, cooled) }, { new Container(12, cooled), new Container(8, cooled), new Container(2, cooled) }, { new Container(14, cooled), new Container(10, cooled), new Container(4, cooled) } }, { { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null }, { null, null, null } } };

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
            Freighter freighter = new Freighter(freighterWidth, freighterLength, freighterHeight, freighterLoadCapacity);

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
            Freighter freighter = new Freighter(freighterWidth, freighterLength, freighterHeight, freighterLoadCapacity);

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
            int expectedResult = 14;

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
            Freighter freighter = new Freighter(freighterWidth, freighterLength, freighterHeight, freighterLoadCapacity);

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

        [TestMethod]
        public void GetNextAvailablePosition_ShouldReturnLocation()
        {
            Freighter freighter = new Freighter(3, 5, 3, 900000);
            Assert.AreEqual(2, freighter.GetNextAvailableSpot(0, 0, true));

            freighter.Containers[2, 0, 0] = new Container(10, Containerschip.Models.Type.Cooled);
            Assert.AreEqual(0, freighter.GetNextAvailableSpot(0, 0, true));

            freighter.Containers[0, 0, 0] = new Container(10, Containerschip.Models.Type.Cooled);
            Assert.AreEqual(1, freighter.GetNextAvailableSpot(0, 0, true));

            freighter.Containers[1, 0, 0] = new Container(10, Containerschip.Models.Type.Cooled);
            Assert.AreEqual(-1, freighter.GetNextAvailableSpot(0, 0, true));

            Assert.AreEqual(0, freighter.GetNextAvailableSpot(1, 0, false));

            freighter.Containers[0, 1, 0] = new Container(10, Containerschip.Models.Type.Cooled);
            Assert.AreEqual(2, freighter.GetNextAvailableSpot(1, 0, false));

            freighter.Containers[2, 1, 0] = new Container(10, Containerschip.Models.Type.Cooled);
            Assert.AreEqual(1, freighter.GetNextAvailableSpot(1, 0, false));

            freighter.Containers[1, 1, 0] = new Container(10, Containerschip.Models.Type.Cooled);
            Assert.AreEqual(-1, freighter.GetNextAvailableSpot(1, 0, false));
        }

        [TestMethod]
        public void Sort_WhenContainersGiven_ShouldSortContainers()
        {
            // Arrange
            int freighterLength = 5;
            int freighterWidth = 5;
            int freighterHeight = 3;
            int freighterLoadCapacity = 900000;
            Freighter freighter = new Freighter(freighterWidth, freighterLength, freighterHeight, freighterLoadCapacity);
            List<Container> unsortedContainers = new List<Container>();
            var cooled = Containerschip.Models.Type.Cooled;
            var standard = Containerschip.Models.Type.Standard;

            unsortedContainers.Add(new Container(1, cooled));
            unsortedContainers.Add(new Container(2, cooled));
            unsortedContainers.Add(new Container(3, cooled));
            unsortedContainers.Add(new Container(4, cooled));
            unsortedContainers.Add(new Container(5, cooled));
            unsortedContainers.Add(new Container(6, cooled));

            for (int i = 1; i < 25; i++)
            {
                unsortedContainers.Add(new Container(i, standard));
            }

            Container[,,] expectedContainersSorted = new Container[5, 5, 3]
            {
                {
                    {new Container(6, cooled), new Container(1, cooled), null},
                    {new Container(4, cooled), new Container(3, standard), null},
                    {new Container(2, cooled), new Container(1, standard), null},
                    {new Container(3, cooled), new Container(2, standard), null},
                    {new Container(5, cooled), new Container(4, standard), null}
                },
                {
                    { new Container(23, standard), null, null },
                    { new Container(21, standard), null, null },
                    { new Container(20, standard), null, null },
                    { new Container(22, standard), null, null },
                    { new Container(24, standard), null, null }
                },
                {
                    { new Container(19, standard), null, null },
                    { new Container(17, standard), null, null },
                    { new Container(15, standard), null, null },
                    { new Container(16, standard), null, null },
                    { new Container(18, standard), null, null }
                },
                {
                    { new Container(13, standard), null, null },
                    { new Container(11, standard), null, null },
                    { new Container(10, standard), null, null },
                    { new Container(12, standard), null, null },
                    { new Container(14, standard), null, null }
                },
                {
                    { new Container(9, standard), null, null },
                    { new Container(7, standard), null, null },
                    { new Container(5, standard), null, null },
                    { new Container(6, standard), null, null },
                    { new Container(8, standard), null, null }
                }
            };

            Algorithm algorithm = new Algorithm(freighter);

            // Act
            Container[,,] actualContainersSorted = algorithm.Sort(unsortedContainers);

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
        public void Sort_WhenCooledContainersNotEntirelyFilled_ShouldSortStandardAtFront()
        {
            // Arrange
            int freighterLength = 5;
            int freighterWidth = 5;
            int freighterHeight = 3;
            int freighterLoadCapacity = 900000;
            Freighter freighter = new Freighter(freighterWidth, freighterLength, freighterHeight, freighterLoadCapacity);
            List<Container> unsortedContainers = new List<Container>();
            var cooled = Containerschip.Models.Type.Cooled;
            var standard = Containerschip.Models.Type.Standard;

            unsortedContainers.Add(new Container(1, cooled));
            unsortedContainers.Add(new Container(2, cooled));
            unsortedContainers.Add(new Container(3, cooled));
            unsortedContainers.Add(new Container(4, cooled));
            unsortedContainers.Add(new Container(5, cooled));
            unsortedContainers.Add(new Container(6, cooled));
            unsortedContainers.Add(new Container(7, cooled));
            unsortedContainers.Add(new Container(8, cooled));
            unsortedContainers.Add(new Container(9, cooled));
            unsortedContainers.Add(new Container(10, cooled));
            unsortedContainers.Add(new Container(11, cooled));
            unsortedContainers.Add(new Container(12, cooled));
            unsortedContainers.Add(new Container(13, cooled));
            unsortedContainers.Add(new Container(14, cooled));
            unsortedContainers.Add(new Container(15, cooled));


            for (int i = 1; i < 23; i++)
            {
                unsortedContainers.Add(new Container(i, standard));
            }

            Container[,,] expectedContainersSorted = new Container[5, 5, 3]
            {
                {
                    {
                        new Container(15, cooled), new Container(9, cooled), new Container(5, cooled)
                    },
                    {
                        new Container(13, cooled), new Container(7, cooled), new Container(3, cooled)
                    },
                    {
                        new Container(11, cooled), new Container(6, cooled), new Container(1, cooled)
                    },
                    {
                        new Container(12, cooled), new Container(8, cooled), new Container(2, cooled)
                    },
                    {
                        new Container(14, cooled), new Container(10, cooled), new Container(4, cooled)
                    }
                },
                {
                    { new Container(21, standard), new Container(2, standard), null },
                    { new Container(19, standard), null, null },
                    { new Container(18, standard), null, null },
                    { new Container(20, standard), null, null },
                    { new Container(22, standard), new Container(1, standard), null }
                },
                {
                    { new Container(17, standard), null, null },
                    { new Container(15, standard), null, null },
                    { new Container(13, standard), null, null },
                    { new Container(14, standard), null, null },
                    { new Container(16, standard), null, null }
                },
                {
                    { new Container(11, standard), null, null },
                    { new Container(9, standard), null, null },
                    { new Container(8, standard), null, null },
                    { new Container(10, standard), null, null },
                    { new Container(12, standard), null, null }
                },
                {
                    { new Container(7, standard), null, null },
                    { new Container(5, standard), null, null },
                    { new Container(3, standard), null, null },
                    { new Container(4, standard), null, null },
                    { new Container(6, standard), null, null }
                }
            };

            Algorithm algorithm = new Algorithm(freighter);

            // Act
            Container[,,] actualContainersSorted = algorithm.Sort(unsortedContainers);

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
        public void Sort_WhenCooledContainersNotEntirelyFilled2_ShouldSortStandardAtFront()
        {
            // Arrange
            int freighterLength = 5;
            int freighterWidth = 5;
            int freighterHeight = 3;
            int freighterLoadCapacity = 900000;
            Freighter freighter = new Freighter(freighterWidth, freighterLength, freighterHeight, freighterLoadCapacity);
            List<Container> unsortedContainers = new List<Container>();
            var cooled = Containerschip.Models.Type.Cooled;
            var standard = Containerschip.Models.Type.Standard;

            unsortedContainers.Add(new Container(1, cooled));
            unsortedContainers.Add(new Container(2, cooled));
            unsortedContainers.Add(new Container(3, cooled));
            unsortedContainers.Add(new Container(4, cooled));
            unsortedContainers.Add(new Container(5, cooled));
            unsortedContainers.Add(new Container(6, cooled));

            for (int i = 1; i < 31; i++)
            {
                unsortedContainers.Add(new Container(i, standard));
            }

            Container[,,] expectedContainersSorted = new Container[5, 5, 3]
            {
                {
                    {new Container(7, cooled), new Container(2, cooled), null},
                    {new Container(29, cooled), new Container(6, standard), null},
                    {new Container(25, cooled), new Container(2, standard), null},
                    {new Container(19, cooled), null, null},
                    {new Container(15, cooled), null, null}
                },
                {
                    { new Container(5, cooled), new Container(9, standard), null },
                    { new Container(27, standard), new Container(4, standard), null },
                    { new Container(23, standard), null, null },
                    { new Container(17, standard), null, null },
                    { new Container(13, standard), null, null }
                },
                {
                    { new Container(3, cooled), new Container(8, standard), null },
                    { new Container(26, standard), new Container(3, standard), null },
                    { new Container(21, standard), null, null },
                    { new Container(16, standard), null, null },
                    { new Container(11, standard), new Container(1, standard), null }
                },
                {
                    { new Container(4, cooled), new Container(10, standard), null },
                    { new Container(28, standard), new Container(5, standard), null },
                    { new Container(22, standard), null, null },
                    { new Container(18, standard), null, null },
                    { new Container(12, standard), null, null }
                },
                {
                    { new Container(6, cooled), new Container(1, cooled), null },
                    { new Container(30, standard), new Container(7, standard), null },
                    { new Container(24, standard), new Container(1, standard), null },
                    { new Container(20, standard), null, null },
                    { new Container(14, standard), null, null }
                }
            };

            Algorithm algorithm = new Algorithm(freighter);

            // Act
            Container[,,] actualContainersSorted = algorithm.Sort(unsortedContainers);

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
        public void SortStandardContainers_WhenContainersGivenForOneLayer_ShouldSortStandard()
        {
            // Arrange
            const int freighterLength = 5;
            const int freighterWidth = 5;
            const int freighterHeight = 3;
            int freighterLoadCapacity = 900000;
            Freighter freighter = new Freighter(freighterWidth, freighterLength, freighterHeight, freighterLoadCapacity);
            List<Container> unsortedContainers = new List<Container>();
            var standard = Containerschip.Models.Type.Standard;

            for (int i = 1; i < 26; i++)
            {
                unsortedContainers.Add(new Container(i, standard));
            }

            Container[,,] expectedContainersSorted = new Container[freighterWidth, freighterLength, freighterHeight]
            {
                {
                    {new Container(25, standard), null, null},
                    {new Container(19, standard), null, null},
                    {new Container(15, standard), null, null},
                    {new Container(9, standard), null, null},
                    {new Container(5, standard), null, null}
                },
                {
                    { new Container(23, standard), null, null },
                    { new Container(17, standard), null, null },
                    { new Container(13, standard), null, null },
                    { new Container(7, standard), null, null },
                    { new Container(3, standard), null, null }
                },
                {
                    { new Container(21, standard), null, null },
                    { new Container(16, standard), null, null },
                    { new Container(11, standard), null, null },
                    { new Container(6, standard), null, null },
                    { new Container(1, standard), null, null }
                },
                {
                    { new Container(22, standard), null, null },
                    { new Container(18, standard), null, null },
                    { new Container(12, standard), null, null },
                    { new Container(8, standard), null, null },
                    { new Container(2, standard), null, null }
                },
                {
                    { new Container(24, standard), null, null },
                    { new Container(20, standard), null, null },
                    { new Container(14, standard), null, null },
                    { new Container(10, standard), null, null },
                    { new Container(4, standard), null, null }
                }
            };

            Algorithm algorithm = new Algorithm(freighter);

            // Act
            Container[,,] actualContainersSorted = algorithm.SortStandardContainers(unsortedContainers);

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
    }
}
