using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containerschip.Models
{
    public class Freighter
    {
        const int maxAmountOfStackedContainers = (Container.MaxWeightOnTop + Container.MaxWeight) / Container.MaxWeight; 

        public Freighter(int lengthInContainers, int widthInContainers, int heightInCointainers, int loadCapacity)
        {
            Length = lengthInContainers;
            Width = widthInContainers;
            Height = heightInCointainers;
            LoadCapacity = loadCapacity;
            Containers = new Container[widthInContainers, lengthInContainers, heightInCointainers];
            MinimumWeight = CalculateMinimumWeight();
            MaximumWeight = CalculateMaximumWeight();
        }

        public int Length { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int LoadCapacity { get; set; }
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
            return Length * Width * Container.MaxWeight * maxAmountOfStackedContainers;
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

        /// <summary>
        /// Returns a boolean whether the load capacity exceeds the maximum weight of the ship
        /// </summary>
        /// <param name="maximumFreighterweight"></param>
        /// <param name="freighterLoadCapacity"></param>
        /// <returns></returns>
        public static bool CapacityExceedsWeightLimit(int maximumFreighterweight, int freighterLoadCapacity)
        {
            if (freighterLoadCapacity > maximumFreighterweight)
            {
                return true;
            }
            return false;
        }

        //public int NextAvailableSpot(int length, int height)
        //{
        //    for (int x = 0; x < Containers.GetLength(0); x++)
        //    {
        //        if (Containers[x] == 1)
        //        {
        //            if (Containers[(Containers.GetLength(0) - 1) - x] == 0)
        //            {
        //                return (Containers.GetLength(0) - 1) - x;
        //            }
        //        }
        //        else
        //        {
        //            return x;
        //        }
        //    }
        //}
    }
}
