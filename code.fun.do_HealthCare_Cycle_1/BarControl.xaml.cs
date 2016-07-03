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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace code.fun.do_HealthCare_Cycle_1
{
    public sealed partial class BarControl : UserControl
    {
        public int Value
        {
            set { bar.Height = (grid.ActualHeight - 44) * value / 100; }
            get { return (int)(bar.Height * 100 / (grid.ActualHeight - 44)); }
        }

        public string Label
        {
            set { textBlock.Text = value; }
            get { return textBlock.Text; }
        }

        public string Label2
        {
            set { textBlock1.Text = value; }
            get { return textBlock1.Text; }
        }

        public BarControl()
        {
            this.InitializeComponent();
        }
    }
}
