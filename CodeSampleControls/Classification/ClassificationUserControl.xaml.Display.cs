using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Collections.Generic;
using HP.PC.Presentation;
using HP.PC.Presentation.Specification;

namespace WpfCsSample.CodeSampleControls.Classification
{
    // Interaction logic for ClassificationUserControl.xaml
    public partial class ClassificationUserControl : UserControl, ICodeSampleControl
    {
        public int Order { get { return 12; } }
        public string Title { get { return "Classification"; } }
        public string Description { get { return "This sample code demonstrates how to classify the objects in a captured moment. Click Capture to capture a moment and to classify captured items. Mouseover each item to see its classification."; } }

        private HorizontalWindow horizontalWindow;

        private async void PerformCapture_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.ClearErrorStatus();
                horizontalWindow = new HorizontalWindow();

                captureButton.IsEnabled = false;
                DataContext.Root = null;
                DataContext.ItemCollection.Clear();

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
                    using (var windowRegistration = await sdk.RegisterWindowAsync(horizontalWindow))
                    {
                        // Turn on the projector.
                        await windowRegistration.DisplayAsync();

                        // Capture a moment. All captured entities (for example, pictures and outlines) will be
                        // extracted from the moment.
                        using (var moment = await sdk.CaptureMomentAsync())
                        {
                            // Not needed any more
                            horizontalWindow.Hide();

                            // Extract the top-level picture and child images.
                            IPcPicture picture = await sdk.ExtractPictureAsync(moment);

                            // Get specification to translate classification to known ones.
                            var specification = await sdk.AccessSpecificationAsync();

                            // Classify the contents of the moment using classification tags.
                            IPcClassification classification = await sdk.ClassifyAsync(moment);

                            // Use the IPcScreenSpecification interface through the IPcSpecification interface to
                            // retrieve information about the mat screen. The information is used below when displaying
                            // pictures
                            IPcSpecification spec = await sdk.AccessSpecificationAsync();
                            var mat = spec.Screen.Mat;

                            // Create an ObservableCollection that contains the tree structure of classification tags.
                            ObservableCollection<ClassificationTag> collection = new ObservableCollection<ClassificationTag>();
                            collection.Add(await ConvertTagCollection(classification, specification.Classification));


                            var root = new ClassificationObject(collection[0].Tags, picture.Image, picture.PhysicalBoundaries.ToScreenCoordinates(mat));

                            DataContext.Root = root;

                            // Extract all child pictures and their classification, assuming that indexing between
                            // a picture and its classification is consistent (that is, that the picture and the classification
                            // are in the same locations in their respective trees).                            
                            IEnumerator<IPcPicture> it = picture.Children.GetEnumerator();
                            it.MoveNext();

                            for (int i = 0; i < collection[0].Children.Count; i++)
                            {
                                ClassificationObject classObj = new ClassificationObject(collection[0].Children[i].Tags, it.Current.Image, it.Current.PhysicalBoundaries.ToScreenCoordinates(mat));
                                DataContext.ItemCollection.Add(classObj);
                                it.MoveNext();
                            }

                            it.Dispose();

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
                horizontalWindow.Close();
                captureButton.IsEnabled = true;
            }
        }

        internal static async Task<ClassificationTag> ConvertTagCollection(IPcClassification pcTag, IPcClassificationSpecification classSpec)
        {
            if (pcTag != null)
            {
                var ct = new ClassificationTag();

                var sb = new StringBuilder();
                foreach (var pt in pcTag.Tags)
                {
                    if (sb.Length != 0)
                    {
                        sb.Append(", ");
                    }

                    // Match classification to a well known classification
                    if (pt != null)
                    {
                        if (pt.Identifier == classSpec.Flat.Identifier)
                        {
                            sb.Append("Flat");
                        }
                        else if (pt.Identifier == classSpec.Rectangular.Identifier)
                        {
                            sb.Append("Rectangular");
                        }
                        else if (pt.Identifier == classSpec.ThreeDimensional.Identifier)
                        {
                            sb.Append("Three-dimensional");
                        }
                        else
                        {
                            sb.Append("Unknown");
                        }
                    }
                    else
                    {
                        sb.Append("Unknown");
                    }
                }

                foreach (var child in pcTag.Children)
                {
                    ct.Children.Add(await ConvertTagCollection(child, classSpec));
                }

                ct.Tags = sb.ToString();
                return ct;
            }

            return null;
        }
    }
}