using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.StudentExperience
{
    public class StudentExperienceModel
    {
        public int StudentExperienceId { get; set; }
        public DateTime DateStartProgramming { get; set; }
        public int InstitutionId { get; set; }
    }
}
