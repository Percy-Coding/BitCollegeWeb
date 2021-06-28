using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Domain
{
    public class SectionTypeSection
    {
        public int SectionId { get; set; }
        public int TypeSectionId { get; set; }
        public virtual Section Section { get; set; }
        public virtual TypeSection TypeSection { get; set; }
    }
}
