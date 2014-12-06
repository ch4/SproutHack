using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using HP.PC.Presentation;

namespace WpfCsSample.CodeSampleControls.Screens
{
    // Interaction logic for MatMonitorInfoControl.xaml
    // This sample code displays information about the screens for the monitor and mat.
    public partial class ScreenSample : UserControl, ICodeSampleControl
    {
        public int Order { get { return 3; } }
        public string Title { get { return "Screen Information"; } }
        public string Description { get { return "This sample code displays information about the screens for the monitor and mat. Click Display Screen Info to display the information."; } }


        // Handle the Click event of the Refresh button.
        // The parameter "sender" is the source of the event.
        // The parameter "e" is the RoutedEventArgs instance that contains the event data.
        private async void UpdateScreenSpecification_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // The SDK link provides SDK functionality to the application. In this sample code,
                // the SDK link is not needed for very long. By instantiating the link with the
                // using keyword, the SDK link is disposed of automatically when it is no longer needed.
                using (var sdk = HPPC.CreateLink())
                {
                    // From the SDK link, use the AccessSpecificationAsync function to create
                    // an instance of the IPcSpecification interface.
                    IPcSpecification spec = await sdk.AccessSpecificationAsync();

                    // Use the EnumerateAsync function in the IPcScreenSpecification interface through the
                    // IPcSpecification interface to retrieve information about each screen on the system
                    // from an instance of the returned IPcScreen interface, and add the information to
                    // a list of screens that will be displayed.
                    var screens = await spec.Screen.EnumerateAsync();
                    var screenInfos = screens.Select(src => new ScreenTypeInfo(
                            src.Identifier,
                            String.Empty,               // Screen name: TBD
                            String.Empty,               // Screen type: TBD
                            src.PixelDensity,           // Screen pixel density in dots/mm
                            src.WorkArea.Size,          // Screen size in pixels 
                            src.WorkArea.Location)      // Location in pixels of screen's
                                                        // upper-left corner relative to
                                                        // upper-left corner of primary
                                                        // screen
                        ).ToList();

                    // The canvas can't resize itself based on the contents.
                    // So we calculate its size.
                    double width = screenInfos.Max(s => s.Origin.X + s.PixelExtent.Width);
                    double height = screenInfos.Max(s => s.Origin.Y + s.PixelExtent.Height);
                    var canvasSize = new Size(width, height);

                    DataContext.CanvasSize = canvasSize;
                    DataContext.AvailableDisplays = screenInfos;
                }
            }
            // Handle an exception if it occurs.
            catch (Exception sdkError)
            {
                string errorMsg = "There was a problem running this sample: " + sdkError.Message + ".";
                if (sdkError.InnerException != null)
                {
                    errorMsg += " In addition: " + sdkError.InnerException.Message;
                }
                App.UpdateErrorStatus(errorMsg);
            }
        }
    }
}