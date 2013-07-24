
using System.Drawing;
namespace Uatlantica.Drawing
{
    class NACreator
    {
        private int intNA;

        /// <summary>
        /// Initializes a new instance of the <see cref="NACreator" /> class.
        /// </summary>
        /// <param name="NA">The NA.</param>
        public NACreator(int NA)
        {
            intNA = NA;
        }

        /// <summary>
        /// To the image.
        /// </summary>
        /// <param name="ImageBase">The image base.</param>
        /// <returns></returns>
        public Image ToImage(Image ImageBase)
        {
            Image imgNA = Properties.Resources.NA;
            Image img = new Bitmap(ImageBase.Width + (imgNA.Width + 20), ImageBase.Height);

            Graphics g = Graphics.FromImage(img);
            StatisticalChart.SetGraphics(ref g);

            Graphics g2 = Graphics.FromImage(imgNA);
            StatisticalChart.SetGraphics(ref g2);
            StatisticalChart.SetText(ref g2, new Rectangle(0, 5, imgNA.Width, imgNA.Height - 55), intNA.ToString(), 48, Color.Black);

            Point p2 = Math.GetCenter(imgNA.Width, imgNA.Height);
            Point p1 = Math.GetCenter(ImageBase.Width, ImageBase.Height);

            int y = (p1.Y - p2.Y) + 3;

            g.DrawImage(ImageBase, new Rectangle((imgNA.Width + 20), 0, ImageBase.Width, ImageBase.Height));
            g.DrawImage(imgNA, new Rectangle(0, y, imgNA.Width, imgNA.Height));

            g.Dispose();
            return img;
        }
    }
}
