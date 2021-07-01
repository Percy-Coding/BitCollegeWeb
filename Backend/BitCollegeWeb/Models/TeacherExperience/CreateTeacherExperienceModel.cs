using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.TeacherExperience
{
    public class CreateTeacherExperienceModel
    {
        public DateTime DateStartProgramming { get; set; }
        public string Position { get; set; }
        public int CompanyId { get; set; }
    }
}
