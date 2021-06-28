using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class Exam
    {
        public int ExamId { get; set; }
        public string Title { get; set; }
        public DateTime DateStart { get; set; }
        public int StartTime { get; set; }
        public int FinishTime { get; set; }
        public string Description { get; set; }
        public int SectionId { get; set; }
        public int CalificationExamId { get; set; }
        public bool PendingComplete { get; set; }
        public bool SentNotSent { get; set; }
        public virtual Section Section { get; set; }
        public virtual CalificationExam CalificationExam { get; set; }

    }
}
