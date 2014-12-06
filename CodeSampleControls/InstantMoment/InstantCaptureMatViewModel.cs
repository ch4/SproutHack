using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfCsSample.CodeSampleControls.InstantMoment
{
    public class InstantCaptureMatViewModel : INotifyPropertyChanged
    {
        private InstantCapturedDataObject _root;
        private readonly ObservableCollection<InstantCapturedDataObject> _itemCollection = new ObservableCollection<InstantCapturedDataObject>();
        private double _scaleFactor = 0.5;
        private string _status = "waiting for request...";
        private bool _canCapture = true;

        public string Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool CanCapture
        {
            get { return _canCapture; }
            set
            {
                if (_canCapture != value)
                {
                    _canCapture = value;
                    OnPropertyChanged();
                }
            }
        }

        public InstantCapturedDataObject Root
        {
            get { return _root; }
            set
            {
                if (_root != value)
                {
                    _root = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<InstantCapturedDataObject> ItemCollection
        {
            get { return _itemCollection; }
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if(handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
