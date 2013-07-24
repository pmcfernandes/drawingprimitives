
using System.Drawing;
namespace Uatlantica.Drawing
{
    internal class ModaCreator
    {
        private int intModa;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaCreator" /> class.
        /// </summary>
        /// <param name="Media">The media.</param>
        public ModaCreator(int Moda)
        {
            intModa = Moda;
        }

        /// <summary>
        /// To the image.
        /// </summary>
        /// <param name="ImageBase">The image base.</param>
        /// <returns></returns>
        public Image ToImage(Image ImageBase)
        {
            Image imgModa = Properties.Resources.moda;
            Image img = new Bitmap(ImageBase.Width, ImageBase.Height + (imgModa.Height / 2));
            
            Graphics g = Graphics.FromImage(img);
            StatisticalChart.SetGraphics(ref g);

            g.DrawImage(ImageBase, new Rectangle(0, img.Height - ImageBase.Height, ImageBase.Width, ImageBase.Height));
            g.DrawImage(imgModa, new Rectangle(CalculateDistance() + (imgModa.Width / 3), 0, imgModa.Width, imgModa.Height));

            g.Dispose();
            return img;
        }

        /// <summary>
        /// Calculates the distance.
        /// </summary>
        /// <returns></returns>
        private int CalculateDistance()
        {
            int width = Properties.Resources.Celula_Vazia.Width;

            if (intModa > 1)
            {
                width += ((Properties.Resources.Celula_Vazia.Width - 2) * (intModa - 2));
            }

            return width;
        }
    }
}
