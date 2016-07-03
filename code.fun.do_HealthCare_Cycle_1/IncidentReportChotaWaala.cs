using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.fun.do_HealthCare_Cycle_1
{
    public class IncidentReportChotaWaala
    {
        public string Date { get; set; }
        public string Disease { get; set; }

        public static IncidentReportChotaWaala FromIRE(IncidentReportEntry ire)
        {
            IncidentReportChotaWaala chotawaala = new IncidentReportChotaWaala();
            chotawaala.Date = ire.IncidentDate.ToString();
            chotawaala.Disease = DiseaseClassifier.GlobalDiseaseList.Keys.ElementAt(ire.CategoryIndex) + " -> " + DiseaseClassifier.GlobalDiseaseList[DiseaseClassifier.GlobalDiseaseList.Keys.ElementAt(ire.CategoryIndex)][ire.SubCategoryIndex];
            return chotawaala;
        }
    }
}
