using StatisticsAnalyzer.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StatisticsAnalyzer
{
    public partial class ExpensesForm : Form
    {
        private List<string> years;
        private List<double> expenses;

        public ExpensesForm()
        {
            InitializeComponent();
            LoadSampleData();
            DisplayTable();
            DisplayChart();
            DisplayAnalytics();
        }

        private void LoadSampleData()
        {
            // Относительный путь от папки с exe до папки с CSV
            // Из bin\Debug\net8.0\ поднимаемся на 4 уровня вверх до папки проекта
            string projectPath = Directory.GetParent(Application.StartupPath).Parent.FullName;
            string filePath = Path.Combine(projectPath, "Data", "expenses.csv");

            years = new List<string>();
            expenses = new List<double>();

            if (File.Exists(filePath))
            {
                try
                {
                    var lines = File.ReadAllLines(filePath);

                    // Пропускаем заголовок (первая строка)
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string line = lines[i].Trim();
                        if (string.IsNullOrEmpty(line)) continue;

                        var parts = line.Split(',');
                        if (parts.Length >= 2)
                        {
                            string year = parts[0].Trim();
                            double expense;

                            if (double.TryParse(parts[1].Trim(), out expense))
                            {
                                years.Add(year);
                                expenses.Add(expense);
                            }
                        }
                    }

                    if (years.Count == 0)
                    {
                        throw new Exception("Файл пуст или имеет неверный формат");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки файла: {ex.Message}\nИспользую примерные данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadDefaultData();
                }
            }
            else
            {
                MessageBox.Show($"Файл не найден: {filePath}\nИспользую примерные данные.", "Файл не найден", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadDefaultData();
            }
        }

        private void LoadDefaultData()
        {
            years = new List<string> { "2019", "2020", "2021", "2022", "2023" };
            expenses = new List<double> { 23500, 24800, 26200, 27900, 29500 };
        }

        private void DisplayTable()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("Year", "Год");
            dataGridView1.Columns.Add("Expense", "Расходы (руб)");
            dataGridView1.Columns.Add("Growth", "Изменение (%)");

            for (int i = 0; i < years.Count; i++)
            {
                double growth = i > 0 ? AnalyticsService.CalculateGrowth(expenses[i], expenses[i - 1]) : 0;
                dataGridView1.Rows.Add(years[i], expenses[i].ToString("N0"), growth + "%");
            }

            var forecast = ForecastService.LinearForecast(expenses, 3);
            int lastYear = int.Parse(years.Last());
            double prev = expenses.Last();

            for (int i = 0; i < forecast.Count; i++)
            {
                int year = lastYear + i + 1;
                double growth = AnalyticsService.CalculateGrowth(forecast[i], prev);
                dataGridView1.Rows.Add(year.ToString(), forecast[i].ToString("N0"), growth + "% (прогноз)");
                prev = forecast[i];
            }

            dataGridView1.AutoResizeColumns();
        }

        private void DisplayChart()
        {
            try
            {
                // Очищаем всё
                chart1.Series.Clear();

                // Убеждаемся что есть ChartArea
                if (chart1.ChartAreas.Count == 0)
                    chart1.ChartAreas.Add(new ChartArea());

                
                var series = new Series("Расходы");
                series.ChartType = SeriesChartType.Line;
                series.BorderWidth = 2;
                series.Color = System.Drawing.Color.Blue;

                // Добавляем точки 
                series.Points.AddXY(2019, 23500);
                series.Points.AddXY(2020, 24800);
                series.Points.AddXY(2021, 26200);
                series.Points.AddXY(2022, 27900);
                series.Points.AddXY(2023, 29500);

                // Добавляем серию на график
                chart1.Series.Add(series);

                // Настройка осей
                chart1.ChartAreas[0].AxisX.Title = "Год";
                chart1.ChartAreas[0].AxisX.Minimum = 2018;
                chart1.ChartAreas[0].AxisX.Maximum = 2024;
                chart1.ChartAreas[0].AxisX.Interval = 1;

                chart1.ChartAreas[0].AxisY.Title = "Расходы (руб)";
                chart1.ChartAreas[0].AxisY.LabelStyle.Format = "{0:N0}";

                // Легенда
                if (chart1.Legends.Count == 0)
                    chart1.Legends.Add(new Legend());
                chart1.Legends[0].Docking = Docking.Bottom;

                // Заголовок
                chart1.Titles.Clear();
                chart1.Titles.Add("Потребительские расходы");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void DisplayAnalytics()
        {
            double avgGrowth = AnalyticsService.AverageGrowth(expenses);
            lblAvgGrowth.Text = $"📊 Среднегодовой рост: {avgGrowth}%";

            int maxIndex;
            AnalyticsService.FindMax(expenses, out maxIndex);
            lblMax.Text = $"📈 Максимум: {years[maxIndex]} г. ({expenses[maxIndex]:N0} руб.)";

            int minIndex;
            AnalyticsService.FindMin(expenses, out minIndex);
            lblMin.Text = $"📉 Минимум: {years[minIndex]} г. ({expenses[minIndex]:N0} руб.)";
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "PNG Image|*.png";
                saveDialog.Title = "Сохранить график";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    chart1.SaveImage(saveDialog.FileName, ChartImageFormat.Png);
                    MessageBox.Show("График сохранён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}