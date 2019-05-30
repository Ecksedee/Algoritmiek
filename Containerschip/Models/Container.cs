using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containerschip.Models
{
    public class Container
    {
        public const int MaximumWeight = 30000;
        public int Weight { get; private set; }
    }
}
