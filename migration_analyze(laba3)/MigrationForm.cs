using migration_analyze_laba3_;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace migration_analyze_laba3_
{
    public partial class MigrationForm : Form
    {
        private List<MigrationRecord> data =
            new List<MigrationRecord>();

        public MigrationForm()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(
            object sender,
            EventArgs e)
        {
            using (OpenFileDialog dialog =
                   new OpenFileDialog())
            {
                dialog.Filter =
                    "CSV files|*.csv|All files|*.*";

                dialog.Title =
                    "Выберите CSV файл";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    LoadCsv(dialog.FileName);

                    gridData.DataSource = null;

                    gridData.DataSource = data;

                    DrawChart();

                    Analyze();

                    Forecast();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Ошибка: " + ex.Message);
                }
            }
        }

        private void LoadCsv(string path)
        {
            data.Clear();

            var lines = File.ReadAllLines(path);

            foreach (var line in lines.Skip(1))
            {
                var parts = line.Split(',');

                data.Add(new MigrationRecord
                {
                    Year = int.Parse(parts[0]),

                    Immigrants =
                        int.Parse(parts[1]),

                    Emigrants =
                        int.Parse(parts[2])
                });
            }
        }

        private void DrawChart()
        {
            Bitmap bmp = new Bitmap(
                pictureBoxChart.Width,
                pictureBoxChart.Height);

            Graphics g = Graphics.FromImage(bmp);

            g.Clear(Color.White);

            Pen axisPen = new Pen(Color.Black, 2);

            Pen immigrantsPen =
                new Pen(Color.Blue, 2);

            Pen emigrantsPen =
                new Pen(Color.Red, 2);

            int margin = 40;

            int width =
                pictureBoxChart.Width - 2 * margin;

            int height =
                pictureBoxChart.Height - 2 * margin;

            g.DrawLine(
                axisPen,
                margin,
                margin,
                margin,
                margin + height);

            g.DrawLine(
                axisPen,
                margin,
                margin + height,
                margin + width,
                margin + height);

            int maxValue = data.Max(x =>
                Math.Max(
                    x.Immigrants,
                    x.Emigrants));

            for (int i = 0; i < data.Count - 1; i++)
            {
                int x1 =
                    margin + i * width / data.Count;

                int x2 =
                    margin + (i + 1)
                    * width / data.Count;

                int y1 =
                    margin + height -
                    data[i].Immigrants
                    * height / maxValue;

                int y2 =
                    margin + height -
                    data[i + 1].Immigrants
                    * height / maxValue;

                g.DrawLine(
                    immigrantsPen,
                    x1,
                    y1,
                    x2,
                    y2);

                int ey1 =
                    margin + height -
                    data[i].Emigrants
                    * height / maxValue;

                int ey2 =
                    margin + height -
                    data[i + 1].Emigrants
                    * height / maxValue;

                g.DrawLine(
                    emigrantsPen,
                    x1,
                    ey1,
                    x2,
                    ey2);
            }

            pictureBoxChart.Image = bmp;
        }

        private void Analyze()
        {
            double maxChange = 0;

            int maxYear = 0;

            for (int i = 1; i < data.Count; i++)
            {
                double oldValue =
                    data[i - 1].Immigrants;

                double newValue =
                    data[i].Immigrants;

                double change =
                    Math.Abs(
                        (newValue - oldValue)
                        / oldValue * 100);

                if (change > maxChange)
                {
                    maxChange = change;

                    maxYear = data[i].Year;
                }
            }

            lblResult.Text =
                $"Максимальное изменение: " +
                $"{maxChange:F2}% в {maxYear}";
        }

        private void Forecast()
        {
            List<double> values =
                data.Select(x =>
                    (double)x.Immigrants)
                .ToList();

            List<double> forecast =
                new List<double>();

            int window = 3;

            for (int i = 0; i < 5; i++)
            {
                double avg =
                    values
                    .Skip(values.Count - window)
                    .Average();

                forecast.Add(avg);

                values.Add(avg);
            }

            Bitmap bmp =
                (Bitmap)pictureBoxChart.Image;

            Graphics g =
                Graphics.FromImage(bmp);

            Pen forecastPen =
                new Pen(Color.Green, 2);

            int margin = 40;

            int width =
                pictureBoxChart.Width - 2 * margin;

            int height =
                pictureBoxChart.Height - 2 * margin;

            int maxValue =
                (int)values.Max();

            int startX =
                margin +
                (data.Count - 1)
                * width / data.Count;

            int startY =
                margin + height -
                data.Last().Immigrants
                * height / maxValue;

            for (int i = 0; i < forecast.Count; i++)
            {
                int x =
                    margin +
                    (data.Count + i)
                    * width / data.Count;

                int y =
                    margin + height -
                    (int)forecast[i]
                    * height / maxValue;

                g.DrawLine(
                    forecastPen,
                    startX,
                    startY,
                    x,
                    y);

                startX = x;

                startY = y;
            }

            pictureBoxChart.Image = bmp;
        }
    }
}