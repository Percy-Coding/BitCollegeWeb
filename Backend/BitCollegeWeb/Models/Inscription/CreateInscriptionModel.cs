using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.Inscription
{
    public class CreateInscriptionModel
    {
        public int StudentId { get; set; }
        public int ProgrammingStudyId { get; set; }
        public DateTime DateInscription { get; set; }
    }
}
