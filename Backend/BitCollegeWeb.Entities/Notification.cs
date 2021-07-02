using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int? StudentId { get; set; }
        public int? TeacherId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }

    }
}
