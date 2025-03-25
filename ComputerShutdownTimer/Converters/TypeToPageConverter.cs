using System;
using System.Windows.Controls;

namespace ComputerShutdownTimer.Converters
{
    internal class TypeToPageConverter : IBiDirectionalConverter<Type, Page>
    {
        public Page Convert(Type pageType)
        {
            if (pageType == null)
            {
                throw new ArgumentNullException(nameof(pageType), "Page type cannot be null");
            }

            if (!typeof(Page).IsAssignableFrom(pageType))
            {
                throw new ArgumentException($"Type {pageType.Name} must inherit from {nameof(Page)}", nameof(pageType));
            }

            try
            {
                return Activator.CreateInstance(pageType) as Page;
            }
            catch (Exception ex) when (ex is MissingMethodException ||ex is TypeLoadException || ex is InvalidCastException)
            {
                throw new InvalidOperationException($"Failed to create instance of page type {pageType.Name}. Ensure the type has a parameterless constructor.", ex);
            }
        }

        public Type ConvertBack(Page page)
        {
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page), "Page instance cannot be null");
            }

            return page.GetType();
        }
    }
}