using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containerschip.Models
{
    public class Freighter
    {
        public int LengthInContainers { get; private set; }
        public int WidthInContainers { get; private set; }
        public int HeightInContainers { get; private set; }
        public int LoadCapacity { get; private set; }
        public double MinimumWeight { get; private set; }
        public int MaximumWeight { get; private set; }
        public Container[,,] ContainerGrid { get; private set; }

        public Freighter(int lengthInContainers, int widthInContainers, int heightInCointainers, int loadCapacity)
        {
            LengthInContainers = lengthInContainers;
            WidthInContainers = widthInContainers;
            HeightInContainers = heightInCointainers;
            LoadCapacity = loadCapacity;
            ContainerGrid = new Container[lengthInContainers, widthInContainers, heightInCointainers];
            MinimumWeight = CalculateMinimumWeight();
            MaximumWeight = CalculateMaximumWeight();
        }

        /// <summary>
        /// Calculates the minimum weight of the freighter.
        /// </summary>
        /// <returns></returns>
        private double CalculateMinimumWeight()
        {
            return Convert.ToDouble(LoadCapacity / 2);
        }

        /// <summary>
        /// Calculates the maximum weight of the freighter.
        /// </summary>
        /// <returns></returns>
        private int CalculateMaximumWeight()
        {
            return LengthInContainers * WidthInContainers * HeightInContainers * Container.MaximumWeight;
        }

        /// <summary>
        /// Returns a boolean whether the load capacity of the freighter exceeds the maximimum weight.
        /// </summary>
        /// <param name="maximumFreighterWeight"></param>
        /// <param name="FreighterLoadCapacity"></param>
        /// <returns></returns>
        public static bool CapacityExceedsMaxWeight(int maximumFreighterWeight, int freighterLoadCapacity)
        {
            if (freighterLoadCapacity > maximumFreighterWeight)
            {
                return true;
            }
            return false;
        }
    }
}
