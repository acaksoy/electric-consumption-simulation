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
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

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


        private List<Record> records = new List<Record>();


        BackgroundWorker mainBackgroundWorker;
        BackgroundWorker consumerInitializerBackgroundWorker;
        BackgroundWorker calendarInitializerBackgroundWorker;

        public event EventHandler<string> NullRowFoundEvent;



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


            records.Add(new Record("Elec. Prod. Fossil"));
            records.Add(new Record("Total Elec. Prod. Renewable"));
            records.Add(new Record("Total Elec. Consumption"));
            records.Add(new Record("Power Storage"));

            mainBackgroundWorker = new BackgroundWorker();
            mainBackgroundWorker.DoWork += mainBackgroundWorker_DoWork;
            mainBackgroundWorker.RunWorkerCompleted += mainBackgroundWorker_RunWorkCompleted;
            mainBackgroundWorker.ProgressChanged += mainBackgroundWorker_ProgressChanged;
            mainBackgroundWorker.WorkerReportsProgress = true;
            mainBackgroundWorker.WorkerSupportsCancellation = true;

            calendarInitializerBackgroundWorker = new BackgroundWorker();
            calendarInitializerBackgroundWorker.DoWork += calendarInitializerBackgroundWorker_DoWork;
            calendarInitializerBackgroundWorker.RunWorkerCompleted += calendarInitializerBackgroundWorker_RunWorkCompleted;
            calendarInitializerBackgroundWorker.ProgressChanged += calendarInitializerBackgroundWorker_ProgressChanged;
            calendarInitializerBackgroundWorker.WorkerReportsProgress = true;
            calendarInitializerBackgroundWorker.WorkerSupportsCancellation = true;

            consumerInitializerBackgroundWorker = new BackgroundWorker();
            consumerInitializerBackgroundWorker.DoWork += consumerInitializerBackgroundWorker_DoWork;
            consumerInitializerBackgroundWorker.RunWorkerCompleted += consumerInitializerBackgroundWorker_RunWorkCompleted;
            consumerInitializerBackgroundWorker.ProgressChanged += consumerInitializerBackgroundWorker_ProgressChanged;
            consumerInitializerBackgroundWorker.WorkerReportsProgress = true;
            consumerInitializerBackgroundWorker.WorkerSupportsCancellation = true;
        }

        public void Simulate()
        {
            simTextBox.AppendText("Starting simulation..." + Environment.NewLine);
            calendarInitializerBackgroundWorker.RunWorkerAsync();
        }

        private void mainBackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            int progress = 0;
            int perc = 0;

            double powerStorage = 0;
            
            foreach (Hour hour in hours)
            {
                double solarElecGenTotal = 0;
                double windElecGenTotal = 0;
                double hydroElecGenTotal = 0;
                double totalPower = 0;
                double fossilProduction = 0;

                double totalConsumption = 0;

                bool fosilProductionActive = true;

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
                
                foreach (SolarPanel panel in solarPanels)
                {
                    solarElecGenTotal += panel.ProduceElectricity(hour);
                }


                Record spRecord = records.Find(x => x.Name == "Solar panels") ?? throw new InvalidOperationException("Record could not be found!");
                spRecord.RecordResult(hour.Date, solarElecGenTotal);

                
                foreach (WindTurbine wind in windTurbines)
                {
                    windElecGenTotal += wind.ProduceElectricity(hour);
                }

                Record wtRecord = records.Find(x => x.Name == "Wind turbines") ?? throw new InvalidOperationException("Record could not be found!");
                wtRecord.RecordResult(hour.Date, windElecGenTotal);

                foreach (HydroPowerPlant hydro in hydroPowerPlants)
                {
                    hydroElecGenTotal += hydro.ProduceElectricity(hour);
                }

                Record hppRecord = records.Find(x => x.Name == "Hydropower plants") ?? throw new InvalidOperationException("Record could not be found!");
                hppRecord.RecordResult(hour.Date, hydroElecGenTotal);

                totalPower = solarElecGenTotal + windElecGenTotal + hydroElecGenTotal;

                Record teprRecord = records.Find(x => x.Name == "Total Elec. Prod. Renewable") ?? throw new InvalidOperationException("Record could not be found!");
                teprRecord.RecordResult(hour.Date, totalPower);


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
                    Record cRecord = records.Find(x => x.Name == consumer.name) ?? throw new InvalidOperationException("Record could not be found!");
                    cRecord.RecordResult(hour.Date, consumption);
                }

                if (totalPower > totalConsumption) powerStorage += totalPower - totalConsumption;                              

                if (totalConsumption > totalPower)
                {
                    double tempTotalCon = totalConsumption;

                    tempTotalCon -= totalPower;
                    if(tempTotalCon > 0)
                    {
                        if(tempTotalCon >= powerStorage) 
                        {
                            tempTotalCon -= powerStorage;
                            powerStorage = 0;
                            if (fosilProductionActive)
                            {
                                fossilProduction = tempTotalCon; 
                            }
                        }
                        else
                        {
                            powerStorage = powerStorage - tempTotalCon;
                            tempTotalCon = 0;
                        }                       
                    }
                    if (tempTotalCon < 0) { tempTotalCon = 0; }

                }
                Record tecRecord = records.Find(x => x.Name == "Total Elec. Consumption") ?? throw new InvalidOperationException("Record could not be found!");
                tecRecord.RecordResult(hour.Date, totalConsumption);
                Record fRecord = records.Find(x => x.Name == "Elec. Prod. Fossil") ?? throw new InvalidOperationException("Record could not be found!");
                fRecord.RecordResult(hour.Date, fossilProduction);
                Record sRecord = records.Find(x => x.Name == "Power Storage") ?? throw new InvalidOperationException("Record could not be found!");
                sRecord.RecordResult(hour.Date, powerStorage);

                progress++;
                perc = (int)(100 * progress / hours.Count);
                
                if(perc % 10 == 0) {
                    mainBackgroundWorker.ReportProgress(perc);
                }
                               
                
            }
        }
        private void mainBackgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            simProgresBar.Value = e.ProgressPercentage;
            simProgresLabel.Text = "Simulating... %" + e.ProgressPercentage.ToString();
        }
        private void mainBackgroundWorker_RunWorkCompleted(object? sender, RunWorkerCompletedEventArgs e)
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

        private void calendarInitializerBackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            
            try
            {
                int progress = 0;
                int counter = 0;
                int lineCount = File.ReadLines(eventDataFilePath).Count();
                calendarInitializerBackgroundWorker.ReportProgress(progress, "Starting to initialize events.");

                TextFieldParser parserEvent = new TextFieldParser(eventDataFilePath);
                parserEvent.TextFieldType = FieldType.Delimited;
                parserEvent.SetDelimiters(";");

                string[]? headersRE = parserEvent.ReadFields();
                if (headersRE == null || headersRE.Length != 9)
                {
                    e.Cancel = true;
                    NullRowFoundEvent?.Invoke(this, "Random Events file has incorrect Format.Number of headers must be 9!");
                    return;
                }

                string[]? rowEvent = { };
                while (!parserEvent.EndOfData)
                {
                    counter++;
                    progress = (int)100 * counter / lineCount;

                    rowEvent = parserEvent.ReadFields();
                    if (rowEvent == null || rowEvent.Length == 0)
                    {
                        e.Cancel = true;
                        NullRowFoundEvent?.Invoke(this, "Random Events file has incorrect Format. The rows are either empty or null!");
                        return;
                    }


                    string name = rowEvent[0];
                    string description = rowEvent[1];

                    DateOnly startDate;
                    if (!DateOnly.TryParseExact(rowEvent[2], "dd.MM.yyyy", out startDate))
                    {
                        e.Cancel = true;
                        NullRowFoundEvent?.Invoke(this, "Random Events file has incorrect Format. The start date could not be parsed. Make sure the format is dd.MM.yyyy !");
                        return;
                    }
                    DateOnly endDate;
                    if (!DateOnly.TryParseExact(rowEvent[3], "dd.MM.yyyy", out endDate))
                    {
                        e.Cancel = true;
                        NullRowFoundEvent?.Invoke(this, "Random Events file has incorrect Format. The end date could not be parsed. Make sure the format is dd.MM.yyyy !");
                        return;
                    }
                    TimeOnly startHour;
                    if (!TimeOnly.TryParseExact(rowEvent[4], "HH:mm", out startHour))
                    {
                        e.Cancel = true;
                        NullRowFoundEvent?.Invoke(this, "Random Events file has incorrect Format. The start hour could not be parsed. Make sure the format is HH:mm !");
                        return;
                    }
                    TimeOnly endHour;
                    if (!TimeOnly.TryParseExact(rowEvent[5], "HH:mm", out endHour))
                    {
                        e.Cancel = true;
                        NullRowFoundEvent?.Invoke(this, "Random Events file has incorrect Format. The end hour could not be parsed. Make sure the format is HH:mm !");
                        return;
                    }
                    string effectedClass = rowEvent[6];
                    string effectedUnitTag = rowEvent[7];
                    float effectValue;
                    if (!float.TryParse(rowEvent[8], NumberStyles.Float, CultureInfo.InvariantCulture, out effectValue))
                    {
                        e.Cancel = true;
                        NullRowFoundEvent?.Invoke(this, "Random Events file has incorrect Format. The effect value could not be parsed. Make sure the value is a floating point number !");
                        return;
                    }

                    events.Add(new Event(startDate, endDate, startHour, endHour, name, description, effectedClass, effectedUnitTag, effectValue));

                    if (progress % 25 == 0)
                    {
                        calendarInitializerBackgroundWorker.ReportProgress(progress);
                    }
                }
                parserEvent.Close();
            }
            catch(IOException ex)
            {               
                e.Cancel = true;
                NullRowFoundEvent?.Invoke(this, "Failed to read random event  file. " + ex.Message);
                return;
            }

            try
            {
                int progress = 0;
                int counter = 0;
                int lineCount = File.ReadLines(weatherDataFilePath).Count();
                calendarInitializerBackgroundWorker.ReportProgress(progress, "Starting to initialize calendar.");

                TextFieldParser parser = new TextFieldParser(weatherDataFilePath);
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");

                string[]? headersWeather = parser.ReadFields();
                if (headersWeather == null || headersWeather.Length != 6)
                {
                    e.Cancel = true;
                    NullRowFoundEvent?.Invoke(this, "Weather file has incorrect Format. Number of headers must be 6!");
                    return;
                }
                string[]? row = { };
                while (!parser.EndOfData)
                {
                    counter++;
                    progress = (int)100 * counter / lineCount;

                    row = parser.ReadFields();
                    if (row == null || row.Length == 0)
                    {
                        e.Cancel = true;
                        NullRowFoundEvent?.Invoke(this, "Weather file has incorrect Format. The rows are either empty or null!");
                        return;
                    }

                    DateTime date; // g = dd.mm.yyyy hh:mm
                    if (!DateTime.TryParseExact(row[0], "g", new CultureInfo("de-DE"), DateTimeStyles.None, out date))
                    {
                        e.Cancel = true;
                        NullRowFoundEvent?.Invoke(this, "Weather file has incorrect Format. Date must be in dd.mm.yyyy hh:mm format!");
                        return;
                    }
                    float wind;
                    if (!float.TryParse(row[1], NumberStyles.Float, CultureInfo.InvariantCulture, out wind))
                    {
                        e.Cancel = true;
                        NullRowFoundEvent?.Invoke(this, "Weather file has incorrect Format. Wind-Speed must be a floating point number!");
                        return;
                    }
                    float globalirr;
                    if (!float.TryParse(row[2], NumberStyles.Float, CultureInfo.InvariantCulture, out globalirr))
                    {
                        e.Cancel = true;
                        NullRowFoundEvent?.Invoke(this, "Weather file has incorrect Format. Global-Irradiance must be a floating point number!");
                        return;
                    }
                    float temp;
                    if (!float.TryParse(row[3], NumberStyles.Float, CultureInfo.InvariantCulture, out temp))
                    {
                        e.Cancel = true;
                        NullRowFoundEvent?.Invoke(this, "Weather file has incorrect Format. Temperature must be a floating point number!");
                        return;
                    }
                    float discharge;
                    if (!float.TryParse(row[4], NumberStyles.Float, CultureInfo.InvariantCulture, out discharge))
                    {
                        e.Cancel = true;
                        NullRowFoundEvent?.Invoke(this, "Weather file has incorrect Format. Discharge must be a floating point number!");
                        return;
                    }
                    float airPress;
                    if (!float.TryParse(row[5], NumberStyles.Float, CultureInfo.InvariantCulture, out airPress))
                    {
                        e.Cancel = true;
                        NullRowFoundEvent?.Invoke(this, "Weather file has incorrect Format. Air-Pressure must be a floating point number!");
                        return;
                    }
                    hours.Add(new Hour(date, wind, globalirr, temp, discharge, airPress));
                    if (progress % 10 == 0)
                    {
                        calendarInitializerBackgroundWorker.ReportProgress(progress);
                    }
                }
                parser.Close();
            }
            catch (IOException ex) {
                e.Cancel = true;
                NullRowFoundEvent?.Invoke(this, "Failed to read weathetr  file. " + ex.Message);
                return;
            }


                       
        }
        private void calendarInitializerBackgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                simTextBox.AppendText($"{(string)e.UserState} --- Initializing Calendar %{e.ProgressPercentage}" + Environment.NewLine);
            }
        }
        private void calendarInitializerBackgroundWorker_RunWorkCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            if(!e.Cancelled)
            {
                simTextBox.AppendText("Initilazing calendar complete." + Environment.NewLine);
                consumerInitializerBackgroundWorker.RunWorkerAsync();
            }

        }

        private void consumerInitializerBackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            int progress = 0;
            int counter = 0;
            consumerInitializerBackgroundWorker.ReportProgress(progress, "Starting to initialize consumers");
            try
            {
                foreach (ControlGroup group in controls)
                {
                    counter++;
                    progress = (int)(100 * counter / controls.Count);

                    string name = group.ImportButton.Tag.ToString() ?? "default";
                    int numbOfLines = 0;
                    consumerInitializerBackgroundWorker.ReportProgress(progress, "Initializing " + name);

                    TextFieldParser parser = new TextFieldParser(group.FilePath);
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(";");
                    string[]? row;
                    string[]? columnNames = parser.ReadFields();
                    if (columnNames == null || columnNames.Length < 2)
                    {
                        e.Cancel = true;
                        NullRowFoundEvent?.Invoke(this, $"{name} file has incorrect Format. Number of headers must be minimum 2!");
                        return;
                    }

                    List<HourlyConsumption> schedule = new List<HourlyConsumption>();
                    while (!parser.EndOfData)
                    {
                        numbOfLines++;

                        row = parser.ReadFields();
                        if (row == null || row.Length == 0)
                        {
                            e.Cancel = true;
                            NullRowFoundEvent?.Invoke(this, $"{name} file has incorrect Format. The rows are either empty or null");
                            return;
                        }
                        DateTime date; // save date
                        if (!DateTime.TryParseExact(row[0], "g", new CultureInfo("de-DE"), DateTimeStyles.None, out date)) //CultureInfo.CurrentCulture
                        {
                            e.Cancel = true;
                            NullRowFoundEvent?.Invoke(this, $"{name} file has incorrect Format. Date must be in dd.mm.yyyy hh:mm format!");
                            return;
                        }
                        List<ConsumeValue> consumeValuePair = new List<ConsumeValue>();
                        float value;
                        for (int i = 1; i < row.Length; i++) //get every value and column name
                        {
                            if (!float.TryParse(row[i], NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                            {
                                e.Cancel = true;
                                NullRowFoundEvent?.Invoke(this, $"{name} file has incorrect Format. {columnNames[i]} values must be a floating point number!");
                                return;
                            }

                            consumeValuePair.Add(new ConsumeValue(columnNames[i], value));
                        }
                        schedule.Add(new HourlyConsumption(date, consumeValuePair));
                    }

                    consumerInitializerBackgroundWorker.ReportProgress(progress, $"Number of Lines readed:{numbOfLines}");
                    string columns = "";
                    for (int i = 0; i < columnNames!.Length; i++)
                    {
                        columns += columnNames[i] + ",";
                    }
                    consumerInitializerBackgroundWorker.ReportProgress(progress, "Column Names: " + columns);

                    allconsumers.Add(new ElectricityConsumer(name, int.Parse(group.Amount.Text), schedule));
                    records.Add(new Record(name));
                    consumerInitializerBackgroundWorker.ReportProgress(progress, "Initializing " + name + "complete.");
                    parser.Close();
                }
            }
            catch(Exception ex)
            {
                e.Cancel = true;
                NullRowFoundEvent?.Invoke(this, " One of the files containing consumption plans could not be read  " + ex.Message);
                return;
            }
            
        }
        private void consumerInitializerBackgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            if(e.UserState != null)
            {
                simTextBox.AppendText($"{(string)e.UserState} --- Initializing Cosnumers %{e.ProgressPercentage}" + Environment.NewLine);
            }
            
        }
        private void consumerInitializerBackgroundWorker_RunWorkCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                simTextBox.AppendText("Consumer initiation complete!" + Environment.NewLine);
                mainBackgroundWorker.RunWorkerAsync();
            }

        }

        public void InitializeSolarPanels(int amount, float efficiency, float area, float noct, float tempCoefficient)
        {
            for (var i = 0; i < amount; i++)
            {
                solarPanels.Add(new SolarPanel(efficiency, area, noct, tempCoefficient));
            }
            records.Add(new Record("Solar panels"));
        }
        public void InitializeWindTurbines(int amount, float bladeArea, float powerCoefficent, float availablity)
        {
            for (var i = 0; i < amount; i++)
            {
                windTurbines.Add(new WindTurbine(bladeArea, powerCoefficent, availablity));
            }
            records.Add(new Record("Wind turbines"));
        }
        public void InitializeHydroPowerPlants(int amount, float height, float efficiency)
        {
            for (var i = 0; i < amount; i++)
            {
                hydroPowerPlants.Add(new HydroPowerPlant(height, efficiency));
            }
            records.Add(new Record("Hydropower plants"));
        }

    }
}

