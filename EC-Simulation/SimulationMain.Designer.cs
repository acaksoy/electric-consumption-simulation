namespace EC_Simulation
{
    partial class SimulationMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            importWeatherDataButton = new Button();
            importLabelWD = new Label();
            productionParamPanel = new Panel();
            hydroPlantParamPanel = new Panel();
            hydroPlantParamSpecTextBox3 = new TextBox();
            hydroPlantParamSpecLabel3 = new Label();
            hydroPlantParamSpecTextBox2 = new TextBox();
            hydroPlantParamSpecLabel2 = new Label();
            hydroPlantParamSpecTextBox1 = new TextBox();
            hydroPlantParamSpecLabel1 = new Label();
            hydroPlantParamLabel = new Label();
            windTurbinelParamPanel = new Panel();
            windTurbineParamSpecTextBox4 = new TextBox();
            windTurbineParamSpecLabel4 = new Label();
            windTurbineParamSpecTextBox3 = new TextBox();
            windTurbineParamSpecLabel3 = new Label();
            windTurbineParamSpecTextBox2 = new TextBox();
            windTurbineParamSpecLabel2 = new Label();
            windTurbineParamSpecTextBox1 = new TextBox();
            windTurbineParamSpecLabel1 = new Label();
            windTurbineParamLabel = new Label();
            solarPanelParamPanel = new Panel();
            solarPanelParamSpecTextBox4 = new TextBox();
            solarPanelParamSpecLabel4 = new Label();
            solarPanelParamSpecTextBox5 = new TextBox();
            solarPanelParamSpecLabel5 = new Label();
            solarPanelParamSpecTextBox3 = new TextBox();
            solarPanelParamSpecLabel3 = new Label();
            solarPanelParamSpecTextBox2 = new TextBox();
            solarPanelParamSpecLabel2 = new Label();
            solarPanelParamSpecTextBox1 = new TextBox();
            solarPanelParamSpecLabel1 = new Label();
            solarPanelParamLabel = new Label();
            label1 = new Label();
            startSimulationButton = new Button();
            importConsumerDataButton = new Button();
            ImportLabelCD = new Label();
            productionParamPanel.SuspendLayout();
            hydroPlantParamPanel.SuspendLayout();
            windTurbinelParamPanel.SuspendLayout();
            solarPanelParamPanel.SuspendLayout();
            SuspendLayout();
            // 
            // importWeatherDataButton
            // 
            importWeatherDataButton.Location = new Point(18, 442);
            importWeatherDataButton.Name = "importWeatherDataButton";
            importWeatherDataButton.Size = new Size(137, 30);
            importWeatherDataButton.TabIndex = 0;
            importWeatherDataButton.Tag = "";
            importWeatherDataButton.Text = "Import Weather Data";
            importWeatherDataButton.UseVisualStyleBackColor = true;
            importWeatherDataButton.Click += importWeatherDataButton_Click;
            // 
            // importLabelWD
            // 
            importLabelWD.AutoSize = true;
            importLabelWD.Location = new Point(161, 450);
            importLabelWD.Name = "importLabelWD";
            importLabelWD.Size = new Size(82, 15);
            importLabelWD.TabIndex = 1;
            importLabelWD.Text = "- Select a file -";
            // 
            // productionParamPanel
            // 
            productionParamPanel.BorderStyle = BorderStyle.FixedSingle;
            productionParamPanel.Controls.Add(hydroPlantParamPanel);
            productionParamPanel.Controls.Add(hydroPlantParamLabel);
            productionParamPanel.Controls.Add(windTurbinelParamPanel);
            productionParamPanel.Controls.Add(windTurbineParamLabel);
            productionParamPanel.Controls.Add(solarPanelParamPanel);
            productionParamPanel.Controls.Add(solarPanelParamLabel);
            productionParamPanel.Location = new Point(487, 27);
            productionParamPanel.Name = "productionParamPanel";
            productionParamPanel.Size = new Size(484, 300);
            productionParamPanel.TabIndex = 2;
            // 
            // hydroPlantParamPanel
            // 
            hydroPlantParamPanel.BorderStyle = BorderStyle.FixedSingle;
            hydroPlantParamPanel.Controls.Add(hydroPlantParamSpecTextBox3);
            hydroPlantParamPanel.Controls.Add(hydroPlantParamSpecLabel3);
            hydroPlantParamPanel.Controls.Add(hydroPlantParamSpecTextBox2);
            hydroPlantParamPanel.Controls.Add(hydroPlantParamSpecLabel2);
            hydroPlantParamPanel.Controls.Add(hydroPlantParamSpecTextBox1);
            hydroPlantParamPanel.Controls.Add(hydroPlantParamSpecLabel1);
            hydroPlantParamPanel.Location = new Point(241, 154);
            hydroPlantParamPanel.Name = "hydroPlantParamPanel";
            hydroPlantParamPanel.Size = new Size(229, 95);
            hydroPlantParamPanel.TabIndex = 5;
            // 
            // hydroPlantParamSpecTextBox3
            // 
            hydroPlantParamSpecTextBox3.Location = new Point(112, 64);
            hydroPlantParamSpecTextBox3.Name = "hydroPlantParamSpecTextBox3";
            hydroPlantParamSpecTextBox3.Size = new Size(100, 23);
            hydroPlantParamSpecTextBox3.TabIndex = 5;
            hydroPlantParamSpecTextBox3.Validating += validateTextBox_int;
            // 
            // hydroPlantParamSpecLabel3
            // 
            hydroPlantParamSpecLabel3.AutoSize = true;
            hydroPlantParamSpecLabel3.Location = new Point(3, 67);
            hydroPlantParamSpecLabel3.Name = "hydroPlantParamSpecLabel3";
            hydroPlantParamSpecLabel3.Size = new Size(89, 15);
            hydroPlantParamSpecLabel3.TabIndex = 4;
            hydroPlantParamSpecLabel3.Text = "Num. of Plants:";
            // 
            // hydroPlantParamSpecTextBox2
            // 
            hydroPlantParamSpecTextBox2.Location = new Point(112, 35);
            hydroPlantParamSpecTextBox2.Name = "hydroPlantParamSpecTextBox2";
            hydroPlantParamSpecTextBox2.Size = new Size(100, 23);
            hydroPlantParamSpecTextBox2.TabIndex = 3;
            hydroPlantParamSpecTextBox2.Validating += validateTextBox_float;
            // 
            // hydroPlantParamSpecLabel2
            // 
            hydroPlantParamSpecLabel2.AutoSize = true;
            hydroPlantParamSpecLabel2.Location = new Point(3, 38);
            hydroPlantParamSpecLabel2.Name = "hydroPlantParamSpecLabel2";
            hydroPlantParamSpecLabel2.Size = new Size(58, 15);
            hydroPlantParamSpecLabel2.TabIndex = 2;
            hydroPlantParamSpecLabel2.Text = "Efficiency";
            // 
            // hydroPlantParamSpecTextBox1
            // 
            hydroPlantParamSpecTextBox1.Location = new Point(112, 6);
            hydroPlantParamSpecTextBox1.Name = "hydroPlantParamSpecTextBox1";
            hydroPlantParamSpecTextBox1.Size = new Size(100, 23);
            hydroPlantParamSpecTextBox1.TabIndex = 1;
            hydroPlantParamSpecTextBox1.Validating += validateTextBox_float;
            // 
            // hydroPlantParamSpecLabel1
            // 
            hydroPlantParamSpecLabel1.AutoSize = true;
            hydroPlantParamSpecLabel1.Location = new Point(3, 9);
            hydroPlantParamSpecLabel1.Name = "hydroPlantParamSpecLabel1";
            hydroPlantParamSpecLabel1.Size = new Size(46, 15);
            hydroPlantParamSpecLabel1.TabIndex = 0;
            hydroPlantParamSpecLabel1.Text = "Height:";
            // 
            // hydroPlantParamLabel
            // 
            hydroPlantParamLabel.AutoSize = true;
            hydroPlantParamLabel.Location = new Point(241, 136);
            hydroPlantParamLabel.Name = "hydroPlantParamLabel";
            hydroPlantParamLabel.Size = new Size(139, 15);
            hydroPlantParamLabel.TabIndex = 4;
            hydroPlantParamLabel.Text = "Hydro Power Plant Specs";
            hydroPlantParamLabel.TextAlign = ContentAlignment.BottomRight;
            // 
            // windTurbinelParamPanel
            // 
            windTurbinelParamPanel.BorderStyle = BorderStyle.FixedSingle;
            windTurbinelParamPanel.Controls.Add(windTurbineParamSpecTextBox4);
            windTurbinelParamPanel.Controls.Add(windTurbineParamSpecLabel4);
            windTurbinelParamPanel.Controls.Add(windTurbineParamSpecTextBox3);
            windTurbinelParamPanel.Controls.Add(windTurbineParamSpecLabel3);
            windTurbinelParamPanel.Controls.Add(windTurbineParamSpecTextBox2);
            windTurbinelParamPanel.Controls.Add(windTurbineParamSpecLabel2);
            windTurbinelParamPanel.Controls.Add(windTurbineParamSpecTextBox1);
            windTurbinelParamPanel.Controls.Add(windTurbineParamSpecLabel1);
            windTurbinelParamPanel.Location = new Point(6, 154);
            windTurbinelParamPanel.Name = "windTurbinelParamPanel";
            windTurbinelParamPanel.Size = new Size(229, 128);
            windTurbinelParamPanel.TabIndex = 3;
            // 
            // windTurbineParamSpecTextBox4
            // 
            windTurbineParamSpecTextBox4.Location = new Point(112, 93);
            windTurbineParamSpecTextBox4.Name = "windTurbineParamSpecTextBox4";
            windTurbineParamSpecTextBox4.Size = new Size(100, 23);
            windTurbineParamSpecTextBox4.TabIndex = 9;
            windTurbineParamSpecTextBox4.Validating += validateTextBox_int;
            // 
            // windTurbineParamSpecLabel4
            // 
            windTurbineParamSpecLabel4.AutoSize = true;
            windTurbineParamSpecLabel4.Location = new Point(6, 96);
            windTurbineParamSpecLabel4.Name = "windTurbineParamSpecLabel4";
            windTurbineParamSpecLabel4.Size = new Size(102, 15);
            windTurbineParamSpecLabel4.TabIndex = 8;
            windTurbineParamSpecLabel4.Text = "Num. of Turbines:";
            // 
            // windTurbineParamSpecTextBox3
            // 
            windTurbineParamSpecTextBox3.Location = new Point(112, 64);
            windTurbineParamSpecTextBox3.Name = "windTurbineParamSpecTextBox3";
            windTurbineParamSpecTextBox3.Size = new Size(100, 23);
            windTurbineParamSpecTextBox3.TabIndex = 5;
            windTurbineParamSpecTextBox3.Validating += validateTextBox_float;
            // 
            // windTurbineParamSpecLabel3
            // 
            windTurbineParamSpecLabel3.AutoSize = true;
            windTurbineParamSpecLabel3.Location = new Point(3, 67);
            windTurbineParamSpecLabel3.Name = "windTurbineParamSpecLabel3";
            windTurbineParamSpecLabel3.Size = new Size(65, 15);
            windTurbineParamSpecLabel3.TabIndex = 4;
            windTurbineParamSpecLabel3.Text = "Availablity:";
            // 
            // windTurbineParamSpecTextBox2
            // 
            windTurbineParamSpecTextBox2.Location = new Point(112, 35);
            windTurbineParamSpecTextBox2.Name = "windTurbineParamSpecTextBox2";
            windTurbineParamSpecTextBox2.Size = new Size(100, 23);
            windTurbineParamSpecTextBox2.TabIndex = 3;
            windTurbineParamSpecTextBox2.Validating += validateTextBox_float;
            // 
            // windTurbineParamSpecLabel2
            // 
            windTurbineParamSpecLabel2.AutoSize = true;
            windTurbineParamSpecLabel2.Location = new Point(3, 38);
            windTurbineParamSpecLabel2.Name = "windTurbineParamSpecLabel2";
            windTurbineParamSpecLabel2.Size = new Size(101, 15);
            windTurbineParamSpecLabel2.TabIndex = 2;
            windTurbineParamSpecLabel2.Text = "Power Coefficent:";
            // 
            // windTurbineParamSpecTextBox1
            // 
            windTurbineParamSpecTextBox1.Location = new Point(112, 6);
            windTurbineParamSpecTextBox1.Name = "windTurbineParamSpecTextBox1";
            windTurbineParamSpecTextBox1.Size = new Size(100, 23);
            windTurbineParamSpecTextBox1.TabIndex = 1;
            windTurbineParamSpecTextBox1.Validating += validateTextBox_float;
            // 
            // windTurbineParamSpecLabel1
            // 
            windTurbineParamSpecLabel1.AutoSize = true;
            windTurbineParamSpecLabel1.Location = new Point(3, 9);
            windTurbineParamSpecLabel1.Name = "windTurbineParamSpecLabel1";
            windTurbineParamSpecLabel1.Size = new Size(66, 15);
            windTurbineParamSpecLabel1.TabIndex = 0;
            windTurbineParamSpecLabel1.Text = "Blade Area:";
            // 
            // windTurbineParamLabel
            // 
            windTurbineParamLabel.AutoSize = true;
            windTurbineParamLabel.Location = new Point(6, 136);
            windTurbineParamLabel.Name = "windTurbineParamLabel";
            windTurbineParamLabel.Size = new Size(111, 15);
            windTurbineParamLabel.TabIndex = 2;
            windTurbineParamLabel.Text = "Wind Turbine Specs";
            windTurbineParamLabel.TextAlign = ContentAlignment.BottomRight;
            // 
            // solarPanelParamPanel
            // 
            solarPanelParamPanel.BorderStyle = BorderStyle.FixedSingle;
            solarPanelParamPanel.Controls.Add(solarPanelParamSpecTextBox4);
            solarPanelParamPanel.Controls.Add(solarPanelParamSpecLabel4);
            solarPanelParamPanel.Controls.Add(solarPanelParamSpecTextBox5);
            solarPanelParamPanel.Controls.Add(solarPanelParamSpecLabel5);
            solarPanelParamPanel.Controls.Add(solarPanelParamSpecTextBox3);
            solarPanelParamPanel.Controls.Add(solarPanelParamSpecLabel3);
            solarPanelParamPanel.Controls.Add(solarPanelParamSpecTextBox2);
            solarPanelParamPanel.Controls.Add(solarPanelParamSpecLabel2);
            solarPanelParamPanel.Controls.Add(solarPanelParamSpecTextBox1);
            solarPanelParamPanel.Controls.Add(solarPanelParamSpecLabel1);
            solarPanelParamPanel.Location = new Point(7, 30);
            solarPanelParamPanel.Name = "solarPanelParamPanel";
            solarPanelParamPanel.Size = new Size(463, 98);
            solarPanelParamPanel.TabIndex = 1;
            // 
            // solarPanelParamSpecTextBox4
            // 
            solarPanelParamSpecTextBox4.Location = new Point(339, 6);
            solarPanelParamSpecTextBox4.Name = "solarPanelParamSpecTextBox4";
            solarPanelParamSpecTextBox4.Size = new Size(100, 23);
            solarPanelParamSpecTextBox4.TabIndex = 9;
            solarPanelParamSpecTextBox4.Validating += validateTextBox_float;
            // 
            // solarPanelParamSpecLabel4
            // 
            solarPanelParamSpecLabel4.AutoSize = true;
            solarPanelParamSpecLabel4.Location = new Point(233, 9);
            solarPanelParamSpecLabel4.Name = "solarPanelParamSpecLabel4";
            solarPanelParamSpecLabel4.Size = new Size(103, 15);
            solarPanelParamSpecLabel4.TabIndex = 8;
            solarPanelParamSpecLabel4.Text = "Temp. Coefficient:";
            // 
            // solarPanelParamSpecTextBox5
            // 
            solarPanelParamSpecTextBox5.Location = new Point(339, 35);
            solarPanelParamSpecTextBox5.Name = "solarPanelParamSpecTextBox5";
            solarPanelParamSpecTextBox5.Size = new Size(100, 23);
            solarPanelParamSpecTextBox5.TabIndex = 7;
            solarPanelParamSpecTextBox5.Validating += validateTextBox_int;
            // 
            // solarPanelParamSpecLabel5
            // 
            solarPanelParamSpecLabel5.AutoSize = true;
            solarPanelParamSpecLabel5.Location = new Point(233, 38);
            solarPanelParamSpecLabel5.Name = "solarPanelParamSpecLabel5";
            solarPanelParamSpecLabel5.Size = new Size(91, 15);
            solarPanelParamSpecLabel5.TabIndex = 6;
            solarPanelParamSpecLabel5.Text = "Num. of Panels:";
            // 
            // solarPanelParamSpecTextBox3
            // 
            solarPanelParamSpecTextBox3.Location = new Point(67, 64);
            solarPanelParamSpecTextBox3.Name = "solarPanelParamSpecTextBox3";
            solarPanelParamSpecTextBox3.Size = new Size(100, 23);
            solarPanelParamSpecTextBox3.TabIndex = 5;
            solarPanelParamSpecTextBox3.Validating += validateTextBox_float;
            // 
            // solarPanelParamSpecLabel3
            // 
            solarPanelParamSpecLabel3.AutoSize = true;
            solarPanelParamSpecLabel3.Location = new Point(3, 67);
            solarPanelParamSpecLabel3.Name = "solarPanelParamSpecLabel3";
            solarPanelParamSpecLabel3.Size = new Size(36, 15);
            solarPanelParamSpecLabel3.TabIndex = 4;
            solarPanelParamSpecLabel3.Text = "Noct:";
            // 
            // solarPanelParamSpecTextBox2
            // 
            solarPanelParamSpecTextBox2.Location = new Point(67, 35);
            solarPanelParamSpecTextBox2.Name = "solarPanelParamSpecTextBox2";
            solarPanelParamSpecTextBox2.Size = new Size(100, 23);
            solarPanelParamSpecTextBox2.TabIndex = 3;
            solarPanelParamSpecTextBox2.Validating += validateTextBox_float;
            // 
            // solarPanelParamSpecLabel2
            // 
            solarPanelParamSpecLabel2.AutoSize = true;
            solarPanelParamSpecLabel2.Location = new Point(3, 38);
            solarPanelParamSpecLabel2.Name = "solarPanelParamSpecLabel2";
            solarPanelParamSpecLabel2.Size = new Size(34, 15);
            solarPanelParamSpecLabel2.TabIndex = 2;
            solarPanelParamSpecLabel2.Text = "Area:";
            // 
            // solarPanelParamSpecTextBox1
            // 
            solarPanelParamSpecTextBox1.Location = new Point(67, 6);
            solarPanelParamSpecTextBox1.Name = "solarPanelParamSpecTextBox1";
            solarPanelParamSpecTextBox1.Size = new Size(100, 23);
            solarPanelParamSpecTextBox1.TabIndex = 1;
            solarPanelParamSpecTextBox1.Validating += validateTextBox_float;
            // 
            // solarPanelParamSpecLabel1
            // 
            solarPanelParamSpecLabel1.AutoSize = true;
            solarPanelParamSpecLabel1.Location = new Point(3, 9);
            solarPanelParamSpecLabel1.Name = "solarPanelParamSpecLabel1";
            solarPanelParamSpecLabel1.Size = new Size(61, 15);
            solarPanelParamSpecLabel1.TabIndex = 0;
            solarPanelParamSpecLabel1.Text = "Efficiency:";
            // 
            // solarPanelParamLabel
            // 
            solarPanelParamLabel.AutoSize = true;
            solarPanelParamLabel.Location = new Point(7, 12);
            solarPanelParamLabel.Name = "solarPanelParamLabel";
            solarPanelParamLabel.Size = new Size(98, 15);
            solarPanelParamLabel.TabIndex = 0;
            solarPanelParamLabel.Text = "Solar Panel Specs";
            solarPanelParamLabel.TextAlign = ContentAlignment.BottomRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(487, 9);
            label1.Name = "label1";
            label1.Size = new Size(123, 15);
            label1.TabIndex = 3;
            label1.Text = "Production Parameter";
            // 
            // startSimulationButton
            // 
            startSimulationButton.Location = new Point(781, 485);
            startSimulationButton.Name = "startSimulationButton";
            startSimulationButton.Size = new Size(160, 56);
            startSimulationButton.TabIndex = 4;
            startSimulationButton.Text = "Start";
            startSimulationButton.UseVisualStyleBackColor = true;
            startSimulationButton.Click += startSimulationButton_Click;
            // 
            // importConsumerDataButton
            // 
            importConsumerDataButton.Location = new Point(18, 478);
            importConsumerDataButton.Name = "importConsumerDataButton";
            importConsumerDataButton.Size = new Size(150, 32);
            importConsumerDataButton.TabIndex = 5;
            importConsumerDataButton.Text = "Import Consumer Data";
            importConsumerDataButton.UseVisualStyleBackColor = true;
            importConsumerDataButton.Click += importConsumerDataButton_Click;
            // 
            // ImportLabelCD
            // 
            ImportLabelCD.AutoSize = true;
            ImportLabelCD.Location = new Point(174, 487);
            ImportLabelCD.Name = "ImportLabelCD";
            ImportLabelCD.Size = new Size(84, 15);
            ImportLabelCD.TabIndex = 6;
            ImportLabelCD.Text = "- Select a File -";
            // 
            // SimulationMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(985, 574);
            Controls.Add(ImportLabelCD);
            Controls.Add(importConsumerDataButton);
            Controls.Add(startSimulationButton);
            Controls.Add(label1);
            Controls.Add(productionParamPanel);
            Controls.Add(importLabelWD);
            Controls.Add(importWeatherDataButton);
            Name = "SimulationMain";
            Text = "Simulation";
            productionParamPanel.ResumeLayout(false);
            productionParamPanel.PerformLayout();
            hydroPlantParamPanel.ResumeLayout(false);
            hydroPlantParamPanel.PerformLayout();
            windTurbinelParamPanel.ResumeLayout(false);
            windTurbinelParamPanel.PerformLayout();
            solarPanelParamPanel.ResumeLayout(false);
            solarPanelParamPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button importWeatherDataButton;
        private Label importLabelWD;
        private Panel productionParamPanel;
        private Label label1;
        private Label solarPanelParamLabel;
        private Panel solarPanelParamPanel;
        private Label solarPanelParamSpecLabel1;
        private TextBox solarPanelParamSpecTextBox1;
        private TextBox solarPanelParamSpecTextBox2;
        private Label solarPanelParamSpecLabel2;
        private TextBox solarPanelParamSpecTextBox4;
        private Label solarPanelParamSpecLabel4;
        private TextBox solarPanelParamSpecTextBox5;
        private Label solarPanelParamSpecLabel5;
        private TextBox solarPanelParamSpecTextBox3;
        private Label solarPanelParamSpecLabel3;
        private Panel windTurbinelParamPanel;
        private TextBox windTurbineParamSpecTextBox4;
        private Label windTurbineParamSpecLabel4;
        private TextBox windTurbineParamSpecTextBox3;
        private Label windTurbineParamSpecLabel3;
        private TextBox windTurbineParamSpecTextBox2;
        private Label windTurbineParamSpecLabel2;
        private TextBox windTurbineParamSpecTextBox1;
        private Label windTurbineParamSpecLabel1;
        private Label windTurbineParamLabel;
        private Panel hydroPlantParamPanel;
        private TextBox hydroPlantParamSpecTextBox3;
        private Label hydroPlantParamSpecLabel3;
        private TextBox hydroPlantParamSpecTextBox2;
        private Label hydroPlantParamSpecLabel2;
        private TextBox hydroPlantParamSpecTextBox1;
        private Label hydroPlantParamSpecLabel1;
        private Label hydroPlantParamLabel;
        private Button startSimulationButton;
        private Button importConsumerDataButton;
        private Label ImportLabelCD;
    }
}