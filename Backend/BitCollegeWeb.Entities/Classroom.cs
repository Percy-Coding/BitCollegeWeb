using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Entities
{
    public class Classroom
    {
        public int ClassroomId { get; set; }
        public DateTime DateStart { get; set; }
        public string Name { get; set; }
        public int SectionId { get; set; }
        public int TeacherForumId { get; set; }
        public virtual TeacherForum TeacherForum { get; set; }
        public virtual ICollection<ClassroomExternalTool> ClassroomExternalTools { get; set; }
        public virtual Section Section { get; set; }
    }
}
