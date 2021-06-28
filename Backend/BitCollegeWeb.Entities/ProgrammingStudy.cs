using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class ProgrammingStudy
    {
        public int ProgrammingStudyId { get; set; }
        public string Name { get; set; }
        public int TypeStudyId { get; set; }
        public int CalificationSystemId { get; set; }
        public int TypeProgrammingClassId { get; set; }
        public virtual CalificationSystem CalificationSystem { get; set; }
        public virtual TypeStudy TypeStudy { get; set; }
        public virtual Section Section { get; set; }
        public virtual TypeProgrammingClass TypeProgrammingClass { get; set; }
        public virtual ICollection<GeneralInformation> GeneralInformations { get; set; }
        public virtual ICollection<Inscription> Inscriptions { get; set; }

    }
}
