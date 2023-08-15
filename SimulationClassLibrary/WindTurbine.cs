using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationClassLibrary
{
    internal class WindTurbine : ElectricityProducer
    {
        private static float airDenstiy;

        private float bladeArea;
        private float powerCoefficent;
        private float availablity;
        
        public override float ProduceElectricity(Hour hour)
        {
            float power = 0.5f * airDenstiy * bladeArea * powerCoefficent * availablity * (float)Math.Pow(hour.WindSpeed, 3);
            return power;
        }
    }
}
