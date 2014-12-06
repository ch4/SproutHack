using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using HP.PC.Presentation;

namespace WpfCsSample.CodeSampleControls.Present
{
    // Interaction logic for Present.xaml
    // This sample code demonstrates how to present a window on the mat.
    public partial class Present : UserControl, ICodeSampleControl
    {
        public int Order { get { return 4; } }
        public string Title { get { return "Mat Window"; } }
        public string Description { get { return "This sample code shows how to display and close a full-screen window on the mat. Click Display Mat Window and Close Mat Window to display and close the window."; } }


        private HorizontalWindow _horizontalWindow;
        private IPcWindowRegistration _windowregistration;
        private IPcLink _sdk;

        private async void CreateAndShowHorizontalWindow()
        {
            if (_horizontalWindow == null)
            {
                // Create the mat window.
                _horizontalWindow = new HorizontalWindow();


                // Before registering the window, be sure WPF has a handle to the window. See: http://msdn.microsoft.com/en-us/library/system.windows.interop.windowinterophelper.ensurehandle%28v=vs.110%29.aspx
                var windowInteropHelper = new WindowInteropHelper(_horizontalWindow);
                windowInteropHelper.EnsureHandle();

                try
                {
                    App.ClearErrorStatus();

                    // The SDK link provides SDK functionality to the application. In this sample code,
                    // the SDK link is needed for a while, so instantiation does not use the using keyword.
                    // It will be necessary to dispose of the link.
                    _sdk = HPPC.CreateLink();



                    // Register the window.
                    _windowregistration = await _sdk.RegisterWindowAsync(_horizontalWindow);

                    // Display the window.
                    await _windowregistration.DisplayAsync();
                }
                catch (Exception sdkError)
                {
                    string errorMsg = "There was a problem running this sample: " + sdkError.Message + ".";
                    App.UpdateErrorStatus(errorMsg);
                }

            }
        }


        // Unsubscribe from the Window.SourceInitialized event for the mat window and close the window.
        private void CloseHorizontalWindow()
        {
            if (_horizontalWindow != null)
            {
                // Unsubscribe from the Window.SourceInitialized event for the mat window.
                // Close the mat window.
                _horizontalWindow.Close();
                _horizontalWindow = null;
            }
            DisposeEverything();
        }

        // Handle the Clicked event of the PresentWindow control.
        // The parameter "sender" is the source of the event.
        // The parameter "e" is the RoutedEventArgs instance that contains the event data.
        private void PresentWindow_Clicked(object sender, RoutedEventArgs e)
        {
            CreateAndShowHorizontalWindow();
        }

        // Handle the Click event of the Button control.
        // The parameter "sender" is the source of the event.
        // The parameter "e" is the RoutedEventArgs instance that contains the event data.
        private void CloseWindow_Clicked(object sender, RoutedEventArgs e)
        {
            CloseHorizontalWindow();
        }

        // Perform application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        private void DisposeEverything()
        {
            if (_windowregistration != null)
            {
                _windowregistration.Dispose();
                _windowregistration = null;
            }

            if (_sdk != null)
            {
                // Dispose of the SDK link.
                _sdk.Dispose();
                _sdk = null;
            }
        }
    }
}
