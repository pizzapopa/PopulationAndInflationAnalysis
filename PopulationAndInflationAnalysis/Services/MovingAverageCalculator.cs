using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationAndInflationAnalysis.Services
{
    public class MovingAverageCalculator
    {
        public List<double> CalculateForecast(List<double> values, int n, int forecastSteps)
        {
            if (values == null || values.Count < n)
                throw new ArgumentException("Недостаточно данных для расчёта");

            var forecast = new List<double>();
            var currentValues = new List<double>(values);

            for (int step = 0; step < forecastSteps; step++)
            {
                var lastN = currentValues.Skip(currentValues.Count - n).Take(n).ToList();
                double average = lastN.Average();
                forecast.Add(average);
                currentValues.Add(average);
            }
            return forecast;
        }

        public List<double> CalculateMovingAverage(List<double> values, int n)
        {
            var result = new List<double>();
            for (int i = 0; i < values.Count; i++)
            {
                if (i < n - 1)
                {
                    result.Add(0);
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

        // 10 вариант (инфляция) - расчёт стоимости товара
        public List<double> CalculateFuturePrices(double price, List<double> inflationRates, int years)
        {
            var futurePrices = new List<double>();
            double currentPrice =


price;

            for (int i = 0; i < years; i++)
            {
                double avgInflation = inflationRates.Skip(Math.Max(0, inflationRates.Count - 3)).Average();
                currentPrice = currentPrice * (1 + avgInflation / 100);
                futurePrices.Add(currentPrice);
            }
            return futurePrices;
        }
    }
}