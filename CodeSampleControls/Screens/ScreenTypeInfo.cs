using System;
using System.Windows;
using HP.PC.Presentation;

namespace WpfCsSample.CodeSampleControls.Screens
{
    public class ScreenTypeInfo
    {
        private readonly Guid _id;
        private readonly String _screenName;
        private readonly String _screenType;
        private readonly PcPixelDensity _pixelDensity;
        private readonly Size _pixelExtent;
        private readonly Point _origin;

        public ScreenTypeInfo(Guid id, String screenName, String screenType, PcPixelDensity pixelDensity, Size pixelExtent, Point origin)
        {
            _id = id;
            _pixelDensity = pixelDensity;
            _pixelExtent = pixelExtent;
            _origin = origin;
            _screenName = screenName;
            _screenType = screenType;
        }

        public Guid ScreenId
        {
            get { return _id; }
        }

        public string ScreenName
        {
            get { return _screenName; }
        }

        public string ScreenType
        {
            get { return _screenType; }
        }

        public PcPixelDensity PixelDensity
        {
            get { return _pixelDensity; }
        }

        public Size PixelExtent
        {
            get { return _pixelExtent; }
        }

        public Point Origin
        {
            get { return _origin; }
        }
    }
}
