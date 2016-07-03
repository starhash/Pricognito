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
using Windows.UI.Notifications;
using Microsoft.WindowsAzure.MobileServices;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace code.fun.do_HealthCare_Cycle_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewReportInRegion : Page
    {

        public ViewReportInRegion()
        {
            this.InitializeComponent();
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UserHome));
        }

        private void pin_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                DoIt();
            }
        }

        public async void DoIt()
        {
            string pintxt = pin.Text;
            int p = int.Parse(pintxt);
            IMobileServiceTable<IncidentReportEntry> ires = App.MobileService.GetTable<IncidentReportEntry>();
            var results = await ires.Where((x) => x.PIN == p).ToCollectionAsync();
            DateTime today = DateTime.Today;
            IEnumerable<IncidentReportEntry> results2 = results.Where((x) => x.IncidentDate.Year == today.Year);
            BarControl[] control = new BarControl[] { jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec };
            Tuple<int, string>[] values = new Tuple<int, string>[12];
            for (int i = 0; i < 12; i++)
            {
                values[i] = new Tuple<int, string>(-1, null);
            }
            for (int i = 0; i < 12; i++)
            {
                IEnumerable<IncidentReportEntry> temp = results2.Where((x) => x.IncidentDate.Month == (i + 1));
                Dictionary<Tuple<int, int>, int> diseaseCount = new Dictionary<Tuple<int, int>, int>();
                foreach (IncidentReportEntry ire in temp)
                {
                    Tuple<int, int> t = new Tuple<int, int>(ire.CategoryIndex, ire.SubCategoryIndex);
                    if (diseaseCount.ContainsKey(t))
                        diseaseCount[t] += 1;
                    else
                        diseaseCount.Add(t, 1);
                }
                int max = 0;
                Tuple<int, int> maxt = new Tuple<int, int>(-1, -1);
                foreach (Tuple<int, int> t in diseaseCount.Keys)
                {
                    if (diseaseCount[t] > max)
                    {
                        max = diseaseCount[t];
                        maxt = t;
                    }
                }
                if (maxt.Item1 == -1 || maxt.Item2 == -1)
                    continue;
                string[] ss = DiseaseClassifier.GetDisease(maxt.Item1, maxt.Item2);
                values[i] = new Tuple<int, string>(max, ss[1]);
            }
            for (int i = 0; i < 12; i++)
            {
                if (values[i].Item1 != -1 && values[i].Item2 != null)
                {
                    control[i].Label2 = values[i].Item2;
                    control[i].Value = values[i].Item1;
                }
            }
        }
    }
}
