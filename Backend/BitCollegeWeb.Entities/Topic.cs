using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Entities
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<URL> URLS { get; set; }
        public virtual ICollection<GeneralInformation> GeneralInformations { get; set; }
    }
}
