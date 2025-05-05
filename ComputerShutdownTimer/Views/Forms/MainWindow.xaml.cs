using System.Windows;
using System.Windows.Input;

namespace ComputerShutdownTimer.Views.Forms
{
    public partial class MainWindow : Window
    {
        private readonly ResizingWindow _resizingWindow;

        public MainWindow()
        {
            InitializeComponent();

            _resizingWindow = new ResizingWindow(this);
        }

        private void Resizing(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement element && !string.IsNullOrWhiteSpace(element.Name))
            {
                _resizingWindow.Resizing(element.Name);
            }
        }

    }
}
