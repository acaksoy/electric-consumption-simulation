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

        //private List<ControlGroup> controls;
        private SolarPanelSpecs solarSpecs;
        private WindTurbineSpecs windSpecs;
        private HydroTurbineSpecs hydroSpecs;

        public Simulator(List<ControlGroup> controls, SolarPanelSpecs solarSpecs, WindTurbineSpecs windSpecs, HydroTurbineSpecs hydroSpecs, string weatherDataFilePath, string eventDataFilePath)
        {
            InitializeComponent();
            //this.controls = controls;
            this.solarSpecs = solarSpecs;
            this.windSpecs = windSpecs;
            this.hydroSpecs = hydroSpecs;

            simulationManager = new SimulationManager(simProgresLabel, simulationProgressBar, loggerTextBox, controls, weatherDataFilePath, eventDataFilePath);
            simulationManager.NullRowFoundEvent += NullRowFound_EventHandler;
        }

        private void Simulator_Shown(object sender, EventArgs e)
        {
            simulationManager.InitializeSolarPanels(solarSpecs.Amount, solarSpecs.Efficiency, solarSpecs.Area, solarSpecs.Noct, solarSpecs.TempCoefficient);
            simulationManager.InitializeWindTurbines(windSpecs.Amount, windSpecs.BladeArea, windSpecs.PowerCoefficent, windSpecs.Availablity);
            simulationManager.InitializeHydroPowerPlants(hydroSpecs.Amount, hydroSpecs.Height, hydroSpecs.Efficiency);
            simulationManager.Simulate();
            Debug.WriteLine("Simulator stoped.");
        }

        private void NullRowFound_EventHandler(object? sender, string msg)
        {

            MessageBox.Show(msg,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Invoke(new Action(() => this.Close()));

        }
        


    }
}
