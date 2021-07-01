using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCollegeWeb.Models.Section
{
    public class UpdateSectionModel
    {
        public int NumberRecordings { get; set; }
        public int NumberStudentsEnroll { get; set; }
        public bool Vacancies { get; set; }
    }
}
