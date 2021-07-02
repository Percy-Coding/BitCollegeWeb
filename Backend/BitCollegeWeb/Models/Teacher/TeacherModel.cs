using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.Teacher
{
    public class TeacherModel
    {
        public int TeacherId { get; set; }
        public int TeacherExperienceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Level { get; set; }
    }
}
