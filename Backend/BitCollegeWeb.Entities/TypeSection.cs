using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Entities
{
    public class TypeSection
    {
        public int TypeSectionId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SectionTypeSection> SectionTypeSections { get; set; }
    }
}
