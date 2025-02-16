using System;
using System.Windows.Controls;

namespace ComputerShutdownTimer.Converters
{
    internal class TypeToPage : IConverterType<Type, Page>
    {
        public Page Convert(Type value)
        {
            if (value == null || !typeof(Page).IsAssignableFrom(value))
            {
                throw new ArgumentException($"Invalid page type: {value}", nameof(value));
            }

            return Activator.CreateInstance(value) as Page;
        }

        public Type ConvertBack(Page value)
        {
            throw new NotImplementedException();
        }
    }
}
