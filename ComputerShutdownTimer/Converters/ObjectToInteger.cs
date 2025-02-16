using System;

internal class ObjectToInteger : IConverterType<object, int>
{
    public int Convert(object value)
    {
        if (value == null)
        {
            throw new ArgumentException("Cannot convert the provided object to an integer.");
        }

        if (value is int intValue)
        {
            return intValue;
        }

        if (int.TryParse(value.ToString(), out int parsedValue))
        {
            return parsedValue;
        }

        throw new ArgumentException("Cannot convert the provided object to an integer.");
    }

    public object ConvertBack(int value)
    {
        return value.ToString();
    }
}
