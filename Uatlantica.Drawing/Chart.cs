using System;
using System.Collections.Generic;
using System.Drawing;

namespace Uatlantica.Drawing
{
    public class Chart
    {
        List<Serie> lstSeries;

        /// <summary>
        /// Initializes a new instance of the <see cref="Chart" /> class.
        /// </summary>
        public Chart()
        {
            this.Series = new List<Serie>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chart" /> class.
        /// </summary>
        /// <param name="Width">The width.</param>
        /// <param name="Height">The height.</param>
        public Chart(int Width, int Height)
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
        /// Gets the series.
        /// </summary>
        /// <value>
        /// The series.
        /// </value>
        public List<Serie> Series
        {
            get
            {
                return lstSeries;
            }
            private set
            {
                lstSeries = value;
            }
        }

        /// <summary>
        /// Generates this instance.
        /// </summary>
        /// <returns></returns>
        public Bitmap Generate()
        {
            Image img = new Bitmap(this.Width, this.Height);

            Graphics g = Graphics.FromImage(img);
            SetBackground(ref g);

            int intHeight = Convert.ToInt32(decimal.Divide(this.Height, 3));
            int intWidth;

            for (int i = 0; i < this.Series.Count; i++)
            {
                intWidth = CalculateSeriesWidth();

                if (i == (this.Series.Count - 1))
                {
                    intWidth = intWidth - 1;
                }

                Rect rect = new Rect(intWidth, intHeight);              
                rect.Border = new Border(Color.Black, 1);

                if (this.Series[i].Value == 0)
                {
                    rect.FillColor = Color.White;
                }
                else
                {
                    rect.FillColor = Color.Blue.Lerp(Color.White, GetPercentage(this.Series[i]));
                }

                rect.DrawElement(ref g, intWidth * i, intHeight);
            }

            return new Bitmap(img);
        }

        /// <summary>
        /// Sums the total series values.
        /// </summary>
        /// <returns></returns>
        private decimal SumTotalSeriesValues()
        {
            decimal d = 0;

            this.Series.ForEach((serie) => d = decimal.Add(d, serie.Value));
            return d;
        }

        /// <summary>
        /// Gets the percentage.
        /// </summary>
        /// <param name="serie">The serie.</param>
        /// <returns></returns>
        private float GetPercentage(Serie serie)
        {
            decimal d = decimal.Divide(decimal.Multiply(serie.Value, 100), this.SumTotalSeriesValues());
            return Convert.ToSingle(d);
        }

        /// <summary>
        /// Calculates the width of the series.
        /// </summary>
        /// <returns></returns>
        public int CalculateSeriesWidth()
        {
            decimal d = decimal.Divide(this.Width, this.Series.Count);
            return Convert.ToInt32(System.Math.Round(d, 0));
        }

        /// <summary>
        /// Sets the background.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        private void SetBackground(ref Graphics graphics)
        {
            using (SolidBrush solidBrush = new SolidBrush(Color.White))
            {
                graphics.FillRectangle(solidBrush, new Rectangle(0, 0, this.Width, this.Height));
            }
        }
    }
}
