using System;
using System.Windows.Input;

namespace WpfCsSample.CodeSampleControls.TouchBypass
{
    class LambdaCommand : ICommand
    {
        private readonly Action<object> _action;

        public LambdaCommand(Action<object> action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return _action != null;
        }

        private void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if(handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
