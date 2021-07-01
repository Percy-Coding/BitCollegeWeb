using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public string Title { get; set; }
        public DateTime DateLimit { get; set; }
        public string Description { get; set; }
        public int SectionId { get; set; }
        public string DocumentLink { get; set; }
        public DateTime ShippingDate { get; set; }
        public bool PendingComplete { get; set; }
        public bool SentNotSent { get; set; }
        public int CalificationAssignmentId { get; set; }
        public virtual Section Section { get; set; }
        public virtual CalificationAssignment CalificationAssignment { get; set; }

    }
}
