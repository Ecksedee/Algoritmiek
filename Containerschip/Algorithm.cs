using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containerschip.Models
{
    class Algorithm
    {
        private readonly Freighter freighter;

        public Algorithm(int lengthInContainers, int widthInContainers, int heightInContainers, int loadCapacity)
        {
            freighter = new Freighter(lengthInContainers, widthInContainers, heightInContainers, loadCapacity);
        }

        public List<Container> OrderByWeight(List<Container> containers)
        {
            return containers.OrderBy(x => x.Weight).ToList();
        }
    }
}
