using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PopulationVariant5.Models;
using PopulationVariant5.Services;

namespace PopulationVariant5
{
    public partial class Form1 : Form
    {
        private readonly PopulationCsvService _csvService;
        private readonly PopulationAnalysisService _analysisService;
        private readonly MovingAverageService _movingAverageService;

        private List<PopulationRecord> _records;
        private List<PopulationRecord> _forecastRecords;

        public Form1()
        {
            InitializeComponent();

            _csvService = new PopulationCsvService();
            _analysisService = new PopulationAnalysisService();
            _movingAverageService = new MovingAverageService();

            _records = new List<PopulationRecord>();
            _forecastRecords = new List<PopulationRecord>();

            ConfigureChart();
        }

        private void ConfigureChart()
        {
            chartPopulation.Series.Clear();
            chartPopulation.ChartAreas.Clear();
            chartPopulation.Legends.Clear();

            ChartArea chartArea = new ChartArea("MainArea");

            chartArea.AxisX.Title = "Год";
            chartArea.AxisY.Title = "Численность населения";
            chartArea.AxisX.Interval = 1;

            chartArea.CursorX.IsUserEnabled = true;
            chartArea.CursorX.IsUserSelectionEnabled = true;
            chartArea.CursorY.IsUserEnabled = true;
            chartArea.CursorY.IsUserSelectionEnabled = true;

            chartArea.AxisX.ScaleView.Zoomable = true;
            chartArea.AxisY.ScaleView.Zoomable = true;

            chartPopulation.ChartAreas.Add(chartArea);
            chartPopulation.Legends.Add(new Legend("Legend"));
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                _records = _csvService.LoadFromCsv(openFileDialog.FileName);
                _forecastRecords.Clear();

                dataGridViewPopulation.DataSource = null;
                dataGridViewPopulation.DataSource = _records;

                ShowAnalysis();
                BuildChart();

                MessageBox.Show("Файл успешно загружен.", "Успех");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка загрузки файла");
            }
        }

        private void btnBuildChart_Click(object sender, EventArgs e)
        {
            if (!HasData())
                return;

            BuildChart();
        }

        private void btnForecast_Click(object sender, EventArgs e)
        {
            if (!HasData())
                return;

            try
            {
                int period = (int)numPeriod.Value;
                int yearsCount = (int)numForecastYears.Value;

                _forecastRecords = _movingAverageService.Forecast(_records, period, yearsCount);

                BuildChart();

                MessageBox.Show("Прогноз успешно построен.", "Успех");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка прогнозирования");
            }
        }

        private void btnExportChart_Click(object sender, EventArgs e)
        {
            if (chartPopulation.Series.Count == 0)
            {
                MessageBox.Show("Сначала необходимо построить график.", "Ошибка");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG image (*.png)|*.png";
            saveFileDialog.FileName = "population_chart.png";

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                chartPopulation.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                MessageBox.Show("График успешно экспортирован.", "Успех");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка экспорта");
            }
        }

        private bool HasData()
        {
            if (_records == null || _records.Count == 0)
            {
                MessageBox.Show("Сначала загрузите файл с данными.", "Ошибка");
                return false;
            }

            return true;
        }

        private void ShowAnalysis()
        {
            PopulationAnalysisResult result = _analysisService.Analyze(_records);

            lblAnalysis.Text =
                "Максимальный процент прироста населения: " +
                result.MaxGrowthPercent.ToString("F3") +
                "% в " +
                result.MaxGrowthYear +
                " году" +
                Environment.NewLine +
                "Максимальный процент убыли населения: " +
                result.MaxDeclinePercent.ToString("F3") +
                "% в " +
                result.MaxDeclineYear +
                " году";
        }

        private void BuildChart()
        {
            chartPopulation.Series.Clear();

            Series actualSeries = new Series("Фактические данные");
            actualSeries.ChartType = SeriesChartType.Line;
            actualSeries.BorderWidth = 3;
            actualSeries.MarkerStyle = MarkerStyle.Circle;
            actualSeries.MarkerSize = 7;

            foreach (PopulationRecord record in _records)
            {
                actualSeries.Points.AddXY(record.Year, record.Population);
            }

            chartPopulation.Series.Add(actualSeries);

            if (_forecastRecords != null && _forecastRecords.Count > 0)
            {
                Series forecastSeries = new Series("Прогноз");
                forecastSeries.ChartType = SeriesChartType.Line;
                forecastSeries.BorderWidth = 3;
                forecastSeries.BorderDashStyle = ChartDashStyle.Dash;
                forecastSeries.MarkerStyle = MarkerStyle.Diamond;
                forecastSeries.MarkerSize = 7;

                PopulationRecord lastActualRecord = _records[_records.Count - 1];
                forecastSeries.Points.AddXY(lastActualRecord.Year, lastActualRecord.Population);

                foreach (PopulationRecord record in _forecastRecords)
                {
                    forecastSeries.Points.AddXY(record.Year, record.Population);
                }

                chartPopulation.Series.Add(forecastSeries);
            }

            chartPopulation.ChartAreas[0].RecalculateAxesScale();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}