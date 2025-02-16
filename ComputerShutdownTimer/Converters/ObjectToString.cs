namespace ComputerShutdownTimer.Converters
{
    internal class ObjectToString : IConverterType<object, string>
    {
        public string Convert(object value)
        {
            return value.ToString();
        }

        public object ConvertBack(string value)
        {
            return value;
        }
    }
}
