using System;
using System.Windows.Controls;

namespace WpfCsSample.CodeSampleControls.Present
{
    /// <summary>
    /// Interaction logic for Present.xaml
    /// </summary>
    public partial class Present : UserControl
    {
        public Present()
        {
            InitializeComponent();
            Dispatcher.ShutdownFinished += DispatcherOnShutdownFinished;
        }

        private void DispatcherOnShutdownFinished(object sender, EventArgs e)
        {
            Dispatcher.ShutdownFinished -= DispatcherOnShutdownFinished;
            DisposeEverything();
        }
    }
}
