using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

internal class ResizingWindow
{
    private readonly Window _window;

    public ResizingWindow(Window window)
    {
        _window = window ?? throw new ArgumentNullException(nameof(window));

        ResizeDirections = new Dictionary<string, Action>
        {
            { "LeftResizing", () => ResizeWindow(DirectionMovement.Left, Cursors.SizeWE) },
            { "RightResizing", () => ResizeWindow(DirectionMovement.Right, Cursors.SizeWE) },
            { "TopResizing", () => ResizeWindow(DirectionMovement.Top, Cursors.SizeNS) },
            { "BottomResizing", () => ResizeWindow(DirectionMovement.Bottom, Cursors.SizeNS) },
            { "TopLeftResizing", () => ResizeWindow(DirectionMovement.TopLeft, Cursors.SizeNWSE) },
            { "TopRightResizing", () => ResizeWindow(DirectionMovement.TopRight, Cursors.SizeNESW) },
            { "BottomLeftResizing", () => ResizeWindow(DirectionMovement.BottomLeft, Cursors.SizeNESW) },
            { "BottomRightResizing", () => ResizeWindow(DirectionMovement.BottomRight, Cursors.SizeNWSE) }
        };
    }

    private const int WM_SYSCOMMAND = 0x112;
    private const int SC_SIZE = 0xF000;

    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    private static extern bool ReleaseCapture();

    private enum DirectionMovement
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

    private readonly Dictionary<string, Action> ResizeDirections;

    public void Resizing(string directionName)
    {
        if (ResizeDirections.TryGetValue(directionName, out Action? action))
        {
            action.Invoke();
        }
    }

    private void ResizeWindow(DirectionMovement direction, Cursor cursor)
    {
        try
        {
            Mouse.OverrideCursor = cursor;

            var hwnd = new WindowInteropHelper(_window).Handle;
            if (hwnd == IntPtr.Zero) return;

            ReleaseCapture();
            SendMessage(hwnd, WM_SYSCOMMAND, SC_SIZE + (int)direction, IntPtr.Zero);
        }
        finally
        {
            Mouse.OverrideCursor = null;
        }
    }
}
