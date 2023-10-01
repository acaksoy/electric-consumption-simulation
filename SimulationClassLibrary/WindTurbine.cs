using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationClassLibrary
{
    public class WindTurbine : ElectricityProducer
    {
        private static float kelvin = 273.15f;
        private static float gasConstatn = 287.05f;

        private float airDenstiy;
        private float bladeArea;
        private float powerCoefficent;
        private float availablity;

        public WindTurbine(float bladeArea, float powerCoefficent, float availablity)
        {
            this.bladeArea = bladeArea;
            this.powerCoefficent = powerCoefficent;
            this.availablity = availablity;
        }

        public override float ProduceElectricity(Hour hour)
        {
            // Wenn die Windgeschwindigkeit zu hoch oder zu niedrig ist, produziert keine Strom.
            if (hour.WindSpeed < 3f || hour.WindSpeed > 25) return 0;

            // Luftdichte berechnen.
            airDenstiy = hour.AirPressure*100 / (gasConstatn * (hour.Temperature + kelvin));
            //Stromproduktion der Windkraftanlage berechnen.
            float power = 0.5f * airDenstiy * bladeArea * powerCoefficent * availablity * (float)Math.Pow(hour.WindSpeed, 3);
            //Umrechnung von Watt in Kilowatt
            power = power / 1000;
            return power;
        }
    }
}
