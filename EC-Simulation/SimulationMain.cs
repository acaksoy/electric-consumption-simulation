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

        private string filePathHoushold1;
        private string filePathHoushold2;
        private string filePathHoushold3;
        private string filePathbusiness1;
        private string filePathbusiness2;
        private string filePathbusiness3;
        private string filePathPublic;

        private Dictionary<Button, Label> buttonLabelPairs;
        private Dictionary<Button, string> buttonFilePathPairs;

        //private string fileName = string.Empty;

        public SimulationMain()
        {
            InitializeComponent();

            errorProvider1 = new ErrorProvider();

            buttonLabelPairs = new Dictionary<Button, Label>();
            buttonLabelPairs.Add(importHouseholdBtn1, ImportLabelHousehold1);
            buttonLabelPairs.Add(importHouseholdBtn2, ImportLabelHousehold2);
            buttonLabelPairs.Add(importHouseholdBtn3, ImportLabelHousehold3);
            buttonLabelPairs.Add(importBusinessBtn1, ImportLabelBusiness1);
            buttonLabelPairs.Add(importBusinessBtn2, ImportLabelBusiness2);
            buttonLabelPairs.Add(importBusinessBtn3, ImportLabelBusiness3);
            buttonLabelPairs.Add(importPublicBtn1, ImportLabelPublic);
            buttonLabelPairs.Add(importWeatherDataButton, importLabelWD);
            buttonLabelPairs.Add(importEventDataBtn, importLabelED);

            buttonFilePathPairs = new Dictionary<Button, string>();
            buttonFilePathPairs.Add(importHouseholdBtn1, string.Empty);
            buttonFilePathPairs.Add(importHouseholdBtn2, string.Empty);
            buttonFilePathPairs.Add(importHouseholdBtn3, string.Empty);
            buttonFilePathPairs.Add(importBusinessBtn1, string.Empty);
            buttonFilePathPairs.Add(importBusinessBtn2, string.Empty);
            buttonFilePathPairs.Add(importBusinessBtn3, string.Empty);
            buttonFilePathPairs.Add(importPublicBtn1, string.Empty);
            buttonFilePathPairs.Add(importWeatherDataButton, string.Empty);
            buttonFilePathPairs.Add(importEventDataBtn, string.Empty);


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
                    importLabelWD.Text = openFileDialog.SafeFileName;

                    TextFieldParser parser = new TextFieldParser(openFileDialog.FileName);
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(";");
                    weatherParser = parser;
                    //simulationManager.FillCalendar(parser);
                    isWeatherDataParsed = true;


                }
            }
        }
        private void importData_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "CSV file (*.csv)|*.csv";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (KeyValuePair<Button, Label> pair in buttonLabelPairs)
                    {
                        if (pair.Key == button)
                        {
                            pair.Value.Text = openFileDialog.SafeFileName;
                            buttonFilePathPairs[pair.Key] = openFileDialog.FileName;
                        }
                    }
                    // control csv structure? headers?
                    //ImportLabelHousehold1.Text = openFileDialog.SafeFileName;

                    /*TextFieldParser parser = new TextFieldParser(openFileDialog.FileName);
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(";");
                    consumerDataParser = parser;
                    isConsumerDataParsed = true;*/
                    
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
        private void validateImport(object sender, CancelEventArgs e)
        {
            foreach (KeyValuePair<Button, string> pair in buttonFilePathPairs)
            {
                if (pair.Value == string.Empty)
                {
                    errorProvider1.SetError(pair.Key, "Please select a file.");
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void startSimulationButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                /*if (!isWeatherDataParsed || !isConsumerDataParsed) //buttonfilepathPairs empty? means not all selected.
                {
                    errorProvider1.SetError(importWeatherDataButton, "Import all data needed.");
                    MessageBox.Show("Fill all fields correctly");
                    return;
                }*/
                simulationManager.FillCalendar(buttonFilePathPairs[importWeatherDataButton]);
                simulationManager.FillConsumer(buttonFilePathPairs[importHouseholdBtn1]);

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