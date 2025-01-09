using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace ComputerShutdownTimer.Services
{
    internal enum DirectionStretching
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
        private const int WM_SYSCOMMAND = 0x112;
        private const int SC_SIZE = 0xF000;

        private readonly Window _window;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        public WindowResizer(Window window)
        {
            _window = window ?? throw new ArgumentNullException(nameof(window));
        }

        public void ResizeWindow(DirectionStretching directionStretching, Cursor cursor)
        {
            try
            {
                Mouse.OverrideCursor = cursor;

                SendMessage(new WindowInteropHelper(_window).Handle, WM_SYSCOMMAND, (IntPtr)(SC_SIZE + (int)directionStretching), IntPtr.Zero);
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }
    }
}
