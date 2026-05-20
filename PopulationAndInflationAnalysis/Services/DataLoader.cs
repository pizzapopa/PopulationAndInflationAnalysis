using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using PopulationAndInflationAnalysis.Models;

namespace PopulationAndInflationAnalysis.Services
{
    // Класс для загрузки данных из JSON-файла
    public class DataLoader
    {
        // Загружает данные о населении по субъектам из файла
        public List<PopulationData> LoadPopulationData(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл {filePath} не найден");
            }

            string json = File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<List<PopulationData>>(json);
            return data ?? new List<PopulationData>();
        }

        // Создаёт пример файла с данными для демонстрации
        public void CreateSamplePopulationFile(string filePath)
        {
            var sampleData = new List<PopulationData>
            {
                new PopulationData { Year = 2010, Region = "Москва", Population = 11.5 },
                new PopulationData { Year = 2011, Region = "Москва", Population = 11.6 },
                new PopulationData { Year = 2012, Region = "Москва", Population = 11.7 },
                new PopulationData { Year = 2013, Region = "Москва", Population = 11.8 },
                new PopulationData { Year = 2014, Region = "Москва", Population = 12.0 },
                new PopulationData { Year = 2015, Region = "Москва", Population = 12.1 },
                new PopulationData { Year = 2016, Region = "Москва", Population = 12.3 },
                new PopulationData { Year = 2017, Region = "Москва", Population = 12.4 },
                new PopulationData { Year = 2018, Region = "Москва", Population = 12.5 },
                new PopulationData { Year = 2019, Region = "Москва", Population = 12.6 },
                new PopulationData { Year = 2020, Region = "Москва", Population = 12.7 },
                new PopulationData { Year = 2021, Region = "Москва", Population = 13.0 },
                new PopulationData { Year = 2022, Region = "Москва", Population = 13.1 },
                new PopulationData { Year = 2023, Region = "Москва", Population = 13.2 },
                new PopulationData { Year = 2024, Region = "Москва", Population = 13.4 },
                new PopulationData { Year = 2010, Region = "СПб", Population = 4.8 },
                new PopulationData { Year = 2011, Region = "СПб", Population = 4.9 },
                new PopulationData { Year = 2012, Region = "СПб", Population = 5.0 },
                new PopulationData { Year = 2013, Region = "СПб", Population = 5.1 },
                new PopulationData { Year = 2014, Region = "СПб", Population = 5.2 },
                new PopulationData { Year = 2015, Region = "СПб", Population = 5.3 },
                new PopulationData { Year = 2016, Region = "СПб", Population = 5.4 },
                new PopulationData { Year = 2017, Region = "СПб", Population = 5.5 },
                new PopulationData { Year = 2018, Region = "СПб", Population = 5.6 },
                new PopulationData { Year = 2019, Region = "СПб", Population = 5.7 },
                new PopulationData { Year = 2020, Region = "СПб", Population = 5.6 },
                new PopulationData { Year = 2021, Region = "СПб", Population = 5.7 },
                new PopulationData { Year = 2022, Region = "СПб", Population = 5.8 },
                new PopulationData { Year = 2023, Region = "СПб", Population = 5.9 },
                new PopulationData { Year = 2024, Region = "СПб", Population = 6.0 }
            };

            string json = JsonConvert.SerializeObject(sampleData, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}