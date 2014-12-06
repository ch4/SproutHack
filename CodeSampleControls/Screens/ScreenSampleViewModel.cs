using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WpfCsSample.CodeSampleControls.Screens
{
    public class ScreenSampleViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<ScreenTypeInfo> _availableDisplays = new ObservableCollection<ScreenTypeInfo>();
        private Size _canvasSize;

        public IEnumerable<ScreenTypeInfo> AvailableDisplays
        {
            get { return _availableDisplays; }
            set
            {
                _availableDisplays.Clear();
                foreach (var screen in value)
                {
                    _availableDisplays.Add(screen);
                }
                OnPropertyChanged("HasInfo");
            }
        }

        public bool HasInfo
        {
            get { return _availableDisplays.Count > 0; }
        }

        public Size CanvasSize
        {
            get { return _canvasSize; }
            set
            {
                if (_canvasSize != value)
                {
                    _canvasSize = value;
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
