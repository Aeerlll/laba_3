using System;
using System.Collections.Generic;
using System.Linq;

namespace StatisticsAnalyzer.Core
{
    public static class AnalyticsService
    {
        public static double CalculateGrowth(double current, double previous)
        {
            if (previous == 0) return 0;
            return Math.Round((current - previous) / previous * 100, 2);
        }

        public static List<double> GrowthRateSeries(List<double> data)
        {
            var result = new List<double>();
            for (int i = 1; i < data.Count; i++)
                result.Add(CalculateGrowth(data[i], data[i - 1]));
            return result;
        }

        public static double AverageGrowth(List<double> data)
        {
            var rates = GrowthRateSeries(data);
            return rates.Count > 0 ? Math.Round(rates.Average(), 2) : 0;
        }

        public static double FindMax(List<double> data, out int index)
        {
            index = data.IndexOf(data.Max());
            return data.Max();
        }

        public static double FindMin(List<double> data, out int index)
        {
            index = data.IndexOf(data.Min());
            return data.Min();
        }
    }
}