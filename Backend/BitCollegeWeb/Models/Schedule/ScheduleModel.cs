using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.Schedule
{
    public class ScheduleModel
    {
        public int ScheduleId { get; set; }
        public int TypeProgrammingClassId { get; set; }
        public int StudentId { get; set; }
    }
}
