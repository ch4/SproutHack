using System;

namespace WpfCsSample.CodeSampleControls.Communications
{
    public partial class Communications
    {
        public Communications()
        {
            DataContext = new CommunicationViewModel();
            InitializeComponent();
            Dispatcher.ShutdownFinished += DispatcherOnShutdownFinished;
        }

        private void DispatcherOnShutdownFinished(object sender, EventArgs e)
        {
            Dispatcher.ShutdownFinished -= DispatcherOnShutdownFinished;
            DisposeEverything();
        }

        public new CommunicationViewModel DataContext
        {
            get { return base.DataContext as CommunicationViewModel; }
            set { base.DataContext = value; }
        }
    }
}
