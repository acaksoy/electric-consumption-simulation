using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationClassLibrary
{
    public struct HourlyConsumption
    {
        public HourlyConsumption(DateTime date, List<ConsumeValue> consumeValues)
        {
            Date = date;
            ConsumeValues = consumeValues;
        }
        public DateTime Date;
        public List<ConsumeValue> ConsumeValues; //dishwasher value
    }
    public struct ConsumeValue
    {
        public ConsumeValue(string name, float value)
        {
            Name = name;
            Value = value;
            // get set Value*katsayi dirty mirty bi bakalim ona
        }
        public string Name;
        public float Value;
    }
    public  class ElectricityConsumer
    {
        public string name;
        private int numberOfHousholds;
        private List<HourlyConsumption> schedule;

        public ElectricityConsumer(string name, int numberOfHousholds, List<HourlyConsumption> schedules)
        {
            this.name = name;
            this.numberOfHousholds = numberOfHousholds;
            this.schedule = schedules;
        }
        public float ConsumeElectricity(Hour hour) // kWh because of data
        {
            float totalConsumption = 0;
            foreach (HourlyConsumption hourlyCon in schedule)
            {
                if (DateTime.Compare(hour.Date, hourlyCon.Date) == 0) //all consume values are under single date
                {
                    foreach (ConsumeValue consumption in hourlyCon.ConsumeValues)
                    {
                        totalConsumption += consumption.Value;
                    }
                }
            }
            return totalConsumption * numberOfHousholds;
        }
        public float ConsumeElectricity(Hour hour, Event ev) 
        {
            float totalConsumption = 0;
            float evValMultiplier = 1;
            foreach (HourlyConsumption hourlyCon in schedule)
            {
                if (DateTime.Compare(hour.Date, hourlyCon.Date) == 0) //all consume values are under single date
                {
                    foreach (ConsumeValue consumption in hourlyCon.ConsumeValues)
                    {
                        if (consumption.Name == ev.EffectedUnitTag) evValMultiplier = ev.EffectValue;

                        totalConsumption += consumption.Value * evValMultiplier;
                    }
                }
            }
            return totalConsumption * numberOfHousholds;
        }
    }
}
