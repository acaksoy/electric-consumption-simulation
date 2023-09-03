using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationClassLibrary
{
    public class SolarPanel : ElectricityProducer
    {
        private static float refTemp = 25;
        private static float ambientTemp = 20;
        private static float eNoct = 800;

        private float efficiency;
        private float area;
        private float noct;
        private float operatingTemp;
        private float tempCoefficient;

        public SolarPanel(float efficiency, float area, float noct, float tempCoefficient) { 
            this.efficiency = efficiency;
            this.area = area;
            this.noct = noct;
            this.tempCoefficient = tempCoefficient;
        }

        public override float ProduceElectricity(Hour hour)
        {
            operatingTemp = hour.Temperature + (noct - ambientTemp) * hour.SolarIrradiance / eNoct;
            float power = area * efficiency * (1 + tempCoefficient * (operatingTemp - refTemp)) * hour.SolarIrradiance;
            return power;
        }
    }
}
