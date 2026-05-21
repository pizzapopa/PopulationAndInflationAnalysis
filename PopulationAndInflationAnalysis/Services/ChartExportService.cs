using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PopulationAndInflationAnalysis.Services
{
    /// <summary>
    /// Сервис для экспорта графиков в файлы изображений
    /// </summary>
    public class ChartExportService
    {
        /// <summary>
        /// Экспортирует график из элемента Chart в PNG-изображение
        /// </summary>
        /// <param name="chart">Элемент управления Chart, содержащий график для экспорта</param>
        /// <param name="filePath">Полный путь для сохранения файла </param>
        public void ExportToImage(Chart chart, string filePath)
        {
            try
            {
                // Сохранение графика в PNG формате
                chart.SaveImage(filePath, ChartImageFormat.Png);
                MessageBox.Show($"График сохранён: {filePath}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Обработка ошибок при сохранении
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}