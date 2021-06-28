using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class CalificationAssignment
    {
        public int CalificationAssignmentId { get; set; }
        public int Note { get; set; }
        public string Comment { get; set; }
        public bool CommentPublished { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
