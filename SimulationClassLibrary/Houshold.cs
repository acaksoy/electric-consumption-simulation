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
        }
        public string Name;
        public float Value;
    }
    public class Houshold : ElectricityConsumer
    {
        private string name;
        private int numberOfHousholds;
        private List<HourlyConsumption> schedule;

        public Houshold(string name, int numberOfHousholds, List<HourlyConsumption> schedules)
        {
            this.name = name;
            this.numberOfHousholds = numberOfHousholds;
            this.schedule = schedules;
        }
        public override float ConsumeElectricity(Hour hour) // kWh because of data
        {
            
            float totalConsumption=0;
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
    }
}
