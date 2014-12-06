using System;

namespace WpfCsSample.CodeSampleControls.InputLayer
{
    /// <summary>
    /// Interaction logic for InputLayerControl.xaml
    /// </summary>
    public partial class InputLayerControl
    {
        public InputLayerControl()
        {
            DataContext = new InputLayerSampleViewModel();
            InitializeComponent();
            Dispatcher.ShutdownFinished += DispatcherOnShutdownFinished;
        }

        private void DispatcherOnShutdownFinished(object sender, EventArgs e)
        {
            Dispatcher.ShutdownFinished -= DispatcherOnShutdownFinished;
            DisposeEverything();
        }

        private new InputLayerSampleViewModel DataContext
        {
            get { return (InputLayerSampleViewModel)base.DataContext; }
            set { base.DataContext = value; }
        }
    }
}
