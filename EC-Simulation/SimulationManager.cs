using Microsoft.VisualBasic.FileIO;
using SimulationClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace EC_Simulation
{
    public class SimulationManager
    {
        private List<Hour> hours { get; set; }
        private List<SolarPanel> solarPanels { get; set; }
        private List<WindTurbine> windTurbines { get; set; }
        private List<HydroPowerPlant> hydroPowerPlants { get; set; }

        private List<ElectricityConsumer> allconsumers { get; set; }

        BackgroundWorker mainBackgroundWorker;
        BackgroundWorker consumerInitializerBackgroundWorker;
        BackgroundWorker calendarInitializerBackgroundWorker;

        List<ControlGroup> controls;
        Label simProgresLabel;
        ProgressBar simProgresBar;
        TextBox simTextBox;

        private string weatherDataFilePath;
        private string eventDataFilePath;
        public SimulationManager(Label simLabel, ProgressBar simPBar, TextBox simTB, List<ControlGroup> controls, string weatherDataFilePath, string eventDataFilePath) //initilaze icin bilgiler önden yüklenmeli
        {
            simProgresLabel = simLabel;
            simProgresBar = simPBar;
            simTextBox = simTB;
            this.controls = controls;
            this.weatherDataFilePath = weatherDataFilePath;
            this.eventDataFilePath = eventDataFilePath;
            
            hours = new List<Hour>();
            solarPanels = new List<SolarPanel>();
            windTurbines = new List<WindTurbine>();
            hydroPowerPlants = new List<HydroPowerPlant>();
            allconsumers = new List<ElectricityConsumer>();

            mainBackgroundWorker = new BackgroundWorker();
            mainBackgroundWorker.DoWork += mainBackgroundWorker_DoWork;
            mainBackgroundWorker.RunWorkerCompleted += mainBackgroundWorker_RunWorkCompleted;
            mainBackgroundWorker.ProgressChanged += mainBackgroundWorker_ProgressChanged;
            mainBackgroundWorker.WorkerReportsProgress = true;

            calendarInitializerBackgroundWorker = new BackgroundWorker();
            calendarInitializerBackgroundWorker.DoWork += calendarInitializerBackgroundWorker_DoWork;
            calendarInitializerBackgroundWorker.RunWorkerCompleted += calendarInitializerBackgroundWorker_RunWorkCompleted;
            calendarInitializerBackgroundWorker.ProgressChanged += calendarInitializerBackgroundWorker_ProgressChanged;
            calendarInitializerBackgroundWorker.WorkerReportsProgress = true;

            consumerInitializerBackgroundWorker = new BackgroundWorker();
            consumerInitializerBackgroundWorker.DoWork += consumerInitializerBackgroundWorker_DoWork;
            consumerInitializerBackgroundWorker.RunWorkerCompleted += consumerInitializerBackgroundWorker_RunWorkCompleted;
            consumerInitializerBackgroundWorker.ProgressChanged += consumerInitializerBackgroundWorker_ProgressChanged;
            consumerInitializerBackgroundWorker.WorkerReportsProgress = true;
        }

        public void Simulate()
        {
            simTextBox.AppendText("Starting simulation..." + Environment.NewLine);
            calendarInitializerBackgroundWorker.RunWorkerAsync();
        }

        private void mainBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int progress = 0;
            int perc = 0;

            string message = "";
            foreach (Hour hour in hours)
            {
                float solarElecGenTotal = 0;
                float windElecGenTotal = 0;
                float hydroElecGenTotal = 0;
                float totalPower = 0;
                float fossilProduction = 0;

                float totalConsumption = 0;
                message += $"Date: {hour.Date.ToString()} - Temp: {hour.Temperature.ToString()} - Wind: {hour.WindSpeed.ToString()} - Irradiance: {hour.SolarIrradiance.ToString()}" + "\n";
                foreach (SolarPanel panel in solarPanels)
                {
                    solarElecGenTotal += panel.ProduceElectricity(hour);
                }
                message += "Solar panels: " + solarElecGenTotal.ToString() + "\n";
                foreach (WindTurbine wind in windTurbines)
                {
                    windElecGenTotal += wind.ProduceElectricity(hour);
                }
                message += "Wind turbine: " + solarElecGenTotal.ToString() + "\n";
                foreach (HydroPowerPlant hydro in hydroPowerPlants)
                {
                    hydroElecGenTotal += hydro.ProduceElectricity(hour);
                }
                message += "Hydro power plant: " + solarElecGenTotal.ToString() + "\n";

                totalPower = solarElecGenTotal + windElecGenTotal + hydroElecGenTotal;
                message += "total: " + totalPower.ToString() + "\n";

                foreach (ElectricityConsumer consumer in allconsumers)
                {
                    float consumption = consumer.ConsumeElectricity(hour);
                    totalConsumption += consumption;
                    message += consumer.name +  "-- total electricity used: " + consumption.ToString();
                }
                if (totalConsumption > totalPower)
                {
                    fossilProduction = totalConsumption - totalPower;
                }
                progress++;
                perc = (int)(100 * progress / hours.Count);
                mainBackgroundWorker.ReportProgress(perc, message);
            }
        }
        private void mainBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            simProgresBar.Value = e.ProgressPercentage;
            simProgresLabel.Text = "Simulating... %" + e.ProgressPercentage.ToString();
            if (e.UserState != null)
            {
                simTextBox.AppendText($"{(string)e.UserState}" + Environment.NewLine);
            }
        }
        private void mainBackgroundWorker_RunWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Simulation complete...");
        }

        private void calendarInitializerBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int progress = 0;
            int counter = 0;
            int lineCount = File.ReadLines(weatherDataFilePath).Count();
            calendarInitializerBackgroundWorker.ReportProgress(progress, "Starting to initialize calendar.");

            TextFieldParser parser = new TextFieldParser(weatherDataFilePath);
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(";");

            parser.ReadLine(); // passing first row
            string[] row = { };
            while (!parser.EndOfData)
            {
                counter++;
                progress = (int) 100 * counter / lineCount;

                row = parser.ReadFields();
                for (int i = 0; i < row.Length; i++) //checks if columns has empty data
                {
                    if (row[i] == "")
                    {
                        row[i] = "0";
                    }
                }
                DateTime date = DateTime.ParseExact(row[0], "g", CultureInfo.CurrentCulture); // g = dd.mm.yyyy hh:mm
                hours.Add(new Hour(date, float.Parse(row[1], CultureInfo.InvariantCulture), float.Parse(row[2], CultureInfo.InvariantCulture), float.Parse(row[3], CultureInfo.InvariantCulture), float.Parse(row[4], CultureInfo.InvariantCulture), float.Parse(row[5], CultureInfo.InvariantCulture)));
                if (progress % 10 == 0)
                {
                    calendarInitializerBackgroundWorker.ReportProgress(progress, date.ToString());
                }
            }
            parser.Close();           
        }
        private void calendarInitializerBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                simTextBox.AppendText($"{(string)e.UserState} --- Initializing Calendar %{e.ProgressPercentage}" + Environment.NewLine);
            }
        }
        private void calendarInitializerBackgroundWorker_RunWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            simTextBox.AppendText("Initilazing calendar complete." + Environment.NewLine);
            consumerInitializerBackgroundWorker.RunWorkerAsync();
        }

        private void consumerInitializerBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int progress = 0;
            int counter = 0;
            consumerInitializerBackgroundWorker.ReportProgress(progress, "Starting to initialize consumers");
            
            
            foreach (ControlGroup group in controls)
            {
                counter++;
                progress = (int)(100*counter / controls.Count);

                string name = "default";
                if (group.ImportButton.Tag != null)
                {
                    name = group.ImportButton.Tag.ToString();
                }
                consumerInitializerBackgroundWorker.ReportProgress(progress, "Initializing " + name);

                TextFieldParser parser = new TextFieldParser(group.FilePath);
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                bool firstLine = true;
                string[] row = { };
                string[] columnNames = { };

                List<HourlyConsumption> schedule = new List<HourlyConsumption>(); // holds every hour

                int numbOfLines = 0;
                while (!parser.EndOfData)
                {
                    numbOfLines++;
                    if (firstLine) // get column names
                    {
                        columnNames = parser.ReadFields();
                        firstLine = false;
                        continue;
                    }
                    row = parser.ReadFields();
                    for (int i = 0; i < row.Length; i++) //checks if columns has empty data
                    {
                        if (row[i] == "")
                        {
                            row[i] = "0";
                        }

                    }
                    DateTime date = DateTime.ParseExact(row[0], "g", CultureInfo.CurrentCulture); // save date
                    List<ConsumeValue> consumeValuePair = new List<ConsumeValue>();
                    for (int i = 1; i < row.Length; i++) //get every value and column name
                    {
                        consumeValuePair.Add(new ConsumeValue(columnNames[i], float.Parse(row[i], CultureInfo.InvariantCulture)));
                    }
                    schedule.Add(new HourlyConsumption(date, consumeValuePair));
                }
                consumerInitializerBackgroundWorker.ReportProgress(progress,$"Number of Lines readed:{numbOfLines}");
                string columns  = "";
                for(int i =0; i< columnNames.Length; i++)
                {
                    columns += columnNames[i] + ",";
                }
                consumerInitializerBackgroundWorker.ReportProgress(progress, "Column Names: " + columns);
                consumerInitializerBackgroundWorker.ReportProgress(progress, name + "-Sample: " + "date: " + schedule[300].Date.ToString()
                                                                                                    + "Values: " + schedule[300].ConsumeValues[2].Name
                                                                                                    + ", " + schedule[300].ConsumeValues[2].Value);

                allconsumers.Add(new ElectricityConsumer(name, int.Parse(group.Amount.Text), schedule));
                consumerInitializerBackgroundWorker.ReportProgress(progress, "Initializing " + name + "complete.");
                parser.Close();
            }
        }
        private void consumerInitializerBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(e.UserState != null)
            {
                simTextBox.AppendText($"{(string)e.UserState} --- Initializing Cosnumers %{e.ProgressPercentage}" + Environment.NewLine);
            }
            
        }
        private void consumerInitializerBackgroundWorker_RunWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            simTextBox.AppendText("Consumer initiation complete!" + Environment.NewLine);
            mainBackgroundWorker.RunWorkerAsync();
        }

        public void InitilazieSolarPanels(int amount, float efficiency, float area, float noct, float tempCoefficient)
        {
            for (var i = 0; i < amount; i++)
            {
                solarPanels.Add(new SolarPanel(efficiency, area, noct, tempCoefficient));
            }
        }
        public void InitilazieWindTurbines(int amount, float bladeArea, float powerCoefficent, float availablity)
        {
            for (var i = 0; i < amount; i++)
            {
                windTurbines.Add(new WindTurbine(bladeArea, powerCoefficent, availablity));
            }
        }
        public void InitilazieHydroPowerPlanets(int amount, float height, float efficiency)
        {
            for (var i = 0; i < amount; i++)
            {
                hydroPowerPlants.Add(new HydroPowerPlant(height, efficiency));
            }
        }
        /*public void FillCalendar(string filePath) // control data
        {
            
            TextFieldParser parser = new TextFieldParser(filePath);
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(";");

            parser.ReadLine(); // passing first row
            string[] row = { };
            while (!parser.EndOfData)
            {

                row = parser.ReadFields();
                for (int i = 0; i < row.Length; i++) //checks if columns has empty data
                {
                    if (row[i] == "")
                    {
                        row[i] = "0";
                    }
                }
                DateTime date = DateTime.ParseExact(row[0], "g", CultureInfo.CurrentCulture); // g = dd.mm.yyyy hh:mm
                hours.Add(new Hour(date, float.Parse(row[1], CultureInfo.InvariantCulture), float.Parse(row[2], CultureInfo.InvariantCulture), float.Parse(row[3], CultureInfo.InvariantCulture), float.Parse(row[4], CultureInfo.InvariantCulture), float.Parse(row[5], CultureInfo.InvariantCulture)));

            }
            parser.Close();
            simTextBox.AppendText("Filled calendar..." + Environment.NewLine);
        }*/
        /*public void FillConsumer(List<ControlGroup> contorls) // string filePath
        {
            foreach(ControlGroup group in contorls)
            {
                TextFieldParser parser = new TextFieldParser(group.FilePath);
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                bool firstLine = true;
                string[] row = { };
                string[] columnNames = { };


                List<HourlyConsumption> schedule = new List<HourlyConsumption>(); // holds every hour

                while (!parser.EndOfData)
                {
                    if (firstLine) // get column names
                    {
                        columnNames = parser.ReadFields();
                        firstLine = false;
                        continue;
                    }
                    row = parser.ReadFields();
                    for (int i = 0; i < row.Length; i++) //checks if columns has empty data
                    {
                        if (row[i] == "")
                        {
                            row[i] = "0";
                        }

                    }
                    DateTime date = DateTime.ParseExact(row[0], "g", CultureInfo.CurrentCulture); // save date
                    List<ConsumeValue> consumeValuePair = new List<ConsumeValue>();
                    for (int i = 1; i < row.Length; i++) //get every value and column name
                    {
                        consumeValuePair.Add(new ConsumeValue(columnNames[i], float.Parse(row[i], CultureInfo.InvariantCulture)));
                    }
                    schedule.Add(new HourlyConsumption(date, consumeValuePair));
                }
                string name = "default";
                if(group.ImportButton.Tag != null)
                {
                    name = group.ImportButton.Tag.ToString();
                }
                allconsumers.Add(new ElectricityConsumer(name, int.Parse(group.Amount.Text), schedule));

                parser.Close();
            }
            
        }*/

    }
}

