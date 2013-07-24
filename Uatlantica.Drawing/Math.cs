using System;
using System.Drawing;

namespace Uatlantica.Drawing
{
    internal class Math
    {

        /// <summary>
        /// Gets the center.
        /// </summary>
        /// <param name="Width">The width.</param>
        /// <param name="Height">The height.</param>
        /// <returns></returns>
        public static Point GetCenter(int Width, int Height)
        {
            decimal d1 = decimal.Divide(Width, 2);
            decimal d2 = decimal.Divide(Height, 2);

            return new Point(Convert.ToInt32(d1), Convert.ToInt32(d2));
        }

        /// <summary>
        /// Gets the percentage.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public static int GetPercentage(int[] Distribution, int index)
        {
            decimal t = 0;

            for (int i = 0; i < Distribution.Length; i++)
            {
                t = decimal.Add(t, Distribution[i]);
            }

            // Regra de tres simples
            decimal d = 0;
            d = decimal.Divide(decimal.Multiply(Distribution[index], 100), t);

            return Convert.ToInt32(d);
        }
    }
}
