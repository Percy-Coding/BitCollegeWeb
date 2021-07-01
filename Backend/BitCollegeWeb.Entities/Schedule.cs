using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public int TypeProgrammingClassId { get; set; }
        public int StudentId { get; set; }
        public virtual ICollection<ScheduleDay> ScheduleDays { get; set; }
        public virtual Student Student { get; set; }
        public virtual TypeProgrammingClass TypeProgrammingClass { get; set; }

    }
}
