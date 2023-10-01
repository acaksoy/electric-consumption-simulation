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
            DataGridView1 = new DataGridView();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            resultsComboBox = new ComboBox();
            label1 = new Label();
            checkBoxSolarPanel = new CheckBox();
            checkBoxWindTurbine = new CheckBox();
            checkBoxHydroPlant = new CheckBox();
            checkBoxTotalProd = new CheckBox();
            checkBoxHouse1 = new CheckBox();
            checkBoxHouse2 = new CheckBox();
            checkBoxHouse3 = new CheckBox();
            checkBoxBusiness1 = new CheckBox();
            checkBoxBusiness2 = new CheckBox();
            checkBoxBusiness3 = new CheckBox();
            checkBoxPublic = new CheckBox();
            checkBoxTotalCons = new CheckBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            checkBoxFossil = new CheckBox();
            yearlyTotalProductionLabel = new Label();
            yearlyTotalConsumptionLabel = new Label();
            selectedYearlyTotal = new Label();
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
            DataGridView1.Size = new Size(309, 636);
            DataGridView1.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(336, 36);
            chart1.Name = "chart1";
            chart1.Size = new Size(1307, 665);
            chart1.TabIndex = 1;
            chart1.Text = "chart1";
            // 
            // resultsComboBox
            // 
            resultsComboBox.FormattingEnabled = true;
            resultsComboBox.Location = new Point(21, 36);
            resultsComboBox.Name = "resultsComboBox";
            resultsComboBox.Size = new Size(309, 23);
            resultsComboBox.TabIndex = 2;
            resultsComboBox.SelectedIndexChanged += ComboBox_Selected;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(677, -4);
            label1.Name = "label1";
            label1.Size = new Size(254, 37);
            label1.TabIndex = 3;
            label1.Text = "Simulation Results";
            // 
            // checkBoxSolarPanel
            // 
            checkBoxSolarPanel.AutoSize = true;
            checkBoxSolarPanel.Location = new Point(571, 754);
            checkBoxSolarPanel.Name = "checkBoxSolarPanel";
            checkBoxSolarPanel.Size = new Size(83, 19);
            checkBoxSolarPanel.TabIndex = 4;
            checkBoxSolarPanel.Tag = "Production";
            checkBoxSolarPanel.Text = "checkBox1";
            checkBoxSolarPanel.UseVisualStyleBackColor = true;
            checkBoxSolarPanel.CheckedChanged += CheckBox_Checked;
            // 
            // checkBoxWindTurbine
            // 
            checkBoxWindTurbine.AutoSize = true;
            checkBoxWindTurbine.Location = new Point(677, 754);
            checkBoxWindTurbine.Name = "checkBoxWindTurbine";
            checkBoxWindTurbine.Size = new Size(83, 19);
            checkBoxWindTurbine.TabIndex = 5;
            checkBoxWindTurbine.Tag = "Production";
            checkBoxWindTurbine.Text = "checkBox2";
            checkBoxWindTurbine.UseVisualStyleBackColor = true;
            checkBoxWindTurbine.CheckedChanged += CheckBox_Checked;
            // 
            // checkBoxHydroPlant
            // 
            checkBoxHydroPlant.AutoSize = true;
            checkBoxHydroPlant.Location = new Point(459, 705);
            checkBoxHydroPlant.Name = "checkBoxHydroPlant";
            checkBoxHydroPlant.Size = new Size(83, 19);
            checkBoxHydroPlant.TabIndex = 6;
            checkBoxHydroPlant.Tag = "Production";
            checkBoxHydroPlant.Text = "checkBox3";
            checkBoxHydroPlant.UseVisualStyleBackColor = true;
            checkBoxHydroPlant.CheckedChanged += CheckBox_Checked;
            // 
            // checkBoxTotalProd
            // 
            checkBoxTotalProd.AutoSize = true;
            checkBoxTotalProd.Location = new Point(459, 730);
            checkBoxTotalProd.Name = "checkBoxTotalProd";
            checkBoxTotalProd.Size = new Size(83, 19);
            checkBoxTotalProd.TabIndex = 7;
            checkBoxTotalProd.Tag = "Production";
            checkBoxTotalProd.Text = "checkBox4";
            checkBoxTotalProd.UseVisualStyleBackColor = true;
            checkBoxTotalProd.CheckedChanged += CheckBox_Checked;
            // 
            // checkBoxHouse1
            // 
            checkBoxHouse1.AutoSize = true;
            checkBoxHouse1.Location = new Point(571, 705);
            checkBoxHouse1.Name = "checkBoxHouse1";
            checkBoxHouse1.Size = new Size(83, 19);
            checkBoxHouse1.TabIndex = 8;
            checkBoxHouse1.Tag = "Consumption";
            checkBoxHouse1.Text = "checkBox5";
            checkBoxHouse1.UseVisualStyleBackColor = true;
            checkBoxHouse1.CheckedChanged += CheckBox_Checked;
            // 
            // checkBoxHouse2
            // 
            checkBoxHouse2.AutoSize = true;
            checkBoxHouse2.Location = new Point(571, 730);
            checkBoxHouse2.Name = "checkBoxHouse2";
            checkBoxHouse2.Size = new Size(83, 19);
            checkBoxHouse2.TabIndex = 9;
            checkBoxHouse2.Tag = "Consumption";
            checkBoxHouse2.Text = "checkBox6";
            checkBoxHouse2.UseVisualStyleBackColor = true;
            checkBoxHouse2.CheckedChanged += CheckBox_Checked;
            // 
            // checkBoxHouse3
            // 
            checkBoxHouse3.AutoSize = true;
            checkBoxHouse3.Location = new Point(677, 704);
            checkBoxHouse3.Name = "checkBoxHouse3";
            checkBoxHouse3.Size = new Size(83, 19);
            checkBoxHouse3.TabIndex = 10;
            checkBoxHouse3.Tag = "Consumption";
            checkBoxHouse3.Text = "checkBox7";
            checkBoxHouse3.UseVisualStyleBackColor = true;
            checkBoxHouse3.CheckedChanged += CheckBox_Checked;
            // 
            // checkBoxBusiness1
            // 
            checkBoxBusiness1.AutoSize = true;
            checkBoxBusiness1.Location = new Point(677, 729);
            checkBoxBusiness1.Name = "checkBoxBusiness1";
            checkBoxBusiness1.Size = new Size(83, 19);
            checkBoxBusiness1.TabIndex = 11;
            checkBoxBusiness1.Tag = "Consumption";
            checkBoxBusiness1.Text = "checkBox8";
            checkBoxBusiness1.UseVisualStyleBackColor = true;
            checkBoxBusiness1.CheckedChanged += CheckBox_Checked;
            // 
            // checkBoxBusiness2
            // 
            checkBoxBusiness2.AutoSize = true;
            checkBoxBusiness2.Location = new Point(787, 705);
            checkBoxBusiness2.Name = "checkBoxBusiness2";
            checkBoxBusiness2.Size = new Size(83, 19);
            checkBoxBusiness2.TabIndex = 12;
            checkBoxBusiness2.Tag = "Consumption";
            checkBoxBusiness2.Text = "checkBox9";
            checkBoxBusiness2.UseVisualStyleBackColor = true;
            checkBoxBusiness2.CheckedChanged += CheckBox_Checked;
            // 
            // checkBoxBusiness3
            // 
            checkBoxBusiness3.AutoSize = true;
            checkBoxBusiness3.Location = new Point(787, 729);
            checkBoxBusiness3.Name = "checkBoxBusiness3";
            checkBoxBusiness3.Size = new Size(83, 19);
            checkBoxBusiness3.TabIndex = 13;
            checkBoxBusiness3.Tag = "Consumption";
            checkBoxBusiness3.Text = "checkBox9";
            checkBoxBusiness3.UseVisualStyleBackColor = true;
            checkBoxBusiness3.CheckedChanged += CheckBox_Checked;
            // 
            // checkBoxPublic
            // 
            checkBoxPublic.AutoSize = true;
            checkBoxPublic.Location = new Point(889, 705);
            checkBoxPublic.Name = "checkBoxPublic";
            checkBoxPublic.Size = new Size(83, 19);
            checkBoxPublic.TabIndex = 14;
            checkBoxPublic.Tag = "Consumption";
            checkBoxPublic.Text = "checkBox9";
            checkBoxPublic.UseVisualStyleBackColor = true;
            checkBoxPublic.CheckedChanged += CheckBox_Checked;
            // 
            // checkBoxTotalCons
            // 
            checkBoxTotalCons.AutoSize = true;
            checkBoxTotalCons.Location = new Point(889, 729);
            checkBoxTotalCons.Name = "checkBoxTotalCons";
            checkBoxTotalCons.Size = new Size(83, 19);
            checkBoxTotalCons.TabIndex = 15;
            checkBoxTotalCons.Tag = "Consumption";
            checkBoxTotalCons.Text = "checkBox9";
            checkBoxTotalCons.UseVisualStyleBackColor = true;
            checkBoxTotalCons.CheckedChanged += CheckBox_Checked;
            // 
            // button1
            // 
            button1.Location = new Point(1182, 726);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 16;
            button1.Tag = "Monthly";
            button1.Text = "Monthly";
            button1.UseVisualStyleBackColor = true;
            button1.Click += DrawGraph;
            // 
            // button2
            // 
            button2.Location = new Point(1263, 726);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 17;
            button2.Tag = "Daily";
            button2.Text = "Daily";
            button2.UseVisualStyleBackColor = true;
            button2.Click += DrawGraph;
            // 
            // button3
            // 
            button3.Location = new Point(1344, 726);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 18;
            button3.Tag = "Hourly";
            button3.Text = "Hourly";
            button3.UseVisualStyleBackColor = true;
            button3.Click += DrawGraph;
            // 
            // checkBoxFossil
            // 
            checkBoxFossil.AutoSize = true;
            checkBoxFossil.Location = new Point(787, 754);
            checkBoxFossil.Name = "checkBoxFossil";
            checkBoxFossil.Size = new Size(83, 19);
            checkBoxFossil.TabIndex = 19;
            checkBoxFossil.Tag = "Consumption";
            checkBoxFossil.Text = "checkBox9";
            checkBoxFossil.UseVisualStyleBackColor = true;
            checkBoxFossil.CheckedChanged += CheckBox_Checked;
            // 
            // yearlyTotalProductionLabel
            // 
            yearlyTotalProductionLabel.AutoSize = true;
            yearlyTotalProductionLabel.Location = new Point(21, 734);
            yearlyTotalProductionLabel.Name = "yearlyTotalProductionLabel";
            yearlyTotalProductionLabel.Size = new Size(200, 15);
            yearlyTotalProductionLabel.TabIndex = 20;
            yearlyTotalProductionLabel.Text = "Total Elec. Prod. Renewable (annual):";
            // 
            // yearlyTotalConsumptionLabel
            // 
            yearlyTotalConsumptionLabel.AutoSize = true;
            yearlyTotalConsumptionLabel.Location = new Point(21, 762);
            yearlyTotalConsumptionLabel.Name = "yearlyTotalConsumptionLabel";
            yearlyTotalConsumptionLabel.Size = new Size(185, 15);
            yearlyTotalConsumptionLabel.TabIndex = 21;
            yearlyTotalConsumptionLabel.Text = "Total Elec. Consumption (annual):";
            // 
            // selectedYearlyTotal
            // 
            selectedYearlyTotal.AutoSize = true;
            selectedYearlyTotal.Location = new Point(21, 709);
            selectedYearlyTotal.Name = "selectedYearlyTotal";
            selectedYearlyTotal.Size = new Size(163, 15);
            selectedYearlyTotal.TabIndex = 22;
            selectedYearlyTotal.Text = "Selected Record Annual Total:";
            // 
            // DisplayResult
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1655, 786);
            Controls.Add(selectedYearlyTotal);
            Controls.Add(yearlyTotalConsumptionLabel);
            Controls.Add(yearlyTotalProductionLabel);
            Controls.Add(checkBoxFossil);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(checkBoxTotalCons);
            Controls.Add(checkBoxPublic);
            Controls.Add(checkBoxBusiness3);
            Controls.Add(checkBoxBusiness2);
            Controls.Add(checkBoxBusiness1);
            Controls.Add(checkBoxHouse3);
            Controls.Add(checkBoxHouse2);
            Controls.Add(checkBoxHouse1);
            Controls.Add(checkBoxTotalProd);
            Controls.Add(checkBoxHydroPlant);
            Controls.Add(checkBoxWindTurbine);
            Controls.Add(checkBoxSolarPanel);
            Controls.Add(label1);
            Controls.Add(resultsComboBox);
            Controls.Add(chart1);
            Controls.Add(DataGridView1);
            Name = "DisplayResult";
            Text = "DisplayResult";
            Shown += DisplayResult_Shown;
            ((System.ComponentModel.ISupportInitialize)DataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private ComboBox resultsComboBox;
        private Label label1;
        private CheckBox checkBoxSolarPanel;
        private CheckBox checkBoxWindTurbine;
        private CheckBox checkBoxHydroPlant;
        private CheckBox checkBoxTotalProd;
        private CheckBox checkBoxHouse1;
        private CheckBox checkBoxHouse2;
        private CheckBox checkBoxHouse3;
        private CheckBox checkBoxBusiness1;
        private CheckBox checkBoxBusiness2;
        private CheckBox checkBoxBusiness3;
        private CheckBox checkBoxPublic;
        private CheckBox checkBoxTotalCons;
        private Button button1;
        private Button button2;
        private Button button3;
        private CheckBox checkBoxFossil;
        private Label yearlyTotalProductionLabel;
        private Label yearlyTotalConsumptionLabel;
        private Label selectedYearlyTotal;
    }
}