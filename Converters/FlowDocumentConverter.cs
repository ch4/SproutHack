using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using WpfCsSample.SourcePreview;

namespace WpfCsSample.Converters
{
    class FlowDocumentConverter : IValueConverter
    {
        private readonly SourceCodeFormatter _sourceCodeFormatter = new SourceCodeFormatter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var sourceViewModel = value as SourceViewModel;
            if (sourceViewModel != null)
            {
                FlowDocument flowDocument = _sourceCodeFormatter.Format(sourceViewModel.FileName, sourceViewModel.Document);
                return new FlowDocumentScrollViewer
                {
                    Document = flowDocument,
                };
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
