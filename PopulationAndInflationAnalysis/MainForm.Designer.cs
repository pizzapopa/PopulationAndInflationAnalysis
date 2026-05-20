namespace PopulationAndInflationAnalysis
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();

            this.rbtnPopulation = new System.Windows.Forms.RadioButton();
            this.rbtnInflation = new System.Windows.Forms.RadioButton();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.txtN = new System.Windows.Forms.TextBox();
            this.labelN = new System.Windows.Forms.Label();
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            this.chartData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnExportChart = new System.Windows.Forms.Button();
            this.richTextBoxResult = new System.Windows.Forms.RichTextBox();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartData)).BeginInit();
            this.SuspendLayout();

            // rbtnPopulation
            this.rbtnPopulation.AutoSize = true;
            this.rbtnPopulation.Checked = true;
            this.rbtnPopulation.Location = new System.Drawing.Point(12, 12);
            this.rbtnPopulation.Name = "rbtnPopulation";
            this.rbtnPopulation.Size = new System.Drawing.Size(164, 20);
            this.rbtnPopulation.TabIndex = 0;
            this.rbtnPopulation.TabStop = true;
            this.rbtnPopulation.Text = "Население по субъектам";
            this.rbtnPopulation.UseVisualStyleBackColor = true;

            // rbtnInflation
            this.rbtnInflation.AutoSize = true;
            this.rbtnInflation.Location = new System.Drawing.Point(182, 12);
            this.rbtnInflation.Name = "rbtnInflation";
            this.rbtnInflation.Size = new System.Drawing.Size(86, 20);
            this.rbtnInflation.TabIndex = 1;
            this.rbtnInflation.Text = "Инфляция";
            this.rbtnInflation.UseVisualStyleBackColor = true;

            // btnLoadFile
            this.btnLoadFile.Location = new System.Drawing.Point(12, 38);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(120, 30);
            this.btnLoadFile.TabIndex = 2;
            this.btnLoadFile.Text = "Загрузить файл";
            this.btnLoadFile.UseVisualStyleBackColor = true;

            // txtN
            this.txtN.Location = new System.Drawing.Point(260, 42);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(50, 22);
            this.txtN.TabIndex = 3;
            this.txtN.Text = "3";

            // labelN
            this.labelN.AutoSize = true;
            this.labelN.Location = new System.Drawing.Point(182, 45);
            this.labelN.Name = "labelN";
            this.labelN.Size = new System.Drawing.Size(72, 16);
            this.labelN.TabIndex = 4;
            this.labelN.Text = "Период N:";

            // dataGridViewData
            this.dataGridViewData.AllowUserToAddRows = false;
            this.dataGridViewData.AllowUserToDeleteRows = false;
            this.dataGridViewData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewData.Location = new System.Drawing.Point(12, 80);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.ReadOnly = true;
            this.dataGridViewData.RowHeadersWidth = 51;
            this.dataGridViewData.RowTemplate.Height = 24;
            this.dataGridViewData.Size = new System.Drawing.Size(860, 180);
            this.dataGridViewData.TabIndex = 5;

            // chartData
            this.chartData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartData.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartData.Legends.Add(legend1);
            this.chartData.Location = new System.Drawing.Point(12, 270);
            this.chartData.Name = "chartData";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartData.Series.Add(series1);
            this.chartData.Size = new System.Drawing.Size(860, 280);
            this.chartData.TabIndex = 6;
            this.chartData.Text = "chartData";

            // btnCalculate
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCalculate.Location = new System.Drawing.Point(12, 560);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(150, 30);
            this.btnCalculate.TabIndex = 7;
            this.btnCalculate.Text = "Рассчитать прогноз";
            this.btnCalculate.UseVisualStyleBackColor = true;

            // btnExportChart
            this.btnExportChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportChart.Location = new System.Drawing.Point(170, 560);
            this.btnExportChart.Name = "btnExportChart";
            this.btnExportChart.Size = new System.Drawing.Size(150, 30);
            this.btnExportChart.TabIndex = 8;
            this.btnExportChart.Text = "Сохранить график";
            this.btnExportChart.UseVisualStyleBackColor = true;

            // richTextBoxResult
            this.richTextBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxResult.BackColor = System.Drawing.Color.LightYellow;
            this.richTextBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.richTextBoxResult.Location = new System.Drawing.Point(12, 600);
            this.richTextBoxResult.Name = "richTextBoxResult";
            this.richTextBoxResult.ReadOnly = true;
            this.richTextBoxResult.Size = new System.Drawing.Size(860, 100);
            this.richTextBoxResult.TabIndex = 10;
            this.richTextBoxResult.Text = "";

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 720);
            this.Controls.Add(this.richTextBoxResult);
            this.Controls.Add(this.btnExportChart);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.chartData);
            this.Controls.Add(this.dataGridViewData);
            this.Controls.Add(this.labelN);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.rbtnInflation);
            this.Controls.Add(this.rbtnPopulation);
            this.MinimumSize = new System.Drawing.Size(700, 650);
            this.Name = "MainForm";
            this.Text = "Анализ населения и инфляции России";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.RadioButton rbtnPopulation;
        private System.Windows.Forms.RadioButton rbtnInflation;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Label labelN;
        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartData;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnExportChart;
        private System.Windows.Forms.RichTextBox richTextBoxResult;
    }
}