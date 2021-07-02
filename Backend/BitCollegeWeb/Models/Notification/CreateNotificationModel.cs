using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.Notification
{
    public class CreateNotificationModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
    }
}
