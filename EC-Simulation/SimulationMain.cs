using Microsoft.VisualBasic.FileIO;
using System.CodeDom;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using SimulationClassLibrary;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Diagnostics.Eventing.Reader;
using System.ComponentModel;
using System.Diagnostics;

namespace EC_Simulation
{

    public partial class SimulationMain : Form
    {

        private ErrorProvider errorProvider1;

        private List<ControlGroup> controls = new List<ControlGroup>();
        private string weatherDataFilePath = string.Empty;
        private string eventDataFilePath = string.Empty;

        public SimulationMain()
        {
            InitializeComponent();

            errorProvider1 = new ErrorProvider();
            controls.Add(new ControlGroup(importHouseholdBtn1, ImportLabelHousehold1, householdAmountTextBox1));
            controls.Add(new ControlGroup(importHouseholdBtn2, ImportLabelHousehold2, householdAmountTextBox2));
            controls.Add(new ControlGroup(importHouseholdBtn3, ImportLabelHousehold3, householdAmountTextBox3));
            controls.Add(new ControlGroup(importBusinessBtn1, ImportLabelBusiness1, businessAmountTextBox1));
            controls.Add(new ControlGroup(importBusinessBtn2, ImportLabelBusiness2, businessAmountTextBox2));
            controls.Add(new ControlGroup(importBusinessBtn3, ImportLabelBusiness3, businessAmountTextBox3));
            controls.Add(new ControlGroup(importPublicBtn1, ImportLabelPublic, publicAmountTextBox));

        }
        private void importData_Click(object sender, EventArgs e)
        {
            Button button = sender as Button ?? throw new InvalidCastException("Invalid Cast at importData_Click");
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "CSV file (*.csv)|*.csv";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (button == importWeatherDataButton)
                    {
                        importLabelWD.Text = openFileDialog.SafeFileName;
                        weatherDataFilePath = openFileDialog.FileName;
                        return;
                    }
                    if (button == importEventDataBtn)
                    {
                        importLabelED.Text = openFileDialog.SafeFileName;
                        eventDataFilePath = openFileDialog.FileName;
                        return;
                    }
                    foreach (ControlGroup group in controls)
                    {
                        if (group.ImportButton == button)
                        {
                            group.ImportLabel.Text = openFileDialog.SafeFileName;
                            group.FilePath = openFileDialog.FileName;
                            return;
                        }
                    }

                }
            }
        }


        private void validateTextBox_float(object sender, CancelEventArgs e)
        {

            TextBox tb = (TextBox)sender ?? throw new InvalidCastException("Invalid Cast at importData_Click"); ;
            float value;
            bool parseSuccess = float.TryParse(tb.Text, out value);
            if (String.IsNullOrEmpty(tb.Text) || !parseSuccess)
            {
                errorProvider1.SetError(tb, "Enter a float value");
                e.Cancel = true;
                return;
            }

            errorProvider1.SetError(tb, String.Empty); //remove error if value is float
        }
        private void validateTextBox_int(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender ?? throw new InvalidCastException("Invalid Cast at importData_Click"); ;
            int value;
            bool parseSuccess = int.TryParse(tb.Text, out value);
            if (String.IsNullOrEmpty(tb.Text) || !parseSuccess)
            {
                errorProvider1.SetError(tb, "Enter a int value");
                e.Cancel = true;
                return;
            }

            errorProvider1.SetError(tb, String.Empty);
        }
        private void validateImport(object sender, CancelEventArgs e)
        {
            foreach (ControlGroup group in controls)
            {
                if (group.FilePath == string.Empty)
                {
                    errorProvider1.SetError(group.ImportButton, "Please select a file.");
                    e.Cancel = true;
                    return;
                }

            }
            if (eventDataFilePath == string.Empty)
            {
                errorProvider1.SetError(importEventDataBtn, "Please select a file.");
                e.Cancel = true;
                return;
            }
            if (weatherDataFilePath == string.Empty)
            {
                errorProvider1.SetError(importWeatherDataButton, "Please select a file.");
                e.Cancel = true;
                return;
            }

        }

        private void startSimulationButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {

                SolarPanelSpecs solarSpecs = new SolarPanelSpecs(int.Parse(solarPanelParamSpecTextBox5.Text),
                                                                 float.Parse(solarPanelParamSpecTextBox1.Text),
                                                                 float.Parse(solarPanelParamSpecTextBox2.Text),
                                                                 float.Parse(solarPanelParamSpecTextBox3.Text),
                                                                 float.Parse(solarPanelParamSpecTextBox4.Text));

                WindTurbineSpecs windSpecs = new WindTurbineSpecs(int.Parse(windTurbineParamSpecTextBox4.Text),
                                                                  float.Parse(windTurbineParamSpecTextBox1.Text),
                                                                  float.Parse(windTurbineParamSpecTextBox2.Text),
                                                                  float.Parse(windTurbineParamSpecTextBox3.Text));

                HydroTurbineSpecs hydroSpecs = new HydroTurbineSpecs(int.Parse(hydroPlantParamSpecTextBox3.Text),
                                                                     float.Parse(hydroPlantParamSpecTextBox1.Text),
                                                                     float.Parse(hydroPlantParamSpecTextBox2.Text));

                Simulator sim = new Simulator(controls, solarSpecs, windSpecs, hydroSpecs, weatherDataFilePath, eventDataFilePath);
                sim.Show();
            }
            else
            {
                MessageBox.Show("Fill all fields correctly");
                return;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = false;
            base.OnFormClosing(e);
        }

    }
    public class ControlGroup
    {
        public Button ImportButton;
        public Label ImportLabel;
        public TextBox Amount;
        public string FilePath = string.Empty;

        public ControlGroup(Button importButton, Label importLabel, TextBox amount)
        {
            ImportButton = importButton;
            ImportLabel = importLabel;
            Amount = amount;

        }
    }
    public struct SolarPanelSpecs
    {
        public SolarPanelSpecs(int amount, float efficiency, float area, float noct, float tmpCoeff)
        {
            Amount = amount;
            Efficiency = efficiency;
            Area = area;
            Noct = noct;
            TempCoefficient = tmpCoeff;
        }
        public int Amount;
        public float Efficiency;
        public float Area;
        public float Noct;
        public float TempCoefficient;

    }
    public struct WindTurbineSpecs
    {
        public WindTurbineSpecs(int amount, float bladeArea, float powerCoefficent, float availablity)
        {
            Amount = amount;
            BladeArea = bladeArea;
            PowerCoefficent = powerCoefficent;
            Availablity = availablity;
        }
        public int Amount;
        public float BladeArea;
        public float PowerCoefficent;
        public float Availablity;

    }
    public struct HydroTurbineSpecs
    {
        public HydroTurbineSpecs(int amount, float height, float efficiency)
        {
            Amount = amount;
            Height = height;
            Efficiency = efficiency;

        }
        public int Amount;
        public float Height;
        public float Efficiency;

    }
}