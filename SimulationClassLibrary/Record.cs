using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationClassLibrary
{
    public class Record
    {
        public Dictionary<DateTime, double> results = new Dictionary<DateTime, double>();
        public string Name;

        public Record(string name)
        {
            Name = name;
        }
        public void RecordResult(DateTime date, double result)
        {
            if(results.ContainsKey(date))
            {
                return;
            }
            results.Add(date, result);
        }

    }
}
