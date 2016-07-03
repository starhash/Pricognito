using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace code.fun.do_HealthCare_Cycle_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MostContagious : Page
    {
        MobileServiceCollection<IncidentReportEntry, IncidentReportEntry> results;
        IEnumerable<IncidentReportChotaWaala> Results { get { return results.Select<IncidentReportEntry, IncidentReportChotaWaala>((x) => IncidentReportChotaWaala.FromIRE(x)); } }

        public MostContagious()
        {
            this.InitializeComponent();
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(UserHome));
        }

        private async void button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string pintxt = pinCode.Text;
            int pin = int.Parse(pintxt);
            IMobileServiceTable<IncidentReportEntry> ires = App.MobileService.GetTable<IncidentReportEntry>();
            results = await ires.Where((x) => x.PIN == pin).ToCollectionAsync();
            Dictionary<Tuple<int, int>, int> diseaseCount = new Dictionary<Tuple<int, int>, int>();
            foreach(IncidentReportEntry i in results)
            {
                Tuple<int, int> t = new Tuple<int, int>(i.CategoryIndex, i.SubCategoryIndex);
                if (diseaseCount.ContainsKey(t))
                    diseaseCount[t] += 1;
                else
                    diseaseCount.Add(t, 1);
            }
            int max = 0, min = int.MaxValue;
            Tuple<int, int> maxt = new Tuple<int, int>(-1, -1);
            Tuple<int, int> mint = new Tuple<int, int>(-1, -1);
            foreach (Tuple<int, int> t in diseaseCount.Keys)
            {
                if (diseaseCount[t] > max)
                {
                    max = diseaseCount[t];
                    maxt = t;
                }
                if (diseaseCount[t] < min)
                {
                    min = diseaseCount[t];
                    mint = t;
                }
            }
            if (maxt != new Tuple<int, int>(-1, -1))
            {
                string[] disees = DiseaseClassifier.GetDisease(maxt.Item1, maxt.Item2);
                mostContagious.Text = " Most frequent and contagious disease\nin this area is " + disees[1] + ",\nunder the " + disees[0] + " category";
            }
            if (mint != new Tuple<int, int>(-1, -1))
            {
                string[] disees = DiseaseClassifier.GetDisease(mint.Item1, mint.Item2);
                leastContagious.Text = " Least frequent and contagious disease\nin this area is " + disees[1] + ",\nunder the " + disees[0] + " category";
            }
        }
    }
}
