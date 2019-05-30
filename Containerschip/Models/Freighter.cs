using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containerschip.Models
{
    class Freighter
    {
        private double LengthInContainers { get; set; }
        private double HeightInContainers { get; set; }
        private double WidthInContainers { get; set; }
        private double MaximumCapacity { get; set; }
        private double MinimumWeight { get; set; }
        private Container[,,] ContainerGrid { get; set; }

        public Freighter(int lengthInContainers, int heightInCointainers, int widthInContainers, int maximumCapacity)
        {
            LengthInContainers = lengthInContainers;
            HeightInContainers = heightInCointainers;
            WidthInContainers = widthInContainers;
            MaximumCapacity = maximumCapacity;
            MinimumWeight = CalculateMinimumWeight();
            ContainerGrid = new Container[lengthInContainers, widthInContainers, heightInCointainers];
        }

        /// <summary>
        /// Calculates the minimum weight of the freighter
        /// </summary>
        /// <returns></returns>
        private double CalculateMinimumWeight()
        {
            return Convert.ToDouble(MaximumCapacity / 2);
        }
    }
}
