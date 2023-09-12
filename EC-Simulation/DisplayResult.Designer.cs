namespace EC_Simulation
{
    partial class DisplayResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            DataGridView1 = new DataGridView();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            resultsComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)DataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // DataGridView1
            // 
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView1.Location = new Point(21, 65);
            DataGridView1.Name = "DataGridView1";
            DataGridView1.ReadOnly = true;
            DataGridView1.RowTemplate.Height = 25;
            DataGridView1.Size = new Size(283, 549);
            DataGridView1.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(310, 65);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(960, 549);
            chart1.TabIndex = 1;
            chart1.Text = "chart1";
            // 
            // resultsComboBox
            // 
            resultsComboBox.FormattingEnabled = true;
            resultsComboBox.Location = new Point(320, 20);
            resultsComboBox.Name = "resultsComboBox";
            resultsComboBox.Size = new Size(339, 23);
            resultsComboBox.TabIndex = 2;
            resultsComboBox.SelectedIndexChanged += ComboBox_Selected;
            // 
            // DisplayResult
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1292, 639);
            Controls.Add(resultsComboBox);
            Controls.Add(chart1);
            Controls.Add(DataGridView1);
            Name = "DisplayResult";
            Text = "DisplayResult";
            ((System.ComponentModel.ISupportInitialize)DataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private ComboBox resultsComboBox;
    }
}