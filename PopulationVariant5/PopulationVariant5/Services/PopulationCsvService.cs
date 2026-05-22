using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using PopulationVariant5.Models;

namespace PopulationVariant5.Services
{
    public class PopulationCsvService
    {
        public List<PopulationRecord> LoadFromCsv(string filePath)
        {
            List<PopulationRecord> records = new List<PopulationRecord>();

            if (!File.Exists(filePath))
                throw new FileNotFoundException("Файл с данными не найден.");

            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length <= 1)
                throw new Exception("Файл не содержит данных.");

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(',');

                if (parts.Length < 2)
                    throw new Exception("Некорректный формат строки: " + line);

                int year;
                double population;

                bool yearParsed = int.TryParse(parts[0], out year);

                bool populationParsed = double.TryParse(
                    parts[1],
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out population
                );

                if (!yearParsed || !populationParsed)
                    throw new Exception("Ошибка чтения данных в строке: " + line);

                records.Add(new PopulationRecord(year, population));
            }

            return records;
        }
    }
}