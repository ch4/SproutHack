using System.Windows.Controls;

namespace WpfCsSample.CodeSampleControls.CaptureAudio
{
    /// <summary>
    /// Interaction logic for CaptureMatControl.xaml
    /// </summary>
    public partial class AudibleCaptureControl : UserControl
    {
        public AudibleCaptureControl()
        {
            DataContext = new AudibleCaptureMatViewModel();
            InitializeComponent();
        }

        public new AudibleCaptureMatViewModel DataContext
        {
            get { return (AudibleCaptureMatViewModel)base.DataContext; }
            set { base.DataContext = value; }
        }
    }
}
