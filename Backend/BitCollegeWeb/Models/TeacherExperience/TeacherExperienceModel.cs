using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.TeacherExperience
{
    public class TeacherExperienceModel
    {
        public int TeacherExperienceId { get; set; }
        public DateTime DateStartProgramming { get; set; }
        public string Position { get; set; }
        public int CompanyId { get; set; }
    }
}
