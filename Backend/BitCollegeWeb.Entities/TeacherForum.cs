using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Entities
{
    public class TeacherForum
    {
        public int TeacherForumId { get; set; }
        public string ProblemDescription { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Evidence> Evidences { get; set; }
        public virtual Classroom Classroom { get; set; }
    }
}
