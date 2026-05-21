using System;

namespace PopulationAndInflationAnalysis.Models
{
    /// <summary>
    /// Класс, представляющий данные о численности населения по субъекту РФ за год
    /// </summary>
    public class PopulationData
    {
        /// <summary>
        /// Год, за который указаны данные
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Название субъекта РФ (региона)
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Численность населения (в миллионах человек)
        /// </summary>
        public double Population { get; set; }

        /// <summary>
        /// Строковое представление объекта для отладки
        /// </summary>
        public override string ToString()
        {
            return $"{Year} - {Region}: {Population}";
        }
    }
}