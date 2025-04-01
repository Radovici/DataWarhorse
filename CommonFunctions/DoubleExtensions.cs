using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFunctions
{
    public static class DoubleExtensions
    {
        public static bool IsZero(this double value)
        {
            return (Math.Abs(value) < 0.00001); // Double.Epsilon);
        }

        public static DateTime Min(DateTime dt1, DateTime dt2) { return dt1 < dt2 ? dt1 : dt2; }
    }
}
