using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfCsSample.CodeSampleControls.TouchBypass
{
    /// <summary>
    /// Interaction logic for ControlsWindow.xaml
    /// </summary>
    public partial class ControlsWindow : Window
    {
        public ControlsWindow()
        {
            InitializeComponent();
        }

        public new TouchBypassViewModel DataContext
        {
            get { return (TouchBypassViewModel)base.DataContext; }
            set { base.DataContext = value; }
        }

        public void HandleTouch(Point point)
        {
            var el = InputHitTest(point);
            var btn = GetParentButton(el as DependencyObject);
            if (btn != null && btn.Command != null)
            {
                btn.Command.Execute(btn.CommandParameter);
            }
        }

        private static Button GetParentButton(DependencyObject obj)
        {
            if (obj == null)
                return null;

            var btn = obj as Button;
            if (btn != null)
                return btn;

            var parent = VisualTreeHelper.GetParent(obj);
            return GetParentButton(parent);
        }
    }
}
