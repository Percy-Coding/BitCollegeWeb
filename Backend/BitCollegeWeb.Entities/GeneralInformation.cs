using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class GeneralInformation
    {
        public int TopicId { get; set; }
        public int ProgrammingStudyId { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual ProgrammingStudy ProgrammingStudy { get; set; }
    }
}
