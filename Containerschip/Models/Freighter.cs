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

        public Freighter(int widthInContainers, int lengthInContainers, int heightInCointainers)
        {
            Length = lengthInContainers;
            Width = widthInContainers;
            Height = heightInCointainers;
            Containers = new Container[widthInContainers, lengthInContainers, heightInCointainers];
            MaximumWeight = CalculateMaximumWeight();
            MinimumWeight = CalculateMinimumWeight();
        }

        public int Length { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public double MinimumWeight { get; private set; }
        public int MaximumWeight { get; private set; }
        public Container[,,] Containers { get; set; }
        public double Balance { get; set; }

        /// <summary>
        /// Calculates the minimum weight of the freighter.
        /// </summary>
        /// <returns></returns>
        private double CalculateMinimumWeight()
        {
            return Convert.ToDouble(MaximumWeight / 2);
        }

        /// <summary>
        /// Calculates the maximum weight of the freighter.
        /// </summary>
        /// <returns></returns>
        private int CalculateMaximumWeight()
        {
            return Length * Width * Height * Container.MaxWeight;
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

            if (totalContainersWeight > MaximumWeight)
            {
                throw new ArgumentException(String.Format("The current weight of {0} kg exceeds the maximum weight of the freighter of {1} Kg", totalContainersWeight, MaximumWeight));
            }
            else if (totalContainersWeight < MinimumWeight )
            {
                throw new ArgumentException(String.Format("The current weight: {0} kg fails to reach the minimum amount of {1} kg required.", totalContainersWeight, MinimumWeight));
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
                    if (Containers[(Containers.GetLength(0) - 1) - x, length, height] == null
                    && (height == 0
                    || (Containers[(Containers.GetLength(0) - 1) - x, length, height - 1] != null
                    && Containers[(Containers.GetLength(0) - 1) - x, length, height - 1].Type != Type.Valuable))) //Er is geen container op de meest rechtse positie
                    {
                        return (Containers.GetLength(0) - 1) - x;
                    }
                    else if (Containers[x, length, height] == null
                    && (height == 0
                    || (Containers[x, length, height - 1] != null
                    && Containers[x, length, height - 1].Type != Type.Valuable))) //Er is geen container op de meest linkse positie
                    {
                        return x;
                    }
                }
                else
                {
                    if (Containers[x, length, height] == null
                    && (height == 0
                    || (Containers[x, length, height - 1] != null
                    && Containers[x, length, height - 1].Type != Type.Valuable))) //Er is geen container op de meest linkse positie
                    {
                        return x;
                    }
                    else if (Containers[(Containers.GetLength(0) - 1) - x, length, height] == null
                    && (height == 0
                    || (Containers[(Containers.GetLength(0) - 1) - x, length, height - 1] != null
                    && Containers[(Containers.GetLength(0) - 1) - x, length, height - 1].Type != Type.Valuable))) //Er is geen container op de meest rechtse positie
                    {
                        return (Containers.GetLength(0) - 1) - x;
                    }
                }
                if (x > (Containers.GetLength(0) - 1) - x) //We zijn over het midden heen we kunnen stoppen
                {
                    return -1;
                }
            }
            return -1;
        }

        public double CalculateBalance()
        {
            double weightLeft = 0;
            double weightRight = 0;
            double weightDifference;

            if (Width % 2 == 0) // Width is even
            {
                for (int height = 0; height < Height; height++)
                {
                    for (int length = 0; length < Length; length++)
                    {
                        for (int width = 0; width < Width / 2; width++)
                        {
                            if (Containers[width, length, height] == null)
                            {
                                weightLeft += 0;
                            }
                            else
                            {
                                weightLeft += Containers[width, length, height].Weight;
                            }
                        }
                        for (int width = Width / 2; width < Width; width++)
                        {
                            if (Containers[width, length, height] == null)
                            {
                                weightRight += 0;
                            }
                            else
                            {
                                weightRight += Containers[width, length, height].Weight;
                            }
                        }
                    }
                }
                weightDifference = (weightLeft - weightRight) / weightRight * 100;
            }
            else // Width is uneven
            {
                for (int height = 0; height < Height; height++)
                {
                    for (int length = 0; length < Length; length++)
                    {
                        for (int width = 0; width < Width / 2 - 0.5; width++)
                        {
                            if (Containers[width, length, height] == null)
                            {
                                weightLeft += 0;
                            }
                            else
                            {
                                weightLeft += Containers[width, length, height].Weight;
                            }
                        }
                        for (double width = (double)Width / 2 + 0.5; width < Width; width++)
                        {
                            if (Containers[(int)width, length, height] == null)
                            {
                                weightRight += 0;
                            }
                            else
                            {
                                weightRight += Containers[(int)width, length, height].Weight;
                            }
                        }
                    }
                }
                weightDifference = (weightLeft - weightRight) / weightRight * 100;
            }
            return weightDifference;
        }
    }
}
