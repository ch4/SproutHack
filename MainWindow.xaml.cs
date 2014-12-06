using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using WpfCsSample.SourcePreview;
using WpfCsSample.Welcome;

namespace WpfCsSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }

        public new MainWindowViewModel DataContext
        {
            get { return (MainWindowViewModel)base.DataContext; }
            set { base.DataContext = value; }
        }

        private void exitWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Handle the Initialized event of the Window control.
        // The parameter "sender" is the source of the event.
        // The parameter "e" is the EventArgs instance that contains the event data.
        private void Window_Initialized(object sender, EventArgs e)
        {
            var samples = GetType().Assembly.GetTypes()
                .Where(t => t.IsClass)
                .Where(typeof(ICodeSampleControl).IsAssignableFrom)
                .Select(t => (ICodeSampleControl)Activator.CreateInstance(t))
                .OrderBy(sample => sample.Order)
                .ThenBy(sample => sample.Title)
                .Select(sample => new SampleTabViewModel(sample.Title, sample.Description, (UserControl)sample, ReadSourceCodes(sample.GetType())))
                .ToList();

            DataContext.Tabs.Add(new SampleTabViewModel("Welcome", String.Empty, new WelcomeTab(), new SourceViewModel[0]));

            foreach (var sample in samples)
            {
                DataContext.Tabs.Add(sample);
            }
        }

        private IEnumerable<SourceViewModel> ReadSourceCodes(Type sampleUserControlType)
        {
            var assembly = sampleUserControlType.Assembly;
            var allResources = assembly.GetManifestResourceNames();
            var name = String.Join(".", sampleUserControlType.FullName.Split('.').Skip(1).Take(2));
            var resources = allResources
                .Where(n => n.IndexOf(name, StringComparison.InvariantCultureIgnoreCase) >= 0)
                .OrderBy(n => n.Split('.').Last())
                .ThenBy(n => n)
                .ToList();

            var result = new List<SourceViewModel>();
            foreach (var resource in resources)
            {
                var stream = assembly.GetManifestResourceStream(resource);
                if (stream == null)
                    throw new InvalidOperationException("Invalid resource");

                using (var mem = new MemoryStream())
                {
                    stream.CopyTo(mem);
                    string fileName = String.Join(".", resource.Split('.').Skip(3));
                    byte[] fileContent = mem.ToArray();
                    result.Add(new SourceViewModel(fileName, fileContent));
                }
            }

            return result;
        }

        private void SampleTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Clear the last error status when we change tabs.
            App.ClearErrorStatus();
        }

        private void SourceCode_Click(object sender, RoutedEventArgs e)
        {
            var current = DataContext.Current;
            if (current != null)
            {
                var sv = new SourceView(current.SourceCodes);
                sv.Show();
            }
        }

        public void UpdateErrorStatus(string errorStatus)
        {
            if (String.IsNullOrWhiteSpace(errorStatus))
            {
                DataContext.ErrorStatus = String.Empty;
            }
            else
            {
                DataContext.ErrorStatus = DateTime.Now.ToString("G") + Environment.NewLine + errorStatus;
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
