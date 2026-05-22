using System;
using System.Collections.Generic;
using System.Linq;
using PopulationVariant5.Models;

namespace PopulationVariant5.Services
{
    public class MovingAverageService
    {
        public List<PopulationRecord> Forecast(
            List<PopulationRecord> records,
            int period,
            int yearsCount)
        {
            if (records == null || records.Count == 0)
                throw new Exception("Нет данных для прогнозирования.");

            if (period <= 0)
                throw new Exception("Период скользящей средней должен быть больше нуля.");

            if (yearsCount <= 0)
                throw new Exception("Количество лет прогноза должно быть больше нуля.");

            if (records.Count < period)
                throw new Exception("Период скользящей средней больше количества исходных данных.");

            List<PopulationRecord> sortedRecords = records.OrderBy(r => r.Year).ToList();
            List<double> values = sortedRecords.Select(r => r.Population).ToList();

            List<PopulationRecord> forecast = new List<PopulationRecord>();

            int lastYear = sortedRecords.Last().Year;

            for (int i = 1; i <= yearsCount; i++)
            {
                double average = values
                    .Skip(values.Count - period)
                    .Take(period)
                    .Average();

                int forecastYear = lastYear + i;

                forecast.Add(new PopulationRecord(forecastYear, average));

                values.Add(average);
            }

            return forecast;
        }
    }
}