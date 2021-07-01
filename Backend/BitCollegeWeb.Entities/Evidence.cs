using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class Evidence
    {
        public int EvidenceId { get; set; }
        public string EvidenceLink { get; set; }
        public int TeacherForumId { get; set; }
        public virtual TeacherForum TeacherForum { get; set; }

    }
}
