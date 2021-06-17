using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Entities
{
    public class ClassroomExternalTool
    {
        public int ExternalToolId { get; set; }
        public int ClassroomId { get; set; }
        public virtual ExternalTool ExternalTool { get; set; }
        public virtual Classroom Classroom { get; set; }

    }
}
