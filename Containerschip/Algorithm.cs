
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

            int containernumber = 0;

            for (int height = 0; height < freighter.Containers.GetLength(2); height++) // Voor elke laag
            {
                int width = 0;
                int widthCounterUp = width;
                int widthCounterDown = freighter.Containers.GetLength(0) - 1;
                bool countUp = false;

                if (containernumber >= cooledContainers.Count)
                {
                    Console.WriteLine("No more containers, ending sorting");
                    break;
                }

                for (int x = 0; x < freighter.Containers.GetLength(0); x++) // Voor elk vak in de breedte
                {
                    if (containernumber >= cooledContainers.Count)
                    {
                        Console.WriteLine("No more containers, ending sorting");
                        break;
                    }

                    if (WeightOnTopOfLowest(width, 0) + cooledContainers[containernumber].Weight < Container.MaxWeightOnTop)
                    {
                        freighter.Containers[width, 0, height] = cooledContainers[containernumber];
                    }
                    else
                    {
                        throw new ArgumentException("The containers could not be sorted because the maximum weight on top of one or more containers exceeds the limit of " + Container.MaxWeightOnTop + " kg");
                    }

                    if (countUp)
                    {
                        width = widthCounterUp;
                        countUp = false;
                    }
                    else
                    {
                        width = widthCounterDown;
                        widthCounterDown--;
                        widthCounterUp++;
                        countUp = true;
                    }

                    containernumber++;
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

