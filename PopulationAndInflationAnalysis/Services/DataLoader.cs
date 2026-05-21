using PopulationAndInflationAnalysis.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace PopulationAndInflationAnalysis.Services
{
    /// <summary>
    /// Сервис для загрузки данных из JSON-файлов
    /// </summary>
    public class DataLoader
    {
        /// <summary>
        /// Загружает данные о численности населения из JSON-файла
        /// </summary>
        /// <param name="filePath">Путь к JSON-файлу</param>
        /// <returns>Список объектов PopulationData</returns>
        /// <exception cref="FileNotFoundException">Выбрасывается, если файл не найден</exception>
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

        /// <summary>
        /// Создаёт пример JSON-файла с демонстрационными данными о населении
        /// </summary>
        /// <param name="filePath">Путь для сохранения файла</param>
        public void CreateSamplePopulationFile(string filePath)
        {
            var sampleData = new List<PopulationData>
            {
                new PopulationData { Year = 2010, Region = "Москва", Population = 11.5 },
                new PopulationData { Year = 2024, Region = "Москва", Population = 13.4 },
                new PopulationData { Year = 2010, Region = "СПб", Population = 4.8 },
                new PopulationData { Year = 2024, Region = "СПб", Population = 6.0 }
            };
            string json = JsonConvert.SerializeObject(sampleData, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Загружает данные об инфляции из JSON-файла (основной метод 10 варианта)
        /// </summary>
        /// <param name="filePath">Путь к JSON-файлу с данными об инфляции</param>
        /// <returns>Список объектов InflationData</returns>
        /// <exception cref="FileNotFoundException">Выбрасывается, если файл не найден</exception>
        public List<InflationData> LoadInflationData(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл {filePath} не найден");
            }
            string json = File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<List<InflationData>>(json);
            return data ?? new List<InflationData>();
        }
    }
}