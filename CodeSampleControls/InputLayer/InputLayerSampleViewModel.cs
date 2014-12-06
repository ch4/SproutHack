using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfCsSample.CodeSampleControls.InputLayer
{
    class InputLayerSampleViewModel : INotifyPropertyChanged
    {
        private bool _CanProcess = true;
        private bool _IsStarted;

        private bool _CanShowInputLayer;
        private bool _IsInputLayerVisible;

        public bool CanProcess
        {
            get { return _CanProcess; }
            set
            {
                if (_CanProcess != value)
                {
                    _CanProcess = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsStarted
        {
            get { return _IsStarted; }
            set
            {
                if (_IsStarted != value)
                {
                    _IsStarted = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool CanShowInputLayer
        {
            get { return _CanShowInputLayer; }
            set
            {
                if (_CanShowInputLayer != value)
                {
                    _CanShowInputLayer = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsInputLayerVisible
        {
            get { return _IsInputLayerVisible; }
            set
            {
                if (_IsInputLayerVisible != value)
                {
                    _IsInputLayerVisible = value;
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
