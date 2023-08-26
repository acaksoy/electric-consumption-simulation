using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimulationClassLibrary
{
    public class SimulationManager
    {
        
        private List<Hour> hours { get;  set; }
        private List<SolarPanel> solarPanels { get; set; }
        private List<WindTurbine> windTurbines { get; set; }
        private List<HydroPowerPlant> hydroPowerPlants { get; set; }
        public SimulationManager() {
            hours = new List<Hour>();
            solarPanels = new List<SolarPanel>();
            windTurbines = new List<WindTurbine>();
            hydroPowerPlants = new List<HydroPowerPlant>();
        }
 
        public void InitilazieSolarPanels(int amount, float efficiency, float area, float noct, float tempCoefficient)
        {
            for(var i = 0; i < amount; i++)
            {
                solarPanels.Add(new SolarPanel(efficiency, area, noct, tempCoefficient));
            }
        }
        public void InitilazieWindTurbines(int amount, float bladeArea, float powerCoefficent, float availablity)
        {
            for(var i = 0; i < amount;i++)
            {
                windTurbines.Add(new WindTurbine(bladeArea, powerCoefficent, availablity));
            }
        }

        public void InitilazieHydroPowerPlanets(int amount, float height, float efficiency)
        {
            for(var i = 0; i < amount; i++)
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
                for(int i=0; i<6; i++) //checks if columns has empty data
                {
                    if (row[i] == "")
                    {
                        row[i] = "0";
                    }
                }
                DateTime date = DateTime.ParseExact(row[0], "g", CultureInfo.CurrentCulture); // g = dd.mm.yyyy hh:mm
                hours.Add(new Hour(date, float.Parse( row[1]), float.Parse(row[2]), float.Parse(row[3]), float.Parse(row[4]), float.Parse(row[5]) ));

            }  
            parser.Close();
            Console.WriteLine("hour example: " + hours[10].Date + " --- " + hours[10].AirPressure);
        }
        
    }
}
