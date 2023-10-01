using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationClassLibrary
{
    public abstract class ElectricityProducer
    {
       /* Random random = new Random();
        float minValue = 0.95f;
        float maxValue = 1.05f;

        protected float randomProductionValueMultiplier
        {
            get { return (float)random.NextDouble() * (maxValue - minValue) + minValue; }
        }*/
        public ElectricityProducer() { }

        public abstract float ProduceElectricity(Hour hour);

    }
}
