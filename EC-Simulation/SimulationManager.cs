using Microsoft.VisualBasic.FileIO;
using SimulationClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace EC_Simulation
{
    public class SimulationManager
    {
        private List<Hour> hours { get; set; }
        private List<Event> events { get; set; }

        private List<SolarPanel> solarPanels { get; set; }
        private List<WindTurbine> windTurbines { get; set; }
        private List<HydroPowerPlant> hydroPowerPlants { get; set; }

        private List<ElectricityConsumer> allconsumers { get; set; }

        //private List<Record> productionRecords = new List<Record>();
        //private List<Record> consumptionRecords = new List<Record>();
        private List<Record> records = new List<Record>();


        BackgroundWorker mainBackgroundWorker;
        BackgroundWorker consumerInitializerBackgroundWorker;
        BackgroundWorker calendarInitializerBackgroundWorker;

        List<ControlGroup> controls;
        Label simProgresLabel;
        ProgressBar simProgresBar;
        TextBox simTextBox;

        private string weatherDataFilePath;
        private string eventDataFilePath;

        double yearTotalConsump = 0;
        double totalProduction = 0;
        double solarTotalProduction = 0;
        double windTotalProduction = 0;
        double hydroTotalProduction = 0;
        double fosilTotalProduction = 0;

        public SimulationManager(Label simLabel, ProgressBar simPBar, TextBox simTB, List<ControlGroup> controls, string weatherDataFilePath, string eventDataFilePath) //initilaze icin bilgiler önden yüklenmeli
        {
            simProgresLabel = simLabel;
            simProgresBar = simPBar;
            simTextBox = simTB;
            this.controls = controls;
            this.weatherDataFilePath = weatherDataFilePath;
            this.eventDataFilePath = eventDataFilePath;
            
            hours = new List<Hour>();
            events = new List<Event>();
            solarPanels = new List<SolarPanel>();
            windTurbines = new List<WindTurbine>();
            hydroPowerPlants = new List<HydroPowerPlant>();
            allconsumers = new List<ElectricityConsumer>();

            /*productionRecords.Add(new Record("Fosil resources"));
            productionRecords.Add(new Record("Total Production"));
            consumptionRecords.Add(new Record("Total Consumption"));*/


            records.Add(new Record("Elec. Prod. Fossil"));
            records.Add(new Record("Total Elec. Prod. Renewable"));
            records.Add(new Record("Total Elec. Consumption"));

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
            
            //Event activeEvent = null;
            foreach (Hour hour in hours)
            {
                double solarElecGenTotal = 0;
                double windElecGenTotal = 0;
                double hydroElecGenTotal = 0;
                double totalPower = 0;
                double fossilProduction = 0;

                double totalConsumption = 0;

                bool fosilProductionActive = true;

                Debug.WriteLine($"weather: temp: {hour.Temperature}, solarirr: {hour.SolarIrradiance}");
                List<Event> activeEvents = new List<Event>();
                DateOnly date = DateOnly.FromDateTime(hour.Date);
                TimeOnly time = TimeOnly.FromDateTime(hour.Date);
                foreach (Event ev in events)
                {
                    if ((ev.StartDate <= date && ev.EndDate >= date) && (ev.StartHour <= time && ev.EndHour >= time))
                    {
                        activeEvents.Add(ev);
                        if (ev.EffectedClass == "Weather")
                        {
                            switch (ev.EffectedUnitName)
                            {
                                case "Temperature":
                                    hour.Temperature = ev.EffectValue;
                                    break;
                                case "SolarIrradiance":
                                    hour.SolarIrradiance = ev.EffectValue;
                                    break;
                                case "WindSpeed":
                                    hour.WindSpeed = ev.EffectValue;
                                    break;
                                case "Discharge":
                                    hour.Discharge = ev.EffectValue;
                                    break;
                                case "AirPressure":
                                    hour.AirPressure = ev.EffectValue;
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (ev.EffectedUnitName == "Fosil" && ev.EffectValue == 0)
                        {
                            fosilProductionActive = false;
                        }

                    }
                }

                /*foreach(Event ev in activeEvents)
                {
                    if(ev.EffectedUnitName == "Fosil" && ev.EffectValue == 0)
                    {
                        fosilProductionActive = false;
                    }
                }*/
                
                foreach (SolarPanel panel in solarPanels)
                {
                    solarElecGenTotal += panel.ProduceElectricity(hour);
                }

                records.Find(x => x.Name == "Solar panels").RecordResult(hour.Date, solarElecGenTotal);

                solarTotalProduction += solarElecGenTotal;//test
                
                foreach (WindTurbine wind in windTurbines)
                {
                    windElecGenTotal += wind.ProduceElectricity(hour);
                }
                records.Find(x => x.Name == "Wind turbines").RecordResult(hour.Date, windElecGenTotal);
                windTotalProduction += windElecGenTotal;//test
                foreach (HydroPowerPlant hydro in hydroPowerPlants)
                {
                    hydroElecGenTotal += hydro.ProduceElectricity(hour);
                }
                records.Find(x => x.Name == "Hydropower plants").RecordResult(hour.Date, hydroElecGenTotal);
                hydroTotalProduction += hydroElecGenTotal;//test

                totalPower = solarElecGenTotal + windElecGenTotal + hydroElecGenTotal;
                records.Find(x => x.Name == "Total Elec. Prod. Renewable").RecordResult(hour.Date, totalPower);
                totalProduction += totalPower;//test


                foreach (ElectricityConsumer consumer in allconsumers)
                {
                    float consumption = consumer.ConsumeElectricity(hour);
                    foreach(Event ev in activeEvents)
                    {
                        if(ev.EffectedUnitName == consumer.name)
                        {
                            consumption *= ev.EffectValue;
                        }
                    }
                    totalConsumption += consumption;

                    records.Find(x => x.Name == consumer.name).RecordResult(hour.Date, consumption);
                }
                if (totalConsumption > totalPower)
                {
                    if (fosilProductionActive)
                    {
                        fossilProduction = totalConsumption - totalPower;
                    }
                }
                records.Find(x => x.Name == "Total Elec. Consumption").RecordResult(hour.Date, totalConsumption);
                records.Find(x => x.Name == "Elec. Prod. Fossil").RecordResult(hour.Date, fossilProduction);

                progress++;
                perc = (int)(100 * progress / hours.Count);
                
                if(perc % 10 == 0) {
                    mainBackgroundWorker.ReportProgress(perc);
                }
                               
                
            }
        }
        private void mainBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            simProgresBar.Value = e.ProgressPercentage;
            simProgresLabel.Text = "Simulating... %" + e.ProgressPercentage.ToString();
            /*if (e.UserState != null)
            {
                List<string> messages = e.UserState as List<string>;                              
                for(int i=0; i< messages.Count; i++)
                {
                    simTextBox.AppendText(messages[i] + Environment.NewLine);
                }
                
            }*/
        }
        private void mainBackgroundWorker_RunWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            simProgresBar.Value = 100;
            simProgresLabel.Text = "Complete";
            Debug.WriteLine("--------------------------");
            Debug.WriteLine($"Single solar production: {solarPanels[0].ProduceElectricity(hours[612])}");
            Debug.WriteLine($"Single wind production: {windTurbines[0].ProduceElectricity(hours[612])}");
            Debug.WriteLine($"Single hydro production: {hydroPowerPlants[0].ProduceElectricity(hours[612])}");

            Debug.WriteLine($"Total consumption: {yearTotalConsump}");
            Debug.WriteLine($"Total production: {totalProduction}");
            Debug.WriteLine($"Total solar production: {solarTotalProduction}");
            Debug.WriteLine($"Total wind production: {windTotalProduction}");
            Debug.WriteLine($"Total hydro production: {hydroTotalProduction}");
            Debug.WriteLine($"Total fosil production: {fosilTotalProduction}");
            Debug.WriteLine("--------------------------");

            MessageBox.Show("Simulation complete...");
            DisplayResult displayResult = new DisplayResult(records);
            displayResult.Show();
        }

        private void calendarInitializerBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int progress = 0;
            int counter = 0;
            int lineCount = File.ReadLines(eventDataFilePath).Count();
            calendarInitializerBackgroundWorker.ReportProgress(progress, "Starting to initialize events.");

            TextFieldParser parserEvent = new TextFieldParser(eventDataFilePath);
            parserEvent.TextFieldType = FieldType.Delimited;
            parserEvent.SetDelimiters(";");

            parserEvent.ReadLine(); // passing first row
            string[] rowEvent = { };
            while (!parserEvent.EndOfData)
            {
                counter++;
                progress = (int)100 * counter / lineCount;

                rowEvent = parserEvent.ReadFields();
                for (int i = 0; i < rowEvent.Length; i++) //checks if columns has empty data
                {
                    if (rowEvent[i] == "")
                    {
                        rowEvent[i] = "0";
                    }
                }
                string name = rowEvent[0];
                string description = rowEvent[1];
                DateOnly startDate = DateOnly.ParseExact(rowEvent[2], "dd.MM.yyyy", CultureInfo.CurrentCulture);
                DateOnly endDate = DateOnly.ParseExact(rowEvent[3], "dd.MM.yyyy", CultureInfo.CurrentCulture);
                TimeOnly startHour = TimeOnly.ParseExact(rowEvent[4], "HH:mm", CultureInfo.CurrentCulture);
                TimeOnly endHour = TimeOnly.ParseExact(rowEvent[5], "HH:mm", CultureInfo.CurrentCulture);
                string effectedClass = rowEvent[6];
                string effectedUnitTag = rowEvent[7];
                float effectValue = float.Parse(rowEvent[8], CultureInfo.InvariantCulture);

                events.Add(new Event(startDate, endDate, startHour, endHour, name, description, effectedClass ,effectedUnitTag ,effectValue));

                if (progress % 25 == 0)
                {
                    calendarInitializerBackgroundWorker.ReportProgress(progress);
                }
            }
            parserEvent.Close();

            progress = 0;
            counter = 0;
            lineCount = File.ReadLines(weatherDataFilePath).Count();
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
                    calendarInitializerBackgroundWorker.ReportProgress(progress);
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

                allconsumers.Add(new ElectricityConsumer(name, int.Parse(group.Amount.Text), schedule));
                //consumptionRecords.Add(new Record(name));
                records.Add(new Record(name));
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
            //productionRecords.Add(new Record("Solar panels"));
            records.Add(new Record("Solar panels"));
        }
        public void InitilazieWindTurbines(int amount, float bladeArea, float powerCoefficent, float availablity)
        {
            for (var i = 0; i < amount; i++)
            {
                windTurbines.Add(new WindTurbine(bladeArea, powerCoefficent, availablity));
            }
            //productionRecords.Add(new Record("Wind turbines"));
            records.Add(new Record("Wind turbines"));
        }
        public void InitilazieHydroPowerPlanets(int amount, float height, float efficiency)
        {
            for (var i = 0; i < amount; i++)
            {
                hydroPowerPlants.Add(new HydroPowerPlant(height, efficiency));
            }
            //productionRecords.Add(new Record("Hydropower plants"));
            records.Add(new Record("Hydropower plants"));
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

