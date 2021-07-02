using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class Chat
    {
        public int ChatId { get; set; }
        public string Content { get; set; }
        public int? ClassroomId { get; set; }
        public int? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Classroom Classroom { get; set; }
    }
}
