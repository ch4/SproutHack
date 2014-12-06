using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfCsSample.CodeSampleControls.Segmentation
{
    // Interaction logic for AssistedSegmentationControl.xaml
    // This sample code demonstrates assisted segmentation of a picture in a captured moment.
    public partial class AssistedSegmentationControl : ICodeSampleControl
    {
        public int Order { get { return 9; } }
        public string Title { get { return "Assisted Segmentation"; } }
        public string Description { get { return "This sample code demonstrates assisted segmentation. Click Capture to capture a moment and to display pictures and outlines. Draw inclusion and exclusion strokes, and the click Apply Segmentation to refine the pictures and outlines."; } }

        private readonly HorizontalWindow _horizontalWindow = new HorizontalWindow();

        private readonly AssistedSegmentationController _controller;

        public AssistedSegmentationControl()
        {
            DataContext = new AssistedSegmentationViewModel();
            InitializeComponent();
            Dispatcher.ShutdownFinished += DispatcherOnShutdownFinished;
            _controller = new AssistedSegmentationController(DataContext, _horizontalWindow);
        }

        private void DispatcherOnShutdownFinished(object sender, EventArgs e)
        {
            Dispatcher.ShutdownFinished -= DispatcherOnShutdownFinished;
            DisposeEverything();
        }

        public new AssistedSegmentationViewModel DataContext
        {
            get { return (AssistedSegmentationViewModel)base.DataContext; }
            set { base.DataContext = value; }
        }

        // Handle the Click event of the captureMomement control.
        // The parameter "sender" is the source of the event.
        // The parameter "e" is the RoutedEventArgs instance that contains the event data.
        private async void CaptureMomement_Click(object sender, RoutedEventArgs e)
        {
            await _controller.ExecuteCaptureMoment();
        }

        // Handle the Click event of the DrawAssistedContour control.
        // The parameter "sender" is the source of the event.
        // The parameter "e" is the RoutedEventArgs instance that contains the event data.
        private async void PerformAssistedSegmentation_Click(object sender, RoutedEventArgs e)
        {
            await _controller.PerformAssistedSegmentation();
        }

        private void ClearStroke_Click(object sender, RoutedEventArgs e)
        {
            _controller.ClearStrokes();
        }

        private void CapturedItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _controller.HandleSelectionChanged();
        }

        private void DisposeEverything()
        {
            _controller.Dispose();
        }
    }
}
