using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class StudentExperience
    {
        public int StudentExperienceId { get; set; }
        public DateTime DateStartProgramming { get; set; }
        public int InstitutionId { get; set; }
        public virtual Institution Institution { get; set; }
        public virtual Student Student { get; set; }

    }
}
