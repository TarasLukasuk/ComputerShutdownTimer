using System;
using System.Globalization;
using System.Windows.Media;
using ComputerShutdownTimer.Helpers;

namespace ComputerShutdownTimer.Converters
{
    internal class HexToBrushConverter : IBiDirectionalConverter<string, Brush>
    {
        private const byte DefaultAlpha = 255;
        private const int HexComponentLength = 2;
        private const int RgbHexLength = 6;
        private const int ArgbHexLength = 8;

        public Brush Convert(string hexColor)
        {
            if (string.IsNullOrWhiteSpace(hexColor))
            {
                throw new ArgumentNullException(nameof(hexColor), "Hex color cannot be null or empty");
            }

            string normalizedHex = NormalizeHexString(hexColor);
            ValidateHexFormat(normalizedHex);

            var components = ParseHexComponents(normalizedHex);
            return CreateSolidColorBrush(components.alpha, components.red, components.green, components.blue);
        }

        public string ConvertBack(Brush brush)
        {
            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            var solidBrush = brush as SolidColorBrush;
            if (solidBrush != null)
            {
                return ColorToHexString(solidBrush.Color);
            }

            throw new ArgumentException("Only SolidColorBrush is supported", nameof(brush));
        }

        private static string NormalizeHexString(string hexColor)
        {
            return hexColor.StartsWith("#") ? hexColor.Substring(1) : hexColor;
        }

        private static void ValidateHexFormat(string hexColor)
        {
            if (!ColorFormatValidator.IsValidHexColor(hexColor))
            {
                throw new ArgumentException($"Invalid hex color format: {hexColor}", nameof(hexColor));
            }

            if (hexColor.Length != RgbHexLength && hexColor.Length != ArgbHexLength)
            {
                throw new ArgumentException($"Hex color must be {RgbHexLength} or {ArgbHexLength} characters long", nameof(hexColor));
            }
        }

        private static (byte alpha, byte red, byte green, byte blue) ParseHexComponents(string hexColor)
        {
            byte alpha = DefaultAlpha;
            int colorStartIndex = 0;

            if (hexColor.Length == ArgbHexLength)
            {
                alpha = ParseHexByte(hexColor, 0);
                colorStartIndex = HexComponentLength;
            }

            byte red = ParseHexByte(hexColor, colorStartIndex);
            byte green = ParseHexByte(hexColor, colorStartIndex + HexComponentLength);
            byte blue = ParseHexByte(hexColor, colorStartIndex + 2 * HexComponentLength);

            return (alpha, red, green, blue);
        }

        private static byte ParseHexByte(string hex, int startIndex)
        {
            return byte.Parse(hex.Substring(startIndex, HexComponentLength), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
        }

        private static SolidColorBrush CreateSolidColorBrush(byte a, byte r, byte g, byte b)
        {
            return new SolidColorBrush(Color.FromArgb(a, r, g, b));
        }

        private static string ColorToHexString(Color color)
        {
            return $"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}";
        }
    }
}