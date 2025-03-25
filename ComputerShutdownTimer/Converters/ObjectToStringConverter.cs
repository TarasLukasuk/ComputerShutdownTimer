using System;

namespace ComputerShutdownTimer.Converters
{
    internal class ObjectToStringConverter : IBiDirectionalConverter<object, string>
    {
        public string Convert(object value)
        {
            return value?.ToString() ?? string.Empty;
        }

        public object ConvertBack(string value)
        {
            return value ?? string.Empty;
        }
    }
}