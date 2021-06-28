using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class CalificationSystemTypeCalification
    {
        public int TypeCalificationId { get; set; }
        public int CalificationSystemId { get; set; }
        public virtual TypeCalification TypeCalification { get; set; }
        public virtual CalificationSystem CalificationSystem { get; set; }
    }
}
