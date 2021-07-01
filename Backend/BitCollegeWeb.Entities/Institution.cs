using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class Institution
    {
        public int InstitutionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<StudentExperience> StudentExperiences { get; set; }

    }
}
