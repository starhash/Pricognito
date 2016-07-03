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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace code.fun.do_HealthCare_Cycle_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserHome : Page
    {
        public UserHome()
        {
            this.InitializeComponent();
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void fetchSubmit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(UserLogin));
        }

        private void fetchSubmit_Copy_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MostContagious));
        }

        private void fetchReportandChart_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(ViewReportInRegion));
        }
    }
}
