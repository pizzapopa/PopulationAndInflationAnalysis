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
        private List<PopulationData> _currentPopulationData;

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
            if (rbtnPopulation.Checked)
            {
                LoadPopulationData();
            }
            else if (rbtnInflation.Checked)
            {
                MessageBox.Show("Режим инфляции будет реализован позже (код подруги)", "Информация");
            }
        }

        private void LoadPopulationData()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.Title = "Выберите файл с данными о населении";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _currentPopulationData = _dataLoader.LoadPopulationData(openFileDialog.FileName);
                        if (_currentPopulationData == null || _currentPopulationData.Count == 0)
                        {
                            MessageBox.Show("Файл пуст или имеет неверный формат", "Ошибка");
                            return;
                        }

                        DisplayPopulationDataInGrid();
                        DrawPopulationChart();

                        MessageBox.Show($"Загружено {_currentPopulationData.Count} записей", "Успех");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка");
                    }
                }
            }
        }

        private void DisplayPopulationDataInGrid()
        {
            dataGridViewData.Columns.Clear();
            dataGridViewData.DataSource = null;

            var displayData = _currentPopulationData
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Region)
                .Select(x => new { x.Year, x.Region, x.Population })
                .ToList();

            dataGridViewData.DataSource = displayData;
            dataGridViewData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void DrawPopulationChart()
        {
            chartData.Series.Clear();

            var regions = _currentPopulationData.Select(x => x.Region).Distinct();

            foreach (var region in regions)
            {
                var regionData = _currentPopulationData
                    .Where(x => x.Region == region)
                    .OrderBy(x => x.Year)
                    .ToList();

                Series series = new Series
                {
                    Name = region,
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 2
                };

                foreach (var item in regionData)
                {
                    series.Points.AddXY(item.Year, item.Population);
                }

                chartData.Series.Add(series);
            }

            chartData.ChartAreas[0].AxisX.Title = "Год";
            chartData.ChartAreas[0].AxisY.Title = "Численность населения (млн)";
            chartData.ChartAreas[0].AxisY.Minimum = 0;

            if (_currentPopulationData != null && _currentPopulationData.Any())
            {
                double maxPopulation = _currentPopulationData.Max(x => x.Population);
                chartData.ChartAreas[0].AxisY.Maximum = maxPopulation * 1.1;
            }

            chartData.Legends[0].Docking = Docking.Bottom;
            chartData.Invalidate();
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            if (rbtnPopulation.Checked)
            {
                CalculatePopulationForecast();
            }
            else if (rbtnInflation.Checked)
            {
                MessageBox.Show("Прогноз инфляции будет реализован позже (код подруги)", "Информация");
            }
        }

        private void CalculatePopulationForecast()
        {
            if (_currentPopulationData == null || _currentPopulationData.Count == 0)
            {
                MessageBox.Show("Сначала загрузите данные (пункт Загрузить файл)", "Ошибка");
                return;
            }

            if (!int.TryParse(txtN.Text, out int n) || n < 2)
            {
                MessageBox.Show("Введите корректный период N (целое число больше 1)", "Ошибка");
                return;
            }

            string region = "Москва";
            var regionData = _currentPopulationData
                .Where(x => x.Region == region)
                .OrderBy(x => x.Year)
                .ToList();

            if (regionData.Count < n)
            {
                MessageBox.Show($"Недостаточно данных по региону {region} для периода N={n}", "Ошибка");
                return;
            }

            var values = regionData.Select(x => x.Population).ToList();
            var forecast = _maCalculator.CalculateForecast(values, n, 5);

            Series series = chartData.Series.FindByName(region);
            if (series == null)
            {
                series = new Series(region);
                series.ChartType = SeriesChartType.Line;
                series.BorderWidth = 2;
                chartData.Series.Add(series);
            }

            int startYear = regionData.Last().Year + 1;
            for (int i = 0; i < forecast.Count; i++)
            {
                DataPoint point = new DataPoint();
                point.SetValueXY(startYear + i, forecast[i]);
                point.Color = System.Drawing.Color.Red;
                point.MarkerStyle = MarkerStyle.Triangle;
                point.MarkerSize = 8;
                series.Points.Add(point);
            }

            var populationChanges = _currentPopulationData
                .GroupBy(x => x.Region)
                .Select(g => new
                {
                    Region = g.Key,
                    FirstPopulation = g.OrderBy(x => x.Year).First().Population,
                    LastPopulation = g.OrderBy(x => x.Year).Last().Population,
                    Change = g.OrderBy(x => x.Year).Last().Population - g.OrderBy(x => x.Year).First().Population
                })
                .ToList();

            var maxDecline = populationChanges.OrderBy(x => x.Change).First();
            var minDecline = populationChanges.OrderBy(x => x.Change).Last();

            string resultText = "";
            resultText += "========== РЕЗУЛЬТАТЫ АНАЛИЗА ==========\r\n";
            resultText += "\r\n";
            resultText += $"Прогноз для {region} на 5 лет вперёд:\r\n";
            resultText += string.Join(" → ", forecast.Select(f => f.ToString("F2"))) + " млн\r\n";
            resultText += "\r\n";
            resultText += $"Субъект с максимальным снижением населения: {maxDecline.Region} (снижение на {Math.Abs(maxDecline.Change):F2} млн)\r\n";
            resultText += "\r\n";
            resultText += $"Субъект с минимальным снижением (или ростом): {minDecline.Region} (изменение на {minDecline.Change:F2} млн)\r\n";

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