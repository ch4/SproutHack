using System.Windows.Controls;

namespace WpfCsSample.CodeSampleControls.Screens
{
    /// <summary>
    /// Interaction logic for MatMonitorInfoControl.xaml
    /// </summary>
    public partial class ScreenSample : UserControl
    {
        public ScreenSample()
        {
            DataContext = new ScreenSampleViewModel();
            InitializeComponent();
        }

        public new ScreenSampleViewModel DataContext
        {
            get { return (ScreenSampleViewModel)base.DataContext; }
            set { base.DataContext = value; }
        }
    }
}
