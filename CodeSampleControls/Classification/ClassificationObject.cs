using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfCsSample.CodeSampleControls.Classification
{
    public class ClassificationObject
    {
        private string _tag;
        private BitmapSource _image;
        private Rect _boundary;

        public ClassificationObject(string tag, BitmapSource image, Rect boundary)
        {
            _tag = tag;
            _image = image;
            _boundary = boundary;
        }

        public string Tag
        {
            get { return _tag; }
        }

        public BitmapSource Image
        {
            get { return _image; }
        }

        public Rect Boundary
        {
            get { return _boundary; }
        }

    }
}
