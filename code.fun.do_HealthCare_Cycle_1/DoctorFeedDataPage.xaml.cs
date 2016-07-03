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
    public sealed partial class DoctorFeedDataPage : Page
    {
        public DoctorFeedDataPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(string key in DiseaseClassifier.GlobalDiseaseList.Keys)
            {
                diseaseCategory.Items.Add(key);
            }
        }

        private void diseaseCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            diseaseSubCategory.Items.Clear();
            foreach(string kei in DiseaseClassifier.GlobalDiseaseList[DiseaseClassifier.GlobalDiseaseList.Keys.ElementAt(diseaseCategory.SelectedIndex)])
            {
                diseaseSubCategory.Items.Add(kei);
            }
        }

        private async void patientReportIncidentButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (patientAADHARorPAN.Text.Length == 0 || patientPinCode.Text.Length == 0)
            {
                textBlock.Text = "Please enter all fields.";
                return;
            }
            IncidentReportEntry ire = new IncidentReportEntry();
            ire.UserPAN_AADHAR = patientAADHARorPAN.Text;
            ire.PIN = int.Parse(patientPinCode.Text.Trim());
            ire.CategoryIndex = diseaseCategory.SelectedIndex;
            ire.SubCategoryIndex = diseaseSubCategory.SelectedIndex;
            ire.IncidentDate = DateTime.Now;
            IMobileServiceTable<IncidentReportEntry> table = App.MobileService.GetTable<IncidentReportEntry>();
            await table.InsertAsync(ire);
            this.Frame.Navigate(typeof(DoctorFeedDataPage));
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(DoctorHome));
        }
    }
}
