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
using Windows.Services.Maps;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace code.fun.do_HealthCare_Cycle_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DoctorHome : Page
    {
        public DoctorHome()
        {
            this.InitializeComponent();
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Report_Incident_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(DoctorFeedDataPage));
        }

        private void textBlock_Loaded(object sender, RoutedEventArgs e)
        {
            var app = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            var title = app.TitleBar;
            title.BackgroundColor = Windows.UI.Color.FromArgb(255, 50, 32, 99);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            doctorHomePivotItem.Header = DoctorRegistration.medoc.RegNo + " - " + DoctorRegistration.medoc.Name;
        }
    }
}
