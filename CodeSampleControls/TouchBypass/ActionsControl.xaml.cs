using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using HP.PC.Presentation;

namespace WpfCsSample.CodeSampleControls.TouchBypass
{
    /// <summary>
    /// Interaction logic for ActionsControl.xaml
    /// </summary>
    public partial class ActionsControl : UserControl, ICodeSampleControl
    {
        public int Order { get { return 5; } }
        public string Title { get { return "Touch Bypass"; } }
        public string Description { get { return "This sample code shows how to use the Bypass touch layer, a touch layer that can send touch events to an app, instead of the the operating system. The sample shows how to handle events from the Bypass touch layer."; } }

        private ControlsWindow _controlsWindow;

        public ActionsControl()
        {
            DataContext = new TouchBypassViewModel();
            InitializeComponent();
            Dispatcher.ShutdownFinished += DispatcherOnShutdownFinished;
        }

        private void DispatcherOnShutdownFinished(object sender, EventArgs eventArgs)
        {
            Dispatcher.ShutdownFinished -= DispatcherOnShutdownFinished;
            DisposeEverything();
        }

        public new TouchBypassViewModel DataContext
        {
            get { return (TouchBypassViewModel)base.DataContext; }
            set { base.DataContext = value; }
        }

        private async void StartSampleClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                DataContext.CanProcess = false;
                await InitializeAsync();
                DataContext.IsStarted = true;
            }
            catch (Exception sdkError)
            {
                string errorMsg = "There was a problem running this sample: " + sdkError.Message + ".";
                App.UpdateErrorStatus(errorMsg);
            }
            finally
            {
                DataContext.CanProcess = true;
            }
        }

        private void StopSampleClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                DataContext.CanProcess = false;
                DataContext.IsStarted = false;
                DisposeEverything();
            }
            catch (Exception sdkError)
            {
                string errorMsg = "There was a problem running this sample: " + sdkError.Message + ".";
                App.UpdateErrorStatus(errorMsg);
            }
            finally
            {
                DataContext.CanProcess = true;
            }
        }



        private IPcLink _link;
        private IPcWindowRegistration _windowRegistration;
        private IPcTouch _touchController;
        private IPcTouchLayer _bypassLayer;
        private IPcScreen _matInfo;

        private async Task InitializeAsync()
        {
            // The SDK link provides SDK functionality to the application. In this sample code,
            // the SDK link is needed for a while, so instantiation does not use the using keyword.
            // It will be necessary to dispose of the link.
            _link = HPPC.CreateLink();

            _controlsWindow = new ControlsWindow();
            _controlsWindow.DataContext = DataContext;

            // Before registering the window, be sure WPF has a handle to the Window. 
            // See: http://msdn.microsoft.com/en-us/library/system.windows.interop.windowinterophelper.ensurehandle%28v=vs.110%29.aspx
            var windowInteropHelper = new WindowInteropHelper(_controlsWindow);
            windowInteropHelper.EnsureHandle();

            // Register the window with the SDK so the window can appear on the mat.
            _windowRegistration = await _link.RegisterWindowAsync(_controlsWindow);

            _windowRegistration.DisplayabilityChanged += WindowRegistration_DisplayabilityChanged;

            if (_windowRegistration.Displayability == PcDisplayability.MatScreenNotAvailable)
            {
                DataContext.IsMatAvailable = false;
                DataContext.State = "Attach the mat";
            }
            else
            {
                await InitializeBypassLayer();
                DataContext.IsMatAvailable = true;
                DataContext.State = "Use buttons on the mat for text navigation";
            }
        }

        private async Task InitializeBypassLayer()
        {
            // Display the window.
            await _windowRegistration.DisplayAsync();

            // Access the touch controller for the mat window.
            _touchController = await _link.AccessTouchAsync(_windowRegistration);
            IPcSpecification spec = await _link.AccessSpecificationAsync();

            _matInfo = spec.Screen.Mat;

            _bypassLayer = _touchController.GetTouchLayer(spec.Touch.Bypass);
            await _bypassLayer.EnableAsync();

            var matRectangle = new Rect(new Point(0, 0), spec.Screen.Mat.PixelExtent);
            var matGeometry = new RectangleGeometry(matRectangle);
            await _bypassLayer.SetGeometryAsync(matGeometry);
            _bypassLayer.LayerTouchDown += BypassLayer_LayerTouchDown;

            await Task.Delay(1000).ContinueWith(_ =>
                {
                    Dispatcher.BeginInvoke((Action)delegate
                    {
                        LoremIpsumTextBox.Focus();
                    });
                });
        }

        // Events
        private async void WindowRegistration_DisplayabilityChanged(object sender, PcDisplayabilityChangeEventArgs e)
        {
            if (e.NewValue == PcDisplayability.MatScreenNotAvailable)
            {
                DataContext.IsMatAvailable = false;
                DataContext.State = "Attach the mat";
            }
            else
            {
                DataContext.CanProcess = false;
                await InitializeBypassLayer();
                DataContext.IsMatAvailable = true;
                DataContext.State = "Use buttons on the mat for text navigation";
                DataContext.CanProcess = true;
            }
        }
        private void BypassLayer_LayerTouchDown(object sender, PcTouchDownEventArgs e)
        {
            _controlsWindow.HandleTouch(e.TouchPoint.ToScreenCoordinates(_matInfo));
        }

        private void DisposeEverything()
        {
            // Dispose of the Input layer.
            if (_bypassLayer != null)
            {
                _bypassLayer.LayerTouchDown -= BypassLayer_LayerTouchDown;
                _bypassLayer.Dispose();
                _bypassLayer = null;
            }

            // Dispose of the touch controller.
            if (_touchController != null)
            {
                _touchController.Dispose();
                _touchController = null;
            }

            // Dispose of the window registration.
            if (_windowRegistration != null)
            {
                _windowRegistration.Dispose();
                _windowRegistration = null;
            }

            // Dispose of the SDK link.
            if (_link != null)
            {
                _link.Dispose();
                _link = null;
            }

            if (_controlsWindow != null)
            {
                _controlsWindow.Close();
                _controlsWindow = null;
            }
        }
    }
}
