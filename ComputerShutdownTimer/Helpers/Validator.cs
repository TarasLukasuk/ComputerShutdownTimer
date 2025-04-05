using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace ComputerShutdownTimer.Helpers
{
    internal static class Validator
    {
        private static readonly Regex HexColorRegex = new Regex(@"^#?([A-Fa-f0-9]{3}|[A-Fa-f0-9]{4}|[A-Fa-f0-9]{6}|[A-Fa-f0-9]{8})$", RegexOptions.Compiled | RegexOptions.ExplicitCapture);

        public static bool IsValidHexColor(string colorHex)
        {
            if (string.IsNullOrWhiteSpace(colorHex))
            {
                throw new ArgumentException(message: "Hex color string cannot be null or whitespace", nameof(colorHex));
            }

            return HexColorRegex.IsMatch(colorHex);
        }

        public static bool IsValidClassImplementInterface<TClass>(TClass @class)
        {
            if (@class == null)
            {
                throw new ArgumentNullException(nameof(@class), "Class instance cannot be null");
            }

            if (!(@class is INotifyPropertyChanged))
            {
                throw new ArgumentException("Class Doesn’t implement interface 'INotifyPropertyChanged'", nameof(@class));
            }

            return true;
        }
    }
}