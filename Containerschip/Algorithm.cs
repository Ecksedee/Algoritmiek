
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

        public Algorithm(Freighter freighter)
        {
            this.freighter = freighter;
        }

        public List<Container> OrderByWeight(List<Container> containers)
        {
            return containers.OrderBy(x => x.Weight).ToList();
        }

        public Container[,,] Sort(List<Container> unsortedContainers)
        {
            for(int heightCount = 0; heightCount < freighter.Height; heightCount++)
            {
                bool reverse = false;
                for(int lengthCount = 0; lengthCount < freighter.Length; lengthCount++)
                {
                    if(!reverse)
                    {
                        reverse = true;
                        for (int widthCount = 0; widthCount < freighter.Width; widthCount++)
                        {
                            int count = unsortedContainers.Count;
                            freighter.Containers[heightCount, lengthCount, widthCount] = unsortedContainers[count - 1];
                            unsortedContainers.RemoveAt(count - 1);
                        }
                    }
                    else
                    {
                        reverse = false;
                        for(int widthCount = freighter.Width; widthCount > 0; widthCount--)
                        {
                            int count = unsortedContainers.Count;
                            freighter.Containers[heightCount, lengthCount, widthCount - 1] = unsortedContainers[count - 1];
                            unsortedContainers.RemoveAt(count - 1); //ERROR 404 PORN NOT FOUND >:( Wat?
                        }
                    }
                }
            }
            return freighter.Containers;
        }
    }
}
