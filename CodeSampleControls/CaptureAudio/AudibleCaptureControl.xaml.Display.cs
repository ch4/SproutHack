using System;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using HP.PC.Presentation;

namespace WpfCsSample.CodeSampleControls.CaptureAudio
{
    // Interaction logic for AudibleCaptureControl.xaml
    // This sample code demonstrates how to capture a moment and how to synchronize a shutter sound
    // with the capture flash. Nothing is extracted from the moment.
    public partial class AudibleCaptureControl : UserControl, ICodeSampleControl
    {
        public int Order { get { return 7; } }
        public string Title { get { return "Capture Audio"; } }
        public string Description { get { return "This sample code demonstrates how to capture a moment and to synchronize a shutter sound with the flash. Click Capture to hear the shutter sound during the flash."; } }

        // Handle the Click event of the captureButton control.
        // The parameter "sender" is the source of the event.
        // The parameter "e" is the RoutedEventArgs instance that contains the event data.
        private async void PerformCapture_Click(object sender, RoutedEventArgs e)
        {
            App.ClearErrorStatus();
            var horizontalWindow = new HorizontalWindow();

            try
            {

                DataContext.CanCapture = false;

                DataContext.Status = "initializing...";

                // The SDK link provides SDK functionality to the application. In this sample code,
                // the SDK link is not needed for very long. By instantiating the link with the
                // using keyword, the SDK link is disposed of automatically when it is no longer needed.
                using (var sdk = HPPC.CreateLink())
                {
                    // Before registering the window, be sure WPF has a handle to the Window.
                    // See: http://msdn.microsoft.com/en-us/library/system.windows.interop.windowinterophelper.ensurehandle%28v=vs.110%29.aspx
                    var windowInteropHelper = new WindowInteropHelper(horizontalWindow);
                    windowInteropHelper.EnsureHandle();

                    // Register the window for the mat.
                    using(var windowRegistration = await sdk.RegisterWindowAsync(horizontalWindow))
                    {
                        // Turn on the projector and show the application window
                        await windowRegistration.DisplayAsync();

                        DataContext.Status = "capturing...";
                        // We need to create an instance of the capture-progress monitor interface IPcCaptureProgressMonitor
                        // and pass it as a parameter in the method CaptureMomentAsync when capturing the 
                        // moment. This capture-progress monitor allows the app to listen for events that happen during the 
                        // capture. One such event is the Flash event, which is triggered when the flash occurs during
                        // the capture. We use this event to determine when to play the shutter sound.
                        var captureProgress = sdk.CreateCaptureProgressMonitor();
                        captureProgress.Flash += CaptureProgress_Flash;

                        // Capture a moment. After this statement, the moment contains only raw sensor data.
                        using (var moment = await sdk.CaptureMomentAsync(captureProgress))
                        {
                            DataContext.Status = "Moment captured. Waiting for the next request...";
                        }
                        captureProgress.Flash -= CaptureProgress_Flash;
                        horizontalWindow.Hide();

                    }
                }
            }
            catch (Exception sdkError)
            {
                DataContext.Status = "failed.";
                App.UpdateErrorStatus("There was a problem running this sample: " + sdkError.Message + ".");
            }
            finally
            {
                horizontalWindow.Close();
                DataContext.CanCapture = true;
            }
        }

        private void CaptureProgress_Flash(object sender, PcCaptureFlashEventArgs e)
        {
            Type type = GetType();
            var stream = type.Assembly.GetManifestResourceStream(type, "capture.wav");
            var soundPlayer = new SoundPlayer(stream);
            soundPlayer.PlaySync();
        }
    }
}
