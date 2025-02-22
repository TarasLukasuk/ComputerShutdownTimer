using System;
using System.Text.RegularExpressions;

namespace ComputerShutdownTimer.Helpers
{
    internal static class Validator
    {
        private static readonly Regex HexPattern = new Regex(@"^#([A-Fa-f0-9]{3}|[A-Fa-f0-9]{6}|[A-Fa-f0-9]{8})$", RegexOptions.Compiled);

        public static bool IsHex(string color)
        {
            if (string.IsNullOrWhiteSpace(color))
            {
                throw new ArgumentException($"\"{nameof(color)}\" cannot be null, empty, or whitespace.", nameof(color));
            }

            return HexPattern.IsMatch(color);
        }
    }
}
