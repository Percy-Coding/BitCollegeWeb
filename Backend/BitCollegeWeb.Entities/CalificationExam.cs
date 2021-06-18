using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Entities
{
    public class CalificationExam
    {
        public int CalificationExamId { get; set; }
        public int Note { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
    }
}
