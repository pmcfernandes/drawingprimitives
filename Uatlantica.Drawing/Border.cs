using System.Drawing;

namespace Uatlantica.Drawing
{
    class Border
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Border" /> class.
        /// </summary>
        public Border()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Border" /> class.
        /// </summary>
        /// <param name="Color">The color.</param>
        /// <param name="Width">The width.</param>
        public Border(Color Color, float Width)
            :this()
        {
            this.Width = Width;
            this.Color = Color;
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public float Width 
        {
            get; 
            set; 
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public Color Color 
        { 
            get;
            set;
        }

        /// <summary>
        /// Draws this instance.
        /// </summary>
        /// <returns></returns>
        public Pen DrawBorder()
        {
            return new Pen(this.Color, Width);
        }

    }
}
