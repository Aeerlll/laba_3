namespace PopulationVariant5.Models
{
    public class PopulationRecord
    {
        public int Year { get; set; }
        public double Population { get; set; }

        public PopulationRecord()
        {
        }

        public PopulationRecord(int year, double population)
        {
            Year = year;
            Population = population;
        }
    }
}