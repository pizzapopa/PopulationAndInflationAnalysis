using System;
using System.Collections.Generic;
using System.Linq;

namespace PopulationAndInflationAnalysis.Services
{
    /// <summary>
    /// Класс для расчёта скользящей средней (метод экстраполяции)
    /// Используется для прогнозирования временных рядов
    /// </summary>
    public class MovingAverageCalculator
    {
        /// <summary>
        /// Рассчитывает прогноз на N периодов вперёд методом скользящей средней
        /// </summary>
        /// <param name="values">Исходный ряд данных (список чисел)</param>
        /// <param name="n">Период скользящей средней (сколько последних значений усреднять)</param>
        /// <param name="forecastSteps">Сколько шагов вперёд нужно спрогнозировать</param>
        /// <returns>Список прогнозных значений</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если недостаточно данных</exception>
        public List<double> CalculateForecast(List<double> values, int n, int forecastSteps)
        {
            if (values == null || values.Count < n)
                throw new ArgumentException("Недостаточно данных для расчёта");

            var forecast = new List<double>();
            var currentValues = new List<double>(values);

            for (int step = 0; step < forecastSteps; step++)
            {
                // Берём последние n значений
                var lastN = currentValues.Skip(currentValues.Count - n).Take(n).ToList();
                // Считаем среднее арифметическое
                double average = lastN.Average();
                forecast.Add(average);
                // Добавляем прогнозное значение для следующего шага (чтобы использовать в расчёте)
                currentValues.Add(average);
            }

            return forecast;
        }

        /// <summary>
        /// Рассчитывает скользящую среднюю для всего ряда данных
        /// Используется для отображения сглаженного графика
        /// </summary>
        /// <param name="values">Исходный ряд данных</param>
        /// <param name="n">Период скользящей средней</param>
        /// <returns>Список значений скользящей средней (первые n-1 элементов равны 0)</returns>
        public List<double> CalculateMovingAverage(List<double> values, int n)
        {
            var result = new List<double>();
            for (int i = 0; i < values.Count; i++)
            {
                if (i < n - 1)
                {
                    result.Add(0); // для первых n-1 точек нет данных
                }
                else
                {
                    double sum = 0;
                    for (int j = i - n + 1; j <= i; j++)
                    {
                        sum += values[j];
                    }
                    result.Add(sum / n);
                }
            }
            return result;
        }

        /// <summary>
        /// Рассчитывает стоимость товара через N лет с учётом инфляции
        /// Используется для 10 варианта (инфляция)
        /// </summary>
        /// <param name="price">Текущая цена товара</param>
        /// <param name="inflationRates">Исторические данные об инфляции по годам</param>
        /// <param name="years">Количество лет прогноза</param>
        /// <returns>Список цен по годам (на каждый год прогноза)</returns>
        public List<double> CalculateFuturePrices(double price, List<double> inflationRates, int years)
        {
            var futurePrices = new List<double>();
            double currentPrice = price;

            for (int i = 0; i < years; i++)
            {
                // Берём среднюю инфляцию за последние 3 года для прогноза
                double avgInflation = inflationRates.Skip(Math.Max(0, inflationRates.Count - 3)).Average();
                currentPrice = currentPrice * (1 + avgInflation / 100);
                futurePrices.Add(currentPrice);
            }
            return futurePrices;
        }
    }
}