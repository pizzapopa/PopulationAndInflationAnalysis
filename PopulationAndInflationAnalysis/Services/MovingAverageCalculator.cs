using System;
using System.Collections.Generic;
using System.Linq;

namespace PopulationAndInflationAnalysis.Services
{
    // Класс для расчёта скользящей средней (метод экстраполяции)
    public class MovingAverageCalculator
    {
        // Рассчитывает прогноз на N периодов вперёд
        // values: список исходных значений
        // n: период скользящей средней
        // forecastSteps: сколько шагов вперёд прогнозировать
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
                // Считаем среднее
                double average = lastN.Average();
                forecast.Add(average);
                // Добавляем прогнозное значение для следующего шага
                currentValues.Add(average);
            }

            return forecast;
        }

        // Рассчитывает скользящую среднюю для всего ряда (для отображения сглаженного графика)
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
    }
}