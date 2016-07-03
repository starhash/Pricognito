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
using HtmlAgilityPack;
using Microsoft.WindowsAzure.MobileServices;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace code.fun.do_HealthCare_Cycle_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DoctorRegistration : Page
    {
        public static DoctorInfo medoc = null;

        public DoctorRegistration()
        {
            this.InitializeComponent();
        }
                
        private async void browserValidator_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            string addr = sender.Source.OriginalString;
            HtmlAgilityPack.HtmlDocument html = new HtmlDocument();
            string htmlCode = "";
            try
            {
                htmlCode = await sender.InvokeScriptAsync("eval", new string[] { "document.documentElement.outerHTML;" });
            }
            catch(Exception) { }
            html.LoadHtml(htmlCode);
            if (addr.Contains("http://www.mciindia.org/InformationDesk/IndianMedicalRegister.aspx"))
            {
                #region Chutzpah
                try
                {
                    HtmlNode htmlnode = html.DocumentNode.FirstChild;
                    htmlnode = htmlnode.ChildNodes[1];
                    htmlnode = htmlnode.ChildNodes[20];
                    htmlnode = htmlnode.FirstChild;
                    htmlnode = htmlnode.FirstChild;
                    htmlnode = htmlnode.ChildNodes[9];
                    htmlnode = htmlnode.ChildNodes[1];
                    htmlnode = htmlnode.ChildNodes[1];
                    htmlnode = htmlnode.ChildNodes[1];
                    htmlnode = htmlnode.ChildNodes[1];
                    htmlnode = htmlnode.ChildNodes[3];
                    htmlnode = htmlnode.ChildNodes[1];
                    htmlnode = htmlnode.Element("tr");
                    htmlnode = htmlnode.ChildNodes[3];
                    htmlnode = htmlnode.ChildNodes[2];
                    htmlnode = htmlnode.ChildNodes[1];
                    htmlnode = htmlnode.ChildNodes[3];
                    htmlnode = htmlnode.ChildNodes[0];
                    htmlnode = htmlnode.ChildNodes[1];
                    htmlnode = htmlnode.ChildNodes[0];
                    htmlnode = htmlnode.ChildNodes[1];
                    htmlnode = htmlnode.ChildNodes[0];
                    htmlnode = htmlnode.ChildNodes[0];
                    HtmlNodeCollection coll = htmlnode.ChildNodes;
                    List<HtmlNode> nodes = new List<HtmlNode>();
                    foreach(HtmlNode n in coll)
                    {
                        if (n.Name.Equals("tr"))
                            nodes.Add(n);
                    }
                    if (nodes.Count() > 2)
                    {
                        textBlock.Text = "Please select or view the correct detail";
                    }
                    else if (nodes.Count() == 2)
                    {
                        htmlnode = htmlnode.ChildNodes[1];
                        htmlnode = htmlnode.ChildNodes[6];
                        htmlnode = htmlnode.ChildNodes[1];
                        HtmlAttribute attr = htmlnode.Attributes[1];
                        string link = attr.Value;
                        link = link.Replace("javascript:CallURL('http://www.mciindia.org/','", "");
                        link = "http://www.mciindia.org/ViewDetails.aspx?ID=" + link.Replace("');", "");
                        browserValidator.Navigate(new Uri(link, UriKind.Absolute));
                    }
                } catch (Exception) { }
                #endregion
            }
            else if (addr.Contains("http://www.mciindia.org/ViewDetails.aspx"))
            {
                DoctorInfo docinfo = new DoctorInfo();
                docinfo.LoadFromHtmlDocument(html);
                textBlock.Text = "Validated";
                browserValidator.Visibility = Visibility.Collapsed;
                doctorIMRNumber.Visibility = Visibility.Visible;
                doctorIMRNumber.Text = docinfo.RegNo;
                doctorRegistrationName.Visibility = Visibility.Visible;
                doctorRegistrationName.Text = docinfo.Name;
                doctorAddress.Visibility = Visibility.Visible;
                doctorAddress.Text = docinfo.Address;
                doctorState.Visibility = Visibility.Visible;
                doctorCity.Visibility = Visibility.Visible;
                doctorPINCode.Visibility = Visibility.Visible;
                doctorValidationProgress.IsIndeterminate = false;
                medoc = docinfo;
            }
        }

        private void browserValidator_NewWindowRequested(WebView sender, WebViewNewWindowRequestedEventArgs args)
        {
            sender.Navigate(args.Uri);
            args.Handled = true;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "Please validate your IMR number from website below";
            doctorValidationProgress.IsIndeterminate = true;
        }

        private async void doctorRegister_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //REgister
            if (medoc != null)
            {
                IMobileServiceTable<DoctorInfo> table = App.MobileService.GetTable<DoctorInfo>();
                await table.InsertAsync(medoc);
                Frame.Navigate(typeof(DoctorHome));
            }
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
