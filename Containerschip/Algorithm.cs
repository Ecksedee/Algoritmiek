
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Sort(List<Container> _unsortedList)
        {
            unsortedList = _unsortedList;
            List<Container> cooledContainers = GetCooledContainers();
            SortCooledContainers(cooledContainers);
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
    }
}

