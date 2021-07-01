using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class TypeCalification
    {
        public int TypeCalificationId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CalificationSystemTypeCalification> CalificationSystemTypeCalifications { get; set; }
    }
}
