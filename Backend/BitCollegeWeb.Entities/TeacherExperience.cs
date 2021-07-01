using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class TeacherExperience
    {
        public int TeacherExperienceId { get; set; }
        public DateTime DateStartProgramming { get; set; }
        public string Position { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual Teacher Teacher { get; set; }

    }
}
