using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PopulationAndInflationAnalysis.Models;
using PopulationAndInflationAnalysis.Services;

namespace PopulationAndInflationAnalysis
{
    public partial class MainForm : Form
    {
        private DataLoader _dataLoader;
        private MovingAverageCalculator _maCalculator;
        private ChartExportService _exportService;

        private List<InflationData> _currentInflationData;
        private double _currentPrice = 1000;

        public MainForm()
        {
            InitializeComponent();
            _dataLoader = new DataLoader();
            _maCalculator = new MovingAverageCalculator();
            _exportService = new ChartExportService();

            dataGridViewData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            btnLoadFile.Click += BtnLoadFile_Click;
            btnCalculate.Click += BtnCalculate_Click;
            btnExportChart.Click += BtnExportChart_Click;
        }

        private void BtnLoadFile_Click(object sender, EventArgs e)
        {
            if (rbtnInflation.Checked)
            {
                LoadInflationData();
            }
        }

        private void LoadInflationData()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.Title = "Выберите файл с данными об инфляции";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _currentInflationData = _dataLoader.LoadInflationData(openFileDialog.FileName);
                        if (_currentInflationData == null || _currentInflationData.Count == 0)
                        {
                            MessageBox.Show("Файл пуст", "Ошибка");
                            return;
                        }
                        DisplayInflationDataInGrid();
                        DrawInflationChart();
                        MessageBox.Show($"Загружено {_currentInflationData.Count} записей", "Успех");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
                    }
                }
            }
        }

        private void DisplayInflationDataInGrid()
        {
            dataGridViewData.Columns.Clear();
            dataGridViewData.DataSource = null;
            var displayData = _currentInflationData.OrderBy(x => x.Year)
                .Select(x => new { x.Year, x.InflationRate }).ToList();
            dataGridViewData.DataSource = displayData;
        }

        private void DrawInflationChart()
        {
            chartData.Series.Clear();
            var sortedData = _currentInflationData.OrderBy(x => x.Year).ToList();
            Series series = new Series
            {
                Name = "Инфляция",
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                Color = System.Drawing.Color.Blue
            };
            foreach (var item in sortedData)
            {
                series.Points.AddXY(item.Year, item.InflationRate);
            }
            chartData.Series.Add(series);
            chartData.ChartAreas[0].AxisX.Title = "Год";
            chartData.ChartAreas[0].AxisY.Title = "Инфляция(%)";
            chartData.Legends[0].Docking = Docking.Bottom;
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            if (rbtnInflation.Checked)
            {
                CalculateInflationForecast();
            }
        }

        private void CalculateInflationForecast()
        {
            if (_currentInflationData == null || _currentInflationData.Count == 0)
            {
                MessageBox.Show("Сначала загрузите данные", "Ошибка");
                return;
            }
            if (!int.TryParse(txtN.Text, out int n) || n < 2)
            {
                MessageBox.Show("Введите период N (целое число больше 1)", "Ошибка");
                return;
            }

            var sortedData = _currentInflationData.OrderBy(x => x.Year).ToList();
            var values = sortedData.Select(x => x.InflationRate).ToList();
            var forecast = _maCalculator.CalculateForecast(values, n, 5);
            var futurePrices = _maCalculator.CalculateFuturePrices(_currentPrice, values, 5);

            Series series = chartData.Series.FindByName("Инфляция");
            if (series == null)
            {
                series = new Series("Инфляция");
                series.ChartType = SeriesChartType.Line;
                series.BorderWidth = 2;
                chartData.Series.Add(series);
            }

            int startYear = sortedData.Last().Year + 1;
            for (int i = 0; i < forecast.Count; i++)
            {
                DataPoint point = new DataPoint();
                point.SetValueXY(startYear + i, forecast[i]);
                point.Color = System.Drawing.Color.Red;
                point.MarkerStyle = MarkerStyle.Triangle;
                point.MarkerSize = 8;
                series.Points.Add(point);
            }

            string resultText = "========== РЕЗУЛЬТАТЫ АНАЛИЗА ИНФЛЯЦИИ ==========\r\n\r\n";
            resultText += $"Прогноз инфляции на 5 лет: {string.Join(" → ", forecast.Select(f => f.ToString("F2")))} %\r\n\r\n";
            resultText += $"Стоимость товара ({_currentPrice} руб) через 5 лет:\r\n";
            for (int i = 0; i < futurePrices.Count; i++)
            {
                resultText += $"  {startYear + i}: {futurePrices[i]:F2} руб\r\n";
            }
            richTextBoxResult.Text = resultText;
        }

        private void BtnExportChart_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png";
                saveFileDialog.Title = "Сохранить график";
                saveFileDialog.FileName = $"chart_{DateTime.Now:yyyyMMdd_HHmmss}.png";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _exportService.ExportToImage(chartData, saveFileDialog.FileName);
                }
            }
        }
    }
}