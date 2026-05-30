using System;
using System.Windows.Forms;
using migration_analyze_laba3_;
using PopulationVariant5;
using StatisticsAnalyzer;

namespace WindowsFormsApp3
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnWeather_Click(object sender, EventArgs e)
        {
            // Открываем форму анализа погоды
            Form1 weatherForm = new Form1();
            weatherForm.Show();
        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            // Открываем форму анализа расходов
            ExpensesForm expensesForm = new ExpensesForm();
            expensesForm.Show();
        }

        private void btnMigration_Click(object sender, EventArgs e)
        {
            // Открываем форму анализа миграции
            MigrationForm migrationForm = new MigrationForm();
            migrationForm.Show();
        }

        private void btnPopulation_Click(object sender, EventArgs e)
        {
            // Открываем форму анализа населения
            PopulationForm populationForm = new PopulationForm();
            populationForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}