using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationClassLibrary
{
    public class HydroPowerPlant : ElectricityProducer
    {
        private static float GravitationalForce = 9.8f;
        private static float WaterDensity = 1000;

        private float height;
        private float efficiency;

        public HydroPowerPlant(float height, float efficiency) {
            this.height = height;
            this.efficiency = efficiency;
        }

        public override float ProduceElectricity(Hour hour)
        {
            //Stromproduktion des Wasserkraftwerks berechnen.
            float power = WaterDensity * GravitationalForce * hour.Discharge * height * efficiency;
            //Umrechnung von Watt in Kilowatt
            power = power / 1000; //kW
            return power;

        }
    }
}
