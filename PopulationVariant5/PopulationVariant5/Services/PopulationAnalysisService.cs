using System;
using System.Collections.Generic;
using System.Linq;
using PopulationVariant5.Models;

namespace PopulationVariant5.Services
{
    public class PopulationAnalysisService
    {
        public PopulationAnalysisResult Analyze(List<PopulationRecord> records)
        {
            if (records == null || records.Count < 2)
                throw new Exception("Для анализа необходимо минимум два значения.");

            List<PopulationRecord> sortedRecords = records.OrderBy(r => r.Year).ToList();

            double maxGrowth = double.MinValue;
            int maxGrowthYear = 0;

            double maxDecline = double.MaxValue;
            int maxDeclineYear = 0;

            for (int i = 1; i < sortedRecords.Count; i++)
            {
                double previousPopulation = sortedRecords[i - 1].Population;
                double currentPopulation = sortedRecords[i].Population;

                if (previousPopulation == 0)
                    continue;

                double percentChange = ((currentPopulation - previousPopulation) / previousPopulation) * 100.0;

                if (percentChange > maxGrowth)
                {
                    maxGrowth = percentChange;
                    maxGrowthYear = sortedRecords[i].Year;
                }

                if (percentChange < maxDecline)
                {
                    maxDecline = percentChange;
                    maxDeclineYear = sortedRecords[i].Year;
                }
            }

            return new PopulationAnalysisResult
            {
                MaxGrowthYear = maxGrowthYear,
                MaxGrowthPercent = maxGrowth,
                MaxDeclineYear = maxDeclineYear,
                MaxDeclinePercent = maxDecline
            };
        }
    }
}