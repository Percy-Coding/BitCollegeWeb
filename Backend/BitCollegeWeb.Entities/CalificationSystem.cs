using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class CalificationSystem
    {
        public int CalificationSystemId { get; set; }
        public int NumberPercentage { get; set; }
        public virtual ProgrammingStudy ProgrammingStudy { get; set; }
        public virtual ICollection<CalificationSystemTypeCalification> CalificationSystemTypeCalifications { get; set; }

    }
}
