using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using WpfCsSample.SourcePreview;

namespace WpfCsSample
{
    public class SampleTabViewModel
    {
        private readonly string _title;
        private readonly string _description;
        private readonly UserControl _sampleContent;
        private readonly IEnumerable<SourceViewModel> _sourceCodes;

        public SampleTabViewModel(string title, string description, UserControl sampleContent, IEnumerable<SourceViewModel> sourceCodes)
        {
            _title = title;
            _description = description;
            _sampleContent = sampleContent;
            _sourceCodes = sourceCodes;
        }

        public string Title
        {
            get { return _title; }
        }

        public string Description
        {
            get { return _description; }
        }

        public UserControl SampleContent
        {
            get { return _sampleContent; }
        }

        public IEnumerable<SourceViewModel> SourceCodes
        {
            get { return _sourceCodes; }
        }

        public bool HasSourceCodes
        {
            get { return _sourceCodes.Any(); }
        }
    }
}
