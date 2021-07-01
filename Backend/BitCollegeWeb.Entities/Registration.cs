using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class Registration
    {
        public int RegistrationId { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }

    }
}
