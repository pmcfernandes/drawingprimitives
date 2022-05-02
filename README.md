# A Statistical chart

Is a new statistical chart that include a lot of data in same chart, like Moda, NA or Media.


### Code sample

```
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
}
```

### Sample

!(sample)[https://i.ibb.co/6yGNgQd/1.png]


