using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using HP.PC.Presentation;

namespace WpfCsSample.CodeSampleControls.Segmentation
{
    class AssistedSegmentationController
    {
        private readonly AssistedSegmentationViewModel _viewModel;
        private readonly HorizontalWindow _horizontalWindow;
        private IPcLink _sdk;
        private IPcMoment _moment;
        private IPcScreen _mat;
        private bool _isDisposed;
        private IPcWindowRegistration _windowRegistration;

        public AssistedSegmentationController(AssistedSegmentationViewModel viewModel, HorizontalWindow horizontalWindow)
        {
            _viewModel = viewModel;
            _horizontalWindow = horizontalWindow;
        }

        private async Task Initialize()
        {
            if (_isDisposed) return;

            if (_sdk != null) return;

            App.ClearErrorStatus();

            _sdk = HPPC.CreateLink();

            IPcSpecification spec = await _sdk.AccessSpecificationAsync();
            if (_isDisposed) return;

            var windowInteropHelper = new WindowInteropHelper(_horizontalWindow);
            windowInteropHelper.EnsureHandle();

            _windowRegistration = await _sdk.RegisterWindowAsync(_horizontalWindow);
            if (_isDisposed) return;

            _mat = spec.Screen.Mat;
        }

        public async Task ExecuteCaptureMoment()
        {
            if (_isDisposed) return;

            try
            {
                App.ClearErrorStatus();

                _viewModel.CanProcess = false;

                await Initialize();
                if (_isDisposed) return;

                // Dispose of the previous moment if one exists.
                if (_moment != null)
                {
                    _moment.Dispose();
                }

                // Turn on the projector.
                await _windowRegistration.DisplayAsync();
                if (_isDisposed) return;

                // Capture a moment.
                _moment = await _sdk.CaptureMomentAsync();
                if (_isDisposed) return;

                // Hide the mat window because it is not needed any more.
                _horizontalWindow.Hide();

                // Retrieve the top-level mat picture.
                var picture = await _sdk.ExtractPictureAsync(_moment);
                if (_isDisposed) return;


                var outline = await _sdk.ExtractOutlineAsync(_moment);
                if (_isDisposed) return;

                // Extract all child pictures and their outlines, assuming that indexing between
                // a picture and its outline is consistent (that is, that the picture and the outline
                // are in the same locations in their respective trees).
                var combolist =
                    new List<AssistedSegmentationDataObject>(
                        picture.Children.Zip(outline.Children,
                            (pic, oln) => new AssistedSegmentationDataObject
                                (
                                // The image is already device independent.
                                image: pic,
                                // The outline contour is NOT device independent, so its container must be
                                // stretched to match that of the image (or boundary). In this sample, this
                                // is done by setting the captureContour control's Stretch property to Fill
                                // in the XAML.
                                outline: oln,
                                boundary: pic.PhysicalBoundaries.ToScreenCoordinates(_mat)
                                )));

                // Draw extracted pictures and their outlines.
                _viewModel.RefinedItemCollection = combolist.Select(item => new AssistedSegmentationPair { OrigObject = item, RefinedObject = item });
                _viewModel.CurrentItem = _viewModel.RefinedItemCollection.FirstOrDefault();
            }
            catch (TaskCanceledException)
            {
                App.UpdateErrorStatus("Task is cancelled");
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
                _viewModel.CanProcess = true;
            }
        }

        public async Task PerformAssistedSegmentation()
        {
            if (_isDisposed) return;

            try
            {
                App.ClearErrorStatus();

                _viewModel.CanProcess = false;

                var currentItem = _viewModel.CurrentItem;
                if (currentItem != null)
                {
                    IPcPicture originalPicture = currentItem.OrigObject.PcPicture;
                    IPcOutline originalOutline = currentItem.OrigObject.PcOutline;

                    // Get the stroke collection as a bitmap.
                    PcPixelDensity targetDensity = _mat.PixelDensity;
                    double scaleX = targetDensity.X * 25.4 / 96.0;
                    double scaleY = targetDensity.Y * 25.4 / 96.0;
                    Vector strokesScale = new Vector(scaleX, scaleY);

                    //The Segmentation algorithm only works with both exclusion and inclusion strokes are defined
                    if (_viewModel.StrokeCollection.Count > 0)
                    {
                        Boolean greenStroke = false;
                        Boolean redStroke = false;
                        foreach (Stroke s in _viewModel.StrokeCollection)
                        {
                            String strokeColor = s.DrawingAttributes.Color.ToString();

                            //#B052860C green
                            if (strokeColor.Equals("#B052860C")) greenStroke = true;
                            //#B0FE0202 red
                            else if (strokeColor.Equals("#B0FE0202")) redStroke = true;
                        }

                        if (greenStroke && redStroke)
                        {
                            StrokeCollection strokes = _viewModel.StrokeCollection;
                            BitmapSource bitmapSourceFromStrokes = BitmapExtension.BitmapSourceFromStrokes(originalPicture.PhysicalBoundaries.Size, originalPicture.PixelDensity, strokesScale, strokes);

                            // Apply assisted segmentation and get a refined outline.
                            IPcOutline refinedOutline = await _sdk.RefineOutlineAsync(_moment, originalOutline, bitmapSourceFromStrokes);
                            if (_isDisposed) return;

                            // Get a refined picture based on the refined outline.
                            IPcPicture refinedPicture = await _sdk.RefinePictureAsync(_moment, originalPicture, refinedOutline);
                            if (_isDisposed) return;

                            // Combine the image and the contour.
                            var refinedObject = new AssistedSegmentationDataObject(refinedPicture, refinedOutline,
                                refinedPicture.PhysicalBoundaries.ToScreenCoordinates(_mat));

                            // Change the collection element.
                            currentItem.RefinedObject = refinedObject;
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
                _viewModel.CanProcess = true;
            }
        }

        public void ClearStrokes()
        {
            if (_isDisposed) return;

            _viewModel.StrokeCollection.Clear();
        }

        public void HandleSelectionChanged()
        {
            if (_isDisposed) return;

            _viewModel.StrokeCollection.Clear();
            AssistedSegmentationPair currentItem = _viewModel.CurrentItem;
            if (currentItem != null)
            {
                currentItem.RefinedObject = currentItem.OrigObject;
            }
        }

        public void Dispose()
        {
            if (_isDisposed) return;

            _viewModel.CanProcess = false;

            // Dispose of the moment.
            if (_moment != null)
            {
                _moment.Dispose();
            }

            // Dispose of the mat window registration.
            if (_windowRegistration != null)
            {
                _windowRegistration.Dispose();
            }

            if (_sdk != null)
            {
                // Dispose of the SDK link.
                _sdk.Dispose();
            }

            _mat = null;
            _moment = null;
            _sdk = null;

            _isDisposed = true;
        }
    }
}
