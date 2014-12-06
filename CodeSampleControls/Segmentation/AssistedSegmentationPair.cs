using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WpfCsSample.CodeSampleControls.Segmentation
{
    public class AssistedSegmentationPair : INotifyPropertyChanged
    {
        private AssistedSegmentationDataObject _origObject;
        private AssistedSegmentationDataObject _refinedObject;

        public AssistedSegmentationDataObject OrigObject
        {
            get
            {
                return _origObject;
            }
            set
            {
                if (_origObject != value)
                {
                    _origObject = value;
                    OnPropertyChanged();
                }
            }
        }
        public AssistedSegmentationDataObject RefinedObject
        {
            get
            {
                return _refinedObject;
            }
            set
            {
                if (_refinedObject != value)
                {
                    _refinedObject = value;
                    OnPropertyChanged();
                    OnPropertyChanged("RelativePosition");
                }
            }
        }

        public Point RelativePosition 
        { 
            get
            {
                if (RefinedObject == null)
                    return new Point();

                var resX = (RefinedObject.Boundary.Location.X - OrigObject.Boundary.Location.X);
                var resY = (RefinedObject.Boundary.Location.Y - OrigObject.Boundary.Location.Y);
                return new Point(resX, resY);
            }
            
        }

        public Size TotalSize
        { 
            get
            {
                if (RefinedObject == null)
                    return new Size(OrigObject.Boundary.Width, OrigObject.Boundary.Height);

                var rel = RelativePosition;
                var resX = Math.Max(RefinedObject.Boundary.Width + rel.X, OrigObject.Boundary.Width);
                var resY = Math.Max(RefinedObject.Boundary.Height + rel.Y, OrigObject.Boundary.Height);
                return new Size(resX, resY);
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