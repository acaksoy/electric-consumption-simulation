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
        public DateTime Date; // Date of electricity consumption (dd.MM.yyyy HH:mm)
        public List<ConsumeValue> ConsumeValues; //List of units and consumed electricity
    }
    public struct ConsumeValue
    {
        public ConsumeValue(string name, float value)
        {
            Name = name; //Name of the unit that uses electricity
            Value = value; // used electricity in kW
        }
        public string Name;
        public float Value;
    }
    public  class ElectricityConsumer
    {
        public string name;
        private int numberOfEntities;
        private List<HourlyConsumption> schedule;
        Random random = new Random();
        float minValue = 0.95f;
        float maxValue = 1.05f;
        
        public ElectricityConsumer(string name, int numberOfHousholds, List<HourlyConsumption> schedules)
        {
            this.name = name;
            this.numberOfEntities = numberOfHousholds;
            this.schedule = schedules;
        }
        public float ConsumeElectricity(Hour hour) // kWh because of data
        {
            float totalConsumption = 0;
            float hourlyConsumption = 0;
            foreach (HourlyConsumption hourlyCon in schedule)
            {
                if (DateTime.Compare(hour.Date, hourlyCon.Date) == 0) //all consume values are under single date
                {
                    foreach (ConsumeValue consumption in hourlyCon.ConsumeValues)
                    {

                        hourlyConsumption += consumption.Value;
                    }
                }
            }
            for(int i = 0; i < numberOfEntities; i++)
            {
                float randomConsumptionValueMultiplier = (float)random.NextDouble() * (maxValue - minValue) + minValue;
                totalConsumption += hourlyConsumption * randomConsumptionValueMultiplier;
            }
            return totalConsumption;
        }

    }
}
