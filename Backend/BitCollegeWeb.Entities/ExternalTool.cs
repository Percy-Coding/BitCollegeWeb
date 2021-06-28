using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class ExternalTool
    {
        public int ExternalToolId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ClassroomExternalTool> ClassroomExternalTools { get; set; }
        public virtual ICollection<URL> URLS { get; set; }

    }
}
