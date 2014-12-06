using System.Windows.Controls;

namespace WpfCsSample.CodeSampleControls.Classification
{
    /// <summary>
    /// Interaction logic for ClassificationUserControl.xaml
    /// </summary>
    public partial class ClassificationUserControl : UserControl
    {
        public ClassificationUserControl()
        {
            DataContext = new ClassificationViewModel();
            InitializeComponent();
        }

        public new ClassificationViewModel DataContext
        {
            get { return base.DataContext as ClassificationViewModel; }
            set { base.DataContext = value; }
        }
    }
}
