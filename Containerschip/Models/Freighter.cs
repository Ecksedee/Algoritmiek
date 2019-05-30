using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containerschip.Models
{
    public class Freighter
    {
        public Freighter(int lengthInContainers, int widthInContainers, int heightInCointainers, int loadCapacity)
        {
            Length = lengthInContainers;
            Width = widthInContainers;
            Height = heightInCointainers;
            LoadCapacity = loadCapacity;
            Containers = new Container[lengthInContainers, widthInContainers, heightInCointainers];
            MinimumWeight = CalculateMinimumWeight();
            MaximumWeight = CalculateMaximumWeight();
        }

        public int Length { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int LoadCapacity { get; private set; }
        public double MinimumWeight { get; private set; }
        public int MaximumWeight { get; private set; }
        public Container[,,] Containers { get; private set; }

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
            return Length * Width * Height * Container.MaximumWeight;
        }

        /// <summary>
        /// Returns a boolean whether the load capacity of the freighter exceeds the maximimum weight.
        /// </summary>
        /// <param name="maximumFreighterWeight"></param>
        /// <param name="FreighterLoadCapacity"></param>
        /// <returns></returns>
        public static bool WeightExceedsMaxWeight(int maximumFreighterWeight, int totalContainersWeight)
        {
            if (totalContainersWeight > maximumFreighterWeight)
            {
                throw new ArgumentException("The total weight of the containers exceeds the maximum weight of the ship of " + maximumFreighterWeight + "Kg");
            }
            return false;
            
        }

        public static bool WeightExceedsCapacity(int freighterLoadCapacity, int totalContainersWeight)
        {
            if (totalContainersWeight > freighterLoadCapacity)
            {
                return false;
            }
            throw new ArgumentException("The total weight of the containers exceeds the maximum load capacity of the ship of " + freighterLoadCapacity + "Kg");
        }
    }
}
