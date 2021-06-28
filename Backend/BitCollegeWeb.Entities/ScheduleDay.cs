using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class ScheduleDay
    {
        public int DayId { get; set; }
        public int ScheduleId { get; set; }
        public int StartTime { get; set; }
        public int FinishTime { get; set; }
        public virtual Day Day { get; set; }
        public virtual Schedule Schedule { get; set; }

    }
}
