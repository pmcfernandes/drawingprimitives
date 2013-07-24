
using System.Drawing;
namespace Uatlantica.Drawing
{
    internal class BlockAggregator
    {
        private int[] intDistribution;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockAggregator" /> class.
        /// </summary>
        /// <param name="Distribution">The distribution.</param>
        public BlockAggregator(int[] Distribution)
        {
            intDistribution = Distribution;
        }

        /// <summary>
        /// To the image.
        /// </summary>
        /// <returns></returns>
        public Image ToImage()
        {
            Image img = new Bitmap(Properties.Resources.Celula_Vazia.Width * intDistribution.Length, Properties.Resources.Celula_Vazia.Height);
            Graphics g = Graphics.FromImage(img);
            StatisticalChart.SetGraphics(ref g);

            int x = 0;

            for (int i = 0; i < intDistribution.Length; i++)
            {               
                Image block = BlockCreator.GetBlock(intDistribution, i);
                if (i > 0)
                {
                    x += (block.Width - 2);
                }

                g.DrawImage(block, new Rectangle(x, 0, block.Width,block.Height));
            }

            g.Dispose();
            return img;
        }
    }
}
