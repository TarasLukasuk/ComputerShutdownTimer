using System;
using System.Globalization;

namespace ComputerShutdownTimer.Converters
{
    
    internal class ObjectToIntegerConverter : IBiDirectionalConverter<object, int>
    {
        public int Convert(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Input cannot be null");
            }

            switch (value)
            {
                case int intValue:
                    return intValue;

                case IConvertible convertible:
                    try
                    {
                        return convertible.ToInt32(CultureInfo.InvariantCulture);
                    }
                    catch (FormatException ex)
                    {
                        throw new FormatException($"Failed to convert '{value}' to integer", ex);
                    }

                default:
                    if (int.TryParse(value.ToString(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int parsedValue))
                    {
                        return parsedValue;
                    }
                    throw new FormatException($"Cannot convert type {value.GetType().Name} to integer");
            }
        }

        public object ConvertBack(int value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}