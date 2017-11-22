using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varian.Common
{
    public static class Extensions
    {
        public static bool IsInBetween(this int n, int min, int max, bool including)
        {
            if (including)
            {
                return n >= min && n <= max;
            }

            return n > min && n < max;
        }
    }
}
