using ComputerShutdownTimer.Converters;
using System;
using System.Runtime.Caching;
using System.Windows.Controls;

namespace ComputerShutdownTimer.Services
{
    internal class PageCache
    {
        private readonly MemoryCache _cache = MemoryCache.Default;

        public Page GetOrCreatePage(string pageName)
        {
            if (string.IsNullOrWhiteSpace(pageName))
            {
                throw new ArgumentNullException(nameof(pageName));
            }

            return _cache.Get(pageName) as Page ?? CreateAndCachePage(pageName);
        }

        private Page CreateAndCachePage(string pageName)
        {
            Type pageType = Type.GetType(pageName);
            if (pageType == null)
            {
                throw new ArgumentException($"Не вдалося знайти тип сторінки для '{pageName}'. Переконайтеся, що повне ім'я типу правильне.", nameof(pageName));
            }

            Page page = new TypeToPage().Convert(pageType);
            if (page == null)
            {
                throw new InvalidOperationException($"Конвертація типу '{pageType.FullName}' у Page повернула null.");
            }

            _cache.Set(pageName, page, new CacheItemPolicy());

            return page;
        }
    }
}
