using ComputerShutdownTimer.Converters;
using System;
using System.Runtime.Caching;
using System.Windows.Controls;

namespace ComputerShutdownTimer.Services
{
    internal class PageCache
    {
        private readonly MemoryCache _cache = MemoryCache.Default;
        private readonly TypeToPageConverter _pageConverter = new TypeToPageConverter();

        public Page GetOrCreatePage(string pageTypeName)
        {
            if (string.IsNullOrWhiteSpace(pageTypeName))
            {
                throw new ArgumentNullException(nameof(pageTypeName), "Page type name cannot be null or empty");
            }

            if (_cache.Get(pageTypeName) is Page cachedPage)
            {
                return cachedPage;
            }

            return CreateAndCachePage(pageTypeName);
        }

        private Page CreateAndCachePage(string pageTypeName)
        {
            Type pageType = GetPageType(pageTypeName);
            Page page = ConvertToPage(pageType);
            CachePage(pageTypeName, page);

            return page;
        }

        private Type GetPageType(string pageTypeName)
        {
            Type pageType = Type.GetType(pageTypeName);
            if (pageType == null)
            {
                throw new TypeLoadException($"Failed to find page type '{pageTypeName}'. Ensure the full type name is correct and includes namespace and assembly.");
            }

            if (!typeof(Page).IsAssignableFrom(pageType))
            {
                throw new TypeLoadException($"Type '{pageType.FullName}' is not a Page. Only types inheriting from System.Windows.Controls.Page are supported.");
            }

            return pageType;
        }

        private Page ConvertToPage(Type pageType)
        {
            try
            {
                Page page = _pageConverter.Convert(pageType);
                if (page == null)
                {
                    throw new InvalidOperationException($"Page conversion for type '{pageType.FullName}' returned null. Verify the TypeToPageConverter implementation.");
                }
                return page;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to create page instance of type '{pageType.FullName}'", ex);
            }
        }

        private void CachePage(string pageTypeName, Page page)
        {
            var cachePolicy = new CacheItemPolicy
            {
                SlidingExpiration = TimeSpan.FromMinutes(30)
            };

            _cache.Set(pageTypeName, page, cachePolicy);
        }
    }
}