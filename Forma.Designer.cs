namespace WindowsFormsApp3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnForecast;
        private System.Windows.Forms.Label lblForecastDays;
        private System.Windows.Forms.NumericUpDown nudForecastDays;
        private System.Windows.Forms.DataGridView gridData;
        private System.Windows.Forms.PictureBox chartBox;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeather;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnForecast = new System.Windows.Forms.Button();
            this.lblForecastDays = new System.Windows.Forms.Label();
            this.nudForecastDays = new System.Windows.Forms.NumericUpDown();
            this.gridData = new System.Windows.Forms.DataGridView();
            this.chartBox = new System.Windows.Forms.PictureBox();
            this.lblStats = new System.Windows.Forms.Label();
            this.colDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeather = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.nudForecastDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBox)).BeginInit();
            this.SuspendLayout();

            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(110, 25);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Загрузить CSV";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            this.lblForecastDays.AutoSize = true;
            this.lblForecastDays.Location = new System.Drawing.Point(140, 18);
            this.lblForecastDays.Name = "lblForecastDays";
            this.lblForecastDays.Size = new System.Drawing.Size(85, 13);
            this.lblForecastDays.TabIndex = 1;
            this.lblForecastDays.Text = "Дней прогноза:";

            this.nudForecastDays.Location = new System.Drawing.Point(231, 16);
            this.nudForecastDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudForecastDays.Name = "nudForecastDays";
            this.nudForecastDays.Size = new System.Drawing.Size(50, 20);
            this.nudForecastDays.TabIndex = 2;
            this.nudForecastDays.Value = new decimal(new int[] { 5, 0, 0, 0 });

            this.btnForecast.Location = new System.Drawing.Point(295, 12);
            this.btnForecast.Name = "btnForecast";
            this.btnForecast.Size = new System.Drawing.Size(90, 25);
            this.btnForecast.TabIndex = 3;
            this.btnForecast.Text = "Прогноз";
            this.btnForecast.UseVisualStyleBackColor = true;
            this.btnForecast.Click += new System.EventHandler(this.btnForecast_Click);

            this.gridData.AllowUserToAddRows = false;
            this.gridData.AllowUserToDeleteRows = false;
            this.gridData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDay, this.colDate, this.colMin, this.colAvg, this.colMax, this.colWeather});
            this.gridData.Location = new System.Drawing.Point(12, 50);
            this.gridData.Name = "gridData";
            this.gridData.ReadOnly = true;
            this.gridData.RowHeadersVisible = false;
            this.gridData.Size = new System.Drawing.Size(380, 400);
            this.gridData.TabIndex = 4;

            this.colDay.HeaderText = "День";
            this.colDay.Name = "colDay";
            this.colDay.ReadOnly = true;
            this.colDate.HeaderText = "Дата";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colMin.HeaderText = "Мин";
            this.colMin.Name = "colMin";
            this.colMin.ReadOnly = true;
            this.colAvg.HeaderText = "Средняя";
            this.colAvg.Name = "colAvg";
            this.colAvg.ReadOnly = true;
            this.colMax.HeaderText = "Макс";
            this.colMax.Name = "colMax";
            this.colMax.ReadOnly = true;
            this.colWeather.HeaderText = "Погода";
            this.colWeather.Name = "colWeather";
            this.colWeather.ReadOnly = true;

            this.chartBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chartBox.Location = new System.Drawing.Point(400, 50);
            this.chartBox.Name = "chartBox";
            this.chartBox.Size = new System.Drawing.Size(580, 400);
            this.chartBox.TabIndex = 5;
            this.chartBox.TabStop = false;

            this.lblStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStats.Location = new System.Drawing.Point(12, 460);
            this.lblStats.Name = "lblStats";
            this.lblStats.Padding = new System.Windows.Forms.Padding(5);
            this.lblStats.Size = new System.Drawing.Size(968, 80);
            this.lblStats.TabIndex = 6;
            this.lblStats.Text = "Загрузите файл для отображения статистики";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 552);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.chartBox);
            this.Controls.Add(this.gridData);
            this.Controls.Add(this.btnForecast);
            this.Controls.Add(this.nudForecastDays);
            this.Controls.Add(this.lblForecastDays);
            this.Controls.Add(this.btnLoad);
            this.Name = "Form1";
            this.Text = "Анализ температуры";
            ((System.ComponentModel.ISupportInitialize)(this.nudForecastDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}