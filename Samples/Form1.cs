using System;
using System.Windows.Forms;
using Uatlantica.Drawing;

namespace Samples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Chart chart = new Chart(pictureBox1.Width, pictureBox1.Height);
            chart.Series.Add(new Serie("0", 10));
            chart.Series.Add(new Serie("1", 4));
            chart.Series.Add(new Serie("2", 0));
            chart.Series.Add(new Serie("3", 8));
            chart.Series.Add(new Serie("4", 19));

            pictureBox1.Image = chart.Generate();
        }
    }
}
