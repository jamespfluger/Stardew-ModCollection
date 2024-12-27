using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyConfiguration
{
    public class ModConfig
    {
        public bool? Sunday { get; set; }
        public bool? Monday { get; set; }
        public bool? Tuesday { get; set; }
        public bool? Wednesday { get; set; }
        public bool? Thursday { get; set; }
        public bool? Friday { get; set; }
        public bool? Saturday { get; set; }

        public List<DayOfWeek> GetDaysToWater()
        {
            List<DayOfWeek> daysToWater = new();

            if (Sunday == true)
                daysToWater.Add(DayOfWeek.Sunday);
            if (Monday == true)
                daysToWater.Add(DayOfWeek.Monday);
            if (Tuesday == true)
                daysToWater.Add(DayOfWeek.Tuesday);
            if (Wednesday == true)
                daysToWater.Add(DayOfWeek.Wednesday);
            if (Thursday == true)
                daysToWater.Add(DayOfWeek.Thursday);
            if (Friday == true)
                daysToWater.Add(DayOfWeek.Friday);
            if (Saturday == true)
                daysToWater.Add(DayOfWeek.Saturday);

            return daysToWater;
        }
    }
}
