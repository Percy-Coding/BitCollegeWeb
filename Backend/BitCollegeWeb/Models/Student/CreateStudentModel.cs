using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.Student
{
    public class CreateStudentModel
    {
        public int StudentExperienceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Level { get; set; }
    }
}
