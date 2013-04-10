
using System.Drawing;
namespace Uatlantica.Drawing
{
    class Rect
    {        
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangule" /> class.
        /// </summary>
        public Rect()
        {
          
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangule" /> class.
        /// </summary>
        /// <param name="Width">The width.</param>
        /// <param name="Height">The height.</param>
        public Rect(int Width, int Height)
            : this()
        {
            this.Width = Width;
            this.Height = Height;
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int Width 
        { 
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int Height 
        { 
            get;
            set; 
        }

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>
        /// The border.
        /// </value>
        public Border Border 
        { 
            get;
            set; 
        }

        /// <summary>
        /// Gets or sets the color of the fill.
        /// </summary>
        /// <value>
        /// The color of the fill.
        /// </value>
        public Color FillColor 
        { 
            get;
            set; 
        }

        /// <summary>
        /// Generates a rectangule.
        /// </summary>
        /// <returns></returns>
        public void DrawElement(ref Graphics graphics)
        {
            this.DrawElement(ref graphics, 0, 0);
        }

        /// <summary>
        /// Draws the element.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="X">The X.</param>
        /// <param name="Y">The Y.</param>
        /// <returns></returns>
        public void DrawElement(ref Graphics graphics, int X, int Y)
        {
            Rectangle rect = new Rectangle();
            rect.X = X;
            rect.Y = Y;
            rect.Width = Width;
            rect.Height = Height;

            SolidBrush solidBrush = new SolidBrush(this.FillColor);
            graphics.FillRectangle(solidBrush, rect);

            if (this.Border != null)
            {
                graphics.DrawRectangle(Border.DrawBorder(), rect);
            }
        }
    }
}
