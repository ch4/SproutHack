using System;

namespace WpfCsSample.SourcePreview
{
    public class SourceViewModel
    {
        private readonly String _fileName;
        private readonly byte[] _document;

        public SourceViewModel(String fileName, byte[] document)
        {
            _fileName = fileName;
            _document = document;
        }

        public String FileName
        {
            get { return _fileName; }
        }

        public byte[] Document
        {
            get { return _document; }
        }
    }
}
