using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfCsSample
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private int _selectedIndex = -1;
        private string _errorStatus = String.Empty;
        private readonly ObservableCollection<SampleTabViewModel> _tabs = new ObservableCollection<SampleTabViewModel>();

        public string ErrorStatus
        {
            get { return _errorStatus; }
            set
            {
                if (_errorStatus != value)
                {
                    _errorStatus = value;
                    OnPropertyChanged();
                }
            }
        }

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<SampleTabViewModel> Tabs
        {
            get { return _tabs; }
        }

        public SampleTabViewModel Current
        {
            get
            {
                var index = SelectedIndex;
                if (-1 < index && index < Tabs.Count)
                {
                    var current = Tabs[index];
                    return current;
                }
                return null;
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
