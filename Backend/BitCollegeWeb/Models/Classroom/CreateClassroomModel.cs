using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.Classroom
{
    public class CreateClassroomModel
    {
        public DateTime DateStart { get; set; }
        public string Name { get; set; }
        public int SectionId { get; set; }
        public int TeacherForumId { get; set; }
    }
}
