using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PopulationAndInflationAnalysis.Services
{
    /// <summary>
    /// Сервис для экспорта графиков в изображения
    /// </summary>
    public class ChartExportService
    {
        /// <summary>
        /// Сохраняет график в PNG-файл
        /// </summary>
        /// <param name="chart">Элемент Chart для сохранения</param>
        /// <param name="filePath">Путь к файлу для сохранения</param>
        public void ExportToImage(Chart chart, string filePath)
        {
            try
            {
                chart.SaveImage(filePath, ChartImageFormat.Png);
                MessageBox.Show($"График сохранён: {filePath}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}