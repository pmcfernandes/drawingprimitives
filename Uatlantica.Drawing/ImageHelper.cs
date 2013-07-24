using System.Drawing;

namespace Uatlantica.Drawing
{
    internal class ImageHelper
    {
        /// <summary>
        /// Fit to best scale
        /// </summary>
        /// <param name="currentWidth">Width of the current.</param>
        /// <param name="currentHeight">Height of the current.</param>
        /// <param name="maxSize">Size of the max.</param>
        /// <returns></returns>
        public static Size BestFit(int currentWidth, int currentHeight, int maxSize)
        {
            decimal tempMultiplier;

            if (currentHeight > currentWidth)
            {
                // Portrait
                tempMultiplier = decimal.Divide(maxSize, currentHeight);
                if ((currentWidth * tempMultiplier) > currentWidth)
                {
                    tempMultiplier /= 2;
                }
            }
            else
            {
                // Landscape
                tempMultiplier = decimal.Divide(maxSize, currentWidth);
                if ((currentHeight * tempMultiplier) > currentHeight)
                {
                    tempMultiplier /= 2;
                }
            }

            return new Size((int)(currentWidth * tempMultiplier), (int)(currentHeight * tempMultiplier));
        }

        /// <summary>
        /// Resizes to.
        /// </summary>
        /// <param name="img">The img.</param>
        /// <param name="Width">The width.</param>
        /// <returns></returns>
        public static Image ResizeTo(Image img, int Width)
        {
            Size size = BestFit(img.Width, img.Height, Width);
            return new Bitmap(img, size.Width, size.Height);
        }
    }
}
