namespace EC_Simulation
{
    partial class Simulator
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
            loggerTextBox = new TextBox();
            simulationProgressBar = new ProgressBar();
            simProgresLabel = new Label();
            SuspendLayout();
            // 
            // loggerTextBox
            // 
            loggerTextBox.BackColor = SystemColors.Window;
            loggerTextBox.Location = new Point(129, 81);
            loggerTextBox.Multiline = true;
            loggerTextBox.Name = "loggerTextBox";
            loggerTextBox.ReadOnly = true;
            loggerTextBox.ScrollBars = ScrollBars.Vertical;
            loggerTextBox.Size = new Size(890, 459);
            loggerTextBox.TabIndex = 0;
            // 
            // simulationProgressBar
            // 
            simulationProgressBar.Location = new Point(340, 36);
            simulationProgressBar.Name = "simulationProgressBar";
            simulationProgressBar.Size = new Size(460, 23);
            simulationProgressBar.TabIndex = 1;
            // 
            // simProgresLabel
            // 
            simProgresLabel.AutoSize = true;
            simProgresLabel.Location = new Point(533, 18);
            simProgresLabel.Name = "simProgresLabel";
            simProgresLabel.Size = new Size(76, 15);
            simProgresLabel.TabIndex = 2;
            simProgresLabel.Text = "Simulating ...";
            // 
            // Simulator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1107, 613);
            Controls.Add(simProgresLabel);
            Controls.Add(simulationProgressBar);
            Controls.Add(loggerTextBox);
            Name = "Simulator";
            Text = "Simulator";
            Shown += Simulator_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox loggerTextBox;
        private ProgressBar simulationProgressBar;
        private Label simProgresLabel;
    }
}