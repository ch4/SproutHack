using System;
using System.Windows;
using System.Windows.Threading;
using HP.PC.Presentation;

namespace WpfSdkClient.CodeSampleControls.AppSettings
{
    // Interaction logic for SettingsSample.xaml
    // This sample code shows how to set application-specific parameters using the PcAppSettings class.
    // To do so, we create an instance of the PcAppSettings class, set required parameters, and provide
    // the instance to the method that creates the SDK link.
    public partial class SettingsSample
    {
        public void ExecuteClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                // The SDK link provides SDK functionality to the application. In this sample code,
                // the SDK link is not needed for very long. By instantiating the link with the
                // using keyword, the SDK link is disposed of automatically when it is no longer needed.
                using (IPcLink pcLink = HPPC.CreateLink())
                {
                    // Here you would include code to use SDK features through the SDK link.
                }
                resultText.Text = "Application settings were set and passed to the SDK link.";
            }
            catch (Exception sdkError)
            {
                string errorMsg = "There was a problem running this sample: " + sdkError.Message + ".";
                if (sdkError.InnerException != null)
                {
                    errorMsg += " In addition: " + sdkError.InnerException.Message;
                }
                MessageBox.Show(errorMsg);
            }
        }
    }
}
