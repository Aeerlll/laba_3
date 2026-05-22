namespace PopulationVariant5
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnBuildChart = new System.Windows.Forms.Button();
            this.btnForecast = new System.Windows.Forms.Button();
            this.btnExportChart = new System.Windows.Forms.Button();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.numPeriod = new System.Windows.Forms.NumericUpDown();
            this.lblForecastYears = new System.Windows.Forms.Label();
            this.numForecastYears = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewPopulation = new System.Windows.Forms.DataGridView();
            this.lblAnalysis = new System.Windows.Forms.Label();
            this.chartPopulation = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.numPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numForecastYears)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPopulation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPopulation)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(41, 35);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(116, 57);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Открыть CSV";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnBuildChart
            // 
            this.btnBuildChart.Location = new System.Drawing.Point(163, 35);
            this.btnBuildChart.Name = "btnBuildChart";
            this.btnBuildChart.Size = new System.Drawing.Size(176, 57);
            this.btnBuildChart.TabIndex = 1;
            this.btnBuildChart.Text = "Построить график";
            this.btnBuildChart.UseVisualStyleBackColor = true;
            this.btnBuildChart.Click += new System.EventHandler(this.btnBuildChart_Click);
            // 
            // btnForecast
            // 
            this.btnForecast.Location = new System.Drawing.Point(345, 35);
            this.btnForecast.Name = "btnForecast";
            this.btnForecast.Size = new System.Drawing.Size(121, 57);
            this.btnForecast.TabIndex = 2;
            this.btnForecast.Text = "Прогноз";
            this.btnForecast.UseVisualStyleBackColor = true;
            this.btnForecast.Click += new System.EventHandler(this.btnForecast_Click);
            // 
            // btnExportChart
            // 
            this.btnExportChart.Location = new System.Drawing.Point(472, 35);
            this.btnExportChart.Name = "btnExportChart";
            this.btnExportChart.Size = new System.Drawing.Size(168, 57);
            this.btnExportChart.TabIndex = 3;
            this.btnExportChart.Text = "Экспорт графика";
            this.btnExportChart.UseVisualStyleBackColor = true;
            this.btnExportChart.Click += new System.EventHandler(this.btnExportChart_Click);
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(39, 119);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(118, 16);
            this.lblPeriod.TabIndex = 4;
            this.lblPeriod.Text = "Период средней:";
            // 
            // numPeriod
            // 
            this.numPeriod.Location = new System.Drawing.Point(163, 119);
            this.numPeriod.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPeriod.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numPeriod.Name = "numPeriod";
            this.numPeriod.Size = new System.Drawing.Size(120, 22);
            this.numPeriod.TabIndex = 5;
            this.numPeriod.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblForecastYears
            // 
            this.lblForecastYears.AutoSize = true;
            this.lblForecastYears.Location = new System.Drawing.Point(308, 119);
            this.lblForecastYears.Name = "lblForecastYears";
            this.lblForecastYears.Size = new System.Drawing.Size(99, 16);
            this.lblForecastYears.TabIndex = 6;
            this.lblForecastYears.Text = "Лет прогноза:";
            // 
            // numForecastYears
            // 
            this.numForecastYears.Location = new System.Drawing.Point(413, 119);
            this.numForecastYears.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numForecastYears.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numForecastYears.Name = "numForecastYears";
            this.numForecastYears.Size = new System.Drawing.Size(120, 22);
            this.numForecastYears.TabIndex = 7;
            this.numForecastYears.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // dataGridViewPopulation
            // 
            this.dataGridViewPopulation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPopulation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPopulation.Location = new System.Drawing.Point(12, 195);
            this.dataGridViewPopulation.Name = "dataGridViewPopulation";
            this.dataGridViewPopulation.ReadOnly = true;
            this.dataGridViewPopulation.RowHeadersWidth = 51;
            this.dataGridViewPopulation.RowTemplate.Height = 24;
            this.dataGridViewPopulation.Size = new System.Drawing.Size(395, 446);
            this.dataGridViewPopulation.TabIndex = 8;
            // 
            // lblAnalysis
            // 
            this.lblAnalysis.Location = new System.Drawing.Point(36, 175);
            this.lblAnalysis.Name = "lblAnalysis";
            this.lblAnalysis.Size = new System.Drawing.Size(495, 17);
            this.lblAnalysis.TabIndex = 9;
            this.lblAnalysis.Text = "Результаты анализа появятся здесь";
            // 
            // chartPopulation
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPopulation.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPopulation.Legends.Add(legend1);
            this.chartPopulation.Location = new System.Drawing.Point(413, 175);
            this.chartPopulation.Name = "chartPopulation";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartPopulation.Series.Add(series1);
            this.chartPopulation.Size = new System.Drawing.Size(657, 466);
            this.chartPopulation.TabIndex = 10;
            this.chartPopulation.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 653);
            this.Controls.Add(this.chartPopulation);
            this.Controls.Add(this.lblAnalysis);
            this.Controls.Add(this.dataGridViewPopulation);
            this.Controls.Add(this.numForecastYears);
            this.Controls.Add(this.lblForecastYears);
            this.Controls.Add(this.numPeriod);
            this.Controls.Add(this.lblPeriod);
            this.Controls.Add(this.btnExportChart);
            this.Controls.Add(this.btnForecast);
            this.Controls.Add(this.btnBuildChart);
            this.Controls.Add(this.btnOpenFile);
            this.Name = "Form1";
            this.Text = "Анализ численности населения России";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numForecastYears)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPopulation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPopulation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnBuildChart;
        private System.Windows.Forms.Button btnForecast;
        private System.Windows.Forms.Button btnExportChart;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.NumericUpDown numPeriod;
        private System.Windows.Forms.Label lblForecastYears;
        private System.Windows.Forms.NumericUpDown numForecastYears;
        private System.Windows.Forms.DataGridView dataGridViewPopulation;
        private System.Windows.Forms.Label lblAnalysis;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPopulation;
    }
}

