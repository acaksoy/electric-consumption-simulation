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
            SuspendLayout();
            // 
            // importWeatherDataButton
            // 
            importWeatherDataButton.Location = new Point(25, 297);
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
            importLabelWD.Location = new Point(168, 305);
            importLabelWD.Name = "importLabelWD";
            importLabelWD.Size = new Size(82, 15);
            importLabelWD.TabIndex = 1;
            importLabelWD.Text = "- Select a file -";
            // 
            // SimulationMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(importLabelWD);
            Controls.Add(importWeatherDataButton);
            Name = "SimulationMain";
            Text = "Simulation";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button importWeatherDataButton;
        private Label importLabelWD;
    }
}