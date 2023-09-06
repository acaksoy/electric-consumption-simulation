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
            if (hour.WindSpeed < 3.5f || hour.WindSpeed > 25) return 0;

            airDenstiy = hour.AirPressure*100 / (gasConstatn * (hour.Temperature + kelvin)); //100 -> hPa to Pa. air density in kg/m3
            float power = 0.5f * airDenstiy * bladeArea * powerCoefficent * availablity * (float)Math.Pow(hour.WindSpeed, 3);
            return power;
        }
    }
}
