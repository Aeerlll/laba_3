namespace migration_analyze_laba3_
{
    partial class MigrationForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnLoad;

        private System.Windows.Forms.DataGridView gridData;

        private System.Windows.Forms.PictureBox pictureBoxChart;

        private System.Windows.Forms.Label lblResult;

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

            this.gridData =
                new System.Windows.Forms.DataGridView();

            this.pictureBoxChart =
                new System.Windows.Forms.PictureBox();

            this.lblResult =
                new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)
                (this.gridData)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.pictureBoxChart)).BeginInit();

            this.SuspendLayout();

            // btnLoad

            this.btnLoad.Location =
                new System.Drawing.Point(12, 12);

            this.btnLoad.Name = "btnLoad";

            this.btnLoad.Size =
                new System.Drawing.Size(180, 40);

            this.btnLoad.TabIndex = 0;

            this.btnLoad.Text = "Загрузить CSV";

            this.btnLoad.UseVisualStyleBackColor = true;

            this.btnLoad.Click +=
                new System.EventHandler(this.btnLoad_Click);

            // gridData

            this.gridData.ColumnHeadersHeightSizeMode =
                System.Windows.Forms
                .DataGridViewColumnHeadersHeightSizeMode
                .AutoSize;

            this.gridData.Location =
                new System.Drawing.Point(12, 70);

            this.gridData.Name = "gridData";

            this.gridData.RowHeadersWidth = 51;

            this.gridData.RowTemplate.Height = 24;

            this.gridData.Size =
                new System.Drawing.Size(450, 450);

            this.gridData.TabIndex = 1;

            // pictureBoxChart

            this.pictureBoxChart.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.pictureBoxChart.Location =
                new System.Drawing.Point(480, 70);

            this.pictureBoxChart.Name =
                "pictureBoxChart";

            this.pictureBoxChart.Size =
                new System.Drawing.Size(650, 450);

            this.pictureBoxChart.TabIndex = 2;

            this.pictureBoxChart.TabStop = false;

            // lblResult

            this.lblResult.AutoSize = true;

            this.lblResult.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.lblResult.Location =
                new System.Drawing.Point(12, 540);

            this.lblResult.Name = "lblResult";

            this.lblResult.Size =
                new System.Drawing.Size(170, 20);

            this.lblResult.TabIndex = 3;

            this.lblResult.Text =
                "Результат анализа";

            // Form1

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1150, 600);

            this.Controls.Add(this.lblResult);

            this.Controls.Add(this.pictureBoxChart);

            this.Controls.Add(this.gridData);

            this.Controls.Add(this.btnLoad);

            this.Name = "Form1";

            this.Text = "Анализ миграции";

            ((System.ComponentModel.ISupportInitialize)
                (this.gridData)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.pictureBoxChart)).EndInit();

            this.ResumeLayout(false);

            this.PerformLayout();
        }
    }
}