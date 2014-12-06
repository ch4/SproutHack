using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfCsSample.CodeSampleControls.Communications
{
    public class CommunicationViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<MessageViewModel> _leftPlayerMessages = new ObservableCollection<MessageViewModel>(); 
        private readonly ObservableCollection<MessageViewModel> _rightPlayerMessages = new ObservableCollection<MessageViewModel>();
        private bool _startIsEnabled = true;
        private bool _isEnabled;

        public ObservableCollection<MessageViewModel> LeftPlayerMessages
        {
            get { return _leftPlayerMessages; }
        }

        public ObservableCollection<MessageViewModel> RightPlayerMessages
        {
            get { return _rightPlayerMessages; }
        }

        public bool StartIsEnabled
        {
            get { return _startIsEnabled; }
            set
            {
                if(value.Equals(_startIsEnabled)) return;
                _startIsEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if(value.Equals(_isEnabled)) return;
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if(handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
