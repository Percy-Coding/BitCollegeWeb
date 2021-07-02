using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.Announcement
{
    public class AnnouncementModel
    {
        public int AnnouncementId { get; set; }
        public string Title { get; set; }
        public DateTime DateLimit { get; set; }
        public string Description { get; set; }
        public int SectionId { get; set; }
    }
}
