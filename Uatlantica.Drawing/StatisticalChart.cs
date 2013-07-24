using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Uatlantica.Drawing
{
    public class StatisticalChart
    {
        private int[] intDistribuicao;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticalChart" /> class.
        /// </summary>
        /// <param name="Distribuicao">The distribuicao.</param>
        public StatisticalChart(int[] Distribuicao)
        {
            intDistribuicao = Distribuicao;
        }

        /// <summary>
        /// Gets or sets the moda.
        /// </summary>
        /// <value>
        /// The moda.
        /// </value>
        [Category("Statistic")]
        public int Moda
        {
            get;
            set;
        }
       
        /// <summary>
        /// Gets or sets the media HE.
        /// </summary>
        /// <value>
        /// The media HA
        /// </value>
        [Category("Statistic")]
        public float MediaHA
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the media AA.
        /// </summary>
        /// <value>
        /// The media AA.
        /// </value>
        [Category("Statistic")]
        public float MediaAA  
        { 
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the NA.
        /// </summary>
        /// <value>
        /// The NA.
        /// </value>
        [Category("Text")]
        public int NA
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the string format.
        /// </summary>
        /// <value>
        /// The string format.
        /// </value>
        [Category("Text")]
        public string StringFormat 
        { 
            get;
            set;
        }

        /// <summary>
        /// Resizes to.
        /// </summary>
        /// <param name="Width">The width.</param>
        /// <returns></returns>
        public Image ResizeTo(int Width)
        {
            return ImageHelper.ResizeTo(ToImage(), Width);
        }

        /// <summary>
        /// Sets the graphics.
        /// </summary>
        /// <param name="g">The g.</param>
        internal static void SetGraphics(ref Graphics g)
        {
            g.PageUnit = GraphicsUnit.Pixel;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;  
        }

        /// <summary>
        /// Sets the text.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="text">The text.</param>
        /// <param name="fontSize">Size of the font.</param>
        /// <param name="color">The color.</param>
        internal static void SetText(ref Graphics g, Rectangle rect, string text, int fontSize, Color color)
        {
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            g.DrawString(text, new Font("Colibri", fontSize), new SolidBrush(color), rect, stringFormat);
        }

        /// <summary>
        /// Sets the background.
        /// </summary>
        /// <param name="img">The img.</param>
        internal static void SetBackground(ref Image img)
        {
            Graphics g = Graphics.FromImage(img);
            SetGraphics(ref g);
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, img.Width, img.Height));
        }

        /// <summary>
        /// To the image.
        /// </summary>
        /// <returns></returns>
        public Image ToImage()
        {                    
            BlockAggregator blocks = new BlockAggregator(intDistribuicao);
            Image blockImage = blocks.ToImage();

            ModaCreator moda = new ModaCreator(this.Moda);
            Image modaImage = moda.ToImage(blockImage);

            InvertedTrianguleCreator invertedTriangule = new InvertedTrianguleCreator( intDistribuicao);
            Image invertedTrianguleImage = invertedTriangule.ToImage(modaImage);

            MediaAACreator mediaAA = new MediaAACreator(intDistribuicao, this.MediaAA, this.StringFormat);
            Image mediaAAImage = mediaAA.ToImage(invertedTrianguleImage);

            MediaHACreator mediaHA = new MediaHACreator(intDistribuicao, this.MediaHA, this.StringFormat);
            Image mediaHAImage = mediaHA.ToImage(mediaAAImage);

            if (!(this.NA == -1))
            {
                NACreator na = new NACreator(this.NA);
                Image naImage = na.ToImage(mediaHAImage);

                return naImage;
            }
            else
            {
                return mediaHAImage;              
            }
        }


    }
}
