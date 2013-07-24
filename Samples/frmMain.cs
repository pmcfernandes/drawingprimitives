using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Windows.Forms;
using SC = Uatlantica.Drawing;

namespace StatisticalChart
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private int[] createDistribution(int max)
        {
            int[] amostra = new int[] { 0, 4, 6, 18, 29, 1, 7, 50 };

            Random r = new Random();
            List<int> lst = new List<int>();

            for (int i = 0; i < max; i++)
            {
                lst.Add(amostra[r.Next(0, amostra.Length)]);
            }

            return lst.ToArray();
        }

        private float createFloat(Random r, int max)
        {
            int i, j = 0;
            i = r.Next(1, max);
            j = r.Next(0, 9);

            return Convert.ToSingle(String.Format("{0},{1}", i, j));
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Random r = new Random();

            for (int i = 0; i < 20; i++)
            {
                int rr = r.Next(4, 7);

                SC.StatisticalChart chart = new SC.StatisticalChart(createDistribution(rr));
                chart.Moda = r.Next(1, rr);
                chart.NA = r.Next(1, 7);
                chart.StringFormat = "0.0";
                chart.MediaHA = createFloat(r, rr);
                chart.MediaAA = createFloat(r, rr);
                pictureBox1.BackColor = System.Drawing.Color.White;
                pictureBox1.Image = chart.ResizeTo(this.Width);

               //  DocumentHelper.SaveImageToDocument(@"c:\Doc1.docx", pictureBox1.Image);
            }
        }

    }
}
