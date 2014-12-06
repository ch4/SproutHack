using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using HP.PC.Presentation;

namespace WpfCsSample.CodeSampleControls.InstantMoment
{
    // Interaction logic for InstantCaptureControl.xaml
    // This sample code demonstrates how to capture a moment and how to extract the
    // top-level (whole mat) picture and outline from the moment, using the BasicProcessing option.
    // This is faster than using the Default option, which segments the captured moment. After this
    // instant capture, the sample proceeds to extract the pictures and outlines, performing segmentation.
    public partial class InstantCaptureControl : UserControl, ICodeSampleControl
    {
        public int Order { get { return 7; } }
        public string Title { get { return "Pictures and Outlines"; } }
        public string Description { get { return "This sample code demonstrates how to capture a moment and to extract pictures and outlines. First, the sample extracts the top-level image and outline quickly. Second, the sample extracts pictures and outlines and performs segmentation."; } }


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
                DataContext.Root = null;
                DataContext.ItemCollection.Clear();

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
                        // Turn on the projector.
                        await windowRegistration.DisplayAsync();

                        // From the SDK link, use the method AccessSpecificationAsync to create
                        // an instance of the interface IPcSpecification.
                        IPcSpecification spec = await sdk.AccessSpecificationAsync();

                        // Use the interface IPcScreenSpecification through the interface IPcSpecification to
                        // retrieve information about the mat screen. The information is used below when displaying
                        // pictures and outlines.
                        var mat = spec.Screen.Mat;

                        DataContext.Status = "capturing...";
                        // Capture a moment. After this statement, the moment contains only raw sensor data.
                        using (var moment = await sdk.CaptureMomentAsync())
                        {
                            DataContext.Status = "getting the image...";
                            // Extract the top-level picture and outline from the moment using the BasicProcessing option,
                            // which performs less processing and takes less time than with Default processing.
                            var fastPicture = await sdk.ExtractPictureAsync(moment, spec.Picture.Extract.Mat);
                            var fastOutline = await sdk.ExtractOutlineAsync(moment, spec.Outline.Extract.Mat);

                            var fastRoot = new InstantCapturedDataObject(
                                image: fastPicture.Image,
                                outline: fastOutline.Contour,
                                boundary: fastPicture.PhysicalBoundaries.ToScreenCoordinates(mat),
                                skewAngle: 0.0
                                );

                            DataContext.Root = fastRoot;

                            // Hide the mat window because it is not needed any more.
                            horizontalWindow.Hide();

                            DataContext.Status = "segmenting...";

                            // Extract the top-level picture and child images.
                            var picture = await sdk.ExtractPictureAsync(moment, spec.Picture.Extract.Object);

                            // Extract the top-level outline and child outlines.
                            var outline = await sdk.ExtractOutlineAsync(moment, spec.Outline.Extract.Object);

                            var root = new InstantCapturedDataObject(
                                image: picture.Image,
                                outline: outline.Contour,
                                boundary: picture.PhysicalBoundaries.ToScreenCoordinates(mat),
                                skewAngle: 0.0
                                );

                            // Extract all child pictures and their outlines, assuming that indexing between
                            // a picture and its outline is consistent (that is, that the picture and the outline
                            // are in the same locations in their respective trees).
                            var combolist =
                                new List<InstantCapturedDataObject>(
                                    picture.Children.Zip<IPcPicture, IPcOutline, InstantCapturedDataObject>(outline.Children,
                                        (pic, oln) => new InstantCapturedDataObject
                                            (
                                            // The image is already device independent.  
                                            image: pic.Image,
                                            // The outline contour is NOT device independent, so its container must be
                                            // stretched to match that of the image (or boundary). In this sample, this
                                            // is done by setting the captureContour control's Stretch property to Fill
                                            // in the XAML.  
                                            outline: oln.Contour,
                                            boundary: pic.PhysicalBoundaries.ToScreenCoordinates(mat),
                                            skewAngle: pic.SkewAngle
                                            )));

                            // Draw extracted pictures and their outlines.
                            DataContext.Root = root;
                            foreach (var item in combolist)
                            {
                                DataContext.ItemCollection.Add(item);
                            }

                            DataContext.Status = "done. Waiting for the next request...";
                        }
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
    }
}
