using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Test
{
    public class Helper
    {
        /// <summary>
        /// Calculates the variance.
        /// using sample variance formula.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns></returns>
        public static double CalculateVariance(double first, double second)
        {
            // mean
            double avg = (first + second) / 2;

            // No need to divide as n-1 = 1;
            return square(first - avg) + square(first - avg);
        }

        private static double square(double x)
        {
            return x * x;
        }
    }
}
