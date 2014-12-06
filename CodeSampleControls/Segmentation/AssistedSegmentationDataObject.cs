using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using HP.PC.Presentation;

namespace WpfCsSample.CodeSampleControls.Segmentation
{
    public class AssistedSegmentationDataObject
    {
        private readonly IPcPicture _image;
        private readonly IPcOutline _outline;
        private readonly Rect _boundary;

        public AssistedSegmentationDataObject(IPcPicture image, IPcOutline outline, Rect boundary)
        {
            _image = image;
            _outline = outline;
            _boundary = boundary;
        }

        public IPcPicture PcPicture
        {
            get { return _image; }
        }

        public IPcOutline PcOutline
        {
            get { return _outline; }
        }
        public BitmapSource Image
        {
            get { return _image.Image; }
        }

        public Geometry Outline
        {
            get { return _outline.Contour; }
        }

        public Rect Boundary
        {
            get { return _boundary; }
        }

        public Vector OutlineScale
        {
            get { return new Vector(Boundary.Width / Image.PixelWidth, Boundary.Height / Image.PixelHeight); }
        }
    }
}
