namespace WindowsFormsApp3
{
    partial class MainMenu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnWeather;
        private System.Windows.Forms.Button btnExpenses;
        private System.Windows.Forms.Button btnMigration;
        private System.Windows.Forms.Button btnPopulation;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnExit;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnWeather = new System.Windows.Forms.Button();
            this.btnExpenses = new System.Windows.Forms.Button();
            this.btnMigration = new System.Windows.Forms.Button();
            this.btnPopulation = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(228, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(203, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Анализ данных";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Location = new System.Drawing.Point(254, 57);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(161, 13);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Выберите модуль для работы:";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnWeather
            // 
            this.btnWeather.Location = new System.Drawing.Point(120, 85);
            this.btnWeather.Name = "btnWeather";
            this.btnWeather.Size = new System.Drawing.Size(440, 55);
            this.btnWeather.TabIndex = 2;
            this.btnWeather.Text = "Прогноз погоды\r\n(анализ температуры, перепады, прогноз)";
            this.btnWeather.UseVisualStyleBackColor = true;
            this.btnWeather.Click += new System.EventHandler(this.btnWeather_Click);
            // 
            // btnExpenses
            // 
            this.btnExpenses.Location = new System.Drawing.Point(120, 150);
            this.btnExpenses.Name = "btnExpenses";
            this.btnExpenses.Size = new System.Drawing.Size(440, 55);
            this.btnExpenses.TabIndex = 3;
            this.btnExpenses.Text = "Анализ расходов\r\n(потребительские расходы по годам, прогноз)";
            this.btnExpenses.UseVisualStyleBackColor = true;
            this.btnExpenses.Click += new System.EventHandler(this.btnExpenses_Click);
            // 
            // btnMigration
            // 
            this.btnMigration.Location = new System.Drawing.Point(120, 215);
            this.btnMigration.Name = "btnMigration";
            this.btnMigration.Size = new System.Drawing.Size(440, 55);
            this.btnMigration.TabIndex = 4;
            this.btnMigration.Text = "Модуль миграции\r\n(анализ миграционных потоков)";
            this.btnMigration.UseVisualStyleBackColor = true;
            this.btnMigration.Click += new System.EventHandler(this.btnMigration_Click);
            // 
            // btnPopulation
            // 
            this.btnPopulation.Location = new System.Drawing.Point(120, 280);
            this.btnPopulation.Name = "btnPopulation";
            this.btnPopulation.Size = new System.Drawing.Size(440, 55);
            this.btnPopulation.TabIndex = 5;
            this.btnPopulation.Text = "Анализ населения\r\n(демографические показатели)";
            this.btnPopulation.UseVisualStyleBackColor = true;
            this.btnPopulation.Click += new System.EventHandler(this.btnPopulation_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(265, 355);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(150, 40);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 420);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPopulation);
            this.Controls.Add(this.btnMigration);
            this.Controls.Add(this.btnExpenses);
            this.Controls.Add(this.btnWeather);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}