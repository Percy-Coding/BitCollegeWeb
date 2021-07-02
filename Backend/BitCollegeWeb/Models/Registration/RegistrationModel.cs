using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.Registration
{
    public class RegistrationModel
    {
        public int RegistrationId { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public int? StudentId { get; set; }
        public int? TeacherId { get; set; }
    }
}
