using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.Student
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        public int StudentExperienceId { get; set; }
        public  List<ScheduleModel> Schedules { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; }
        public virtual ICollection<Inscription> Inscriptions { get; set; }
        public virtual ICollection<StudentSection> StudentSections { get; set; }
    }
}
