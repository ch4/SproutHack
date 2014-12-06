using System;
using System.Windows;
using HP.PC.Presentation;

namespace WpfCsSample.CodeSampleControls.Versions
{
    // Interaction logic for VersionSample.xaml
    // This sample code displays versions of the SDK and binding.
    public partial class VersionSample : ICodeSampleControl
    {
        public int Order { get { return 1; } }
        public string Title { get { return "Versions"; } }
        public string Description { get { return "This sample code displays the versions of the SDK and binding. Click Display Versions to display the versions."; } }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.ClearErrorStatus();

                // The SDK link provides SDK functionality to the application. In this sample code,
                // it is not necessary to keep the SDK link active for a long time. It is disposed of
                // automatically by instantiating it with the using keyword.
                using (IPcLink pcLink = HPPC.CreateLink())
                {
                    // From the SDK link, use the AccessSpecificationAsync function to create
                    // an instance of the IPcSpecification interface.
                    IPcSpecification spec = await pcLink.AccessSpecificationAsync();

                    // Use the IPcVersionSpecification interface through the IPcSpecification interface
                    // to retrieve information about the versions of the SDK and of the binding.
                    // The SDK version is the version installed on the current machine.
                    // The binding version is the version currently being used by the application.
                    Version sdkVersion = spec.Version.SDK;
                    Version bindingVersion = spec.Version.Binding;

                    // Show the version information using labels.
                    this.labelSdkVersion.Content = sdkVersion.ToString();
                    this.labelBindingVersion.Content = bindingVersion.ToString();
                }
            }

            // Every call to the SDK functionality can return a PcException. For
            // example, HPPC.CreateLink returns a PcException if the request fails.
            catch (PcException ex)
            {
                string errorMsg = "There was a problem running this sample: " + ex.Message + ".";
                App.UpdateErrorStatus(errorMsg);
            }

            // Every .NET task can return an AggregateException, which encapsulates
            // all the exceptions generated inside the task. This is the case for
            // asynchronous functionality in the SDK, such as AccessSpecificationAsync.
            catch (AggregateException taskException)
            {
                // In this case, Microsoft's suggested exception handling is to access the inner exceptions.
                foreach (var ex in taskException.InnerExceptions)
                {
                    if (ex is PcException)
                    {
                        string errorMsg = "There was a problem running this sample: " + ex.Message + ".";
                        App.UpdateErrorStatus(errorMsg);
                    }
                }
            }
        }
    }
}
