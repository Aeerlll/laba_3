namespace StatisticsAnalyzer
{
    partial class ExpensesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblAvgGrowth;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Button btnExport;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblAvgGrowth = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();

            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Location = new System.Drawing.Point(20, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(550, 350);
            this.dataGridView1.TabIndex = 0;

            this.chart1.Location = new System.Drawing.Point(590, 20);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(550, 350);
            this.chart1.TabIndex = 1;

            this.lblAvgGrowth.AutoSize = true;
            this.lblAvgGrowth.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAvgGrowth.Location = new System.Drawing.Point(20, 390);
            this.lblAvgGrowth.Name = "lblAvgGrowth";
            this.lblAvgGrowth.Size = new System.Drawing.Size(200, 28);
            this.lblAvgGrowth.TabIndex = 2;
            this.lblAvgGrowth.Text = "Среднегодовой рост:";

            this.lblMax.AutoSize = true;
            this.lblMax.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMax.Location = new System.Drawing.Point(20, 430);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(100, 28);
            this.lblMax.TabIndex = 3;
            this.lblMax.Text = "Максимум:";

            this.lblMin.AutoSize = true;
            this.lblMin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMin.Location = new System.Drawing.Point(20, 470);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(90, 28);
            this.lblMin.TabIndex = 4;
            this.lblMin.Text = "Минимум:";

            this.btnExport.Location = new System.Drawing.Point(590, 390);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 40);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Сохранить график";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblAvgGrowth);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ExpensesForm";
            this.Text = "Потребительские расходы";
            this.Size = new System.Drawing.Size(1200, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}