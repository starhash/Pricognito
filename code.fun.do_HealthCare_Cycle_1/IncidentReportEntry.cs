using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.fun.do_HealthCare_Cycle_1
{
    public class IncidentReportEntry
    {
        public string Id { get; set; }
        public string UserPAN_AADHAR { get; set; }
        public int PIN { get; set; }
        public int CategoryIndex { get; set; }
        public int SubCategoryIndex { get; set; }
        public DateTime IncidentDate { get; set; }
    }
}
