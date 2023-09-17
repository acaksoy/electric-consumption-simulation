using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationClassLibrary
{
    public class Event
    {
        
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public TimeOnly StartHour { get; set; }
        public TimeOnly EndHour { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string EffectedClass { get; set; }
        public string EffectedUnitName { get; set; }
        public float EffectValue { get; set; }
        public Event(DateOnly startDate, DateOnly endDate, TimeOnly startHour, TimeOnly endHour, string name, string description, string effectedClass, string effectedUnitTag, float effectValue)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.StartHour = startHour;
            this.EndHour = endHour;
            this.Name = name;
            this.Description = description;
            this.EffectedClass = effectedClass; 
            this.EffectedUnitName = effectedUnitTag;
            this.EffectValue = effectValue;
        }
    }
}
