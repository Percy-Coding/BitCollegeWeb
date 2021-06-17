using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<TeacherExperience> TeacherExperiences { get; set; }

    }
}
