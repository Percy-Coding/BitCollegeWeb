using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Entities
{
    public class Student : User
    {
        public int StudentId { get; set; }
        public int StudentExperienceId { get; set; }
        public virtual StudentExperience StudentExperience { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; }
        public virtual ICollection<Inscription> Inscriptions { get; set; }
    }
}
