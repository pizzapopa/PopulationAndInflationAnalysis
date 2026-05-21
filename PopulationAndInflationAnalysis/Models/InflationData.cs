using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationAndInflationAnalysis.Models
{
    /// <summary>
    /// Модель данных об инфляции для варианта 10 лабораторной работы
    /// </summary>
    public class InflationData
    {
        /// <summary>
        /// Год, за который зафиксирован показатель инфляции
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Уровень инфляции в процентах за указанный год
        /// </summary>
        public double InflationRate { get; set; }
    }
}