using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace WindowsFormsApp3
{
    public class WeatherRecord
    {
        public DateTime Date { get; set; }
        public double MinTemp { get; set; }
        public double MaxTemp { get; set; }
        public double AvgTemp { get; set; }
        public string Weather { get; set; }

        public double Difference => MaxTemp - MinTemp;
    }

    public static class WeatherService
    {
        public static List<WeatherRecord> LoadData(string path)
        {
            var result = new List<WeatherRecord>();

            var lines = File.ReadAllLines(path);

            foreach (var line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split(',');

                if (parts.Length < 5)
                    continue;

                var record = new WeatherRecord
                {
                    Date = DateTime.ParseExact(parts[0].Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    MinTemp = double.Parse(parts[1].Trim(), CultureInfo.InvariantCulture),
                    MaxTemp = double.Parse(parts[2].Trim(), CultureInfo.InvariantCulture),
                    AvgTemp = double.Parse(parts[3].Trim(), CultureInfo.InvariantCulture),
                    Weather = parts[4].Trim()
                };

                result.Add(record);
            }

            return result.OrderBy(x => x.Date).ToList();
        }

        public static WeatherRecord MaxDiff(List<WeatherRecord> data)
        {
            return data.OrderByDescending(x => x.Difference).First();
        }

        public static WeatherRecord MinDiff(List<WeatherRecord> data)
        {
            return data.OrderBy(x => x.Difference).First();
        }

        public static List<double> MovingAverage(List<double> values, int window, int forecastDays)
        {
            var history = new List<double>(values);
            var result = new List<double>();

            if (window < 1)
                window = 1;

            for (int i = 0; i < forecastDays; i++)
            {
                var recent = history.Skip(Math.Max(0, history.Count - window)).ToList();
                var predicted = recent.Average();

                result.Add(predicted);
                history.Add(predicted);
            }

            return result;
        }
    }
}