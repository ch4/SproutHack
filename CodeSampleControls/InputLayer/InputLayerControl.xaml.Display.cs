using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using HP.PC.Presentation;

namespace WpfCsSample.CodeSampleControls.InputLayer
{
    public partial class InputLayerControl : UserControl, ICodeSampleControl
    {
        public int Order { get { return 6; } }
        public string Title { get { return "Touch Input"; } }
        public string Description { get { return "This sample code shows how to use the Input touch layer, in order to show and hide the keyboard. Click Show Keyboard and Hide Keyboard to show and hide the keyboard."; } }

        private HorizontalWindow _horizontalWindow;



        // Button commands
        private async void StartSampleClicked(object sender, RoutedEventArgs e)
        {
            App.ClearErrorStatus();
            _horizontalWindow = new HorizontalWindow();
            _horizontalWindow.DataContext = DataContext;

            DataContext.CanProcess = false;
            await InitializeAsync();
            DataContext.IsStarted = true;
            DataContext.CanProcess = true;
        }

        private async void StopSampleClicked(object sender, RoutedEventArgs e)
        {
            App.ClearErrorStatus();
            DataContext.CanProcess = false;
            DataContext.CanShowInputLayer = false;
            await _inputLayer.DisableAsync();
            DisposeEverything();
            DataContext.IsStarted = false;
            DataContext.CanProcess = true;
        }

        private async void ShowInputLayerClicked(object sender, RoutedEventArgs e)
        {
            App.ClearErrorStatus();
            DataContext.CanProcess = false;
            // Enable the touch layer to display the input layer control.
            await _inputLayer.EnableAsync();
            DataContext.CanProcess = true;
        }

        private async void HideInputLayerClicked(object sender, RoutedEventArgs e)
        {
            App.ClearErrorStatus();
            DataContext.CanProcess = false;
            // Disable the touch layer to hide the input layer control.
            await _inputLayer.DisableAsync();
            DataContext.CanProcess = true;
        }



        private IPcLink _sdk;
        private IPcWindowRegistration _windowRegistration;
        private IPcTouch _touchController;
        private IPcTouchLayer _inputLayer;

        private async Task InitializeAsync()
        {
            try
            {
                // The SDK link provides SDK functionality to the application. In this sample code,
                // the SDK link is needed for a while, so instantiation does not use the using keyword.
                // It will be necessary to dispose of the link.
                _sdk = HPPC.CreateLink();

                // Before registering the window, be sure WPF has a handle to the Window. 
                // See: http://msdn.microsoft.com/en-us/library/system.windows.interop.windowinterophelper.ensurehandle%28v=vs.110%29.aspx
                var windowInteropHelper = new WindowInteropHelper(_horizontalWindow);
                windowInteropHelper.EnsureHandle();

                // Register the window with the SDK so the window can appear on the mat.
                _windowRegistration = await _sdk.RegisterWindowAsync(_horizontalWindow);

                _windowRegistration.DisplayabilityChanged += WindowRegistration_DisplayabilityChanged;

                // Display the window.
                await _windowRegistration.DisplayAsync();

                // Access the touch controller for the mat window.
                _touchController = await _sdk.AccessTouchAsync(_windowRegistration);
                IPcSpecification spec = await _sdk.AccessSpecificationAsync();

                // Access the Input layer.
                _inputLayer = _touchController.GetTouchLayer(spec.Touch.Input);
                DataContext.IsInputLayerVisible = _inputLayer.IsEnabled;

                // Subscribe to the Input layer's LayerStateChanged event.
                _inputLayer.LayerStateChanged += InputLayer_LayerStateChanged;

                DataContext.CanShowInputLayer = _windowRegistration.Displayability == PcDisplayability.MatScreenOn;
            }
            catch (Exception sdkError)
            {
                string errorMsg = "There was a problem running this sample: " + sdkError.Message + ".";
                App.UpdateErrorStatus(errorMsg);
            }
        }


        // Events
        void WindowRegistration_DisplayabilityChanged(object sender, PcDisplayabilityChangeEventArgs e)
        {
            DataContext.CanShowInputLayer = e.NewValue == PcDisplayability.MatScreenOn;
        }

        void InputLayer_LayerStateChanged(object sender, PcTouchLayerStateEventArgs e)
        {
            DataContext.IsInputLayerVisible = e.IsEnabled;
        }

        private void DisposeEverything()
        {
            // Dispose of the Input layer.
            if (_inputLayer != null)
            {
                _inputLayer.LayerStateChanged -= InputLayer_LayerStateChanged;
                _inputLayer.Dispose();
                _inputLayer = null;
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
            if (_sdk != null)
            {
                _sdk.Dispose();
                _sdk = null;
            }

            if(_horizontalWindow != null)
            {
                _horizontalWindow.Close();
                _horizontalWindow = null;
            }
        }
    }
}
