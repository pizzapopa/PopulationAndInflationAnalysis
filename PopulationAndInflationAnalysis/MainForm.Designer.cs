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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            // 
            // rbtnPopulation
            // 
            this.rbtnPopulation.AutoSize = true;
            this.rbtnPopulation.Checked = true;
            this.rbtnPopulation.Location = new System.Drawing.Point(9, 10);
            this.rbtnPopulation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtnPopulation.Name = "rbtnPopulation";
            this.rbtnPopulation.Size = new System.Drawing.Size(154, 17);
            this.rbtnPopulation.TabIndex = 0;
            this.rbtnPopulation.TabStop = true;
            this.rbtnPopulation.Text = "Население по субъектам";
            this.rbtnPopulation.UseVisualStyleBackColor = true;
            // 
            // rbtnInflation
            // 
            this.rbtnInflation.AutoSize = true;
            this.rbtnInflation.Location = new System.Drawing.Point(136, 10);
            this.rbtnInflation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtnInflation.Name = "rbtnInflation";
            this.rbtnInflation.Size = new System.Drawing.Size(77, 17);
            this.rbtnInflation.TabIndex = 1;
            this.rbtnInflation.Text = "Инфляция";
            this.rbtnInflation.UseVisualStyleBackColor = true;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(9, 31);
            this.btnLoadFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(90, 24);
            this.btnLoadFile.TabIndex = 2;
            this.btnLoadFile.Text = "Загрузить файл";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.BtnLoadFile_Click);
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(195, 34);
            this.txtN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(38, 20);
            this.txtN.TabIndex = 3;
            this.txtN.Text = "3";
            // 
            // labelN
            // 
            this.labelN.AutoSize = true;
            this.labelN.Location = new System.Drawing.Point(136, 37);
            this.labelN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelN.Name = "labelN";
            this.labelN.Size = new System.Drawing.Size(59, 13);
            this.labelN.TabIndex = 4;
            this.labelN.Text = "Период N:";
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.AllowUserToAddRows = false;
            this.dataGridViewData.AllowUserToDeleteRows = false;
            this.dataGridViewData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewData.Location = new System.Drawing.Point(9, 65);
            this.dataGridViewData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.ReadOnly = true;
            this.dataGridViewData.RowHeadersWidth = 51;
            this.dataGridViewData.RowTemplate.Height = 24;
            this.dataGridViewData.Size = new System.Drawing.Size(680, 146);
            this.dataGridViewData.TabIndex = 5;
            // 
            // chartData
            // 
            this.chartData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea4.Name = "ChartArea1";
            this.chartData.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartData.Legends.Add(legend4);
            this.chartData.Location = new System.Drawing.Point(9, 219);
            this.chartData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartData.Name = "chartData";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartData.Series.Add(series4);
            this.chartData.Size = new System.Drawing.Size(680, 228);
            this.chartData.TabIndex = 6;
            this.chartData.Text = "chartData";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCalculate.Location = new System.Drawing.Point(9, 455);
            this.btnCalculate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(112, 24);
            this.btnCalculate.TabIndex = 7;
            this.btnCalculate.Text = "Рассчитать прогноз";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.BtnCalculate_Click);
            // 
            // btnExportChart
            // 
            this.btnExportChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportChart.Location = new System.Drawing.Point(128, 455);
            this.btnExportChart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExportChart.Name = "btnExportChart";
            this.btnExportChart.Size = new System.Drawing.Size(112, 24);
            this.btnExportChart.TabIndex = 8;
            this.btnExportChart.Text = "Сохранить график";
            this.btnExportChart.UseVisualStyleBackColor = true;
            this.btnExportChart.Click += new System.EventHandler(this.BtnExportChart_Click);
            // 
            // richTextBoxResult
            // 
            this.richTextBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxResult.BackColor = System.Drawing.Color.LightYellow;
            this.richTextBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.richTextBoxResult.Location = new System.Drawing.Point(9, 488);
            this.richTextBoxResult.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBoxResult.Name = "richTextBoxResult";
            this.richTextBoxResult.ReadOnly = true;
            this.richTextBoxResult.Size = new System.Drawing.Size(681, 82);
            this.richTextBoxResult.TabIndex = 10;
            this.richTextBoxResult.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 585);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(529, 535);
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