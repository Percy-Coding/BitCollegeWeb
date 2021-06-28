using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class URL
    {
        public int UrlId { get; set; }
        public string UrlLink { get; set; }
        public int ExternalToolId { get; set; }
        public int TopicId { get; set; }
        public virtual ExternalTool ExternalTool { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
