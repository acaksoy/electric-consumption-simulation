using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationClassLibrary
{
    internal abstract class ElectricityProducer
    {

        public ElectricityProducer() { }

        public abstract float ProduceElectricity(Hour hour);

    }
}
