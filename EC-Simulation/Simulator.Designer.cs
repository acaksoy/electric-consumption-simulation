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
            SuspendLayout();
            // 
            // loggerTextBox
            // 
            loggerTextBox.BackColor = SystemColors.Window;
            loggerTextBox.Location = new Point(166, 37);
            loggerTextBox.Multiline = true;
            loggerTextBox.Name = "loggerTextBox";
            loggerTextBox.ReadOnly = true;
            loggerTextBox.ScrollBars = ScrollBars.Vertical;
            loggerTextBox.Size = new Size(460, 303);
            loggerTextBox.TabIndex = 0;
            // 
            // Simulator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(loggerTextBox);
            Name = "Simulator";
            Text = "Simulator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox loggerTextBox;
    }
}