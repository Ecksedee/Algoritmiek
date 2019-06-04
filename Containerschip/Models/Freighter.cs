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
            return 1; //Convert.ToDouble(MaximumWeight / 2);
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
            else if (totalContainersWeight < MinimumWeight)
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

        public int GetNextAvailableSpot(int length, int height, bool leftToRight)
        {
            for (int x = 0; x < Width; x++) //Voor de hele breedte
            {
                if (leftToRight) // Boolean bepaalt waar eerst gekeken wordt
                {
                    if (Containers[(Width - 1) - x, length, height] == null // Als er op de uiterste width (rechterkant) niks staat
                    && (height == 0 || (Containers[(Width - 1) - x, length, height - 1] != null && Containers[(Width - 1) - x, length, height - 1].Type != Type.Valuable))) // EN de container eronder is niet valuable
                    {
                        return (Width - 1) - x; // De plek is vrij
                    }
                    else if (Containers[x, length, height] == null // Anders als er op de andere uiterste kant niks staat
                    && (height == 0 || (Containers[x, length, height - 1] != null && Containers[x, length, height - 1].Type != Type.Valuable))) // EN de container eronder is niet valuable
                    {
                        return x;  // De plek is vrij
                    }
                }
                else  // Hetzelfde maar van de andere kant beginnen
                {
                    if (Containers[x, length, height] == null
                    && (height == 0 || (Containers[x, length, height - 1] != null && Containers[x, length, height - 1].Type != Type.Valuable))) 
                    {
                        return x;
                    }
                    else if (Containers[(Width - 1) - x, length, height] == null
                    && (height == 0 || (Containers[(Width - 1) - x, length, height - 1] != null && Containers[(Width - 1) - x, length, height - 1].Type != Type.Valuable))) 
                    {
                        return (Width - 1) - x;
                    }
                }
                if (x > (Width - 1) - x) //Zodra we over het midden van de width zijn kunnen we stoppen
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
            double totalWeight = 0;

            for (int height = 0; height < Height; height++)
            {
                for (int length = 0; length < Length; length++)
                {
                    for (int width = 0; width < Width; width++) // Door alle vakken iteraten
                    {
                        if (Containers[width, length, height] != null && width < Width / 2) // != null check zodat hij lege containers niet mee neemt
                        {                                                                   // en width kleiner dan de helft voor 1 helft
                            weightLeft += Containers[width, length, height].Weight;
                            totalWeight += Containers[width, length, height].Weight;
                        }
                        else if (Containers[width, length, height] != null && width >= Width / 2 && Width % 2 == 0) // width groter of gelijk dan de helft als het even is
                        {
                            weightRight += Containers[width, length, height].Weight;
                            totalWeight += Containers[width, length, height].Weight;
                        }
                        else if (Containers[width, length, height] != null && width > Width / 2) // Width groter dan de helft als het oneven is
                        {
                            weightRight += Containers[width, length, height].Weight;
                            totalWeight += Containers[width, length, height].Weight;
                        }
                    }
                }
            }
            return Math.Round(((weightLeft / totalWeight) - (weightRight / totalWeight)) * 100, 1);
        }
    }
}