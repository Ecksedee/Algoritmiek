
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Containerschip.Models
{
    public class Algorithm
    {
        private readonly Freighter freighter;
        private List<Container> unsortedList;

        public Algorithm(Freighter freighter)
        {
            this.freighter = freighter;
        }

        public Container[,,] Sort(List<Container> _unsortedList)
        {
            unsortedList = _unsortedList;
            List<Container> cooledContainers = GetCooledContainers();
            List<Container> standardContainers = GetStandardContainers();
            List<Container> valuableContainers = GetValuableContainers();

            SortCooledContainers(cooledContainers);
            SortStandardContainers(standardContainers);
            SortValuableContainers(valuableContainers);

            return freighter.Containers;
        }

        public Container[,,] SortValuableContainers(List<Container> valuableContainers)
        {
            valuableContainers = SortContainersByWeight(valuableContainers);

            int height = 0;
            int length = 0;
            bool order = false;
            bool skipRow = false;

            foreach (Container container in valuableContainers)
            {
                int nextSpot = freighter.GetNextAvailableSpot(length, height, order);
                if (nextSpot == -1)
                {
                    if (length == freighter.Containers.GetLength(1) - 1)
                    {
                        if (height == freighter.Containers.GetLength(2) - 1)
                        {
                            throw new ArgumentException("The containers could not be sorted because the ship is full!");
                        }
                        else
                        {
                            height++;
                        }

                        length = 0;
                    }
                    else
                    {
                        length++;
                    }
                    if (skipRow)
                    {
                        length++;
                    }

                    order = !order;
                    nextSpot = freighter.GetNextAvailableSpot(length, height, order);
                }

                if (!skipRow)
                {
                    if (length >= 1)
                    {
                        skipRow = !skipRow;
                    }
                }
                else
                {
                    skipRow = !skipRow;
                }

                if (nextSpot != -1)
                {
                    if (WeightOnTopOfLowest(nextSpot, length) + container.Weight < Container.MaxWeightOnTop)
                    {
                        freighter.Containers[nextSpot, length, height] = container;
                    }
                    else
                    {
                        throw new ArgumentException("The containers could not be sorted because the maximum weight on top of one or more containers exceeds the limit of " + Container.MaxWeightOnTop + " kg");
                    }
                }
                else
                {
                    throw new ArgumentException("The containers could not be sorted because the ship is full!");
                }

            }
            return freighter.Containers;
        }

        /// <summary>
        /// Sorts all the cooled containers on the first row of the ship
        /// </summary>
        /// <param name="cooledContainers"></param>
        public Container[,,] SortCooledContainers(List<Container> cooledContainers)
        {
            cooledContainers = SortContainersByWeight(cooledContainers);

            int height = 0;
            bool order = false;

            foreach (Container container in cooledContainers)
            {
                int nextSpot = freighter.GetNextAvailableSpot(0, height, order);
                if (nextSpot == -1)
                {
                    height++;
                    order = !order;
                    nextSpot = freighter.GetNextAvailableSpot(0, height, order);
                }

                if (WeightOnTopOfLowest(nextSpot, 0) + container.Weight < Container.MaxWeightOnTop)
                {
                    freighter.Containers[nextSpot, 0, height] = container;
                }
                else
                {
                    throw new ArgumentException("The containers could not be sorted because the maximum weight on top of one or more containers exceeds the limit of " + Container.MaxWeightOnTop + " kg");
                }
            }
            return freighter.Containers;
        }

        public Container[,,] SortStandardContainers(List<Container> standardContainers)
        {
            standardContainers = SortContainersByWeight(standardContainers);

            int height = 0;
            int length = 0;
            bool order = false;

            foreach (Container container in standardContainers)
            {
                int nextSpot = freighter.GetNextAvailableSpot(length, height, order);
                if (nextSpot == -1)
                {
                    if (length == freighter.Containers.GetLength(1) - 1)
                    {
                        if (height == freighter.Containers.GetLength(2) - 1)
                        {
                            throw new ArgumentException("The containers could not be sorted because the ship is full!");
                        }
                        else
                        {
                            height++;
                        }

                        length = 0;
                    }
                    else
                    {
                        length++;
                    }

                    order = !order;
                    nextSpot = freighter.GetNextAvailableSpot(length, height, order);
                }

                if (WeightOnTopOfLowest(nextSpot, length) + container.Weight < Container.MaxWeightOnTop)
                {
                    freighter.Containers[nextSpot, length, height] = container;
                }
                else
                {
                    throw new ArgumentException("The containers could not be sorted because the maximum weight on top of one or more containers exceeds the limit of " + Container.MaxWeightOnTop + " kg");
                }
            }
            return freighter.Containers;
        }

        public int WeightOnTopOfLowest(int width, int length)
        {
            int totalWeightOnTop = 0;

            for (int height = 1; height < freighter.Containers.GetLength(2); height++)
            {
                Container container = freighter.Containers[width, length, height];

                if (container == null)
                {
                    Console.WriteLine("No more containers on top");
                    break;
                }
                totalWeightOnTop += freighter.Containers[width, length, height].Weight;
            }


            return totalWeightOnTop;
        }

        /// <summary>
        /// Returns all containers sorted by weight
        /// </summary>
        /// <returns></returns>
        public List<Container> SortContainersByWeight(List<Container> containers)
        {
            return containers.OrderByDescending(x => x.Weight).ToList();
        }

        private List<Container> GetCooledContainers()
        {
            return unsortedList.Where(x => x.Type == Type.Cooled).ToList();
        }

        private List<Container> GetStandardContainers()
        {
            return unsortedList.Where(x => x.Type == Type.Standard).ToList();
        }

        private List<Container> GetValuableContainers()
        {
            return unsortedList.Where(x => x.Type == Type.Valuable).ToList();
        }
    }
}

