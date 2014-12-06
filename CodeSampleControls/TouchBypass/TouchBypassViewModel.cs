using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace WpfCsSample.CodeSampleControls.TouchBypass
{
    public class TouchBypassViewModel : INotifyPropertyChanged
    {
        private bool _CanProcess = true;
        private bool _IsStarted;
        private bool _IsMatAvailable = true;
        private string _State;

        private readonly ICommand _ControllerCommand;

        public TouchBypassViewModel()
        {
            _ControllerCommand = new LambdaCommand(InvokeKeyPress);
        }

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

        public bool IsMatAvailable
        {
            get { return _IsMatAvailable; }
            set
            {
                if (_IsMatAvailable != value)
                {
                    _IsMatAvailable = value;
                    OnPropertyChanged();
                }
            }
        }

        public String State
        {
            get { return _State; }
            set
            {
                if (_State != value)
                {
                    _State = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ControllerCommand
        {
            get { return _ControllerCommand; }
        }

        private void InvokeKeyPress(object obj)
        {
            byte vk = (byte)obj;
            const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
            keybd_event(vk, 0, KEYEVENTF_EXTENDEDKEY, 0);
        }

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);


        public const byte VK_PRIOR = 0x21;
        public const byte VK_NEXT = 0x22;
        public const byte VK_END = 0x23;
        public const byte VK_HOME = 0x24;
        public const byte VK_LEFT = 0x25;
        public const byte VK_UP = 0x26;
        public const byte VK_RIGHT = 0x27;
        public const byte VK_DOWN = 0x28;


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
