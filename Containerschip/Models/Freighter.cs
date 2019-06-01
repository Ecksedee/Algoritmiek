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

        public Freighter(int widthInContainers, int lengthInContainers, int heightInCointainers, int loadCapacity)
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
        /// Returns the amount of cooled containers the ship can carry
        /// </summary>
        private int MaxAmountOfCooledContainers()
        {
            return Width * Height;
        }

        /// <summary>
        /// Returns a boolean whether the entered parameters exceed the limits of the freighter and returns the corresponding error.
        /// </summary>
        /// <param name="maximumFreighterWeight"></param>
        /// <param name="miminumFreighterWeight"></param>
        /// <param name="freighterLoadCapacity"></param>
        /// <param name="totalContainersWeight"></param>
        /// <returns></returns>
        public bool WeightFailsLimits(List<Container> _containers)
        {
            List<Container> containers = _containers;
            int totalContainersWeight = containers.Sum(x => x.Weight);

            if (totalContainersWeight > LoadCapacity)
            {
                throw new ArgumentException(String.Format("The current weight of {0} kg exceeds the maximum load capacity of the freighter of {1} Kg", totalContainersWeight, LoadCapacity));
            }
            else if (totalContainersWeight > MaximumWeight)
            {
                throw new ArgumentException(String.Format("The current weight of {0} kg exceeds the maximum weight of the freighter of {1} Kg", totalContainersWeight, MaximumWeight));
            }
            else if (totalContainersWeight < MinimumWeight )
            {
                throw new ArgumentException(String.Format("The current weight: {0} kg fails to reach the minimum amount of {1} kg required.", totalContainersWeight, MinimumWeight));
            }
            return false;
        }

        /// <summary>
        /// Returns a boolean whether the load capacity exceeds the maximum weight of the ship
        /// </summary>
        /// <param name="maximumFreighterweight"></param>
        /// <param name="freighterLoadCapacity"></param>
        /// <returns></returns>
        public bool CapacityExceedsWeightLimit()
        {
            if (LoadCapacity > MaximumWeight)
            {
                return true;
            }
            return false;
        }

        public bool CooledContainersExceedsMaximum(List<Container> containers)
        {
            List<Container> cooledContainers = containers.Where(x => x.Type == Type.Cooled).ToList();

            if (cooledContainers.Count > MaxAmountOfCooledContainers())
            {
                throw new ArgumentException(String.Format("The current amount of cooled containers: {0} exceeds the maximum amount of {1} containers.", cooledContainers.Count, MaxAmountOfCooledContainers()));
            }
            return false;
        }

        public int GetNextAvailableSpot(int length, int height, bool rightToLeft)
        {
            for (int x = 0; x < Containers.GetLength(0); x++) //Voor de hele breedte
            {
                if (rightToLeft)
                {
                    if (Containers[(Containers.GetLength(0) - 1) - x, length, height] == null) //Er is geen container op de meest rechtse positie
                    {
                        return (Containers.GetLength(0) - 1) - x;
                    }
                    else if (Containers[x, length, height] == null) //Er is geen container op de meest linkse positie
                    {
                        return x;
                    }
                }
                else
                {
                    if (Containers[x, length, height] == null) //Er is geen container op de meest linkse positie
                    {
                        return x;
                    }
                    else if (Containers[(Containers.GetLength(0) - 1) - x, length, height] == null) //Er is geen container op de meest rechtse positie
                    {
                        return (Containers.GetLength(0) - 1) - x;
                    }
                }

                if (x > (Containers.GetLength(0) - 1) - x) //We zijn over het midden heen we kunnen stoppen
                {
                    break;
                }
            }

            return -1;
        }
    }
}
