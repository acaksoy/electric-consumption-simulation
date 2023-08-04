using Microsoft.VisualBasic.FileIO;
using System.CodeDom;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace EC_Simulation
{
    public partial class SimulationMain : Form
    {
        private string fileName= string.Empty;
        public SimulationMain()
        {
            InitializeComponent();
        }

        private void importWeatherDataButton_Click(object sender, EventArgs e) // Before deleting, clear "click" prop in designer.
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "CSV file (*.csv)|*.csv";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                string[] fields = {"default"};
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // control csv structure? headers?
                    fileName = openFileDialog.SafeFileName;
                    importLabelWD.Text = fileName;

                    TextFieldParser parser = new TextFieldParser(openFileDialog.FileName);
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(";");
                    while (!parser.EndOfData)
                    {
                        //Processing row
                        fields = parser.ReadFields();

                    }

                    MessageBox.Show("File path added: " + fileName + "Data: " + fields[1]);
                }
            }
        }
    }
}