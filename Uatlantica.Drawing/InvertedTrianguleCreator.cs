
using System.Drawing;
namespace Uatlantica.Drawing
{
    internal class InvertedTrianguleCreator
    {

        private int[] intDistribution;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockAggregator" /> class.
        /// </summary>
        /// <param name="Distribution">The distribution.</param>
        public InvertedTrianguleCreator(int[] Distribution)
        {
            intDistribution = Distribution;
        }

        /// <summary>
        /// To the image.
        /// </summary>
        /// <param name="ImageBase">The image base.</param>
        /// <returns></returns>
        public Image ToImage(Image ImageBase)
        {
            Rectangle rect;
            Image invertedTrianguleImage = Properties.Resources.InvertedTriangule;

            Image img = new Bitmap(ImageBase.Width, ImageBase.Height + (invertedTrianguleImage.Height * 2) + 15);
            Graphics g = Graphics.FromImage(img);
            StatisticalChart.SetGraphics(ref g);

            g.DrawImage(ImageBase, new Rectangle(0, 0, ImageBase.Width, ImageBase.Height));

            for (int i = 0; i < intDistribution.Length; i++)
            {                
                Image block = Properties.Resources.Celula_Vazia;

                Point p2 = Math.GetCenter(invertedTrianguleImage.Width, invertedTrianguleImage.Height);
                Point p1 = Math.GetCenter(block.Width, block.Height);

                int x = 0, y = 0;

                if (i == 0)
                {
                    x = (p1.X - p2.X);
                }
                else
                {
                    x = (p1.X - p2.X) + ((block.Width - 2) * i);
                }

                y = (ImageBase.Height + 5);
                rect = new Rectangle(x, y, invertedTrianguleImage.Width, invertedTrianguleImage.Height);
                g.DrawImage(invertedTrianguleImage, rect);

                y += (invertedTrianguleImage.Height + 5);
                rect = new Rectangle(x, y, invertedTrianguleImage.Width, invertedTrianguleImage.Height);
                StatisticalChart.SetText(ref g, rect, (i + 1).ToString(), 26, Color.Gray);
            }

            g.Dispose();
            return img;
        }

    }
}
