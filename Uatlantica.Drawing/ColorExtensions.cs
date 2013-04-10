using System.Drawing;

namespace Uatlantica.Drawing
{

    public static class ColorExtensions
    {

        /// <summary>
        /// Lerps the specified start.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        public static float Lerp(this float start, float end, float amount)
        {
            return start + (end - start) * amount;
        }

        /// <summary>
        /// Lerps the specified colour.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <param name="to">To.</param>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        public static Color Lerp(this Color colour, Color to, float amount)
        {
            // start colours as lerp-able floats
            float sr = colour.R;
            float sg = colour.G;
            float sb = colour.B;

            // end colours as lerp-able floats
            float er = to.R;
            float eg = to.G;
            float eb = to.B;

            // lerp the colours to get the difference
            byte r = (byte)sr.Lerp(er, amount),
                 g = (byte)sg.Lerp(eg, amount),
                 b = (byte)sb.Lerp(eb, amount);

            // return the new colour
            return Color.FromArgb(r, g, b);
        }
    }
}
