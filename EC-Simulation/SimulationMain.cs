using Microsoft.VisualBasic.FileIO;
using System.CodeDom;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using SimulationClassLibrary;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Diagnostics.Eventing.Reader;
using System.ComponentModel;

namespace EC_Simulation
{
    public partial class SimulationMain : Form
    {
        private SimulationManager simulationManager = new SimulationManager();

        public TextFieldParser weatherParser;
        public TextFieldParser consumerDataParser;

        private bool isWeatherDataParsed = false;
        private bool isConsumerDataParsed = false;


        private ErrorProvider errorProvider1;

        private string fileName = string.Empty;
        public SimulationMain()
        {
            InitializeComponent();

            errorProvider1 = new ErrorProvider();

        }

        private void importWeatherDataButton_Click(object sender, EventArgs e) // Before deleting, clear "click" prop in designer.
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "CSV file (*.csv)|*.csv";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // control csv structure? headers?
                    fileName = openFileDialog.SafeFileName;
                    importLabelWD.Text = fileName;

                    TextFieldParser parser = new TextFieldParser(openFileDialog.FileName);
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(";");
                    weatherParser = parser;
                    //simulationManager.FillCalendar(parser);
                    isWeatherDataParsed = true;


                }
            }
        }
        private void importConsumerDataButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "CSV file (*.csv)|*.csv";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // control csv structure? headers?
                    fileName = openFileDialog.SafeFileName;
                    ImportLabelCD.Text = fileName;

                    TextFieldParser parser = new TextFieldParser(openFileDialog.FileName);
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(";");
                    consumerDataParser = parser;
                    //simulationManager.FillCalendar(parser);
                    isConsumerDataParsed = true;


                }
            }
        }
        private void validateTextBox_float(object sender, CancelEventArgs e)
        {

            TextBox tb = (TextBox)sender;
            float value;
            bool parseSuccess = float.TryParse(tb.Text, out value);
            if (String.IsNullOrEmpty(tb.Text) || !parseSuccess)
            {
                errorProvider1.SetError(tb, "Enter a float value");
                e.Cancel = true;
                return;
            }

            errorProvider1.SetError(tb, String.Empty);
        }
        private void validateTextBox_int(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
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
        //TODO: sim icin ayri thread ay ui kilitliyor. sayilar dogru okunmuyor.

        private void startSimulationButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (!isWeatherDataParsed || !isConsumerDataParsed)
                {
                    errorProvider1.SetError(importWeatherDataButton, "Import all data needed.");
                    MessageBox.Show("Fill all fields correctly");
                    return;
                }
                simulationManager.FillCalendar(weatherParser);
                simulationManager.FillConsumer(consumerDataParser);

                simulationManager.InitilazieSolarPanels(int.Parse(solarPanelParamSpecTextBox5.Text), float.Parse(solarPanelParamSpecTextBox1.Text), float.Parse(solarPanelParamSpecTextBox2.Text), float.Parse(solarPanelParamSpecTextBox3.Text), float.Parse(solarPanelParamSpecTextBox4.Text));
                simulationManager.InitilazieWindTurbines(int.Parse(windTurbineParamSpecTextBox4.Text), float.Parse(windTurbineParamSpecTextBox1.Text), float.Parse(windTurbineParamSpecTextBox2.Text), float.Parse(windTurbineParamSpecTextBox3.Text));
                simulationManager.InitilazieHydroPowerPlanets(int.Parse(hydroPlantParamSpecTextBox3.Text), float.Parse(hydroPlantParamSpecTextBox1.Text), float.Parse(hydroPlantParamSpecTextBox2.Text));
                MessageBox.Show("ready");
                Simulator sim = new Simulator(simulationManager);
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
}