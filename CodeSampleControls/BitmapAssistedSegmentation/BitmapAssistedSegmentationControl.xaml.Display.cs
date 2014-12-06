using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media.Imaging;
using HP.PC.Presentation;
using Microsoft.Win32;

namespace WpfCsSample.CodeSampleControls.BitmapAssistedSegmentation
{
    // Interaction logic for BitmapAssistedSegmentationControl.xaml
    // This sample code demonstrates background removal for an image from the Web.
    public partial class BitmapAssistedSegmentationControl : UserControl, ICodeSampleControl
    {
        public int Order { get { return 10; } }
        public string Title { get { return "Background Removal"; } }
        public string Description { get { return "This sample code demonstrates background removal, which is a form of assisted segmentation that can be applied to an image that was not captured with Sprout. Draw inclusion and exclusion strokes, and then click Remove Background to refine the pictures and outlines."; } }


        // Handle the Click event of the DrawAssistedContour control.
        // The parameter "sender" is the source of the event.
        // The parameter "e" is the RoutedEventArgs instance that contains the event data.
        private async void PerformAssistedSegmentation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.ClearErrorStatus();
                DataContext.CanProcess = false;
                // Create the SDK link. The SDK link must be disposed of before exiting.
                using (var sdk = HPPC.CreateLink())
                {
                    // Get the embedded BitmapSource.
                    BitmapSource bmpSrc = DataContext.OriginalImage;

                    // Create a moment using the embedded bitmap.
                    using (var moment = await sdk.CaptureMomentAsync(bmpSrc))
                    {
                        // Get the initial outline.
                        IPcOutline originalOutline = await sdk.ExtractOutlineAsync(moment);

                        // Get the initial picture.
                        IPcPicture originalPicture = await sdk.ExtractPictureAsync(moment);

                        //The Segmentation algorithm only works with both exclusion and inclusion strokes are defined
                        if (DataContext.StrokeCollection.Count > 0)
                        {
                            Boolean greenStroke = false;
                            Boolean redStroke = false;
                            foreach (Stroke s in DataContext.StrokeCollection)
                            {
                                String strokeColor = s.DrawingAttributes.Color.ToString();

                                //#B052860C green
                                if (strokeColor.Equals("#B052860C")) greenStroke = true;
                                //#B0FE0202 red
                                else if (strokeColor.Equals("#B0FE0202")) redStroke = true;
                            }

                            if (greenStroke && redStroke)
                            {
                                // Get the stroke collection as a bitmap.
                                StrokeCollection strokes = DataContext.StrokeCollection;
                                PcPhysicalSize physicalSize = originalOutline.PhysicalBoundaries.Size;
                                PcPixelDensity pixelDensity = originalOutline.PixelDensity;

                                PcPixelDensity targetDensity = DataContext.TargetScreenPixelDensity;
                                double scaleX = targetDensity.X * 25.4 / 96.0;
                                double scaleY = targetDensity.Y * 25.4 / 96.0;
                                Vector strokesScale = new Vector(scaleX, scaleY);
                                BitmapSource bitmapSourceFromStrokes = BitmapExtension.BitmapSourceFromStrokes(physicalSize, pixelDensity, strokesScale, strokes);

                                // Apply assisted segmentation and get a refined outline.
                                IPcOutline outline = await sdk.RefineOutlineAsync(moment, originalOutline, bitmapSourceFromStrokes);

                                // Get a refined picture based on the refined outline.
                                IPcPicture picture = await sdk.RefinePictureAsync(moment, originalPicture, outline);

                                // Update the picture and the contour.
                                var segmentedDataObject = new SegmentedDataObject(picture.Image, outline.Contour, picture.PhysicalBoundaries);
                                DataContext.SegmentedItem = segmentedDataObject;
                            }
                            
                        }

                        
                    }
                }
            }
            catch (Exception sdkError)
            {
                string errorMsg = "There was a problem running this sample: " + sdkError.Message + ".";
                if (sdkError.InnerException != null)
                {
                    errorMsg += " In addition: " + sdkError.InnerException.Message;
                }
                App.UpdateErrorStatus(errorMsg);
            }
            finally
            {
                DataContext.CanProcess = true;
            }
        }

        private void LoadImageFromDisk_Clicked(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Images (*.jpeg, *.jpg, *.png)|*.jpeg;*.jpg;*.png"
                       + "|All Files (*.*)|*.*"
            };


            if (dialog.ShowDialog() == true)
            {
                string filename = dialog.FileName;
                try
                {
                    DataContext.OriginalImage = new BitmapImage(new Uri(filename));
                    DataContext.SegmentedItem = null;
                }
                catch (NotSupportedException)
                {
                }
            }
        }

        private void ClearStroke_Click(object sender, RoutedEventArgs e)
        {
            DataContext.StrokeCollection.Clear();
        }
    }
}
