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
        /// Returns a boolean whether the entered parameters exceed the limits of the freighter and returns the corresponding error.
        /// </summary>
        /// <param name="maximumFreighterWeight"></param>
        /// <param name="miminumFreighterWeight"></param>
        /// <param name="freighterLoadCapacity"></param>
        /// <param name="totalContainersWeight"></param>
        /// <returns></returns>
        public static bool WeightFailsLimits(int maximumFreighterWeight, double miminumFreighterWeight, int freighterLoadCapacity,  int totalContainersWeight)
        {
            if (totalContainersWeight > freighterLoadCapacity)
            {
                throw new ArgumentException(String.Format("The current weight of {0} kg exceeds the maximum load capacity of the freighter of {1} Kg", totalContainersWeight, freighterLoadCapacity));
            }
            else if (totalContainersWeight > maximumFreighterWeight)
            {
                throw new ArgumentException(String.Format("The current weight of {0} kg exceeds the maximum weight of the freighter of {1} Kg", totalContainersWeight, maximumFreighterWeight));
            }
            else if (totalContainersWeight < miminumFreighterWeight )
            {
                throw new ArgumentException(String.Format("The current weight: {0} kg fails to reach the minimum amount of {1} kg required.", totalContainersWeight, miminumFreighterWeight));
            }
            return false;
        }
    }
}
