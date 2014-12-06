using System.Windows.Media;
using System.Windows.Media.Imaging;
using HP.PC.Presentation;

namespace WpfCsSample.CodeSampleControls.BitmapAssistedSegmentation
{
    public class SegmentedDataObject
    {
        private readonly BitmapSource _image;
        private readonly Geometry _outline;
        private readonly PcPhysicalRectangle _boundary;

        public SegmentedDataObject(BitmapSource image, Geometry outline, PcPhysicalRectangle boundary)
        {
            _image = image;
            _outline = outline;
            _boundary = boundary;
        }

        public BitmapSource Image
        {
            get { return _image; }
        }

        public Geometry Outline
        {
            get { return _outline; }
        }

        public PcPhysicalRectangle Boundary
        {
            get { return _boundary; }
        }
    }
}
