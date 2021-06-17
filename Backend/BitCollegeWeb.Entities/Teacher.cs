using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Entities
{
    public class Teacher : User
    {
        public int TeacherId { get; set; }
        public int TeacherExperienceId { get; set; }
        public virtual TeacherExperience TeacherExperience { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
    }
}
