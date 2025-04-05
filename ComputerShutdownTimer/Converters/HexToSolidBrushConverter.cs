using System;
using System.Globalization;
using System.Windows.Media;
using ComputerShutdownTimer.Helpers;

namespace ComputerShutdownTimer.Converters
{
    internal class HexToSolidColorBrushConverter : IBiDirectionalConverter<string, SolidColorBrush>
    {
        byte a = 255, r, g, b;

        public SolidColorBrush Convert(string source)
        {

            if (string.IsNullOrWhiteSpace(source) || !Validator.IsValidHexColor(source))
            {
                throw new ArgumentException("Invalid hex color format.");
            }

            string hex = source.TrimStart('#');

            switch (hex.Length)
            {
                case 3:
                    return ShortRGB(hex);
                case 4:
                    return ShortARGB(hex);
                case 6:
                    return LongRGB(hex);
                case 8:
                    return LongARGB(hex);
                default:
                    return Brushes.Transparent;
            }
        }

        private SolidColorBrush LongARGB(string hex)
        {
            a = System.Convert.ToByte(hex.Substring(0, 2), 16);
            r = System.Convert.ToByte(hex.Substring(2, 2), 16);
            g = System.Convert.ToByte(hex.Substring(4, 2), 16);
            b = System.Convert.ToByte(hex.Substring(6, 2), 16);

            return new SolidColorBrush(Color.FromArgb(a, r, g, b));
        }

        private SolidColorBrush LongRGB(string hex)
        {
            r = System.Convert.ToByte(hex.Substring(0, 2), 16);
            g = System.Convert.ToByte(hex.Substring(2, 2), 16);
            b = System.Convert.ToByte(hex.Substring(4, 2), 16);

            return new SolidColorBrush(Color.FromRgb(r, g, b));
        }

        private SolidColorBrush ShortARGB(string hex)
        {
            a = System.Convert.ToByte(new string(hex[0], 2), 16);
            r = System.Convert.ToByte(new string(hex[1], 2), 16);
            g = System.Convert.ToByte(new string(hex[2], 2), 16);
            b = System.Convert.ToByte(new string(hex[3], 2), 16);

            return new SolidColorBrush(Color.FromArgb(a, r, g, b));
        }

        private SolidColorBrush ShortRGB(string hex)
        {
            r = System.Convert.ToByte(new string(hex[0], 2), 16);
            g = System.Convert.ToByte(new string(hex[1], 2), 16);
            b = System.Convert.ToByte(new string(hex[2], 2), 16);

            return new SolidColorBrush(Color.FromRgb(r, g, b));
        }

        public string ConvertBack(SolidColorBrush target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            Color color = target.Color;

            if (color.A == 255)
            {
               return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
            }
            else
            {
               return $"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}";
            }
        }
    }
}