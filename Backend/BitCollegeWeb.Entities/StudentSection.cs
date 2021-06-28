using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class StudentSection
    {
        public int StudentId { get; set; }
        public int SectionId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Section Section { get; set; }
    }
}
