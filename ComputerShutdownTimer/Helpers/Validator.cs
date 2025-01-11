using System;
using System.Text.RegularExpressions;

namespace ComputerShutdownTimer.Helpers
{
    internal static class Validator
    {
        public static bool IsHex(string color)
        {
            if (string.IsNullOrEmpty(color))
            {
                throw new ArgumentException($"\"{nameof(color)}\" cannot be null or empty.", nameof(color));
            }

            if (string.IsNullOrWhiteSpace(color))
            {
                throw new ArgumentException($"\"{nameof(color)}\" cannot consist only of whitespace.", nameof(color));
            }

            var hexPattern = @"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$";
            return Regex.IsMatch(color, hexPattern);
        }
    }
}
