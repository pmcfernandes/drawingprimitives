using System.Drawing;

namespace Uatlantica.Drawing
{
    internal class BlockCreator
    {
        /// <summary>
        /// Gets the block.
        /// </summary>
        /// <param name="Distribution">The distribution.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public static Image GetBlock(int[] Distribution, int index)
        {
            return ComposeRectangule(Math.GetPercentage(Distribution, index));
        }

        /// <summary>
        /// Composes the rectangule.
        /// </summary>
        /// <param name="percentage">The percentage.</param>
        /// <returns></returns>
        private static Image ComposeRectangule(int percentage)
        {
            Image imgBase = GetRectanguleByPercentage(percentage);

            Graphics g = Graphics.FromImage(imgBase);
            StatisticalChart.SetGraphics(ref g);
            g.DrawImageUnscaled(Properties.Resources.Celula_Vazia, 0, 0);
            g.Dispose();

            return imgBase;
        }

        /// <summary>
        /// Gets the rectangule by percentage.
        /// </summary>
        /// <param name="percentage">The percentage.</param>
        /// <returns></returns>
        private static Image GetRectanguleByPercentage(int percentage)
        {
            if (percentage == 0)
            {
                return Properties.Resources.Celula_Vazia;
            }
            else if (percentage > 0 && percentage < 20)
            {
                return Properties.Resources.Celula_0_20;
            }
            else if (percentage >= 20 && percentage < 40)
            {
                return Properties.Resources.Celula_20_40;
            }
            else if (percentage >= 40 && percentage < 60)
            {
                return Properties.Resources.Celula_40_60;
            }
            else if (percentage >= 60 && percentage < 80)
            {
                return Properties.Resources.Celula_60_80;
            }
            else if (percentage >= 80)
            {
                return Properties.Resources.Celula_80_100;
            }

            return null;
        }
    }
}
