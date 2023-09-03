using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationClassLibrary
{
    public class Hour
    {
        public DateTime Date { get; set; }
        public float SolarIrradiance { get; set; } // W/m²
        public float WindSpeed { get; set; } // m/s
        public float Temperature { get; set; } // °C
        public float Discharge { get; set; } // river discharge, m³/s

        public float AirPressure { get; set; } //pascal, 
        public Hour(DateTime date, float windSpeed, float solarIrradiance, float temperature, float discharge, float airPressure)
        {
            Date = date;
            SolarIrradiance = solarIrradiance;
            WindSpeed = windSpeed;
            Temperature = temperature;
            Discharge = discharge;
            AirPressure = airPressure;
        }
    }
}
