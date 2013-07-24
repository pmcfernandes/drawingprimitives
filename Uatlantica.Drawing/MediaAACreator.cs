using System;
using System.Drawing;

namespace Uatlantica.Drawing
{
    internal class MediaAACreator
    {
        private float intMedia;
        private int[] intDistribution;
        private string strStringFormat;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaAACreator" /> class.
        /// </summary>
        /// <param name="Distribution">The distribution.</param>
        /// <param name="Media">The media.</param>
        /// <param name="StringFormat">The string format.</param>
        public MediaAACreator(int[] Distribution, float Media, string StringFormat)
        {
            intMedia = Media;
            intDistribution = Distribution;
            strStringFormat = StringFormat;
        }

        /// <summary>
        /// To the image.
        /// </summary>
        /// <param name="ImageBase">The image base.</param>
        /// <returns></returns>
        public Image ToImage(Image ImageBase)
        {
            int borderWidth = (Properties.Resources.Celula_Vazia.Width / 2);

            Image indicatorImage = Properties.Resources.IndicadorAA;
            Image img = new Bitmap(ImageBase.Width + (borderWidth * 2), ImageBase.Height + indicatorImage.Height);

            Graphics g = Graphics.FromImage(img);
            StatisticalChart.SetGraphics(ref g);

            Graphics g2 = Graphics.FromImage(indicatorImage);
            StatisticalChart.SetGraphics(ref g2);
            StatisticalChart.SetText(ref g2, new Rectangle(0, 0, indicatorImage.Width, indicatorImage.Height - 30), intMedia.ToString(strStringFormat), 58, Color.Black);

            decimal d = CalculateDistance(0, ImageBase.Width);

            g.DrawImage(ImageBase, new Rectangle(borderWidth, (img.Height - ImageBase.Height), ImageBase.Width, ImageBase.Height));
            g.DrawImage(indicatorImage, new Rectangle(borderWidth + Convert.ToInt32(d), 30, indicatorImage.Width, indicatorImage.Height));

            g.Dispose();
            return img;
        }

        /// <summary>
        /// Calculates the distance.
        /// </summary>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <returns></returns>
        public decimal CalculateDistance(int min, int max)
        {
            float t = (max - min);

            decimal x = decimal.Multiply(decimal.Parse(t.ToString()), decimal.Parse((intMedia - 1).ToString()));
            x = decimal.Divide(x, intDistribution.Length);

            decimal d = decimal.Parse(intMedia.ToString());
            d = decimal.Multiply(d, 2);

            return (x - 23) - d;
        }
    }
}
