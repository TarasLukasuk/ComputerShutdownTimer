using System;
using System.Text.RegularExpressions;

namespace ComputerShutdownTimer.Helpers
{
    
    internal static class ColorFormatValidator
    {
        private static readonly Regex HexColorRegex = new Regex(pattern: @"^#([A-Fa-f0-9]{3,4}|[A-Fa-f0-9]{6}|[A-Fa-f0-9]{8})$", options: RegexOptions.Compiled | RegexOptions.ExplicitCapture, matchTimeout: TimeSpan.FromMilliseconds(250));

        public static bool IsValidHexColor(string colorHex)
        {
            if (string.IsNullOrWhiteSpace(colorHex))
            {
                throw new ArgumentException(message: "Hex color string cannot be null or whitespace", paramName: nameof(colorHex));
            }

            return HexColorRegex.IsMatch(colorHex);
        }
    }
}