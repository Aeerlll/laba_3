using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private List<WeatherRecord> data = new List<WeatherRecord>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "CSV файлы|*.csv|Все файлы|*.*";
                dialog.Title = "Выберите файл с данными";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    data = WeatherService.LoadData(dialog.FileName);
                    if (data.Count == 0)
                    {
                        MessageBox.Show("Нет данных в файле", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    FillTable();
                    DrawChart();
                    ShowStats();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FillTable()
        {
            gridData.Rows.Clear();
            for (int i = 0; i < data.Count; i++)
            {
                var d = data[i];
                int row = gridData.Rows.Add(
                    i + 1,
                    d.Date.ToString("dd.MM.yyyy"),
                    d.MinTemp.ToString("0.0"),
                    d.AvgTemp.ToString("0.0"),
                    d.MaxTemp.ToString("0.0"),
                    d.Weather
                );

                if (d.MinTemp == data.Min(x => x.MinTemp))
                    gridData.Rows[row].Cells[2].Style.ForeColor = Color.Blue;
                if (d.MaxTemp == data.Max(x => x.MaxTemp))
                    gridData.Rows[row].Cells[4].Style.ForeColor = Color.Red;
            }
        }

        private void DrawChart()
        {
            if (data.Count == 0) return;

            Bitmap bmp = new Bitmap(chartBox.Width, chartBox.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                int w = chartBox.Width - 80;
                int h = chartBox.Height - 60;
                int ox = 60, oy = 30;

                double minV = data.Min(x => x.MinTemp) - 1;
                double maxV = data.Max(x => x.MaxTemp) + 1;
                double range = maxV - minV;

                g.DrawLine(Pens.Black, ox, oy, ox, oy + h);
                g.DrawLine(Pens.Black, ox, oy + h, ox + w, oy + h);

                for (int i = 0; i <= 5; i++)
                {
                    double val = minV + range * i / 5;
                    int y = oy + h - (int)((val - minV) / range * h);
                    g.DrawLine(Pens.LightGray, ox, y, ox + w, y);
                    g.DrawString(val.ToString("0"), Font, Brushes.Black, ox - 30, y - 5);
                }

                int step = Math.Max(1, data.Count / 10);
                for (int i = 0; i < data.Count; i += step)
                {
                    int x = ox + i * w / (data.Count - 1);
                    g.DrawString((i + 1).ToString(), Font, Brushes.Black, x - 5, oy + h + 5);
                }

                var minPts = new List<Point>();
                var maxPts = new List<Point>();
                var avgPts = new List<Point>();

                for (int i = 0; i < data.Count; i++)
                {
                    int x = ox + i * w / Math.Max(1, data.Count - 1);
                    int yMin = oy + h - (int)((data[i].MinTemp - minV) / range * h);
                    int yMax = oy + h - (int)((data[i].MaxTemp - minV) / range * h);
                    int yAvg = oy + h - (int)((data[i].AvgTemp - minV) / range * h);
                    minPts.Add(new Point(x, yMin));
                    maxPts.Add(new Point(x, yMax));
                    avgPts.Add(new Point(x, yAvg));
                }

                if (minPts.Count > 1) g.DrawLines(new Pen(Color.Blue, 2), minPts.ToArray());
                if (maxPts.Count > 1) g.DrawLines(new Pen(Color.Red, 2), maxPts.ToArray());
                if (avgPts.Count > 1) g.DrawLines(new Pen(Color.Green, 2), avgPts.ToArray());

                foreach (var p in minPts) g.FillEllipse(Brushes.Blue, p.X - 3, p.Y - 3, 6, 6);
                foreach (var p in maxPts) g.FillEllipse(Brushes.Red, p.X - 3, p.Y - 3, 6, 6);

                g.DrawString("Min", Font, Brushes.Blue, ox + 10, oy + 10);
                g.DrawString("Max", Font, Brushes.Red, ox + 50, oy + 10);
                g.DrawString("Avg", Font, Brushes.Green, ox + 90, oy + 10);
            }
            chartBox.Image = bmp;
        }

        private void ShowStats()
        {
            var maxD = WeatherService.MaxDiff(data);
            var minD = WeatherService.MinDiff(data);
            lblStats.Text = string.Format(
                "Макс перепад: {0} - {1} C\nМин перепад: {2} - {3} C",
                maxD.Date.ToString("dd.MM"), maxD.Difference.ToString("0.0"),
                minD.Date.ToString("dd.MM"), minD.Difference.ToString("0.0")
            );
        }

        private void btnForecast_Click(object sender, EventArgs e)
        {
            if (data.Count == 0) return;

            int days = (int)nudForecastDays.Value;
            var avgVals = data.Select(x => x.AvgTemp).ToList();
            var forecast = WeatherService.MovingAverage(avgVals, 3, days);

            Bitmap bmp = new Bitmap(chartBox.Width, chartBox.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                int w = chartBox.Width - 80;
                int h = chartBox.Height - 60;
                int ox = 60, oy = 30;

                double minV = Math.Min(data.Min(x => x.MinTemp), forecast.Min()) - 1;
                double maxV = Math.Max(data.Max(x => x.MaxTemp), forecast.Max()) + 1;
                double range = maxV - minV;

                g.DrawLine(Pens.Black, ox, oy, ox, oy + h);
                g.DrawLine(Pens.Black, ox, oy + h, ox + w, oy + h);

                var pts = new List<Point>();
                for (int i = 0; i < data.Count; i++)
                {
                    int x = ox + i * w / Math.Max(1, data.Count - 1);
                    int y = oy + h - (int)((data[i].AvgTemp - minV) / range * h);
                    pts.Add(new Point(x, y));
                }
                if (pts.Count > 1) g.DrawLines(new Pen(Color.Green, 2), pts.ToArray());

                var fPts = new List<Point>();
                int total = data.Count + days;
                for (int i = 0; i < days; i++)
                {
                    int x = ox + (data.Count + i) * w / Math.Max(1, total - 1);
                    int y = oy + h - (int)((forecast[i] - minV) / range * h);
                    fPts.Add(new Point(x, y));
                }
                if (fPts.Count > 1)
                    g.DrawLines(new Pen(Color.Orange, 2) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash }, fPts.ToArray());

                g.DrawString("Avg", Font, Brushes.Green, ox + 10, oy + 10);
                g.DrawString("Прогноз", Font, Brushes.Orange, ox + 50, oy + 10);
            }
            chartBox.Image = bmp;
            lblStats.Text += string.Format("\nПрогноз на {0} дней построен", days);
        }
    }
}