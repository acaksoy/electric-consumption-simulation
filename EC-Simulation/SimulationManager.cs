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

namespace EC_Simulation
{
    public class SimulationManager
    {
        private List<Hour> hours { get; set; }
        private List<SolarPanel> solarPanels { get; set; }
        private List<WindTurbine> windTurbines { get; set; }
        private List<HydroPowerPlant> hydroPowerPlants { get; set; }

        private List<Houshold> housholds { get; set; }

        BackgroundWorker backgroundWorker;
        Label simProgresLabel;
        ProgressBar simProgresBar;
        public SimulationManager()
        {
            hours = new List<Hour>();
            solarPanels = new List<SolarPanel>();
            windTurbines = new List<WindTurbine>();
            hydroPowerPlants = new List<HydroPowerPlant>();
            housholds = new List<Houshold>();

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkCompleted;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.WorkerReportsProgress = true;
        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int progress = 0;
            int perc = 0;
            foreach (Hour hour in hours)
            {
                float solarElecGenTotal = 0;
                float windElecGenTotal = 0;
                float hydroElecGenTotal = 0;
                float totalPower = 0;
                float fossilProduction = 0;

                float totalConsumption = 0;
                foreach (SolarPanel panel in solarPanels)
                {
                    solarElecGenTotal += panel.ProduceElectricity(hour);
                }
                foreach (WindTurbine wind in windTurbines)
                {
                    windElecGenTotal += wind.ProduceElectricity(hour);
                }
                foreach (HydroPowerPlant hydro in hydroPowerPlants)
                {
                    hydroElecGenTotal += hydro.ProduceElectricity(hour);
                }
                totalPower = solarElecGenTotal + windElecGenTotal + hydroElecGenTotal;

                foreach (Houshold house in housholds)
                {
                    totalConsumption += house.ConsumeElectricity(hour);
                }
                if (totalConsumption > totalPower)
                {
                    fossilProduction = totalConsumption - totalPower;
                }
                progress++;
                perc = (int)(100 * progress / hours.Count);
                backgroundWorker.ReportProgress(perc);
            }
        }
        private void backgroundWorker_RunWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Simulation complete...");
        }
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            simProgresBar.Value = e.ProgressPercentage;
            simProgresLabel.Text = "Simulating... %" + e.ProgressPercentage.ToString();
        }

        public void Simulate(TextBox tb, Label simProgresLable, ProgressBar simProgressBar)
        {
            this.simProgresLabel = simProgresLable;
            this.simProgresBar = simProgressBar;
            backgroundWorker.RunWorkerAsync();
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
        public void FillCalendar(TextFieldParser parser) // control data
        {
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
            Console.WriteLine("hour example: " + hours[10].Date + " --- " + hours[10].AirPressure);
        }
        public void FillConsumer(TextFieldParser parser)
        {
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
            housholds.Add(new Houshold("res1", 10, schedule));

            parser.Close();
        }

    }
}

