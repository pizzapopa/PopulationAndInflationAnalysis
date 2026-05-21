using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationAndInflationAnalysis.Models
{
    /// <summary>
    /// Модель данных о численности населения
    /// </summary>
    public class PopulationData
    {
        /// <summary>
        /// Год, за который зафиксирована численность населения
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Название региона (субъекта РФ)
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Численность населения в миллионах человек
        /// </summary>
        public double Population { get; set; }
    }
}