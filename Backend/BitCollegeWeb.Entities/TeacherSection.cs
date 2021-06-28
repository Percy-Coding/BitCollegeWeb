using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class TeacherSection
    {
        public int TeacherId { get; set; }
        public int SectionId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Section Section { get; set; }
    }
}
