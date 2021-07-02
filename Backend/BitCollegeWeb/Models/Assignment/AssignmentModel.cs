using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.Assignment
{
    public class AssignmentModel
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

    }
}
