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
        private readonly MainViewModel _mainView;

        public MainWindow()
        {
            InitializeComponent();

            _windowResizer = new WindowResizer(this);
            _mainView = new MainViewModel(ShowPages);

            DataContext = _mainView;
        }


        private void Resize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Rectangle rectangle && _windowResizer.ResizeHandlers.TryGetValue(rectangle.Name, out Action action))
            {
                action?.Invoke();

                
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await _mainView.InitializeAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading icons: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
