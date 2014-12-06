using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfCsSample.CodeSampleControls.InstantMoment
{
    public class InstantCapturedDataObject
    {
        private readonly BitmapSource _image;
        private readonly Geometry _outline;
        private readonly Rect _boundary;
        private readonly Double _skewAngle;

        public InstantCapturedDataObject(BitmapSource image, Geometry outline, Rect boundary, double skewAngle)
        {
            _image = image;
            _outline = outline;
            _boundary = boundary;
            _skewAngle = skewAngle;
        }

        public BitmapSource Image
        {
            get { return _image; }
        }

        public Geometry Outline
        {
            get { return _outline; }
        }

        public Rect Boundary
        {
            get { return _boundary; }
        }

        public double SkewAngle
        {
            get { return _skewAngle; }
        }

        public string Tooltip
        {
            get { return "Skew angle is " + SkewAngle.ToString("F"); }
        }

        public Vector OutlineScale
        {
            get
            {
                return new Vector(Boundary.Width / Image.PixelWidth, Boundary.Height / Image.PixelHeight);
            }
        }
    }
}
