using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.ProgrammingStudy
{
    public class ProgrammingStudyModel
    {
        public int ProgrammingStudyId { get; set; }
        public string Name { get; set; }
        public int TypeStudyId { get; set; }
        public int CalificationSystemId { get; set; }
        public int TypeProgrammingClassId { get; set; }
    }
}
