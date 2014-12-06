using System.Collections.Generic;
using System.Windows;

namespace WpfCsSample.SourcePreview
{
    /// <summary>
    /// Interaction logic for SourceView.xaml
    /// </summary>
    public partial class SourceView : Window
    {
        public SourceView(IEnumerable<SourceViewModel> sourceCodes)
        {
            InitializeComponent();
            DataContext = sourceCodes;
        }
    }
}
