using ComputerShutdownTimer.Services;
using ComputerShutdownTimer.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace ComputerShutdownTimer.Views.Forms
{
    public partial class MainWindow : Window
    {
        private readonly WindowResizer _windowResizer;

        public MainWindow()
        {
            InitializeComponent();

            _windowResizer = new WindowResizer(this);

            InitializeDataContext();
        }

        private void InitializeDataContext()
        {
            DataContext = new MainViewModel(ShowPages);
        }

        private void Resize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Rectangle rectangle && _windowResizer.ResizeHandlers.TryGetValue(rectangle.Name, out Action action))
            {
                action?.Invoke();
            }
        }
    }
}
