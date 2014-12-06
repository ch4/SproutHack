using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using HP.PC.Presentation;

namespace WpfCsSample.CodeSampleControls.Communications
{
    // Interaction logic for Communications.xaml
    // This sample code demonstrates application-communication functionality.
    public partial class Communications : UserControl, ICodeSampleControl
    {
        public int Order { get { return 14; } }
        public string Title { get { return "Communication"; } }
        public string Description { get { return "This sample code demonstrates application-communication functionality. Click Start and Stop to start and stop communication streaming. Click Send Message to send a message."; } }


        private IPcLink _pcLinkLeft;
        private IPcLink _pcLinkRight;

        private IPcCommunicationHandler _pcCommunicationLeft;
        private IPcCommunicationHandler _pcCommunicationRight;

        // Unique identifiers of communication channels that allow any processes on the machine
        // to subscribe to messages delivered through these channels.
        private const string LeftPlayerSignature = "Left Player";
        private const string RightPlayerSignature = "Right Player";

        private readonly Random _rand = new Random();

        // Prepare the left and right players.
        private async Task StartPlayers()
        {
            App.ClearErrorStatus();
            await StartLeftPlayer();
            await StartRightPlayer();
        }

        // Prepare the left player.
        private async Task StartLeftPlayer()
        {
            try
            {
                // Create an SDK link for the left player.  
                _pcLinkLeft = HPPC.CreateLink();

                // Create the communication handler.
                _pcCommunicationLeft = _pcLinkLeft.CreateCommunicationHandler(LeftPlayerSignature, "Optional name");

                // Subscribe to messages.
                _pcCommunicationLeft.MessageReceived += CommunicationMessageReceivedByLeftPlayer;

                // Initialize the communication channel.
                await _pcCommunicationLeft.StartAsync();
            }
            catch (Exception sdkError)
            {
                string errorMsg = "There was a problem running this sample: " + sdkError.Message + ".";
                App.UpdateErrorStatus(errorMsg);
            }
        }

        // Prepare the right player.
        private async Task StartRightPlayer()
        {
            try
            {
                
                // Create an SDK link for the right player.
                _pcLinkRight = HPPC.CreateLink();

                // Create the communication handler.
                _pcCommunicationRight = _pcLinkRight.CreateCommunicationHandler(RightPlayerSignature, "Optional name");

                // Subscribe to messages.
                _pcCommunicationRight.MessageReceived += CommunicationMessageReceivedByRightPlayer;

                // Initialize the communication channel.
                await _pcCommunicationRight.StartAsync();
            }
            catch (Exception sdkError)
            {
                string errorMsg = "There was a problem running this sample: " + sdkError.Message + ".";
                App.UpdateErrorStatus(errorMsg);
            }
        }

        // Message received by the left player
        // The parameter "sender" is the sender.
        // The parameter "e" is the PcMessageEventArgs instance that contains the event data.
        private void CommunicationMessageReceivedByLeftPlayer(object sender, PcMessageEventArgs e)
        {
            using(var reader = new BinaryReader(e.Stream))
            {
                // You can send any type of data that you want to send.
                var message = reader.ReadString(); // Here we are just sending plain string data.
                var rand = reader.ReadInt32();
                DataContext.LeftPlayerMessages.Add(new MessageViewModel(e.Source, e.Destination, message + " " + rand));
            }
        }

        // Message received by right player.
        // The parameter "sender" is the sender.
        // The parameter "e" is the PcMessageEventArgs instance that contains the event data.
        private void CommunicationMessageReceivedByRightPlayer(object sender, PcMessageEventArgs e)
        {
            using(var reader = new BinaryReader(e.Stream))
            {
                var message = reader.ReadString();
                var rand = reader.ReadInt32();
                DataContext.RightPlayerMessages.Add(new MessageViewModel(e.Source, e.Destination, message + " " + rand));
            }
        }

        // Handle the Clicked event of the LeftPlayerSend control.
        // The parameter "sender" is the source of the event.
        // The parameter "e" is the RoutedEventArgs instance that contains the event data.
        private void LeftPlayerSend_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
          
                using (var stream = new MemoryStream())
                {
                    using(var writer = new BinaryWriter(stream))
                    {
                        writer.Write("Hello, my friend.");
                        writer.Write(_rand.Next(100));
                        _pcCommunicationLeft.SendAsync(RightPlayerSignature, stream);
                    }
                }
            }
            catch(Exception sdkError)
            {
                string errorMsg = "There was a problem running this sample: " + sdkError.Message + ".";
                if(sdkError.InnerException != null)
                {
                    errorMsg += " In addition: " + sdkError.InnerException.Message;
                }
                App.UpdateErrorStatus(errorMsg);
            }
        }

        // Handle the Clicked event of the RightPlayerSend control.
        // The parameter "sender" is the source of the event.
        // The parameter "e" is the RoutedEventArgs instance that contains the event data.
        private void RightPlayerSend_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                using(var stream = new MemoryStream())
                {
                    using(var writer = new BinaryWriter(stream))
                    {
                        writer.Write("Hi, there!");
                        writer.Write(_rand.Next(100));
                        _pcCommunicationRight.SendAsync(LeftPlayerSignature, stream);
                    }
                }
            }
            catch(Exception sdkError)
            {
                string errorMsg = "There was a problem running this sample: " + sdkError.Message + ".";
                if(sdkError.InnerException != null)
                {
                    errorMsg += " In addition: " + sdkError.InnerException.Message;
                }
                App.UpdateErrorStatus(errorMsg);
            }
        }

        // Handle the Clicked event of the Start control.
        // The parameter "sender" is the source of the event.
        // The parameter "e" is the RoutedEventArgs instance that contains the event data.
        private async void Start_Clicked(object sender, RoutedEventArgs e)
        {
            // Start the demo sample and open communication channels.
            DataContext.LeftPlayerMessages.Clear();
            DataContext.RightPlayerMessages.Clear();

            if(_pcLinkLeft == null && _pcLinkRight==null)
            {
                DataContext.StartIsEnabled = false;
                DataContext.IsEnabled = false;

                try
                {
                    await StartPlayers();
                    DataContext.IsEnabled = true;
                }
                catch(Exception sdkError)
                {
                    string errorMsg = "There was a problem running this sample: " + sdkError.Message + ".";
                    if(sdkError.InnerException != null)
                    {
                        errorMsg += " In addition: " + sdkError.InnerException.Message;
                    }
                    App.UpdateErrorStatus(errorMsg);
                    DataContext.StartIsEnabled = true;
                }
            }
        }

        // Handle the Clicked event of the Stop control.
        // The parameter "sender" is the source of the event.
        // The parameter "e" is the RoutedEventArgs instance that contains the event data.
        private void Stop_Clicked(object sender, RoutedEventArgs e)
        {
            // Stop the demo sample and close communication channels.
            if(_pcLinkLeft != null && _pcLinkRight!=null)
            {
                DataContext.IsEnabled = false;
                try
                {
                    DisposeEverything();
                }
                catch(Exception sdkError)
                {
                    string errorMsg = "There was a problem running this sample: " + sdkError.Message + ".";
                    if(sdkError.InnerException != null)
                    {
                        errorMsg += " In addition: " + sdkError.InnerException.Message;
                    }
                    App.UpdateErrorStatus(errorMsg);
                }
                DataContext.StartIsEnabled = true;
            }
        }

        private void DisposeEverything()
        {
            // Dispose of streaming resources.
            if(_pcCommunicationLeft != null)
            {
                _pcCommunicationLeft.MessageReceived -= CommunicationMessageReceivedByLeftPlayer;
                _pcCommunicationLeft.Dispose();
                _pcCommunicationLeft = null;
            }

            if(_pcCommunicationRight != null)
            {
                _pcCommunicationRight.MessageReceived -= CommunicationMessageReceivedByRightPlayer;
                _pcCommunicationRight.Dispose();
                _pcCommunicationRight = null;
            }

            // Dispose of the SDK link.
            if(_pcLinkLeft != null)
            {
                _pcLinkLeft.Dispose();
                _pcLinkLeft = null;
            }
            if(_pcLinkRight!=null)
            {
                _pcLinkRight.Dispose();
                _pcLinkRight = null;
            }
        }
    }
}
