using System;
using System.Globalization;
using System.Windows.Media;
using ComputerShutdownTimer.Helpers;

namespace ComputerShutdownTimer.Converters
{
    class HexToBrash : IConverterType<string, Brush>
    {
        public Brush Convert(string value)
        {
            if (!Validator.IsHex(value))
            {
                throw new ArgumentException($"Invalid hex color: {value}", nameof(value));
            }

            if (value.StartsWith("#"))
            {
                value = value.Substring(1);
            }

            byte a = 255;
            int startIndex = 0;

            if (value.Length == 8)
            {
                a = byte.Parse(value.Substring(0, 2), NumberStyles.HexNumber);
                startIndex = 2;
            }

            byte r = byte.Parse(value.Substring(startIndex, 2), NumberStyles.HexNumber);
            byte g = byte.Parse(value.Substring(startIndex + 2, 2), NumberStyles.HexNumber);
            byte b = byte.Parse(value.Substring(startIndex + 4, 2), NumberStyles.HexNumber);

            return new SolidColorBrush(Color.FromArgb(a, r, g, b));
        }

        public string ConvertBack(Brush value)
        {
            if (value is SolidColorBrush solidColorBrush)
            {
                Color color = solidColorBrush.Color;
                return $"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}";
            }

            throw new ArgumentException("Unsupported brush type", nameof(value));
        }

    }
}
