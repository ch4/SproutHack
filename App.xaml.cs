namespace WpfCsSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {       
        static public void ClearErrorStatus()
        {
            UpdateErrorStatus(string.Empty);
        }

        static public void UpdateErrorStatus(string errorStatus)
        {
            MainWindow mainWindow = Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.UpdateErrorStatus(errorStatus);
            }
        }
    }
}
