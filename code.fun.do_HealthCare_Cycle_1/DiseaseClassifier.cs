using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.fun.do_HealthCare_Cycle_1
{
    public class DiseaseClassifier
    {
        public static Dictionary<string, string[]> GlobalDiseaseList { get; set; }

        static DiseaseClassifier()
        {
            GlobalDiseaseList = new Dictionary<string, string[]>()
            {
                ["Airborne"] = new string[] { "Anthrax", "Chickenpox", "Influenza", "Measles", "Smallpox", "Cryptococcosis", "Tuberculosis" },
                ["Waterborne"] = new string[] { "Amoebiasis", "Cholera", "Dysentery", "Typhoid", "Hepatitis A", "Polio", "Otitis Externa" }
            };
        }

        public static string[] GetDisease(int x, int y)
        {
            string pop = GlobalDiseaseList.Keys.ElementAt(x);
            return new string[] { pop, GlobalDiseaseList[pop].ElementAt(y) };
        }
    }
}
