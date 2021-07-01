using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class TypeProgrammingClass
    {
        public int TypeProgrammingClassId { get; set; }
        public string Name { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual ICollection<ProgrammingStudy> ProgrammingStudies { get; set; }
    }
}
