using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationClassLibrary
{
    public class SimulationManager
    {
        public List<Hour> hours { get; set; }
        public SimulationManager() {
            hours = new List<Hour>();
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
