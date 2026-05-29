using System;
using System.Collections.Generic;
using System.Linq;

namespace StatisticsAnalyzer.Core
{
    public static class ForecastService
    {
        public static List<double?> MovingAverage(List<double> data, int window = 3)
        {
            var result = new List<double?>();
            for (int i = 0; i < data.Count; i++)
            {
                if (i < window - 1)
                    result.Add(null);
                else
                {
                    double sum = 0;
                    for (int j = i - window + 1; j <= i; j++)
                        sum += data[j];
                    result.Add(Math.Round(sum / window, 2));
                }
            }
            return result;
        }

        public static List<double> LinearForecast(List<double> values, int steps = 3)
        {
            if (values.Count < 2)
                return Enumerable.Repeat(values.LastOrDefault(), steps).ToList();

            double y1 = values[values.Count - 2];
            double y2 = values[values.Count - 1];
            double diff = y2 - y1;

            var forecast = new List<double>();
            for (int i = 1; i <= steps; i++)
                forecast.Add(Math.Round(y2 + diff * i, 2));
            return forecast;
        }
    }
}