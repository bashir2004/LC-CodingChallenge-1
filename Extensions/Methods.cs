using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class Methods
    {
        public static double Truncate(this double value, int precision = 2)
        {
            double step = (double)Math.Pow(10, precision);
            double tmp = Math.Truncate(step * value);
            return tmp / step;
        }
        public static decimal Truncate(this decimal value, int precision = 2)
        {
            decimal step = (decimal)Math.Pow(10, precision);
            decimal tmp = Math.Truncate(step * value);
            return tmp / step;
        }
    }
}
