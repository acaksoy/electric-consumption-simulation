using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationClassLibrary
{
    internal abstract class ElectricityConsumer
    {
        public ElectricityConsumer() { }

        public abstract float ConsumeElectricity(Hour hour);
    }
}
