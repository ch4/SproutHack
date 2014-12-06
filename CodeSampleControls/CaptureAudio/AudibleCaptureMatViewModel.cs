using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace WpfCsSample.CodeSampleControls.CaptureAudio
{
    public class AudibleCaptureMatViewModel : INotifyPropertyChanged
    {
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


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if(handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
