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
        }
        public void InitilazieProducers()
        {

        }
        public void FillCalendar(TextFieldParser parser)
        {
            parser.ReadLine(); // passing first row
            string[] row = { };
            while (!parser.EndOfData)
            {
                
                row = parser.ReadFields();
                for(int i=0; i<5; i++)
                {
                    if (row[i] == "")
                    {
                        row[i] = "0";
                    }
                }
                DateTime date = DateTime.ParseExact(row[0], "g", CultureInfo.CurrentCulture); // g = dd.mm.yyyy hh:mm
                hours.Add(new Hour(date, float.Parse( row[1]), int.Parse(row[2]), float.Parse(row[3]), float.Parse(row[4]) ));

            }
        }
        
    }
}
