using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.CalificationAssignment
{
    public class CreateCalificationAssignmentModel
    {
        public int Note { get; set; }
        public string Comment { get; set; }
        public bool CommentPublished { get; set; }
    }
}
