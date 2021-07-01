using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.Inscription
{
    public class InscriptionModel
    {
        public int InscriptionId { get; set; }
        public int StudentId { get; set; }
        public int ProgrammingStudyId { get; set; }
        public DateTime DateInscription { get; set; }
    }
}
