using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Entities
{
    public class Day
    {
        public int DayId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ScheduleDay> ScheduleDays { get; set; } 

    }
}
