namespace PopulationAndInflationAnalysis.Models
{
    /// <summary>
    /// Класс, представляющий данные об инфляции в России за год
    /// </summary>
    public class InflationData
    {
        /// <summary>
        /// Год, за который указана инфляция
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Уровень инфляции в процентах
        /// </summary>
        public double InflationRate { get; set; }
    }
}