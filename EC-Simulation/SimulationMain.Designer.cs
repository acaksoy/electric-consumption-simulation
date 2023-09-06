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
            importHouseholdBtn1 = new Button();
            panel1 = new Panel();
            panel8 = new Panel();
            ImportLabelPublic = new Label();
            label20 = new Label();
            publicAmountTextBox = new TextBox();
            importPublicBtn1 = new Button();
            label21 = new Label();
            label18 = new Label();
            label15 = new Label();
            panel7 = new Panel();
            label17 = new Label();
            businessAmountTextBox3 = new TextBox();
            ImportLabelBusiness3 = new Label();
            importBusinessBtn3 = new Button();
            panel6 = new Panel();
            label14 = new Label();
            businessAmountTextBox2 = new TextBox();
            importBusinessBtn2 = new Button();
            ImportLabelBusiness2 = new Label();
            label3 = new Label();
            panel5 = new Panel();
            label11 = new Label();
            businessAmountTextBox1 = new TextBox();
            ImportLabelBusiness1 = new Label();
            importBusinessBtn1 = new Button();
            label8 = new Label();
            panel4 = new Panel();
            label9 = new Label();
            householdAmountTextBox2 = new TextBox();
            ImportLabelHousehold2 = new Label();
            importHouseholdBtn2 = new Button();
            label5 = new Label();
            panel3 = new Panel();
            label6 = new Label();
            householdAmountTextBox3 = new TextBox();
            ImportLabelHousehold3 = new Label();
            importHouseholdBtn3 = new Button();
            label2 = new Label();
            panel2 = new Panel();
            label4 = new Label();
            householdAmountTextBox1 = new TextBox();
            ImportLabelHousehold1 = new Label();
            ConsumeParamLabel = new Label();
            importLabelED = new Label();
            importEventDataBtn = new Button();
            productionParamPanel.SuspendLayout();
            hydroPlantParamPanel.SuspendLayout();
            windTurbinelParamPanel.SuspendLayout();
            solarPanelParamPanel.SuspendLayout();
            panel1.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // importWeatherDataButton
            // 
            importWeatherDataButton.Location = new Point(555, 344);
            importWeatherDataButton.Name = "importWeatherDataButton";
            importWeatherDataButton.Size = new Size(137, 30);
            importWeatherDataButton.TabIndex = 0;
            importWeatherDataButton.Tag = "";
            importWeatherDataButton.Text = "Import Weather Data";
            importWeatherDataButton.UseVisualStyleBackColor = true;
            importWeatherDataButton.Click += importData_Click;
            importWeatherDataButton.Validating += validateImport;
            // 
            // importLabelWD
            // 
            importLabelWD.AutoSize = true;
            importLabelWD.Location = new Point(698, 352);
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
            productionParamPanel.Location = new Point(555, 27);
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
            label1.Location = new Point(555, 9);
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
            // importHouseholdBtn1
            // 
            importHouseholdBtn1.Location = new Point(3, 25);
            importHouseholdBtn1.Name = "importHouseholdBtn1";
            importHouseholdBtn1.Size = new Size(150, 23);
            importHouseholdBtn1.TabIndex = 5;
            importHouseholdBtn1.Text = "Import Consumer Data";
            importHouseholdBtn1.UseVisualStyleBackColor = true;
            importHouseholdBtn1.Validating += validateImport;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel8);
            panel1.Controls.Add(label21);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(18, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(531, 451);
            panel1.TabIndex = 7;
            // 
            // panel8
            // 
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(ImportLabelPublic);
            panel8.Controls.Add(label20);
            panel8.Controls.Add(publicAmountTextBox);
            panel8.Controls.Add(importPublicBtn1);
            panel8.Location = new Point(16, 349);
            panel8.Name = "panel8";
            panel8.Size = new Size(242, 83);
            panel8.TabIndex = 12;
            // 
            // ImportLabelPublic
            // 
            ImportLabelPublic.AutoSize = true;
            ImportLabelPublic.Location = new Point(6, 51);
            ImportLabelPublic.Name = "ImportLabelPublic";
            ImportLabelPublic.Size = new Size(84, 15);
            ImportLabelPublic.TabIndex = 13;
            ImportLabelPublic.Text = "- Select a File -";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(167, 8);
            label20.Name = "label20";
            label20.Size = new Size(51, 15);
            label20.TabIndex = 11;
            label20.Text = "Amount";
            // 
            // publicAmountTextBox
            // 
            publicAmountTextBox.Location = new Point(159, 26);
            publicAmountTextBox.Name = "publicAmountTextBox";
            publicAmountTextBox.Size = new Size(66, 23);
            publicAmountTextBox.TabIndex = 9;
            publicAmountTextBox.Validating += validateTextBox_int;
            // 
            // importPublicBtn1
            // 
            importPublicBtn1.Location = new Point(3, 25);
            importPublicBtn1.Name = "importPublicBtn1";
            importPublicBtn1.Size = new Size(150, 23);
            importPublicBtn1.TabIndex = 5;
            importPublicBtn1.Text = "Import Consumer Data";
            importPublicBtn1.UseVisualStyleBackColor = true;
            importPublicBtn1.Validating += validateImport;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(16, 331);
            label21.Name = "label21";
            label21.Size = new Size(40, 15);
            label21.TabIndex = 10;
            label21.Text = "Public";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(264, 227);
            label18.Name = "label18";
            label18.Size = new Size(63, 15);
            label18.TabIndex = 10;
            label18.Text = "Business-3";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(16, 227);
            label15.Name = "label15";
            label15.Size = new Size(63, 15);
            label15.TabIndex = 10;
            label15.Text = "Business-2";
            // 
            // panel7
            // 
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(label17);
            panel7.Controls.Add(businessAmountTextBox3);
            panel7.Controls.Add(ImportLabelBusiness3);
            panel7.Controls.Add(importBusinessBtn3);
            panel7.Location = new Point(264, 245);
            panel7.Name = "panel7";
            panel7.Size = new Size(242, 83);
            panel7.TabIndex = 18;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(167, 8);
            label17.Name = "label17";
            label17.Size = new Size(51, 15);
            label17.TabIndex = 11;
            label17.Text = "Amount";
            // 
            // businessAmountTextBox3
            // 
            businessAmountTextBox3.Location = new Point(159, 26);
            businessAmountTextBox3.Name = "businessAmountTextBox3";
            businessAmountTextBox3.Size = new Size(66, 23);
            businessAmountTextBox3.TabIndex = 9;
            businessAmountTextBox3.Validating += validateTextBox_int;
            // 
            // ImportLabelBusiness3
            // 
            ImportLabelBusiness3.AutoSize = true;
            ImportLabelBusiness3.Location = new Point(6, 51);
            ImportLabelBusiness3.Name = "ImportLabelBusiness3";
            ImportLabelBusiness3.Size = new Size(84, 15);
            ImportLabelBusiness3.TabIndex = 19;
            ImportLabelBusiness3.Text = "- Select a File -";
            // 
            // importBusinessBtn3
            // 
            importBusinessBtn3.Location = new Point(3, 25);
            importBusinessBtn3.Name = "importBusinessBtn3";
            importBusinessBtn3.Size = new Size(150, 23);
            importBusinessBtn3.TabIndex = 5;
            importBusinessBtn3.Text = "Import Consumer Data";
            importBusinessBtn3.UseVisualStyleBackColor = true;
            importBusinessBtn3.Validating += validateImport;
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(label14);
            panel6.Controls.Add(businessAmountTextBox2);
            panel6.Controls.Add(importBusinessBtn2);
            panel6.Controls.Add(ImportLabelBusiness2);
            panel6.Location = new Point(16, 245);
            panel6.Name = "panel6";
            panel6.Size = new Size(242, 83);
            panel6.TabIndex = 16;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(167, 8);
            label14.Name = "label14";
            label14.Size = new Size(51, 15);
            label14.TabIndex = 11;
            label14.Text = "Amount";
            // 
            // businessAmountTextBox2
            // 
            businessAmountTextBox2.Location = new Point(159, 26);
            businessAmountTextBox2.Name = "businessAmountTextBox2";
            businessAmountTextBox2.Size = new Size(66, 23);
            businessAmountTextBox2.TabIndex = 9;
            businessAmountTextBox2.Validating += validateTextBox_int;
            // 
            // importBusinessBtn2
            // 
            importBusinessBtn2.Location = new Point(3, 25);
            importBusinessBtn2.Name = "importBusinessBtn2";
            importBusinessBtn2.Size = new Size(150, 23);
            importBusinessBtn2.TabIndex = 5;
            importBusinessBtn2.Text = "Import Consumer Data";
            importBusinessBtn2.UseVisualStyleBackColor = true;
            importBusinessBtn2.Validating += validateImport;
            // 
            // ImportLabelBusiness2
            // 
            ImportLabelBusiness2.AutoSize = true;
            ImportLabelBusiness2.Location = new Point(6, 51);
            ImportLabelBusiness2.Name = "ImportLabelBusiness2";
            ImportLabelBusiness2.Size = new Size(84, 15);
            ImportLabelBusiness2.TabIndex = 17;
            ImportLabelBusiness2.Text = "- Select a File -";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(264, 118);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 15;
            label3.Text = "Business-1";
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(label11);
            panel5.Controls.Add(businessAmountTextBox1);
            panel5.Controls.Add(ImportLabelBusiness1);
            panel5.Controls.Add(importBusinessBtn1);
            panel5.Location = new Point(264, 136);
            panel5.Name = "panel5";
            panel5.Size = new Size(242, 83);
            panel5.TabIndex = 14;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(167, 8);
            label11.Name = "label11";
            label11.Size = new Size(51, 15);
            label11.TabIndex = 11;
            label11.Text = "Amount";
            // 
            // businessAmountTextBox1
            // 
            businessAmountTextBox1.Location = new Point(159, 26);
            businessAmountTextBox1.Name = "businessAmountTextBox1";
            businessAmountTextBox1.Size = new Size(66, 23);
            businessAmountTextBox1.TabIndex = 9;
            businessAmountTextBox1.Validating += validateTextBox_int;
            // 
            // ImportLabelBusiness1
            // 
            ImportLabelBusiness1.AutoSize = true;
            ImportLabelBusiness1.Location = new Point(3, 51);
            ImportLabelBusiness1.Name = "ImportLabelBusiness1";
            ImportLabelBusiness1.Size = new Size(84, 15);
            ImportLabelBusiness1.TabIndex = 10;
            ImportLabelBusiness1.Text = "- Select a File -";
            // 
            // importBusinessBtn1
            // 
            importBusinessBtn1.Location = new Point(3, 25);
            importBusinessBtn1.Name = "importBusinessBtn1";
            importBusinessBtn1.Size = new Size(150, 23);
            importBusinessBtn1.TabIndex = 5;
            importBusinessBtn1.Text = "Import Consumer Data";
            importBusinessBtn1.UseVisualStyleBackColor = true;
            importBusinessBtn1.Validating += validateImport;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(264, 12);
            label8.Name = "label8";
            label8.Size = new Size(70, 15);
            label8.TabIndex = 13;
            label8.Text = "Houshold-2";
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label9);
            panel4.Controls.Add(householdAmountTextBox2);
            panel4.Controls.Add(ImportLabelHousehold2);
            panel4.Controls.Add(importHouseholdBtn2);
            panel4.Location = new Point(264, 30);
            panel4.Name = "panel4";
            panel4.Size = new Size(242, 83);
            panel4.TabIndex = 12;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(167, 8);
            label9.Name = "label9";
            label9.Size = new Size(51, 15);
            label9.TabIndex = 11;
            label9.Text = "Amount";
            // 
            // householdAmountTextBox2
            // 
            householdAmountTextBox2.Location = new Point(159, 26);
            householdAmountTextBox2.Name = "householdAmountTextBox2";
            householdAmountTextBox2.Size = new Size(66, 23);
            householdAmountTextBox2.TabIndex = 9;
            householdAmountTextBox2.Validating += validateTextBox_int;
            // 
            // ImportLabelHousehold2
            // 
            ImportLabelHousehold2.AutoSize = true;
            ImportLabelHousehold2.Location = new Point(3, 51);
            ImportLabelHousehold2.Name = "ImportLabelHousehold2";
            ImportLabelHousehold2.Size = new Size(84, 15);
            ImportLabelHousehold2.TabIndex = 10;
            ImportLabelHousehold2.Text = "- Select a File -";
            // 
            // importHouseholdBtn2
            // 
            importHouseholdBtn2.Location = new Point(3, 25);
            importHouseholdBtn2.Name = "importHouseholdBtn2";
            importHouseholdBtn2.Size = new Size(150, 23);
            importHouseholdBtn2.TabIndex = 5;
            importHouseholdBtn2.Text = "Import Consumer Data";
            importHouseholdBtn2.UseVisualStyleBackColor = true;
            importHouseholdBtn2.Validating += validateImport;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 118);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 11;
            label5.Text = "Houshold-3";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label6);
            panel3.Controls.Add(householdAmountTextBox3);
            panel3.Controls.Add(ImportLabelHousehold3);
            panel3.Controls.Add(importHouseholdBtn3);
            panel3.Location = new Point(16, 136);
            panel3.Name = "panel3";
            panel3.Size = new Size(242, 83);
            panel3.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(167, 8);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 11;
            label6.Text = "Amount";
            // 
            // householdAmountTextBox3
            // 
            householdAmountTextBox3.Location = new Point(159, 26);
            householdAmountTextBox3.Name = "householdAmountTextBox3";
            householdAmountTextBox3.Size = new Size(66, 23);
            householdAmountTextBox3.TabIndex = 9;
            householdAmountTextBox3.Validating += validateTextBox_int;
            // 
            // ImportLabelHousehold3
            // 
            ImportLabelHousehold3.AutoSize = true;
            ImportLabelHousehold3.Location = new Point(3, 51);
            ImportLabelHousehold3.Name = "ImportLabelHousehold3";
            ImportLabelHousehold3.Size = new Size(84, 15);
            ImportLabelHousehold3.TabIndex = 10;
            ImportLabelHousehold3.Text = "- Select a File -";
            // 
            // importHouseholdBtn3
            // 
            importHouseholdBtn3.Location = new Point(3, 25);
            importHouseholdBtn3.Name = "importHouseholdBtn3";
            importHouseholdBtn3.Size = new Size(150, 23);
            importHouseholdBtn3.TabIndex = 5;
            importHouseholdBtn3.Text = "Import Consumer Data";
            importHouseholdBtn3.UseVisualStyleBackColor = true;
            importHouseholdBtn3.Validating += validateImport;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 12);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 9;
            label2.Text = "Houshold-1";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(householdAmountTextBox1);
            panel2.Controls.Add(ImportLabelHousehold1);
            panel2.Controls.Add(importHouseholdBtn1);
            panel2.Location = new Point(16, 30);
            panel2.Name = "panel2";
            panel2.Size = new Size(242, 83);
            panel2.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(167, 8);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 11;
            label4.Text = "Amount";
            // 
            // householdAmountTextBox1
            // 
            householdAmountTextBox1.Location = new Point(159, 26);
            householdAmountTextBox1.Name = "householdAmountTextBox1";
            householdAmountTextBox1.Size = new Size(66, 23);
            householdAmountTextBox1.TabIndex = 9;
            householdAmountTextBox1.Validating += validateTextBox_int;
            // 
            // ImportLabelHousehold1
            // 
            ImportLabelHousehold1.AutoSize = true;
            ImportLabelHousehold1.Location = new Point(3, 51);
            ImportLabelHousehold1.Name = "ImportLabelHousehold1";
            ImportLabelHousehold1.Size = new Size(84, 15);
            ImportLabelHousehold1.TabIndex = 10;
            ImportLabelHousehold1.Text = "- Select a File -";
            // 
            // ConsumeParamLabel
            // 
            ConsumeParamLabel.AutoSize = true;
            ConsumeParamLabel.Location = new Point(18, 9);
            ConsumeParamLabel.Name = "ConsumeParamLabel";
            ConsumeParamLabel.Size = new Size(119, 15);
            ConsumeParamLabel.TabIndex = 8;
            ConsumeParamLabel.Text = "Consumer Parameter";
            // 
            // importLabelED
            // 
            importLabelED.AutoSize = true;
            importLabelED.Location = new Point(698, 394);
            importLabelED.Name = "importLabelED";
            importLabelED.Size = new Size(82, 15);
            importLabelED.TabIndex = 10;
            importLabelED.Text = "- Select a file -";
            // 
            // importEventDataBtn
            // 
            importEventDataBtn.Location = new Point(555, 386);
            importEventDataBtn.Name = "importEventDataBtn";
            importEventDataBtn.Size = new Size(137, 30);
            importEventDataBtn.TabIndex = 9;
            importEventDataBtn.Tag = "";
            importEventDataBtn.Text = "Import Event Data";
            importEventDataBtn.UseVisualStyleBackColor = true;
            importEventDataBtn.Validating += validateImport;
            // 
            // SimulationMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(1065, 593);
            Controls.Add(importLabelED);
            Controls.Add(importEventDataBtn);
            Controls.Add(ConsumeParamLabel);
            Controls.Add(panel1);
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
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private Button importHouseholdBtn1;
        private Panel panel1;
        private Label ConsumeParamLabel;
        private Label label2;
        private Panel panel2;
        private Label label4;
        private TextBox householdAmountTextBox1;
        private Label ImportLabelHousehold1;
        private Label label8;
        private Panel panel4;
        private Label label9;
        private TextBox householdAmountTextBox2;
        private Label ImportLabelHousehold2;
        private Button importHouseholdBtn2;
        private Label label5;
        private Panel panel3;
        private Label label6;
        private TextBox householdAmountTextBox3;
        private Label ImportLabelHousehold3;
        private Button importHouseholdBtn3;
        private Label ImportLabelPublic;
        private Panel panel8;
        private Label label20;
        private TextBox publicAmountTextBox;
        private Label label21;
        private Button importPublicBtn1;
        private Label ImportLabelBusiness3;
        private Panel panel7;
        private Label label17;
        private TextBox businessAmountTextBox3;
        private Label label18;
        private Button importBusinessBtn3;
        private Label ImportLabelBusiness2;
        private Panel panel6;
        private Label label14;
        private TextBox businessAmountTextBox2;
        private Label label15;
        private Button importBusinessBtn2;
        private Label label3;
        private Panel panel5;
        private Label label11;
        private TextBox businessAmountTextBox1;
        private Label ImportLabelBusiness1;
        private Button importBusinessBtn1;
        private Label importLabelED;
        private Button importEventDataBtn;
    }
}