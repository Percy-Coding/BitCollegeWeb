using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.Evidence
{
    public class EvidenceModel
    {
        public int EvidenceId { get; set; }
        public string EvidenceLink { get; set; }
        public int TeacherForumId { get; set; }
    }
}
