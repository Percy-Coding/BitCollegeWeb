using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class Section
    {
        public int SectionId { get; set; }
        public string SectionCode { get; set; }
        public int ProgrammingStudyId { get; set; }
        public int NumberRecordings { get; set; }
        public int NumberStudentsEnroll { get; set; }
        public bool Vacancies { get; set; }
        public virtual ProgrammingStudy ProgrammingStudy { get; set; }
        public virtual ICollection<SectionTypeSection> SectionTypeSections { get; set; }
        public virtual ICollection<Classroom> Classrooms { get; set; }
        public virtual ICollection<TeacherSection> TeacherSections { get; set; }
        public virtual ICollection<StudentSection> StudentSections { get; set; }
        public virtual ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }

    }
}
