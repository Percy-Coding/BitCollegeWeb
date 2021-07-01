using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.URL
{
    public class URLModel
    {
        public int UrlId { get; set; }
        public string UrlLink { get; set; }
        public int ExternalToolId { get; set; }
        public int TopicId { get; set; }
    }
}
