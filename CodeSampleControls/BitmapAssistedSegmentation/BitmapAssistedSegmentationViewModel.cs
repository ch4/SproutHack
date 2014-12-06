using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Media.Imaging;
using HP.PC.Presentation;

namespace WpfCsSample.CodeSampleControls.BitmapAssistedSegmentation
{
    public class BitmapAssistedSegmentationViewModel : INotifyPropertyChanged
    {
        // Number of millimeters in one inch
        private const double INCH = 25.4;

        private readonly StrokeCollection _strokeCollection = new StrokeCollection();
        private PcPixelDensity _targetScreenPixelDensity;
        private BitmapSource _originalImage;
        private SegmentedDataObject _segmentedItem;
        private double _zoomFactor = 1;
        private bool _canProcess = true;
        private bool _isInclusionChecked = true;

        public StrokeCollection StrokeCollection
        {
            get { return _strokeCollection; }
        }

        public PcPixelDensity TargetScreenPixelDensity
        {
            get { return _targetScreenPixelDensity; }
            set
            {
                if (_targetScreenPixelDensity != value)
                {
                    _targetScreenPixelDensity = value;
                    OnPropertyChanged();
                    OnPropertyChanged("ImageScale");
                    OnPropertyChanged("ImageRect");
                    OnPropertyChanged("SegmentedItemRect");
                }
            }
        }

        public Vector ImageScale
        {
            get
            {
                if (OriginalImage == null || TargetScreenPixelDensity == null)
                    return new Vector(1, 1);

                double scaleX = TargetScreenPixelDensity.X * INCH / OriginalImage.DpiX;
                double scaleY = TargetScreenPixelDensity.Y * INCH / OriginalImage.DpiY;
                return new Vector(scaleX, scaleY);
            }
        }

        public BitmapSource OriginalImage
        {
            get { return _originalImage; }
            set
            {
                if (_originalImage != value)
                {
                    _originalImage = value;
                    OnPropertyChanged();
                    OnPropertyChanged("ImageScale");
                    OnPropertyChanged("ImageRect");
                }
            }
        }


        public Rect ImageRect
        {
            get
            {
                if (OriginalImage == null || TargetScreenPixelDensity == null)
                    return new Rect();

                PcPhysicalSize physicalSize = _originalImage.GetPhysicalSize();
                PcPhysicalRectangle physicalRectangle = new PcPhysicalRectangle(new PcPhysicalPoint(0, 0), physicalSize);
                Rect targetPixelRectangle = physicalRectangle.ToPixels(TargetScreenPixelDensity);
                return targetPixelRectangle;
            }
        }

        public Rect SegmentedItemRect
        {
            get
            {
                if (SegmentedItem == null || TargetScreenPixelDensity == null)
                    return new Rect();

                Rect pixelRectangle = SegmentedItem.Boundary.ToPixels(TargetScreenPixelDensity);
                return pixelRectangle;
            }
        }

        public SegmentedDataObject SegmentedItem
        {
            get { return _segmentedItem; }
            set
            {
                if (_segmentedItem != value)
                {
                    _segmentedItem = value;
                    OnPropertyChanged();
                    OnPropertyChanged("SegmentedItemRect");
                }
            }
        }

        public double ZoomFactor
        {
            get { return _zoomFactor; }
            set
            {
                if (_zoomFactor != value)
                {
                    _zoomFactor = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool CanProcess
        {
            get { return _canProcess; }
            set
            {
                if (_canProcess != value)
                {
                    _canProcess = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsInclusionChecked
        {
            get { return _isInclusionChecked; }
            set
            {
                if (_isInclusionChecked != value)
                {
                    _isInclusionChecked = value;
                    OnPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
