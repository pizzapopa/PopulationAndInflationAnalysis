using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PopulationAndInflationAnalysis.Services
{
    public class ChartExportService
    {
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