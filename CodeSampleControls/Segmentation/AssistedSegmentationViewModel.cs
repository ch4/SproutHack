using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Ink;

namespace WpfCsSample.CodeSampleControls.Segmentation
{
    public class AssistedSegmentationViewModel : INotifyPropertyChanged
    {
        private AssistedSegmentationPair _currentItem;
        private readonly StrokeCollection _strokeCollection = new StrokeCollection();
        private readonly ObservableCollection<AssistedSegmentationPair> _itemCollection = new ObservableCollection<AssistedSegmentationPair>();
        private double _scaleFactor = 1;
        private bool _canProcess = true;
        private bool _isInclusionChecked = true;

        public StrokeCollection StrokeCollection
        {
            get { return _strokeCollection; }
        }

        public AssistedSegmentationPair CurrentItem
        {
            get 
            {
                return _currentItem;
            }
            set
            {
                if (_currentItem != value)
                {
                    _currentItem = value;
                    OnPropertyChanged();
                    OnPropertyChanged("CanDrawStrokes");
                }
            }
        }
        public IEnumerable<AssistedSegmentationPair> RefinedItemCollection
        {
            get { return _itemCollection; }
            set
            {
                if (_itemCollection != value)
                {
                    _itemCollection.Clear();
                    foreach (var i in value)
                    {
                        _itemCollection.Add(i);
                    }
                    OnPropertyChanged();
                }
            }
        }

        public double ScaleFactor
        {
            get { return _scaleFactor; }
            set
            {
                if (_scaleFactor != value)
                {
                    _scaleFactor = value;
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
                    OnPropertyChanged("CanDrawStrokes");
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

        public bool CanDrawStrokes
        {
            get { return CanProcess && CurrentItem != null; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
