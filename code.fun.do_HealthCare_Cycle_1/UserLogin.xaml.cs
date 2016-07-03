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
    public sealed partial class UserLogin : Page
    {
        MobileServiceCollection<IncidentReportEntry, IncidentReportEntry> results;
        IEnumerable<IncidentReportChotaWaala> Results { get { return results.Select<IncidentReportEntry, IncidentReportChotaWaala>((x) => IncidentReportChotaWaala.FromIRE(x)); } }

        public UserLogin()
        {
            this.InitializeComponent();
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(UserHome));
        }

        private async void loginSubmit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string pintxt = pinCode.Text;
            int pin = int.Parse(pintxt);
            IMobileServiceTable<IncidentReportEntry> ires = App.MobileService.GetTable<IncidentReportEntry>();
            results = await ires.Where((x) => x.PIN == pin).ToCollectionAsync();
            fetchedData.ItemsSource = Results;
        }
    }
}
