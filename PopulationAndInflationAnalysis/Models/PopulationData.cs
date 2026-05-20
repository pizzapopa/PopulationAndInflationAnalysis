using System;

namespace PopulationAndInflationAnalysis.Models
{
    // Модель данных о населении по субъекту РФ
    public class PopulationData
    {
        public int Year { get; set; }           // Год
        public string Region { get; set; }      // Название субъекта
        public double Population { get; set; }  // Численность населения (млн или тыс)

        public override string ToString()
        {
            return $"{Year} - {Region}: {Population}";
        }
    }
}