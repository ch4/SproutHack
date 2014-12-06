using System.Windows.Controls;

namespace WpfCsSample.CodeSampleControls.InstantMoment
{
    /// <summary>
    /// Interaction logic for CaptureMatControl.xaml
    /// </summary>
    public partial class InstantCaptureControl : UserControl
    {
        public InstantCaptureControl()
        {
            DataContext = new InstantCaptureMatViewModel();
            InitializeComponent();
        }

        public new InstantCaptureMatViewModel DataContext
        {
            get { return (InstantCaptureMatViewModel)base.DataContext; }
            set { base.DataContext = value; }
        }
    }
}
