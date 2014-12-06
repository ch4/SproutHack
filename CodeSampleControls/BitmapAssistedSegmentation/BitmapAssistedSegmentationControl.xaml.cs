using System;
using System.Windows.Media.Imaging;
using HP.PC.Presentation;

namespace WpfCsSample.CodeSampleControls.BitmapAssistedSegmentation
{
    public partial class BitmapAssistedSegmentationControl
    {
        private const string IMAGE_SOURCE = "pack://application:,,,/Resources/SegmentationImage.png";

        public BitmapAssistedSegmentationControl()
        {
            DataContext = new BitmapAssistedSegmentationViewModel
            {
                TargetScreenPixelDensity = new PcPixelDensity(3.78, 3.78),
                OriginalImage = new BitmapImage(new Uri(IMAGE_SOURCE)),
            };
            InitializeComponent();
        }

        public new BitmapAssistedSegmentationViewModel DataContext
        {
            get { return (BitmapAssistedSegmentationViewModel)base.DataContext; }
            set { base.DataContext = value; }
        }
    }
}
