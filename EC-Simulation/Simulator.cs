using SimulationClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EC_Simulation
{
    public partial class Simulator : Form
    {
        private SimulationManager simulationManager;

        public Simulator(SimulationManager simulationManager)
        {
            InitializeComponent();

        }

        public void StartSimulation()
        {
            loggerTextBox.AppendText("Starting simulation...");
            
        }

        private void Simulator_Shown(object sender, EventArgs e)
        {
            simulationManager.Simulate(loggerTextBox, simProgresLabel, simulationProgressBar);
        }
    }
}
