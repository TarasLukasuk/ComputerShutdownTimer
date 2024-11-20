namespace ComputerShutdownTimer.Services;

enum StretchingDirections
{
    Left = 1,
    Right = 2,
    Top = 3,
    TopLeft = 4,
    TopRight = 5,
    Bottom = 6,
    BottomLeft = 7,
    BottomRight = 8
}

internal class WindowResizer
{
    private readonly Window _window;

    private const uint WM_SYSCOMMAND = 0x0112;
    private const uint SC_SIZE = 0xF000;

    public WindowResizer(Window window)
    {
        _window = window ?? throw new ArgumentNullException(nameof(window));
    }

    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    private static extern bool ReleaseCapture();

    public void Resize(StretchingDirections direction, Cursor cursor)
    {
        if (cursor is null)
        {
            throw new ArgumentNullException(nameof(cursor));
        }

        try
        {

            Mouse.OverrideCursor = cursor;

            var hwnd = new System.Windows.Interop.WindowInteropHelper(_window).Handle;

            if (hwnd == IntPtr.Zero)
            {
                throw new InvalidOperationException("Failed to get window handle.");
            }

            ReleaseCapture();

            SendMessage(hwnd, WM_SYSCOMMAND, (IntPtr)(SC_SIZE + (int)direction), IntPtr.Zero);
        }
        finally
        {
            Mouse.OverrideCursor = null;
        }
    }
}