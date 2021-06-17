using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Entities
{
    public class Announcement
    {
        public int AnnouncementId { get; set; }
        public string Title { get; set; }
        public DateTime DateLimit { get; set; }
        public string Description { get; set; }
        public int SectionId { get; set; }
        public virtual Section Section { get; set; }
    }
}
