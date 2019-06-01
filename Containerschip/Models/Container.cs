using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containerschip.Models
{
    public class Container
    {
        public const int MaxWeight = 30000;
        public const int MaxWeightOnTop = 120000;

        public Container(int weight, Type type)
        {
            Weight = weight;
            Type = type;
        }

        public int Weight { get; private set; }
        public Type Type { get; private set; }

        public override string ToString()
        {
            return string.Format("Weight: {0} kg, Type: {1}", Weight, Type);
        }
    }

    public enum Type
    {
        Standard,
        Valuable,
        Cooled
    }
}
