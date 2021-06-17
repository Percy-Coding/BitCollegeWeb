using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Entities
{
    public class Inscription
    {
        public int InscriptionId { get; set; }
        public int StudentId { get; set; }
        public int ProgrammingStudyId { get; set; }
        public DateTime DateInscription { get; set; }
        public virtual Student Student { get; set; }
        public virtual ProgrammingStudy ProgrammingStudy { get; set; }
    }
}
