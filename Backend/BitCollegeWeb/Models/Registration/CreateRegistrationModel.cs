using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.Registration
{
    public class CreateRegistrationModel
    {
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
    }
}
