namespace ComputerShutdownTimer.Views;

public partial class MainWindow : Window
{
    private readonly WindowResizer _windowResizer;

    public MainWindow()
    {
        InitializeComponent();
        _windowResizer = new WindowResizer(this);
    }

    private void ResizingTop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        _windowResizer.ResizeWindow(DirectionStretching.Top, Cursors.SizeNS);
    }

    private void ResizingBottom_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        _windowResizer.ResizeWindow(DirectionStretching.Bottom, Cursors.SizeNS);
    }

    private void ResizingLeft_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        _windowResizer.ResizeWindow(DirectionStretching.Left, Cursors.SizeWE);
    }

    private void ResizingRight_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        _windowResizer.ResizeWindow(DirectionStretching.Right, Cursors.SizeWE);
    }

    private void ResizingTopLeft_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        _windowResizer.ResizeWindow(DirectionStretching.TopLeft, Cursors.SizeNWSE);
    }

    private void ResizingTopRight_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        _windowResizer.ResizeWindow(DirectionStretching.TopRight, Cursors.SizeNESW);
    }

    private void ResizingBottomLeft_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        _windowResizer.ResizeWindow(DirectionStretching.BottomLeft, Cursors.SizeNESW);
    }

    private void ResizingBottomRight_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        _windowResizer.ResizeWindow(DirectionStretching.BottomRight, Cursors.SizeNWSE);
    }
}
