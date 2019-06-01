
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
            List<Container> cooledContainers = GetCooledContainersByWeight();

            SortCooledContainers(cooledContainers);
        }

        /// <summary>
        /// Sorts all the cooled containers on the first row of the ship
        /// </summary>
        /// <param name="cooledContainers"></param>
        public Container[,,] SortCooledContainers(List<Container> cooledContainers)
        {
            int containernumber = 0;

            for (int height = 0; height < freighter.Containers.GetLength(2); height++) // Voor elke laag
            {
                int width = 0;
                int widthCounterUp = width;
                int widthCounterDown = freighter.Containers.GetLength(0) - 1;
                bool countUp = false;

                if (containernumber >= cooledContainers.Count)
                {
                    break;
                }

                for (int x = 0; x < freighter.Containers.GetLength(0); x++) // Voor elk vak in de breedte
                {
                    freighter.Containers[width, 0, height] = cooledContainers[containernumber];

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

        /// <summary>
        /// Returns all containers of type cooled sorted by weight
        /// </summary>
        /// <returns></returns>
        public List<Container> GetCooledContainersByWeight()
        {
            return unsortedList.Where(x => x.Type == Type.Cooled).OrderByDescending(x => x.Weight).ToList();
        }
    }
}

//public Container[,,] Sort(List<Container> unsortedContainers)
//{
//    for(int heightCount = 0; heightCount < freighter.Height; heightCount++)
//    {
//        bool reverse = false;
//        for(int lengthCount = 0; lengthCount < freighter.Length; lengthCount++)
//        {
//            if(!reverse)
//            {
//                reverse = true;
//                for (int widthCount = 0; widthCount < freighter.Width; widthCount++)
//                {
//                    int count = unsortedContainers.Count;
//                    freighter.Containers[heightCount, lengthCount, widthCount] = unsortedContainers[count - 1];
//                    unsortedContainers.RemoveAt(count - 1);
//                }
//            }
//            else
//            {
//                reverse = false;
//                for(int widthCount = freighter.Width; widthCount > 0; widthCount--)
//                {
//                    int count = unsortedContainers.Count;
//                    freighter.Containers[heightCount, lengthCount, widthCount - 1] = unsortedContainers[count - 1];
//                    unsortedContainers.RemoveAt(count - 1); //ERROR 404 PORN NOT FOUND >:( Wat?
//                }
//            }
//        }
//    }
//    return freighter.Containers;
//}
